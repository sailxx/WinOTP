[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · **Română** · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="Sigla WinOTP">

# WinOTP

**Codurile tale. Dispozitivul dvs. Autentificatorul dvs. pentru Windows 11.**

TOTP și HOTP într-o fereastră compactă întunecată cu culoare derivată din tapet. Căutați, importați și copii de rezervă criptate fără înregistrare sau sincronizare în cloud.

Construit de Vlad · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — codurile dvs., dispozitivul dvs.; o ilustrare a interfeței">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="Descărcați pentru Windows 11"></a>&nbsp; &nbsp;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="Ce este nou"></a>

Windows 11 · x64 · Interfață engleză

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="Caracteristici: TOTP și HOTP, seif local, import, căutare, backup și fără sincronizare în cloud">

<details>
<summary><b>Mai multe despre caracteristici</b></summary>

### Coduri unice

RFC 6238 TOTP și RFC 4226 HOTP ; SHA -1/256/512; 6 sau 8 cifre. Adăugați, editați, eliminați și copiați conturi și coduri. Căutarea și favoritele păstrează intrarea potrivită la îndemână.

### Adu-ți conturile

Importați URI-uri otpauth, URI-uri de migrare Google Authenticator, imagini QR și Aegis JSON . Previzualizează intrările înainte de a salva și omite conturile existente.

### Copii de rezervă criptate

Portabil `.winotp` fișierele folosesc o parolă separată. Păstrați acea parolă separat și verificați restaurarea înainte de a șterge datele sursă.

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="Controale: Adaugă, Ascunde coduri, Căutare, Import, Backup și Setări">

<details>
<summary><b>Comenzi și captură de ecran a aplicației</b></summary>

| Controla | Acţiune |
| --- | --- |
| **Adăuga** | Creați un cont |
| **Ascunde codurile / Afișează codurile** | Ascunde sau dezvăluie coduri |
| **Căutați conturi** | Găsiți un serviciu sau un cont |
| **Gear → Import** | Importați conturi cu o previzualizare |
| **Gear → Backup** | Creați o copie de rezervă criptată |
| **Gear → Setări** | Configurați blocarea interfeței și expirarea clipboard-ului; versiunea este în partea de jos |

Derulați lista de conturi cu rotița mouse-ului sau cu gesturi; bara de derulare este ascunsă. Interfața permanent întunecată folosește Mica Alt nativ cu culoare derivată din tapet atunci când este permis de setările Windows.

Captură de ecran a unui seif de testare izolat cu date de exemplu publice:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="Fereastra principală WinOTP cu un cont de test">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="Protecția datelor: Windows DPAPI , AES -256- GCM , blocarea interfeței și limitele clipboard">

<details>
<summary><b>Protecția datelor și limitele acesteia</b></summary>

Windows DPAPI protejează seiful pentru utilizatorul actual Windows. Backup-urile portabile folosesc AES -256- GCM și PBKDF2 - SHA256 cu 600.000 de iterații. Parola principală blochează **interfata**, nu accesați de malware care rulează ca utilizator Windows. Ștergerea clipboard-ului nu poate șterge istoricul clipboard-ului sau copiile capturate de alte aplicații.

Datele trăiesc în `%LOCALAPPDATA%\WinOTP`. Migrarea copiază fișierele vechi din `%LOCALAPPDATA%\NoirAuth` fără a îndepărta originalele. Păstrați-le până când ați verificat seiful migrat și o copie de rezervă care poate fi restaurată. Vedea [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="Starea proiectului: compact WinUI 3, fluxuri de lucru ale contului și tapet rămase, verificări de scalare și ambalare">

<details>
<summary><b>Instalați și actualizați</b></summary>

1. Deschide [Lansări](https://github.com/sailxx/WinOTP/releases) și citiți notele versiunii selectate.
2. Pentru versiunile care poartă noul nume, descărcați `WinOTP-Setup.exe`.
3. Rulați Setup și alegeți un folder. Nu sunt necesare drepturi de administrator.

Datele sunt stocate separat și păstrate la dezinstalare. Creați o copie de rezervă înainte de actualizare. Interfața aplicației și programul de instalare folosesc limba engleză.

Programul de instalare nu este semnat de cod Windows; SmartScreen poate avertiza. Verificați sursa și suma de control înainte de a decide dacă să le rulați.

</details>

<details>
<summary><b>Verificați descărcarea</b></summary>

Descărcați programul de instalare și rulați:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

Comparați hash-ul cu valoarea SHA -256 de lângă programul de instalare în lista de active a lansării GitHub. Proveniența nu este semnarea codului Windows sau o garanție a codului fără vulnerabilități. Este posibil ca versiunile mai vechi să nu includă atestări.

</details>

<details>
<summary><b>Construiți din sursă</b></summary>

Necesită Windows , . NET SDK 10 și WinUI unelte de construcție. Înlocuiți calea din prima comandă cu folderul proiectului.

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

Eliberați porțile și instrucțiunile: [RELEASE.md](RELEASE.md). Schimbări: [CHANGELOG.md](CHANGELOG.md). Generați panourile grafice cu `python tools/generate_readme.py` de la rădăcina proiectului.

</details>

<details>
<summary><b>Limitări cunoscute</b></summary>

- Sunt pregătite rețete Avalonia Linux și x64 deb, rpm și AppImage, în așteptarea acceptării și aprobării Linux. [Construcție și limitări](packaging/linux/README.md). Fără macOS sau sincronizare în cloud.
- Linux păstrează aspectul și culorile compacte cu un fundal opac întunecat și un pachet Inter; Windows Mica Alt nu este disponibil. Parola Linux criptează seiful. Transferați conturile Windows printr-o parolă criptată `.winotp` backup.
- Mica depinde de versiunea Windows și de politica de transparență. Este încă necesară schimbarea completă a imaginii de fundal și testarea de acceptare pe mai multe scari.
- Manifestul MSIX este un pachet de intrare, nu un pachet semnat, testat de instalare. Inno Setup este formatul de distribuție.
- Notele fiecărei ediții descriu starea de publicare și verificare. O versiune locală pregătită nu este o versiune publicată.

</details>

<details>
<summary><b>Despre și licență</b></summary>

WinOTP este dezvoltat de Vlad ([sailxx](https://github.com/sailxx)). Sursa este disponibilă sub [Licență MIT](LICENSE). Erori și sugestii: [Probleme](https://github.com/sailxx/WinOTP/issues).

</details>
