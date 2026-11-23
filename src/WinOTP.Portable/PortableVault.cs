using System.Security.Cryptography;
using System.Text.Json;
using WinOTP.Models;
using WinOTP.Services;

namespace WinOTP.Portable;

// Linux storage deliberately requires a password; it never falls back to plaintext or DPAPI.
public sealed class PortableVault : IDisposable
{
    private static readonly byte[] Magic = "WINOTP1\n"u8.ToArray();
    private readonly string _path;
    private byte[]? _key;
    private byte[]? _salt;
    private byte[]? _revision;
    public string Root { get; }
    public bool Exists => File.Exists(_path);
    public bool IsUnlocked => _key is not null;
    public PortableVault(string? root = null)
    {
        var xdg = Environment.GetEnvironmentVariable("XDG_DATA_HOME");
        Root = Path.GetFullPath(root ?? Path.Combine(!string.IsNullOrEmpty(xdg) && Path.IsPathRooted(xdg) ? xdg : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".local", "share"), "WinOTP"));
        _path = Path.Combine(Root, "vault.enc");
    }
    public void Create(string password)
    {
        if (password.Length < 8) throw new ArgumentException("Use at least 8 characters.");
        PrepareDirectory();
        using var guard = Guard();
        if (Exists) throw new IOException("A vault already exists. Unlock it instead.");
        Lock();
        _salt = RandomNumberGenerator.GetBytes(16);
        _key = Derive(password, _salt);
        try { Write([], false); }
        catch { Lock(); throw; }
    }
    public void Unlock(string password)
    {
        Lock();
        var blob = ReadBlob();
        byte[]? key = null;
        try
        {
            if (blob.Length < 52 || !blob.AsSpan(0, 8).SequenceEqual(Magic)) throw new FormatException("Unsupported or damaged vault.");
            var salt = blob.AsSpan(8, 16).ToArray();
            key = Derive(password, salt);
            var plain = Decrypt(blob.AsSpan(24), key);
            try { Validate(JsonSerializer.Deserialize<List<Account>>(plain) ?? throw new FormatException("Empty vault payload.")); }
            finally { CryptographicOperations.ZeroMemory(plain); }
            _salt = salt; _key = key; key = null;
            _revision = SHA256.HashData(blob);
        }
        finally { if (key is not null) CryptographicOperations.ZeroMemory(key); CryptographicOperations.ZeroMemory(blob); }
    }
    public List<Account> Load()
    {
        RequireKey();
        var blob = ReadBlob();
        try
        {
            // Do not silently adopt another writer's password/salt or stale data.
            if (_revision is null || !CryptographicOperations.FixedTimeEquals(SHA256.HashData(blob), _revision)) throw new IOException("Vault changed in another instance. Lock and unlock again.");
            var plain = Decrypt(blob.AsSpan(24), _key!);
            try { var accounts = JsonSerializer.Deserialize<List<Account>>(plain) ?? throw new FormatException("Empty vault payload."); Validate(accounts); return accounts; }
            finally { CryptographicOperations.ZeroMemory(plain); }
        }
        finally { CryptographicOperations.ZeroMemory(blob); }
    }
    public void Save(List<Account> accounts)
    {
        RequireKey(); Validate(accounts);
        PrepareDirectory();
        using var guard = Guard();
        if (!Exists || _revision is null || !CryptographicOperations.FixedTimeEquals(SHA256.HashData(ReadBlob()), _revision)) throw new IOException("Vault changed or was removed. Lock and unlock again before saving.");
        Write(accounts, true);
    }
    private void Write(List<Account> accounts, bool overwrite)
    {
        var plain = JsonSerializer.SerializeToUtf8Bytes(accounts);
        // Leave room for the NOIRPASS1 Base64 envelope within the 20 MiB import limit.
        if (plain.Length > 14 * 1024 * 1024) { CryptographicOperations.ZeroMemory(plain); throw new IOException("Vault exceeds the 20 MB limit."); }
        byte[]? blob = null;
        var temp = _path + "." + Guid.NewGuid().ToString("N") + ".tmp";
        try
        {
            blob = [.. Magic, .. _salt!, .. Encrypt(plain, _key!)];
            using (var stream = PrivateFile(temp, FileMode.CreateNew)) { stream.Write(blob); stream.Flush(true); }
            File.Move(temp, _path, overwrite);
            _revision = SHA256.HashData(blob);
        }
        finally { CryptographicOperations.ZeroMemory(plain); if (blob is not null) CryptographicOperations.ZeroMemory(blob); if (File.Exists(temp)) File.Delete(temp); }
    }
    private byte[] ReadBlob()
    {
        if (new FileInfo(_path).Length > 20 * 1024 * 1024) throw new IOException("Vault exceeds the 20 MB limit.");
        return File.ReadAllBytes(_path);
    }
    private void PrepareDirectory()
    {
        Directory.CreateDirectory(Root);
        if (!OperatingSystem.IsWindows()) File.SetUnixFileMode(Root, UnixFileMode.UserRead | UnixFileMode.UserWrite | UnixFileMode.UserExecute);
    }
    private FileStream Guard() => PrivateFile(Path.Combine(Root, "vault.lock"), FileMode.OpenOrCreate);
    private static FileStream PrivateFile(string path, FileMode mode)
    {
        var options = new FileStreamOptions { Mode = mode, Access = FileAccess.ReadWrite, Share = FileShare.None };
        if (!OperatingSystem.IsWindows()) options.UnixCreateMode = UnixFileMode.UserRead | UnixFileMode.UserWrite;
        return new FileStream(path, options);
    }
    public static void Validate(List<Account> accounts)
    {
        ArgumentNullException.ThrowIfNull(accounts);
        if (accounts.Count > 500) throw new FormatException("A vault supports at most 500 accounts. Export separate backups before merging larger collections.");
        var ids = new HashSet<Guid>();
        foreach (var account in accounts)
        {
            if (account is null) throw new FormatException("Invalid account.");
            Otp.Validate(account);
            if (account.Id == Guid.Empty || !ids.Add(account.Id)) throw new FormatException("Duplicate or empty account ID.");
            account.Issuer ??= ""; account.Name ??= "";
        }
    }
    private void RequireKey() { if (!IsUnlocked) throw new InvalidOperationException("Vault is locked."); }
    public void Lock() { if (_key is not null) CryptographicOperations.ZeroMemory(_key); _key = null; _salt = null; _revision = null; }
    public void Dispose() => Lock();
    private static byte[] Derive(string password, ReadOnlySpan<byte> salt) => Rfc2898DeriveBytes.Pbkdf2(password, salt, 600_000, HashAlgorithmName.SHA256, 32);
    private static byte[] Encrypt(ReadOnlySpan<byte> plain, byte[] key)
    {
        var nonce = RandomNumberGenerator.GetBytes(12); var tag = new byte[16]; var cipher = new byte[plain.Length];
        using var aes = new AesGcm(key, 16); aes.Encrypt(nonce, plain, cipher, tag);
        return [.. nonce, .. tag, .. cipher];
    }
    private static byte[] Decrypt(ReadOnlySpan<byte> blob, byte[] key)
    {
        if (blob.Length < 28) throw new FormatException("Damaged encrypted data.");
        var plain = new byte[blob.Length - 28];
        try { using var aes = new AesGcm(key, 16); aes.Decrypt(blob[..12], blob[28..], blob.Slice(12, 16), plain); return plain; }
        catch { CryptographicOperations.ZeroMemory(plain); throw; }
    }
    // NOIRPASS1 wire format is retained for Windows backup interoperability.
    public static byte[] EncryptBackup(byte[] plain, string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16); var key = Derive(password, salt);
        try { return [.. salt, .. Encrypt(plain, key)]; }
        finally { CryptographicOperations.ZeroMemory(key); }
    }
    public static byte[] DecryptBackup(byte[] blob, string password)
    {
        if (blob.Length < 44 || blob.Length > 20 * 1024 * 1024) throw new FormatException("Invalid backup size.");
        var key = Derive(password, blob.AsSpan(0, 16));
        try { return Decrypt(blob.AsSpan(16), key); }
        finally { CryptographicOperations.ZeroMemory(key); }
    }
}
