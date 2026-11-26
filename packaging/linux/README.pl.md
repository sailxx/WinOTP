[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · **Polski** · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Budowa i zatwierdzenie Linux

Celuje w x86_64 Linux, początkowo Ubuntu 24.04 i Fedora z . NET 10 natywnych zależności. Frontend to Avalonia; aplikacja Windows WinUI pozostaje niezmieniona. Linux wykorzystuje ten sam kompaktowy układ, cyjanowe akcenty i ciemną powierzchnię lekko zabarwioną akcentem systemowym (neutralny powrót, gdy jest niedostępny): Windows Mica Alt i Segoe UI Variable nie są przenośne. Inter jest w pakiecie; żadna czcionka Microsoft nie jest redystrybuowana.

Hasło główne Linux szyfruje skarbiec za pomocą AES -256- GCM i PBKDF2 - SHA256 (600 000 iteracji). Jest wymagany przy uruchomieniu i nie można go odzyskać. Dane: `$XDG_DATA_HOME/WinOTP` Lub `~/.local/share/WinOTP`. Katalog skarbca to 0700, a nowo utworzone pliki skarbca to 0600. Zapisy są niepodzielne, mają blokadę zapisu i odrzucają nieaktualne wersje. W preferencjach nie są przechowywane żadne tajemnice. Skarbiec obsługuje do 500 kont i serializowanych danych o wielkości 14 MiB (więc kopia zapasowa Base64 mieści się w limicie importu 20 MiB); ponadwymiarowe oszczędności są odrzucane przed wymianą. Nigdy nie kopiuj plików Windows DPAPI do Linux: eksportuj plik zaszyfrowany hasłem `.winotp` wykonaj kopię zapasową na Windows i zaimportuj ją na Linux . Zachowaj źródło do czasu zweryfikowania przywrócenia.

## Rozwój lokalny

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

Dla izolowanego podglądu przy użyciu wyłącznie publicznych poświadczeń RFC:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## Pakiety

`.github/workflows/linux.yml` instaluje zależności pakietu, weryfikuje przypięty skrót appimagetool, buduje deb/rpm/AppImage, instaluje i uruchamia deb pod Xvfb, uruchamia AppImage bez FUSE i przesyła pakiety wraz z zrzutami ekranu jako `linux-packages`. Działa na PR i można go uruchomić ręcznie; nie publikuje komunikatu. `packaging/linux/build.sh` działa również lokalnie na hoście x86_64 Linux z . NET 10, fpm 1.16.0 , narzędzia RPM i squashfs; dostarczać `APPIMAGETOOL` wskazując zweryfikowany plik wykonywalny 1.9.1 x86_64. Cała wygenerowana treść pozostaje pod `artifacts/linux`.

Przepływ pracy z tagami czeka na kompilacje Linux i Windows, a następnie przygotowuje plik **projekt** release z instalatorem i wszystkimi trzema pakietami Linux. GitHub pokazuje podsumowanie SHA -256 dla zasobów wersji. Przejrzyj prawdziwe zrzuty ekranu Linux i uzyskaj zgodę Vlada przed publikacją. Tworzenie tagów lub wypychanie zmian nie jest częścią lokalnych przygotowań.

## Nadal wymagana jest akceptacja

Zainstaluj/usuń/uaktualnij deb na Ubuntu i RPM na Fedorze; przetestuj AppImage na obu (FUSE lub `--appimage-extract-and-run`). Sprawdź rzeczywisty pulpit X11 / Wayland, skalowanie, limit czasu schowka, selektory plików, import QR, blokowanie hasłem, przywracanie kopii zapasowej Windows i trwałość HOTP. Instalacja RPM i zachowanie kompozytora pulpitu nie są objęte zadaniem Ubuntu CI. Nie zaimplementowano jeszcze integracji tacy Linux ani importu obrazu ze schowka QR. Dostępny jest import pliku QR i import URI.

`assets/screenshots/linux-ui-preview.png` to prawdziwy render frontendu Avalonia hostowanego na Windows, a nie dowód testu środowiska wykonawczego Linux. W wyniku tej zmiany nie wydano żadnych pakietów.
