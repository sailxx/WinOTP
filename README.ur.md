[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · **اردو** · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="WinOTP لوگو">

# WinOTP

**آپ کے کوڈز۔ آپ کا آلہ۔ Windows 11 کے لیے آپ کا تصدیق کنندہ۔**

TOTP اور HOTP وال پیپر سے اخذ کردہ رنگ کے ساتھ ایک کمپیکٹ ڈارک ونڈو میں۔ رجسٹریشن یا کلاؤڈ سنک کے بغیر تلاش، درآمد اور خفیہ کردہ بیک اپ۔

ولاد نے بنایا · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — آپ کے کوڈز، آپ کا آلہ؛ ایک انٹرفیس کی مثال">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="Windows 11 کے لیے ڈاؤن لوڈ کریں۔"></a>&nbsp; &nbsp;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="نیا کیا ہے۔"></a>

Windows 11 · x64 · انگریزی انٹرفیس

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="خصوصیات: TOTP اور HOTP، مقامی والٹ، درآمد، تلاش، بیک اپ اور کوئی کلاؤڈ مطابقت پذیری نہیں">

<details>
<summary><b>خصوصیات کے بارے میں مزید</b></summary>

### ایک بار کے کوڈز

RFC 6238 TOTP اور RFC 4226 HOTP ; SHA -1/256/512; 6 یا 8 ہندسے۔ اکاؤنٹس اور کوڈز کو شامل کریں، ان میں ترمیم کریں، ہٹائیں اور کاپی کریں۔ تلاش اور پسندیدہ صحیح اندراج کو پہنچ کے اندر رکھتے ہیں۔

### اپنے اکاؤنٹس لائیں۔

otpauth URIs، Google Authenticator migration URIs، QR امیجز اور Aegis JSON درآمد کریں۔ محفوظ کرنے سے پہلے اندراجات کا جائزہ لیں اور موجودہ اکاؤنٹس کو چھوڑ دیں۔

### خفیہ کردہ بیک اپ

پورٹیبل `.winotp` فائلیں الگ پاس ورڈ استعمال کرتی ہیں۔ اس پاس ورڈ کو الگ سے رکھیں اور سورس ڈیٹا کو حذف کرنے سے پہلے بحالی کی تصدیق کریں۔

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="کنٹرولز: شامل کریں، کوڈز چھپائیں، تلاش کریں، درآمد کریں، بیک اپ اور ترتیبات">

<details>
<summary><b>کنٹرولز اور ایپلیکیشن اسکرین شاٹ</b></summary>

| کنٹرول | ایکشن |
| --- | --- |
| **شامل کریں۔** | ایک اکاؤنٹ بنائیں |
| **کوڈز چھپائیں / کوڈ دکھائیں۔** | کوڈز کو چھپائیں یا ظاہر کریں۔ |
| **اکاؤنٹس تلاش کریں۔** | ایک سروس یا اکاؤنٹ تلاش کریں۔ |
| **گیئر → درآمد کریں۔** | پیش نظارہ کے ساتھ اکاؤنٹس درآمد کریں۔ |
| **گیئر → بیک اپ** | ایک انکرپٹڈ بیک اپ بنائیں |
| **گیئر → سیٹنگز** | انٹرفیس لاک اور کلپ بورڈ ٹائم آؤٹ کو ترتیب دیں؛ ورژن نیچے ہے |

اکاؤنٹ کی فہرست کو ماؤس وہیل یا اشاروں سے اسکرول کریں۔ اسکرول بار چھپا ہوا ہے۔ Windows ترتیبات کی طرف سے اجازت ہونے پر مستقل طور پر سیاہ انٹرفیس وال پیپر سے اخذ کردہ رنگ کے ساتھ مقامی Mica Alt کا استعمال کرتا ہے۔

عوامی مثال کے ڈیٹا کے ساتھ الگ تھلگ ٹیسٹ والٹ کا اسکرین شاٹ:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="ٹیسٹ اکاؤنٹ کے ساتھ WinOTP مین ونڈو">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="ڈیٹا تحفظ: Windows DPAPI، AES -256- GCM، انٹرفیس لاک اور کلپ بورڈ کی حدود">

<details>
<summary><b>ڈیٹا کی حفاظت اور اس کی حدود</b></summary>

Windows DPAPI موجودہ Windows صارف کے والٹ کی حفاظت کرتا ہے۔ پورٹیبل بیک اپ AES -256- GCM اور PBKDF2 - SHA256 600,000 تکرار کے ساتھ استعمال کرتے ہیں۔ ماسٹر پاس ورڈ لاک کر دیتا ہے۔ **انٹرفیس**, آپ کے Windows صارف کے طور پر چلنے والے میلویئر کے ذریعے رسائی حاصل نہ کریں۔ کلپ بورڈ کلیئرنگ کلپ بورڈ کی سرگزشت یا دیگر ایپس کے ذریعے کیپچر کی گئی کاپیوں کو نہیں مٹا سکتی ہے۔

ڈیٹا رہتا ہے۔ `%LOCALAPPDATA%\WinOTP`. منتقلی سے میراثی فائلیں کاپی کرتی ہیں۔ `%LOCALAPPDATA%\NoirAuth` اصل کو ہٹائے بغیر۔ انہیں اس وقت تک رکھیں جب تک کہ آپ منتقل شدہ والٹ اور ایک قابل بحالی بیک اپ کی تصدیق نہ کر لیں۔ دیکھیں [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="پروجیکٹ کی حیثیت: کومپیکٹ WinUI 3، اکاؤنٹ ورک فلوز اور باقی وال پیپر، اسکیلنگ اور پیکیجنگ چیک">

<details>
<summary><b>انسٹال اور اپ ڈیٹ کریں۔</b></summary>

1. کھولیں۔ [جاری کرتا ہے۔](https://github.com/sailxx/WinOTP/releases) اور منتخب ورژن کے نوٹس پڑھیں۔
2. نئے نام والی ریلیز کے لیے، ڈاؤن لوڈ کریں۔ `WinOTP-Setup.exe`.
3. سیٹ اپ چلائیں اور ایک فولڈر منتخب کریں۔ منتظم کے حقوق کی ضرورت نہیں ہے۔

ڈیٹا کو الگ سے ذخیرہ کیا جاتا ہے اور ان انسٹال کرتے وقت برقرار رکھا جاتا ہے۔ اپ ڈیٹ کرنے سے پہلے بیک اپ بنائیں۔ ایپلیکیشن انٹرفیس اور انسٹالر انگریزی استعمال کرتے ہیں۔

انسٹالر Windows کوڈ پر دستخط شدہ نہیں ہے۔ اسمارٹ اسکرین خبردار کر سکتی ہے۔ اسے چلانے کا فیصلہ کرنے سے پہلے ذریعہ اور چیکسم کو چیک کریں۔

</details>

<details>
<summary><b>اپنے ڈاؤن لوڈ کی تصدیق کریں۔</b></summary>

انسٹالر ڈاؤن لوڈ کریں اور چلائیں۔:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

GitHub ریلیز اثاثہ کی فہرست میں انسٹالر کے آگے SHA -256 ویلیو کے ساتھ ہیش کا موازنہ کریں۔ Provenance Windows کوڈ پر دستخط یا خطرے سے پاک کوڈ کی ضمانت نہیں ہے۔ پرانی ریلیز میں تصدیق شامل نہیں ہوسکتی ہے۔

</details>

<details>
<summary><b>ماخذ سے بنائیں</b></summary>

Windows کی ضرورت ہے، . NET SDK 10 اور WinUI تعمیراتی ٹولز۔ پہلی کمانڈ میں راستے کو اپنے پروجیکٹ فولڈر سے تبدیل کریں۔

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

رہائی کے دروازے اور ہدایات: [RELEASE.md](RELEASE.md). تبدیلیاں: [CHANGELOG.md](CHANGELOG.md). کے ساتھ گرافک پینل بنائیں `python tools/generate_readme.py` منصوبے کی جڑ سے.

</details>

<details>
<summary><b>معلوم حدود</b></summary>

- Avalonia Linux فرنٹ اینڈ اور x64 deb، rpm اور AppImage کی ترکیبیں تیار ہیں، Linux کی منظوری اور منظوری باقی ہے۔ [تعمیر اور حدود](packaging/linux/README.md). کوئی macOS یا کلاؤڈ مطابقت پذیری نہیں۔
- Linux کومپیکٹ لے آؤٹ اور رنگوں کو ایک مبہم گہرے پس منظر اور بنڈل انٹر کے ساتھ رکھتا ہے۔ Windows Mica Alt دستیاب نہیں ہے۔ Linux پاس ورڈ والٹ کو خفیہ کرتا ہے۔ Windows اکاؤنٹس کو پاس ورڈ انکرپٹڈ کے ذریعے منتقل کریں۔ `.winotp` بیک اپ
- Mica Windows ورژن اور شفافیت کی پالیسی پر منحصر ہے۔ مکمل وال پیپر کی تبدیلی اور کثیر پیمانے پر قبولیت کی جانچ کی ضرورت ہے۔
- MSIX مینی فیسٹ ایک پیکیجنگ ان پٹ ہے، نہ کہ دستخط شدہ، انسٹالیشن ٹیسٹ شدہ پیکیج۔ Inno سیٹ اپ تقسیم کی شکل ہے۔
- ہر ریلیز کے نوٹس اس کی اشاعت اور تصدیق کی حیثیت کو بیان کرتے ہیں۔ ایک تیار شدہ مقامی ورژن شائع شدہ ریلیز نہیں ہے۔

</details>

<details>
<summary><b>کے بارے میں اور لائسنس</b></summary>

WinOTP ولاد نے تیار کیا ہے۔ ([sailxx](https://github.com/sailxx)). ماخذ کے تحت دستیاب ہے۔ [MIT لائسنس](LICENSE). کیڑے اور تجاویز: [مسائل](https://github.com/sailxx/WinOTP/issues).

</details>
