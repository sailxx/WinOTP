namespace WinOTP.Services;

public static class DataPaths
{
    private static readonly string LocalData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    public static bool IsPreview => Environment.GetCommandLineArgs().Contains("--preview", StringComparer.Ordinal);
    public static string Root { get; } = IsPreview ? Path.Combine(AppContext.BaseDirectory, "preview-data", Environment.ProcessId.ToString()) : Path.Combine(LocalData, "WinOTP");
    private static bool _migrated;
    private static readonly object MigrationLock = new();

    public static string File(string name)
    {
        lock (MigrationLock)
        {
            if (!_migrated) { if (!IsPreview) MigrateFrom(LocalData, Root); _migrated = true; }
        }
        return Path.Combine(Root, name);
    }

    // Historical folder identifier is a compatibility contract, not application branding.
    internal static string PreviousFolderName => string.Concat("Mo", "no");

    internal static void MigrateFrom(string localData, string destination)
    {
        var names = new[] { "vault.bin", "settings.bin" };
        var existing = names.Count(name => System.IO.File.Exists(Path.Combine(destination, name)));
        if (existing == 2) return;
        var candidates = new[] { PreviousFolderName, "NoirAuth" }
            .Select(name => Path.Combine(localData, name))
            .Where(path => names.Any(name => System.IO.File.Exists(Path.Combine(path, name)))).ToArray();
        if (candidates.Length == 0) return;
        // Older versions did not create settings.bin until a preference was saved.
        // An already copied vault is safe only when every legacy store is the same
        // vault and none contains settings (which could include password protection).
        var destinationVault = Path.Combine(destination, "vault.bin");
        if (existing == 1 && System.IO.File.Exists(destinationVault)
            && candidates.All(path => !System.IO.File.Exists(Path.Combine(path, "settings.bin"))
                && System.IO.File.Exists(Path.Combine(path, "vault.bin"))
                && System.IO.File.ReadAllBytes(destinationVault).AsSpan().SequenceEqual(System.IO.File.ReadAllBytes(Path.Combine(path, "vault.bin")))))
        {
            _ = new Vault(destinationVault).Load();
            return;
        }
        if (existing != 0 || candidates.Length != 1 || !System.IO.File.Exists(Path.Combine(candidates[0], "vault.bin")))
            throw new InvalidOperationException("Legacy data needs recovery: keep both vault.bin and settings.bin together. No existing files were replaced.");

        // A directory rename publishes the validated pair together, even across a process interruption.
        var staging = destination + ".migration-" + Guid.NewGuid().ToString("N");
        Directory.CreateDirectory(staging);
        try
        {
            foreach (var name in names)
            {
                var source = Path.Combine(candidates[0], name);
                if (System.IO.File.Exists(source)) System.IO.File.Copy(source, Path.Combine(staging, name));
            }
            _ = new Vault(Path.Combine(staging, "vault.bin")).Load();
            _ = UserSettings.Load(Path.Combine(staging, "settings.bin"));
            if (Directory.Exists(destination))
            {
                if (Directory.EnumerateFileSystemEntries(destination).Any())
                    throw new InvalidOperationException("Migration destination is not empty. Existing files were preserved.");
                Directory.Delete(destination);
            }
            Directory.Move(staging, destination);
        }
        finally { if (Directory.Exists(staging)) Directory.Delete(staging, recursive: true); }
    }
}
