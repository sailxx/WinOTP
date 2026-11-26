[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · **ئۇيغۇرچە** · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="WinOTP بەلگىسى">

# WinOTP

**كودىڭىز. ئۈسكۈنىڭىز. Windows 11 ئۈچۈن دەلىللىگۈچىڭىز.**

تام قەغىزىدىن ياسالغان ئىخچام قاراڭغۇ كۆزنەكتە TOTP ۋە HOTP. تىزىملاش ياكى بۇلۇت ماسقەدەملىمەي زاپاسلاش ، ئىزدەش ۋە مەخپىيلەشتۈرۈش.

Vlad تەرىپىدىن ياسالغان · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP - كودلىرىڭىز ، ئۈسكۈنىڭىز كۆرۈنمە يۈزى">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="Windows 11 نى چۈشۈرۈڭ"></a>&nbsp; & nbsp;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="نېمە يېڭىلىق"></a>

Windows 11 · x64 · ئىنگلىزچە كۆرۈنمە يۈزى

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="ئالاھىدىلىكى: TOTP ۋە HOTP ، يەرلىك ئامبار ، ئىمپورت ، ئىزدەش ، زاپاسلاش ۋە بۇلۇت ماسقەدەملەش يوق">

<details>
<summary><b>ئىقتىدارلىرى ھەققىدە تېخىمۇ كۆپ</b></summary>

### بىر قېتىملىق كودلار

RFC 6238 TOTP ۋە RFC 4226 HOTP; SHA -1/256/512; 6 ياكى 8 خانىلىق سان. ھېسابات ۋە كودلارنى قوشۇش ، تەھرىرلەش ، ئۆچۈرۈش ۋە كۆپەيتىش. ئىزدەش ۋە ياقتۇرىدىغانلار توغرا كىرگۈزۈشنى ساقلاپ قالالايدۇ.

### ھېساباتىڭىزنى ئېلىپ كېلىڭ

Otpauth URI ، Google Authenticator كۆچۈش URI ، QR رەسىم ۋە Aegis JSON نى ئىمپورت قىلىڭ. مەۋجۇت ھېساباتلارنى ساقلاش ۋە ئاتلاشتىن بۇرۇن تۈرلەرنى ئالدىن كۆرۈڭ.

### شىفىرلانغان زاپاسلاش

ئېلىپ يۈرۈشكە ئەپلىك `.winotp` ھۆججەتلەر ئايرىم پارول ئىشلىتىدۇ. بۇ پارولنى ئايرىم ساقلاڭ ھەمدە ئەسلى سانلىق مەلۇماتنى ئۆچۈرۈشتىن بۇرۇن ئەسلىگە كەلتۈرۈشنى تەكشۈرۈپ بېقىڭ.

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="كونتروللار: كودلارنى قوشۇش ، يوشۇرۇش ، ئىزدەش ، ئەكىرىش ، زاپاسلاش ۋە تەڭشەكلەر">

<details>
<summary><b>كونترول ۋە قوللىنىشچان ئېكران رەسىمى</b></summary>

| كونترول | ھەرىكەت |
| --- | --- |
| **قوش** | ھېسابات قۇر |
| **كودلارنى يوشۇرۇش / كودلارنى كۆرسىتىش** | كودلارنى يوشۇرۇش ياكى ئاشكارىلاش |
| **ھېسابات ئىزدەش** | مۇلازىمەت ياكى ھېسابات تېپىڭ |
| **Gear → Import** | ئالدىن كۆرۈش ئارقىلىق ھېسابات ئەكىرىڭ |
| **Gear → زاپاسلاش** | شىفىرلانغان زاپاسلاش قۇر |
| **Gear → تەڭشەك** | كۆرۈنمە يۈزى قۇلۇپ ۋە چاپلاش ۋاقتىنى تەڭشەش; نەشرى تۆۋەندە |

مائۇس چاقى ياكى قول ئىشارىتى بىلەن ھېسابات تىزىملىكىنى ئۆرۈڭ. سۈرگۈچ بالداق يوشۇرۇنغان. مەڭگۈلۈك قاراڭغۇ كۆرۈنمە يۈزى Windows تەڭشىكىدە رۇخسەت قىلىنغاندا تام قەغىزىدىن ھاسىل بولغان Mica Alt نى ئىشلىتىدۇ.

ئاممىۋى ئۈلگە سانلىق مەلۇماتلىرى بىلەن يەككە سىناق ئامبىرىنىڭ ئېكران رەسىمى:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="سىناق ھېساباتى بار WinOTP ئاساسلىق كۆزنەك">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="سانلىق مەلۇمات قوغداش: Windows DPAPI ، AES -256- GCM ، كۆرۈنمە يۈزى قۇلۇپ ۋە چاپلاش تاختىسى">

<details>
<summary><b>سانلىق مەلۇمات قوغداش ۋە ئۇنىڭ چېكى</b></summary>

Windows DPAPI نۆۋەتتىكى Windows ئىشلەتكۈچىنىڭ ئامبىرىنى قوغدايدۇ. ئېلىپ يۈرۈشكە ئەپلىك زاپاسلاش AES -256- GCM ۋە PBKDF2 - SHA256 نى 600،000 تەكرارلايدۇ. ئاساسىي پارول قۇلۇپلىنىدۇ **interface**, Windows ئىشلەتكۈچى سۈپىتىدە ئىجرا قىلىنىدىغان يامان غەرەزلىك يۇمشاق دېتاللارنى زىيارەت قىلالمايدۇ. چاپلاش تاختىسىنى تازىلاش قىستۇرما تارىخىنى ياكى باشقا ئەپلەر تارتقان كۆپەيتمىلەرنى ئۆچۈرەلمەيدۇ.

سانلىق مەلۇمات ياشايدۇ `%LOCALAPPDATA%\WinOTP`. كۆچۈش مىراس ھۆججىتىدىن كۆچۈرۈلگەن `%LOCALAPPDATA%\NoirAuth` ئەسلى نۇسخىسىنى ئۆچۈرمەي تۇرۇپ. كۆچۈرۈلگەن ئامبار ۋە ئەسلىگە كەلتۈرگىلى بولىدىغان زاپاسلاشنى دەلىللىگۈچە ساقلاپ قويۇڭ. قاراڭ [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="تۈر ھالىتى: ئىخچام WinUI 3 ، ھېسابات خىزمەت ئېقىمى ۋە قالغان تام قەغىزى ، كۆلەملەشتۈرۈش ۋە ئوراش تەكشۈرۈشى">

<details>
<summary><b>قاچىلاش ۋە يېڭىلاش</b></summary>

1. ئېچىڭ [تارقىتىلدى](https://github.com/sailxx/WinOTP/releases) ھەمدە تاللانغان نۇسخىسىنىڭ خاتىرىسىنى ئوقۇڭ.
2. يېڭى ئىسىم قويۇلغان ئېلانلار ئۈچۈن چۈشۈرۈڭ `WinOTP-Setup.exe`.
3. تەڭشەشنى ئىجرا قىلىپ قىسقۇچ تاللاڭ. باشقۇرغۇچى ھوقۇقى تەلەپ قىلىنمايدۇ.

ئۆچۈرگەندە سانلىق مەلۇماتلار ئايرىم ساقلىنىدۇ ۋە ساقلىنىدۇ. يېڭىلاشتىن بۇرۇن زاپاسلاش قۇر. قوللىنىشچان كۆرۈنمە يۈزى ۋە ئورناتقۇچى ئىنگلىزچە ئىشلىتىدۇ.

قاچىلىغۇچ Windows كود ئىمزالىمىغان. SmartScreen ئاگاھلاندۇرۇشى مۇمكىن. ئىجرا قىلىش-قىلماسلىقنى قارار قىلىشتىن بۇرۇن مەنبە ۋە تەكشۈرۈشنى تەكشۈرۈڭ.

</details>

<details>
<summary><b>چۈشۈرگەنلىكىڭىزنى تەكشۈرۈپ بېقىڭ</b></summary>

قاچىلاش پروگراممىسىنى چۈشۈرۈپ ئىجرا قىلىڭ:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

ھەش-پەش دېگۈچە SHA -256 قىممىتى بىلەن GitHub قويۇپ بېرىش مۈلۈك تىزىملىكىدىكى قاچىلاش پروگراممىسىنىڭ يېنىدىكى قىممەتنى سېلىشتۇرۇڭ. ئىسپاتلاش Windows كود ئىمزالاش ياكى يوچۇقسىز كودنىڭ كاپالىتى ئەمەس. كونا نەشر بۇيۇملىرى گۇۋاھنامىنى ئۆز ئىچىگە ئالمايدۇ.

</details>

<details>
<summary><b>مەنبەدىن قۇرۇش</b></summary>

Windows نى تەلەپ قىلىدۇ. NET SDK 10 ۋە WinUI قۇراشتۇرۇش قوراللىرى. بىرىنچى بۇيرۇقتىكى يولنى تۈر قىسقۇچىڭىز بىلەن ئالماشتۇرۇڭ.

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

دەرۋازا ۋە كۆرسەتمىلەرنى قويۇپ بېرىڭ: [RELEASE.md](RELEASE.md). ئۆزگەرتىش: [CHANGELOG.md](CHANGELOG.md). بىلەن گرافىك تاختىسىنى ھاسىل قىلىڭ `python tools/generate_readme.py` تۈر يىلتىزىدىن.

</details>

<details>
<summary><b>مەلۇم چەكلىمىلەر</b></summary>

- Avalonia Linux ئالدى ۋە x64 deb ، rpm ۋە AppImage رېتسېپلىرى تەييارلانغان بولۇپ ، Linux نىڭ قوبۇل قىلىنىشى ۋە تەستىقلىنىشىنى ساقلاۋاتىدۇ. [قۇرۇش ۋە چەكلەش](packaging/linux/README.md). macOS ياكى بۇلۇت ماسقەدەملەش يوق.
- Linux ئىخچام ئورۇنلاشتۇرۇش ۋە رەڭلەرنى ئوچۇق قاراڭغۇ تەگلىك ۋە باغلانغان Inter بىلەن ساقلايدۇ. Windows Mica Alt نى ئىشلەتكىلى بولمايدۇ. Linux پارولى ئامبارنى مەخپىيلەشتۈردى. پارول شىفىرلانغان Windows ھېساباتىنى يۆتكەڭ `.winotp` زاپاسلاش.
- مىكا Windows نەشرى ۋە سۈزۈكلۈك سىياسىتىگە باغلىق. تولۇق تام قەغەز ئۆزگەرتىش ۋە كۆپ خىل قوبۇل قىلىش سىنىقى يەنىلا لازىم.
- MSIX ئىپادىسى ئورالما كىرگۈزۈش بولۇپ ، ئىمزا قويۇلغان ، قاچىلاش سىنىقى ئەمەس. Inno Setup بولسا تارقىتىش شەكلى.
- ھەر بىر تارقىتىلىش خاتىرىسىدە ئۇنىڭ ئېلان قىلىنىش ۋە دەلىللەش ئەھۋالى بايان قىلىنغان. تەييارلانغان يەرلىك نەشرى ئېلان قىلىنغان نەشرى ئەمەس.

</details>

<details>
<summary><b>ئىجازەتنامە</b></summary>

WinOTP Vlad تەرىپىدىن ياسالغان ([sailxx](https://github.com/sailxx)). مەنبە ئاستىدا [MIT ئىجازەتنامىسى](LICENSE). خاتالىق ۋە تەكلىپ: [مەسىلىلەر](https://github.com/sailxx/WinOTP/issues).

</details>
