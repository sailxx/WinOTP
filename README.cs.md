[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · **Čeština** · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="Logo WinOTP">

# WinOTP

**Vaše kódy. Vaše zařízení. Váš autentizátor pro Windows 11.**

TOTP a HOTP v kompaktním tmavém okně s barvou odvozenou z tapety. Vyhledávejte, importujte a šifrované zálohy bez registrace nebo cloudové synchronizace.

Postavil Vlad · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — vaše kódy, vaše zařízení; ilustrace rozhraní">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="Stáhnout pro Windows 11"></a>&nbsp; &nbsp;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="Co je nového"></a>

Windows 11 · x64 · anglické rozhraní

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="Vlastnosti: TOTP a HOTP, místní trezor, import, vyhledávání, zálohy a žádná synchronizace s cloudem">

<details>
<summary><b>Více o funkcích</b></summary>

### Jednorázové kódy

RFC 6238 TOTP a RFC 4226 HOTP ; SHA -1/256/512; 6 nebo 8 číslic. Přidávejte, upravujte, odebírejte a kopírujte účty a kódy. Vyhledávání a oblíbené položky udrží správný záznam na dosah.

### Přineste své účty

Importujte URI otpauth, URI migrace Google Authenticator, obrázky QR a Aegis JSON . Před uložením si prohlédněte položky a přeskočte stávající účty.

### Šifrované zálohy

Přenosný `.winotp` soubory používají samostatné heslo. Toto heslo uschovejte samostatně a před odstraněním zdrojových dat ověřte obnovení.

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="Ovládací prvky: Přidat, Skrýt kódy, Hledat, Importovat, Zálohovat a Nastavení">

<details>
<summary><b>Snímek obrazovky ovládání a aplikace</b></summary>

| Řízení | Akce |
| --- | --- |
| **Přidat** | Vytvořte si účet |
| **Skrýt kódy / Zobrazit kódy** | Skryjte nebo odhalte kódy |
| **Hledat účty** | Najděte službu nebo účet |
| **Zařízení → Import** | Importujte účty s náhledem |
| **Zařízení → Záloha** | Vytvořte šifrovanou zálohu |
| **Zařízení → Nastavení** | Konfigurace zámku rozhraní a časového limitu schránky; verze je dole |

Procházejte seznam účtů pomocí kolečka myši nebo gest; posuvník je skrytý. Trvale tmavé rozhraní používá nativní Mica Alt s barvou odvozenou z tapety, pokud je povoleno nastavením Windows.

Snímek obrazovky izolovaného testovacího trezoru s veřejnými ukázkovými daty:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="Hlavní okno WinOTP s testovacím účtem">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="Ochrana dat: Windows DPAPI , AES -256- GCM , zámek rozhraní a limity schránky">

<details>
<summary><b>Ochrana dat a její limity</b></summary>

Windows DPAPI chrání trezor pro aktuálního uživatele Windows. Přenosné zálohy používají AES -256- GCM a PBKDF2 - SHA256 s 600 000 iteracemi. Hlavní heslo uzamkne **rozhraní**, nemá přístup malware spuštěný jako váš uživatel Windows. Vymazáním schránky nelze vymazat historii schránky ani kopie zachycené jinými aplikacemi.

Data bydlí v `%LOCALAPPDATA%\WinOTP`. Migrace zkopíruje starší soubory z `%LOCALAPPDATA%\NoirAuth` bez odstranění originálů. Uchovávejte je, dokud neověříte migrovaný vault a obnovitelnou zálohu. Vidět [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="Stav projektu: kompaktní WinUI 3, pracovní postupy účtu a zbývající tapety, změna měřítka a kontroly balení">

<details>
<summary><b>Nainstalujte a aktualizujte</b></summary>

1. OTEVŘENO [Vydání](https://github.com/sailxx/WinOTP/releases) a přečtěte si poznámky k vybrané verzi.
2. Pro vydání s novým názvem si stáhněte `WinOTP-Setup.exe`.
3. Spusťte instalační program a vyberte složku. Nejsou vyžadována žádná administrátorská práva.

Data jsou uložena odděleně a uchována při odinstalaci. Před aktualizací vytvořte zálohu. Rozhraní aplikace a instalační program používají angličtinu.

Instalační program není podepsán kódem Windows; SmartScreen může varovat. Než se rozhodnete, zda jej spustit, zkontrolujte zdroj a kontrolní součet.

</details>

<details>
<summary><b>Ověřte stažení</b></summary>

Stáhněte si instalační program a spusťte:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

Porovnejte hash s hodnotou SHA -256 vedle instalačního programu v seznamu aktiv vydání GitHub. Provenience není podepisování kódu Windows ani záruka kódu bez zranitelnosti. Starší vydání nemusí obsahovat atestace.

</details>

<details>
<summary><b>Sestavte ze zdroje</b></summary>

Vyžaduje Windows , . Stavební nástroje NET SDK 10 a WinUI. Nahraďte cestu v prvním příkazu složkou projektu.

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

Uvolněte brány a pokyny: [RELEASE.md](RELEASE.md). Změny: [CHANGELOG.md](CHANGELOG.md). Vygenerujte grafické panely pomocí `python tools/generate_readme.py` z kořene projektu.

</details>

<details>
<summary><b>Známá omezení</b></summary>

- Čeká na přijetí a schválení Linux frontend Avalonia Linux a receptury x64 deb, rpm a AppImage. [Stavba a omezení](packaging/linux/README.md). Žádná synchronizace macOS nebo cloudu.
- Linux si zachovává kompaktní uspořádání a barvy s neprůhledným tmavým pozadím a přibaleným Inter; Windows Mica Alt není k dispozici. Heslo Linux šifruje trezor. Přeneste účty Windows pomocí zašifrovaného hesla `.winotp` zálohování.
- Slída závisí na verzi Windows a zásadách transparentnosti. Stále je zapotřebí úplná změna tapety a víceúrovňové akceptační testy.
- Manifest MSIX je vstup pro balení, nikoli podepsaný balík testovaný instalací. Inno Setup je distribuční formát.
- Poznámky ke každému vydání popisují jeho publikování a stav ověření. Připravená lokální verze není publikovaná verze.

</details>

<details>
<summary><b>O a licenci</b></summary>

WinOTP je vyvinut Vladem ([sailxx](https://github.com/sailxx)). Zdroj je dostupný pod [Licence MIT](LICENSE). Chyby a návrhy: [Problémy](https://github.com/sailxx/WinOTP/issues).

</details>
