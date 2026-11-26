**English** · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="WinOTP logo">

# WinOTP

**Your codes. Your device. Your authenticator for Windows 11.**

TOTP and HOTP in a compact dark window with wallpaper-derived color. Search, import and encrypted backups without registration or cloud sync.

Built by Vlad · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — your codes, your device; an interface illustration">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="Download for Windows 11"></a>&nbsp;&nbsp;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="What’s new"></a>

Windows 11 · x64 · English interface

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="Features: TOTP and HOTP, local vault, import, search, backups and no cloud sync">

<details>
<summary><b>More about the features</b></summary>

### One-time codes

RFC 6238 TOTP and RFC 4226 HOTP; SHA-1/256/512; 6 or 8 digits. Add, edit, remove and copy accounts and codes. Search and favorites keep the right entry within reach.

### Bring your accounts

Import otpauth URIs, Google Authenticator migration URIs, QR images and Aegis JSON. Preview entries before saving and skip existing accounts.

### Encrypted backups

Portable `.winotp` files use a separate password. Keep that password separately and verify restoration before deleting the source data.

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="Controls: Add, Hide codes, Search, Import, Backup and Settings">

<details>
<summary><b>Controls and application screenshot</b></summary>

| Control | Action |
| --- | --- |
| **Add** | Create an account |
| **Hide codes / Show codes** | Conceal or reveal codes |
| **Search accounts** | Find a service or account |
| **Gear → Import** | Import accounts with a preview |
| **Gear → Backup** | Create an encrypted backup |
| **Gear → Settings** | Configure interface lock and clipboard timeout; version is at the bottom |

Scroll the account list with the mouse wheel or gestures; the scrollbar is hidden. The permanently dark interface uses native Mica Alt with wallpaper-derived color when permitted by Windows settings.

Screenshot of an isolated test vault with public example data:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="WinOTP main window with a test account">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="Data protection: Windows DPAPI, AES-256-GCM, interface lock and clipboard limits">

<details>
<summary><b>Data protection and its limits</b></summary>

Windows DPAPI protects the vault for the current Windows user. Portable backups use AES-256-GCM and PBKDF2-SHA256 with 600,000 iterations. The master password locks the **interface**, not access by malware running as your Windows user. Clipboard clearing cannot erase clipboard history or copies captured by other apps.

Data lives in `%LOCALAPPDATA%\WinOTP`. Migration copies legacy files from `%LOCALAPPDATA%\NoirAuth` without removing the originals. Keep them until you have verified the migrated vault and a restorable backup. See [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="Project status: compact WinUI 3, account workflows and remaining wallpaper, scaling and packaging checks">

<details>
<summary><b>Install and update</b></summary>

1. Open [Releases](https://github.com/sailxx/WinOTP/releases) and read the selected version’s notes.
2. For releases carrying the new name, download `WinOTP-Setup.exe`.
3. Run Setup and choose a folder. No administrator rights are required.

Data is stored separately and retained when uninstalling. Create a backup before updating. The application interface and installer use English.

The installer is not Windows code-signed; SmartScreen may warn. Check the source and checksum before deciding whether to run it.

</details>

<details>
<summary><b>Verify your download</b></summary>

Download the installer and run:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

Compare the hash with the SHA-256 value next to the installer in the GitHub release asset list. Provenance is not Windows code signing or a guarantee of vulnerability-free code. Older releases may not include attestations.

</details>

<details>
<summary><b>Build from source</b></summary>

Requires Windows, .NET SDK 10 and WinUI build tools. Replace the path in the first command with your project folder.

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

Release gates and instructions: [RELEASE.md](RELEASE.md). Changes: [CHANGELOG.md](CHANGELOG.md). Generate the graphic panels with `python tools/generate_readme.py` from the project root.

</details>

<details>
<summary><b>Known limitations</b></summary>

- An Avalonia Linux frontend and x64 deb, rpm and AppImage recipes are prepared, pending Linux acceptance and approval. [Build and limitations](packaging/linux/README.md). No macOS or cloud sync.
- Linux keeps the compact layout and colors with an opaque dark backdrop and bundled Inter; Windows Mica Alt is unavailable. The Linux password encrypts the vault. Transfer Windows accounts through a password-encrypted `.winotp` backup.
- Mica depends on Windows version and transparency policy. Full wallpaper-change and multi-scale acceptance testing is still needed.
- The MSIX manifest is a packaging input, not a signed, installation-tested package. Inno Setup is the distribution format.
- Each release’s notes describe its publication and verification status. A prepared local version is not a published release.

</details>

<details>
<summary><b>About and license</b></summary>

WinOTP is developed by Vlad ([sailxx](https://github.com/sailxx)). Source is available under the [MIT license](LICENSE). Bugs and suggestions: [Issues](https://github.com/sailxx/WinOTP/issues).

</details>
