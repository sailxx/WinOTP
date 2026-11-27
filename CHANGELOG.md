# Changelog

## 0.4.2 — Windows

- Added an Acrylic backdrop option with live blur alongside the default wallpaper-tinted Mica.
- Refined account cards, compact dialogs and the blue accent for primary buttons.
- Smoothed the countdown bar and synchronized it with TOTP refresh.

## 0.4.0 — Unreleased

- Linux Avalonia frontend with shared OTP/import code, compact dark layout, account management, URI/QR/backup import, favorites, clipboard timeout and password-encrypted storage.
- x64 deb, rpm and AppImage package recipes with checksums, Linux build/launch CI and draft-only release assembly pending visual approval.
- Linux vault encryption, corruption/stale-writer guards and Windows backup interoperability regression checks. Linux native acceptance remains pending.

- Compact 540 × 660 WinUI 3 window, permanently dark interface, black native title bar and Segoe UI Variable typography.
- Native Mica Alt wallpaper-derived backdrop with system policy fallback; graphite list surface, thin row dividers, cyan countdown indicators and a darker action bar inspired by compact Windows 11 flyouts.
- WinOTP application identity, taskbar icon, native tray icon and installer branding.
- Reproducible SVG-derived multi-resolution ICO and package PNG assets, README favicon and MSIX packaging manifest input.
- Publish now includes the application PRI resource index as well as compiled XAML, fixing native WinUI theme-resource lookup at startup.
- Validated legacy vault/settings pair migration without overwriting existing stores or deleting original files.
- Fail-closed handling of null vault/settings payloads; loading old settings no longer resets code visibility or writes defaults.
- New migration, privacy and invalid-store regression checks in addition to RFC OTP/import/storage tests.
- Isolated --preview startup and a native UI test using public RFC credentials.

Release gates still require manual wallpaper/system-policy, multi-DPI, complete import/export UI, tray and installer acceptance. MSIX is not yet signed or installation-tested. No public 0.4.0 release has been published.
