[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · **Čeština** · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Sestavení a schválení Linux

Cílí na x86_64 Linux, zpočátku Ubuntu 24.04 a Fedora s . NET 10 nativních závislostí. Frontend je Avalonia ; aplikace Windows WinUI je nezměněna. Linux používá stejné kompaktní uspořádání, azurové akcenty a tmavý povrch lehce zabarvený systémovým zvýrazněním (neutrální záložní, když není k dispozici): Windows Mica Alt a Segoe UI Variable nejsou přenosné. Inter je svázaný; není redistribuováno žádné písmo Microsoft.

Hlavní heslo Linux šifruje vault pomocí AES -256- GCM a PBKDF2 - SHA256 (600 000 iterací). Je vyžadován při spuštění a nelze jej obnovit. Data: `$XDG_DATA_HOME/WinOTP` nebo `~/.local/share/WinOTP`. Adresář úschovny je 0700 a nově vytvořené soubory úschovny 0600. Zápisy jsou atomické, uzamčené pro zápis a odmítají zastaralé revize. V předvolbách nejsou uložena žádná tajemství. Trezor podporuje až 500 účtů a 14 MiB serializovaných dat (takže jeho záloha Base64 odpovídá limitu importu 20 MiB); oversize save jsou před výměnou odmítnuty. Nikdy nekopírujte soubory Windows DPAPI do Linux: exportujte heslo zašifrované `.winotp` zálohovat na Windows a importovat na Linux . Uchovávejte zdroj, dokud nebude ověřena obnova.

## Místní rozvoj

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

Pro izolovaný náhled s použitím pouze veřejných přihlašovacích údajů RFC:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## Balíčky

`.github/workflows/linux.yml` nainstaluje závislosti balení, ověří připnutý přehled nástroje appimagetool, sestaví deb/rpm/AppImage, nainstaluje a spustí deb pod Xvfb, spustí AppImage bez FUSE a nahraje balíčky plus snímky obrazovky jako `linux-packages`. Běží na PR a lze jej spustit ručně; nezveřejňuje vydání. `packaging/linux/build.sh` také běží lokálně na x86_64 Linux hostiteli s . NET 10, fpm 1.16.0 , rpm a squashfs-tools; zásobování `APPIMAGETOOL` ukazující na ověřený spustitelný soubor 1.9.1 x86_64. Veškerý generovaný obsah zůstane pod `artifacts/linux`.

Pracovní postup značek čeká na sestavení Linux a Windows a poté připraví a **návrh** vydání s instalačním programem a všemi třemi balíčky Linux. GitHub zobrazuje SHA -256 výtahy pro aktiva vydání. Prohlédněte si skutečné snímky obrazovky Linux a před publikováním získejte Vladův souhlas. Vytváření značek nebo prosazování změn není součástí místní přípravy.

## Stále vyžadováno přijetí

Nainstalujte/odeberte/upgradujte deb na Ubuntu a rpm na Fedoře; otestujte AppImage na obou ( FUSE nebo `--appimage-extract-and-run`). Ověřte aktuální plochu X11 / Wayland, škálování, časový limit schránky, výběr souborů, import QR, zamykání heslem, obnovení zálohy Windows a trvalost HOTP. Instalace RPM a chování sazbu pro stolní počítače nejsou pokryty úlohou Ubuntu CI. Dosud není implementována žádná integrace zásobníku Linux ani import obrázku QR do schránky. K dispozici je import souboru QR a import URI.

`assets/screenshots/linux-ui-preview.png` je skutečným vykreslením rozhraní Avalonia hostovaného na Windows, nikoli důkazem běhového testu Linux. Touto změnou nebyly vydány žádné balíčky.
