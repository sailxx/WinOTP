# Linux build and approval

Targets x86_64 Linux, initially Ubuntu 24.04 and Fedora with .NET 10 native dependencies. The frontend is Avalonia; the Windows WinUI application is unchanged. Linux uses the same compact layout, cyan accents and a dark surface lightly tinted by the system accent (neutral fallback when unavailable): Windows Mica Alt and Segoe UI Variable are not portable. Inter is bundled; no Microsoft font is redistributed.

The Linux master password encrypts the vault with AES-256-GCM and PBKDF2-SHA256 (600,000 iterations). It is required at startup and cannot be recovered. Data: `$XDG_DATA_HOME/WinOTP` or `~/.local/share/WinOTP`. Vault directory is 0700 and newly created vault files 0600. Writes are atomic, writer-locked, and reject stale revisions. No secrets are stored in preferences. A vault supports up to 500 accounts and 14 MiB serialized data (so its Base64 backup fits the 20 MiB import limit); oversize saves are rejected before replacement. Never copy Windows DPAPI files to Linux: export a password-encrypted `.winotp` backup on Windows and import it on Linux. Keep the source until restoration is verified.

## Local development

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

For an isolated preview using only public RFC credentials:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## Packages

`.github/workflows/linux.yml` installs the packaging dependencies, verifies a pinned appimagetool digest, builds deb/rpm/AppImage, installs and starts the deb under Xvfb, starts the AppImage without FUSE, and uploads packages plus screenshots as `linux-packages`. It runs on PRs and can be run manually; it does not publish a release. `packaging/linux/build.sh` also runs locally on an x86_64 Linux host with .NET 10, fpm 1.16.0, rpm and squashfs-tools; supply `APPIMAGETOOL` pointing to the verified 1.9.1 x86_64 executable. All generated content stays under `artifacts/linux`.

The tag workflow waits for Linux and Windows builds, then prepares a **draft** release with the installer and all three Linux packages. GitHub shows SHA-256 digests for release assets. Review the real Linux screenshots and obtain Vlad's approval before publishing. Creating tags or pushing changes is not part of local preparation.

## Acceptance still required

Install/remove/upgrade deb on Ubuntu and rpm on Fedora; test AppImage on both (FUSE or `--appimage-extract-and-run`). Verify actual X11/Wayland desktop, scaling, clipboard timeout, file pickers, QR import, password locking, Windows backup restoration and HOTP persistence. RPM installation and desktop compositor behavior are not covered by the Ubuntu CI job. No Linux tray integration or clipboard-image QR import is implemented yet. File QR import and URI import are available.

`assets/screenshots/linux-ui-preview.png` is a real rendering of the Avalonia frontend hosted on Windows, not proof of a Linux runtime test. No packages have been released by this change.
