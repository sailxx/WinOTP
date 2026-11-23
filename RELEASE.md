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

Version 0.4.0 is prepared in the project and installer. Do not publish until the above gates pass AND Vlad approves the Linux screenshots. Source changes do not publish a release. The Release workflow now waits for Linux packages and creates only a draft containing Windows Setup, deb, rpm, AppImage and checksums. See [Linux build and acceptance](packaging/linux/README.md). No release or tag deletion is authorized by the current Linux task; the historical cleanup steps below are not automatic authorization.

1. Review and commit the changes; push the approved commit to `sailxx/WinOTP`.
2. Create and push tag `v0.4.0` on that commit using GitHub or a trusted Git client. The Release workflow builds the installer, checksum and provenance attestation.
3. Download and verify the new installer, then install and launch it on Windows 11. Confirm the release points at the tested commit.
4. Only AFTER the new release is usable, list all previous releases and tags. Archive any assets needed for recovery before deleting them. Remove every earlier release and its corresponding old tag; keep `v0.4.0`. Do not delete unrelated branches. GitHub release/tag deletion is irreversible and is not performed by CI automatically.
5. Confirm the repository has exactly the new release and no old release tags. Confirm no open PRs remain.

The local remote URL may still use GitHub's old redirect. Update it to `https://github.com/sailxx/WinOTP.git` in the IDE Git settings; the restricted Git tool cannot change remotes.

## MSIX

`packaging/Package.appxmanifest` references the generated scale-qualified logos shipped in `Assets/Branding`. It is a packaging input, not a signed or validated MSIX deliverable. The supported distribution remains the Inno Setup installer. Before MSIX publication, provide the publisher identity matching your signing certificate, generate a PRI index in the package layout, pack and sign with Windows SDK tooling, and test installation. Never commit signing keys.

## Migration recovery

Legacy data is copied only as a validated vault/settings pair into an empty WinOTP destination. Existing complete WinOTP stores are not replaced. Mixed/incomplete stores or multiple legacy candidates stop safely instead of merging protection settings or rolling back HOTP counters. Keep all files together and resolve the source pair from backups; do not overwrite a newer store blindly. Original data and backup format markers are retained for compatibility.
