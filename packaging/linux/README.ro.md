[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · **Română** · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Linux construcție și aprobare

Vizează x86_64 Linux , inițial Ubuntu 24.04 și Fedora cu . NET 10 dependențe native. Frontend-ul este Avalonia; aplicația Windows WinUI este neschimbată. Linux folosește același aspect compact, accente de cyan și o suprafață întunecată ușor nuanțată de accentul de sistem (fallback neutru atunci când nu este disponibil): Windows Mica Alt și Segoe UI Variable nu sunt portabile. Inter este la pachet; niciun font Microsoft nu este redistribuit.

Parola principală Linux criptează seiful cu AES -256- GCM și PBKDF2 - SHA256 (600.000 de iterații). Este necesar la pornire și nu poate fi recuperat. Date: `$XDG_DATA_HOME/WinOTP` sau `~/.local/share/WinOTP`. Directorul seifului este 0700 și fișierele seifului nou create 0600. Scrierile sunt atomice, blocate de scriitor și resping revizuirile învechite. Nu sunt stocate secrete în preferințe. Un seif acceptă până la 500 de conturi și 14 MiB de date serializate (deci backup-ul său Base64 se încadrează în limita de import de 20 MiB); salvarile supradimensionate sunt respinse înainte de înlocuire. Nu copiați niciodată fișierele Windows DPAPI în Linux: exportați o parolă criptată `.winotp` backup pe Windows și importați-l pe Linux. Păstrați sursa până când restaurarea este verificată.

## Dezvoltare locală

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

Pentru o previzualizare izolată folosind numai acreditările publice RFC:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## Pachete

`.github/workflows/linux.yml` instalează dependențele de ambalare, verifică un digest appimagetool fixat, creează deb/rpm/ AppImage , instalează și pornește deb-ul sub Xvfb, pornește AppImage fără FUSE și încarcă pachete plus capturi de ecran ca `linux-packages`. Se rulează pe PR-uri și poate fi rulat manual; nu publică o lansare. `packaging/linux/build.sh` rulează și local pe o gazdă x86_64 Linux cu . NET 10, fpm 1.16.0 , rpm și scule squashfs; livra `APPIMAGETOOL` indicând executabilul verificat 1.9.1 x86_64. Tot conținutul generat rămâne sub `artifacts/linux`.

Fluxul de lucru etichetă așteaptă versiunile Linux și Windows, apoi pregătește o **proiect** lansare cu programul de instalare și toate cele trei pachete Linux. GitHub afișează SHA -256 rezumate pentru activele de lansare. Examinați capturile de ecran reale Linux și obțineți aprobarea lui Vlad înainte de a publica. Crearea de etichete sau introducerea de modificări nu face parte din pregătirea locală.

## Încă este necesară acceptarea

Instalați/eliminați/actualizați deb pe Ubuntu și rpm pe Fedora; testați AppImage pe ambele (FUSE sau `--appimage-extract-and-run`). Verificați desktopul X11 / Wayland actual, scalarea, expirarea clipboard-ului, selectarea fișierelor, importul QR, blocarea parolei, restaurarea copiei de rezervă Windows și persistența HOTP. Instalarea RPM și comportamentul compozitorului desktop nu sunt acoperite de jobul Ubuntu CI. Nu a fost implementată încă integrarea tăvii Linux sau importul imaginii din clipboard QR. Importul fișierului QR și importul URI sunt disponibile.

`assets/screenshots/linux-ui-preview.png` este o redare reală a frontend-ului Avalonia găzduit pe Windows, nu o dovadă a unui test de rulare Linux. Niciun pachet nu a fost lansat prin această modificare.
