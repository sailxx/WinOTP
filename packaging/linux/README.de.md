[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · **Deutsch** · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Bau und Genehmigung des Linux

Zielt auf x86_64 Linux, zunächst Ubuntu 24.04 und Fedora mit . NET 10 native Abhängigkeiten. Das Frontend ist Avalonia; Die Windows WinUI-Anwendung bleibt unverändert. Linux verwendet das gleiche kompakte Layout, Cyan-Akzente und eine dunkle Oberfläche, die leicht durch den Systemakzent getönt ist (neutraler Ersatz, wenn nicht verfügbar): Windows Mica Alt und Segoe UI Variable sind nicht tragbar. Inter ist gebündelt; Es wird keine Microsoft-Schriftart weitergegeben.

Das Linux-Master-Passwort verschlüsselt den Tresor mit AES -256- GCM und PBKDF2 - SHA256 (600.000 Iterationen). Es ist beim Start erforderlich und kann nicht wiederhergestellt werden. Daten: `$XDG_DATA_HOME/WinOTP` oder `~/.local/share/WinOTP`. Das Tresorverzeichnis ist 0700 und neu erstellte Tresordateien sind 0600. Schreibvorgänge sind atomar, schreibgeschützt und weisen veraltete Revisionen zurück. In den Einstellungen werden keine Geheimnisse gespeichert. Ein Tresor unterstützt bis zu 500 Konten und 14 MiB serialisierte Daten (damit sein Base64-Backup das Importlimit von 20 MiB erfüllt); Übergroße Sicherungen werden vor dem Austausch zurückgewiesen. Kopieren Sie niemals Windows DPAPI-Dateien nach Linux: Exportieren Sie sie passwortverschlüsselt `.winotp` Backup auf Windows erstellen und auf Linux importieren. Bewahren Sie die Quelle auf, bis die Wiederherstellung überprüft wurde.

## Lokale Entwicklung

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

Für eine isolierte Vorschau nur mit öffentlichen RFC-Anmeldeinformationen:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## Pakete

`.github/workflows/linux.yml` Installiert die Paketabhängigkeiten, überprüft einen angehefteten Appimagetool-Digest, erstellt deb/rpm/AppImage, installiert und startet das Deb unter Xvfb, startet AppImage ohne FUSE und lädt Pakete plus Screenshots hoch `linux-packages`. Es läuft auf PRs und kann manuell ausgeführt werden; Es wird keine Veröffentlichung veröffentlicht. `packaging/linux/build.sh` Läuft auch lokal auf einem x86_64 Linux-Host mit . NET 10, fpm 1.16.0, rpm und squashfs-tools; liefern `APPIMAGETOOL` Verweist auf die verifizierte ausführbare Datei 1.9.1 x86_64. Alle generierten Inhalte bleiben unter `artifacts/linux`.

Der Tag-Workflow wartet auf Linux- und Windows-Builds und bereitet dann einen vor **Entwurf** Release mit dem Installer und allen drei Linux-Paketen. GitHub zeigt SHA-256-Digests für Release-Assets. Sehen Sie sich die echten Linux-Screenshots an und holen Sie vor der Veröffentlichung die Genehmigung von Vlad ein. Das Erstellen von Tags oder das Übertragen von Änderungen ist nicht Teil der lokalen Vorbereitung.

## Abnahme noch erforderlich

Deb unter Ubuntu und rpm unter Fedora installieren/entfernen/aktualisieren; Testen Sie AppImage auf beiden ( FUSE oder `--appimage-extract-and-run`). Überprüfen Sie den tatsächlichen X11/Wayland-Desktop, die Skalierung, das Zeitlimit für die Zwischenablage, die Dateiauswahl, den QR-Import, die Passwortsperre, die Windows-Backup-Wiederherstellung und die HOTP-Persistenz. Die RPM-Installation und das Desktop-Compositor-Verhalten werden vom Ubuntu CI-Job nicht abgedeckt. Es ist noch keine Linux-Tray-Integration oder ein QR-Import von Zwischenablagebildern implementiert. Datei-QR-Import und URI-Import sind verfügbar.

`assets/screenshots/linux-ui-preview.png` ist ein echtes Rendering des Avalonia-Frontends, das auf Windows gehostet wird, kein Beweis für einen Linux-Laufzeittest. Durch diese Änderung wurden keine Pakete veröffentlicht.
