# WinOTP release checklist

## Local verification

Run in cmd.exe:

```cmd
cd /d C:\Users\Vlad\sx\winotp
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet publish src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -r win-x64 --self-contained true -p:WindowsAppSDKSelfContained=true -p:PublishDir=artifacts/publish/ -warnaserror
```

For the isolated native acceptance check, publish to `artifacts/winotp-v040/` instead, install pywinauto into `.sharrowkin/python`, then run `python tools/smoke_ui.py`. The `--preview` argument uses a per-process directory beside the executable; it never loads the user's vault. Its RFC example credentials are public test data.

- [ ] Verify compact 540 × 660 window, black title bar active/inactive, dark dialogs and Mica Alt on Windows 11.
- [ ] Change wallpaper, toggle Windows light/dark, transparency and high contrast; check readability and system fallback. The application intentionally stays dark.
- [ ] Verify 100/125/150/200/400% scaling, taskbar, tray, installer and shortcuts.
- [ ] Exercise add/edit/delete, favorites, TOTP rollover, HOTP copy/persistence, import previews, encrypted backup restore, locking and clipboard timeout.
- [ ] Test upgrade against a COPY of legacy data. Never delete the originals before validating a restored backup.
- [ ] Build and test the installer with Inno Setup 6. No administrator rights are needed to install the application.

```cmd
cd /d C:\Users\Vlad\sx\winotp
"C:\Program Files (x86)\Inno Setup 6\ISCC.exe" installer\WinOTP.iss
```

## GitHub publication

1. Match the Windows project and installer versions, then push the reviewed commit and its matching `v<version>` tag to `sailxx/WinOTP`.
2. The Release workflow builds and attests the Windows installer and creates a draft. If the tag also matches the Linux project version, the draft includes Linux packages and a screenshot. Review the Linux output with Vlad before publishing those assets. See [Linux build and acceptance](packaging/linux/README.md).
3. Download the Windows installer, verify its GitHub asset digest, and check installation and launch on Windows 11. Confirm the release points to the tested commit before publishing.

The Git remote for WinOTP is `https://github.com/sailxx/WinOTP.git`.

## MSIX

`packaging/Package.appxmanifest` references the generated scale-qualified logos shipped in `Assets/Branding`. It is a packaging input, not a signed or validated MSIX deliverable. The supported distribution remains the Inno Setup installer. Before MSIX publication, provide the publisher identity matching your signing certificate, generate a PRI index in the package layout, pack and sign with Windows SDK tooling, and test installation. Never commit signing keys.

## Migration recovery

Legacy data is copied only as a validated vault/settings pair into an empty WinOTP destination. Existing complete WinOTP stores are not replaced. Mixed/incomplete stores or multiple legacy candidates stop safely instead of merging protection settings or rolling back HOTP counters. Keep all files together and resolve the source pair from backups; do not overwrite a newer store blindly. Original data and backup format markers are retained for compatibility.
