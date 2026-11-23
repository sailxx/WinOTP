using System.Security.Cryptography;
using System.Text;
using WinOTP.Models;
using WinOTP.Services;

internal static class StorageRegression
{
    public static void Run()
    {
        var root = Path.Combine(Path.GetTempPath(), "WinOTP-migration-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            var source = Path.Combine(root, DataPaths.PreviousFolderName);
            var target = Path.Combine(root, "WinOTP");
            Directory.CreateDirectory(source);
            var account = new Account { Issuer = "Fixture", Name = "legacy@example.test", Type = "HOTP", Counter = 42, Favorite = true, Digits = 8, Algorithm = "SHA256", Secret = "GEZDGNBVGY3TQOJQGEZDGNBVGY3TQOJQ" };
            new Vault(Path.Combine(source, "vault.bin")).Save([account]);
            var settings = new UserSettings(Path.Combine(source, "settings.bin")) { HideCodes = true, ClipboardClearSeconds = 60 };
            settings.SetPassword("migration-test-password");
            var originalVault = File.ReadAllBytes(Path.Combine(source, "vault.bin"));
            var originalSettings = File.ReadAllBytes(Path.Combine(source, "settings.bin"));
            DataPaths.MigrateFrom(root, target);
            var restored = new Vault(Path.Combine(target, "vault.bin")).Load().Single();
            Require(restored.Id == account.Id && restored.Counter == 42 && restored.Favorite && restored.Digits == 8 && restored.Algorithm == "SHA256" && restored.Secret == account.Secret, "Migration preserves all OTP fields");
            var migratedSettings = UserSettings.Load(Path.Combine(target, "settings.bin"));
            Require(migratedSettings.HideCodes && migratedSettings.VerifyPassword("migration-test-password"), "Migration preserves lock and privacy");
            DataPaths.MigrateFrom(root, target);
            Require(originalVault.SequenceEqual(File.ReadAllBytes(Path.Combine(source, "vault.bin"))) && originalSettings.SequenceEqual(File.ReadAllBytes(Path.Combine(source, "settings.bin"))), "Original pair is unchanged");
            Require(originalVault.SequenceEqual(File.ReadAllBytes(Path.Combine(target, "vault.bin"))), "Migration is idempotent");
            var partial = Path.Combine(root, "partial"); Directory.CreateDirectory(partial);
            File.WriteAllBytes(Path.Combine(partial, "settings.bin"), originalSettings);
            Reject(() => DataPaths.MigrateFrom(root, partial));
            Require(!File.Exists(Path.Combine(partial, "vault.bin")), "Mixed stores are never merged");
            File.Delete(Path.Combine(source, "settings.bin"));
            var vaultOnly = Path.Combine(root, "vault-only");
            DataPaths.MigrateFrom(root, vaultOnly);
            Require(originalVault.SequenceEqual(File.ReadAllBytes(Path.Combine(vaultOnly, "vault.bin"))), "Vault without optional settings migrates unchanged");
            Require(!File.Exists(Path.Combine(vaultOnly, "settings.bin")), "Migration does not invent settings");
            File.WriteAllText(Path.Combine(vaultOnly, "startup.log"), "Previous failed launch");
            DataPaths.MigrateFrom(root, vaultOnly);
            Require(new Vault(Path.Combine(vaultOnly, "vault.bin")).Load().Single().Id == account.Id, "Already copied vault starts even with a startup log");
            var different = Path.Combine(root, "different");
            new Vault(Path.Combine(different, "vault.bin")).Save([]);
            Reject(() => DataPaths.MigrateFrom(root, different));
            Require(new Vault(Path.Combine(different, "vault.bin")).Load().Count == 0, "Conflicting vault is not overwritten");
            File.WriteAllBytes(Path.Combine(source, "settings.bin"), originalSettings);
            Reject(() => DataPaths.MigrateFrom(root, vaultOnly));
            Require(!File.Exists(Path.Combine(vaultOnly, "settings.bin")), "Legacy password settings are never silently dropped");
            var corruptTarget = Path.Combine(root, "corrupt-target");
            File.WriteAllBytes(Path.Combine(source, "vault.bin"), [1, 2, 3]);
            Reject(() => DataPaths.MigrateFrom(root, corruptTarget));
            Require(!Directory.Exists(corruptTarget), "Invalid staged data is not published");
            File.WriteAllBytes(Path.Combine(source, "vault.bin"), originalVault);
            foreach (var payload in new[] { "null", "[null]", "{", "[{\"Secret\":\"invalid!\"}]" })
            {
                var path = Path.Combine(root, "invalid.bin");
                Protect(path, payload); var original = File.ReadAllBytes(path);
                Reject(() => new Vault(path).Load());
                Require(original.SequenceEqual(File.ReadAllBytes(path)), "Invalid vault bytes are retained");
            }
            var legacySettings = Path.Combine(root, "legacy-settings.bin");
            foreach (bool hide in new[] { true, false })
            {
                Protect(legacySettings, "{\"HideCodes\":" + hide.ToString().ToLowerInvariant() + "}");
                var original = File.ReadAllBytes(legacySettings);
                Require(UserSettings.Load(legacySettings).HideCodes == hide, "Legacy visibility preference is preserved");
                Require(original.SequenceEqual(File.ReadAllBytes(legacySettings)), "Settings load never writes");
            }
            Protect(legacySettings, "null"); Reject(() => UserSettings.Load(legacySettings));
            var emptyPath = Path.Combine(root, "empty.bin"); Protect(emptyPath, "[]");
            Require(new Vault(emptyPath).Load().Count == 0, "Legitimate empty vault remains supported");
            Console.WriteLine("Passed storage migration, source preservation, idempotence, mixed/incomplete/corrupt store guards, null payload and legacy privacy regressions.");
        }
        finally { Directory.Delete(root, recursive: true); }
    }
    private static void Protect(string path, string json) => File.WriteAllBytes(path, ProtectedData.Protect(Encoding.UTF8.GetBytes(json), null, DataProtectionScope.CurrentUser));
    private static void Require(bool condition, string name) { if (!condition) throw new Exception(name); }
    private static void Reject(Action action)
    {
        try { action(); }
        catch (Exception e) when (e is InvalidOperationException or FormatException) { return; }
        throw new Exception("Invalid store was unexpectedly accepted.");
    }
}
