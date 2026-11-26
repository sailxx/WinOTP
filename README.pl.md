[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · **Polski** · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="Logo WinOTP">

# WinOTP

**Twoje kody. Twoje urządzenie. Twój uwierzytelniacz dla Windows 11.**

TOTP i HOTP w kompaktowym ciemnym oknie z kolorem inspirowanym tapetą. Wyszukuj, importuj i szyfruj kopie zapasowe bez rejestracji i synchronizacji w chmurze.

Zbudowany przez Vlada · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — Twoje kody, Twoje urządzenie; ilustracja interfejsu">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="Pobierz dla Windows 11"></a>&nbsp; &nbsp;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="Co nowego"></a>

Windows 11 · x64 · Interfejs w języku angielskim

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="Funkcje: TOTP i HOTP, lokalny skarbiec, import, wyszukiwanie, kopie zapasowe i brak synchronizacji z chmurą">

<details>
<summary><b>Więcej o funkcjach</b></summary>

### Kody jednorazowe

RFC 6238 TOTP i RFC 4226 HOTP ; SHA -1/256/512; 6 lub 8 cyfr. Dodawaj, edytuj, usuwaj i kopiuj konta i kody. Wyszukiwanie i ulubione pozwalają zachować odpowiedni wpis w zasięgu ręki.

### Przynieś swoje konta

Importuj identyfikatory URI otpauth, identyfikatory URI migracji Google Authenticator, obrazy QR i Aegis JSON. Przeglądaj wpisy przed zapisaniem i pomiń istniejące konta.

### Szyfrowane kopie zapasowe

Przenośny `.winotp` pliki korzystają z osobnego hasła. Zachowaj to hasło oddzielnie i sprawdź jego przywrócenie przed usunięciem danych źródłowych.

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="Sterowanie: dodawanie, ukrywanie kodów, wyszukiwanie, importowanie, tworzenie kopii zapasowych i ustawienia">

<details>
<summary><b>Sterowanie i zrzut ekranu aplikacji</b></summary>

| Kontrola | Działanie |
| --- | --- |
| **Dodać** | Utwórz konto |
| **Ukryj kody / Pokaż kody** | Ukryj lub ujawnij kody |
| **Przeszukaj konta** | Znajdź usługę lub konto |
| **Sprzęt → Importuj** | Importuj konta z podglądem |
| **Sprzęt → Kopia zapasowa** | Utwórz zaszyfrowaną kopię zapasową |
| **Sprzęt → Ustawienia** | Skonfiguruj blokadę interfejsu i limit czasu schowka; wersja znajduje się na dole |

Przewiń listę kont za pomocą kółka myszy lub gestów; pasek przewijania jest ukryty. Trwale ciemny interfejs wykorzystuje natywny Mica Alt z kolorami pochodzącymi z tapety, jeśli pozwalają na to ustawienia Windows.

Zrzut ekranu przedstawiający izolowany skarbiec testowy z publicznymi przykładowymi danymi:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="Okno główne WinOTP z kontem testowym">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="Ochrona danych: Windows DPAPI , AES -256- GCM , blokada interfejsu i limity schowka">

<details>
<summary><b>Ochrona danych i jej ograniczenia</b></summary>

Windows DPAPI chroni skarbiec dla bieżącego użytkownika Windows. Przenośne kopie zapasowe wykorzystują AES -256- GCM i PBKDF2 - SHA256 z 600 000 iteracji. Hasło główne blokuje **interfejs**, niedostępny dla złośliwego oprogramowania działającego jako użytkownik Windows. Czyszczenie schowka nie umożliwia usunięcia historii schowka ani kopii przechwyconych przez inne aplikacje.

Dane żyją `%LOCALAPPDATA%\WinOTP`. Migracja kopiuje starsze pliki z `%LOCALAPPDATA%\NoirAuth` bez usuwania oryginałów. Zachowaj je do czasu zweryfikowania migrowanego skarbca i przywracalnej kopii zapasowej. Widzieć [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="Status projektu: kompaktowy WinUI 3, przepływy pracy na kontach i pozostałe tapety, sprawdzenie skalowania i pakowania">

<details>
<summary><b>Zainstaluj i zaktualizuj</b></summary>

1. Otwarte [Wydania](https://github.com/sailxx/WinOTP/releases) i przeczytaj uwagi do wybranej wersji.
2. W przypadku wydań noszących nową nazwę pobierz `WinOTP-Setup.exe`.
3. Uruchom Instalatora i wybierz folder. Nie są wymagane żadne uprawnienia administratora.

Dane są przechowywane oddzielnie i zachowywane podczas odinstalowywania. Utwórz kopię zapasową przed aktualizacją. Interfejs aplikacji i instalator używają języka angielskiego.

Instalator nie jest podpisany kodem Windows; SmartScreen może ostrzegać. Sprawdź źródło i sumę kontrolną przed podjęciem decyzji o uruchomieniu.

</details>

<details>
<summary><b>Sprawdź pobranie</b></summary>

Pobierz instalator i uruchom:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

Porównaj skrót z wartością SHA -256 obok instalatora na liście zasobów wersji GitHub. Pochodzenie nie stanowi podpisywania kodu Windows ani gwarancji kodu wolnego od luk w zabezpieczeniach. Starsze wersje mogą nie zawierać atestów.

</details>

<details>
<summary><b>Kompiluj ze źródła</b></summary>

Wymaga Windows, . Narzędzia budowlane NET SDK 10 i WinUI. Zastąp ścieżkę w pierwszym poleceniu folderem projektu.

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

Zwolnij bramki i instrukcje: [RELEASE.md](RELEASE.md). Zmiany: [CHANGELOG.md](CHANGELOG.md). Wygeneruj panele graficzne za pomocą `python tools/generate_readme.py` z katalogu głównego projektu.

</details>

<details>
<summary><b>Znane ograniczenia</b></summary>

- Przygotowano frontend Avalonia Linux oraz receptury deb, obr./min i AppImage dla x64, oczekujące na akceptację i zatwierdzenie Linux. [Budowa i ograniczenia](packaging/linux/README.md). Brak synchronizacji macOS lub chmury.
- Linux zachowuje kompaktowy układ i kolory z nieprzezroczystym ciemnym tłem i dołączonym Interem; Windows Mica Alt jest niedostępny. Hasło Linux szyfruje skarbiec. Przenieś konta Windows za pomocą szyfrowanego hasła `.winotp` kopia zapasowa.
- Mika zależy od wersji Windows i polityki przejrzystości. Nadal potrzebne są pełne testy akceptacyjne dotyczące zmiany tapety i wieloskalowe.
- Manifest MSIX to dane wejściowe pakietu, a nie podpisany pakiet przetestowany pod kątem instalacji. Inno Setup to format dystrybucji.
- Uwagi do każdego wydania opisują jego status publikacji i weryfikacji. Przygotowana wersja lokalna nie jest publikacją.

</details>

<details>
<summary><b>O i licencji</b></summary>

WinOTP został opracowany przez Vlada ([sailxx](https://github.com/sailxx)). Źródło jest dostępne pod adresem [Licencja MIT](LICENSE). Błędy i sugestie: [Kwestie](https://github.com/sailxx/WinOTP/issues).

</details>
