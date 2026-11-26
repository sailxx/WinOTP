[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · **Gaeilge** · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="WinOTP lógó">

# WinOTP

**Do chóid. Do ghléas. D'fhíordheimhnitheoir le haghaidh Windows 11.**

TOTP agus HOTP i bhfuinneog dhlúth dorcha le dath ballapháipéir-díorthaithe. Cuardaigh, iompórtáil agus cúltacaí criptithe gan chlárú nó sioncronú scamall.

Tógtha ag Vlad · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — do chóid, do ghléas; léaráid comhéadan">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="Íoslódáil do Windows 11"></a>&nbsp; &nbsp;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="Cad atá nua"></a>

Windows 11 · x64 · comhéadan Béarla

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="Gnéithe: TOTP agus HOTP , cruinneachán áitiúil, allmhairiú, cuardach, cúltacaí agus gan sioncronú scamall">

<details>
<summary><b>Tuilleadh faoi na gnéithe</b></summary>

### Cóid aonuaire

RFC 6238 TOTP agus RFC 4226 HOTP; SHA -1/256/512; 6 nó 8 ndigit. Cuntais agus cóid a chur leis, a chur in eagar, a bhaint agus a chóipeáil. Coinníonn cuardaigh agus ceanáin an iontráil cheart laistigh de rochtain.

### Beir leat do chuntais

Iompórtáil URIanna otpauth, URIs imirce Google Authenticator, íomhánna QR agus Aegis JSON . Réamhamhairc ar iontrálacha roimh shábháil agus scipeáil cuntais reatha.

### Cúltacaí criptithe

Inaistrithe `.winotp` úsáideann comhaid pasfhocal ar leith. Coinnigh an pasfhocal sin ar leithligh agus fíoraigh an t-athchóiriú sula scriostar na sonraí foinseacha.

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="Rialuithe: Cuir leis, Folaigh cóid, Cuardach, Iompórtáil, Cúltaca agus Socruithe">

<details>
<summary><b>Rialuithe agus screenshot feidhmchlár</b></summary>

| Rialú | Gníomh |
| --- | --- |
| **Cuir** | Cruthaigh cuntas |
| **Folaigh cóid / Taispeáin cóid** | Cóid a cheilt nó a nochtadh |
| **Cuardach cuntais** | Aimsigh seirbhís nó cuntas |
| **Fearas → Iompórtáil** | Iompórtáil cuntais le réamhamharc |
| **Fearas → Cúltaca** | Cruthaigh cúltaca criptithe |
| **Fearas → Socruithe** | Cumraigh glas comhéadan agus teorainn ama gearrthaisce; Tá an leagan ag bun an leathanaigh |

Scrollaigh liosta na gcuntas leis an roth luiche nó le gothaí; tá an scrollbharra i bhfolach. Úsáideann an comhéadan buan-dorcha Mica Alt dúchais le dath ballapháipéir nuair a cheadaítear é ag socruithe Windows.

Gabháil scáileáin de cruinneachán tástála scoite le sonraí poiblí mar shampla:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="WinOTP príomhfhuinneog le cuntas tástála">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="Cosaint sonraí: Windows DPAPI , AES -256- GCM , glas comhéadan agus teorainneacha gearrthaisce">

<details>
<summary><b>Cosaint sonraí agus a teorainneacha</b></summary>

Cosnaíonn Windows DPAPI an cruinneachán don úsáideoir Windows reatha. Úsáideann cúltacaí iniompartha AES -256- GCM agus PBKDF2 - SHA256 le 600,000 atriall. Glasálann an máistir phasfhocal an **comhéadan**, gan rochtain ag malware a rith mar d'úsáideoir Windows. Ní féidir le glanadh gearrthaisce stair na gearrthaisce nó cóipeanna arna ngabháil ag aipeanna eile a scriosadh.

Cónaíonn sonraí i `%LOCALAPPDATA%\WinOTP`. Déanann imirce cóipeanna de chomhaid oidhreachta ó `%LOCALAPPDATA%\NoirAuth` gan na bunleaganacha a bhaint. Coinnigh iad go dtí go bhfuil an cruinneachán aistrithe agus cúltaca in-athchóirithe fíoraithe agat. Féach [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="Stádas an tionscadail: WinUI 3 dlúth, sreabhadh oibre cuntais agus páipéar balla atá fágtha, seiceálacha scálaithe agus pacáistithe">

<details>
<summary><b>Suiteáil agus nuashonrú</b></summary>

1. Oscail [Scaoileadh](https://github.com/sailxx/WinOTP/releases) agus léigh nótaí an leagain roghnaithe.
2. Le haghaidh eisiúintí leis an ainm nua saor in aisce, íoslódáil `WinOTP-Setup.exe`.
3. Rith Socrú agus roghnaigh fillteán. Níl aon chearta riarthóra ag teastáil.

Stóráiltear sonraí ar leithligh agus coinnítear iad nuair a bhíonn siad á ndíshuiteáil. Cruthaigh cúltaca roimh nuashonrú. Úsáideann comhéadan an fheidhmchláir agus an suiteálaí Béarla.

Níl an suiteálaí sínithe le cód Windows; Féadfaidh SmartScreen rabhadh a thabhairt. Seiceáil an fhoinse agus an seiceála sula gcinneann tú ar cheart é a rith.

</details>

<details>
<summary><b>Fíoraigh do íoslódáil</b></summary>

Íoslódáil an suiteálaí agus rith:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

Déan comparáid idir an hash leis an luach SHA -256 in aice leis an suiteálaí sa liosta sócmhainní scaoileadh GitHub. Ní síniú cód Windows nó ráthaíocht cód saor ó leochaileacht é an foinse. Ní fhéadfaidh fianuithe a bheith i gceist le heisiúintí níos sine.

</details>

<details>
<summary><b>Tógáil ón bhfoinse</b></summary>

Éilíonn Windows , . Uirlisí tógála NET SDK 10 agus WinUI. Cuir d'fhillteán tionscadail in ionad an chonair sa chéad ordú.

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

Geataí scaoileadh agus treoracha: [RELEASE.md](RELEASE.md). Athruithe: [CHANGELOG.md](CHANGELOG.md). Gin na painéil ghrafacha le `python tools/generate_readme.py` ó fhréamh an tionscadail.

</details>

<details>
<summary><b>Teorainneacha aitheanta</b></summary>

- Ullmhaítear éadan Avalonia Linux agus x64 deb, rpm agus oidis AppImage, ar feitheamh glactha agus formheasa Linux. [Tógáil agus teorainneacha](packaging/linux/README.md). Níl macOS nó sioncrónú scamall ann.
- Coinníonn Linux an leagan amach dlúth agus na dathanna le cúlra dorcha teimhneach agus Inter cuachta; Níl Windows Mica Alt ar fáil. Criptíonn pasfhocal Linux an cruinneachán. Aistrigh cuntais Windows trí phasfhocal criptithe `.winotp` cúltaca.
- Braitheann Mica ar leagan Windows agus ar bheartas trédhearcachta. Tá gá fós le hathrú iomlán ballapháipéir agus tástáil glactha ilscála.
- Is ionchur pacáistithe é an forléiriú MSIX, ní pacáiste sínithe, arna thástáil le suiteáil. Is é Inno Setup an fhormáid dáileacháin.
- Déanann nótaí gach eisiúna cur síos ar a stádas foilsithe agus fíoraithe. Ní eisiúint foilsithe é leagan ullmhaithe áitiúil.

</details>

<details>
<summary><b>Maidir agus ceadúnas</b></summary>

Tá WinOTP forbartha ag Vlad ([sailxx](https://github.com/sailxx)). Tá foinse ar fáil faoin [MIT ceadúnas](LICENSE). Bugs agus moltaí: [Saincheisteanna](https://github.com/sailxx/WinOTP/issues).

</details>
