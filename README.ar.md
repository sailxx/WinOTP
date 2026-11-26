[English](README.md) · **العربية** · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="شعار WinOTP">

# WinOTP

**الرموز الخاصة بك. جهازك. الموثق الخاص بك لـ Windows 11.**

TOTP وHOTP في نافذة داكنة مدمجة ذات ألوان مشتقة من ورق الحائط. البحث عن النسخ الاحتياطية واستيرادها وتشفيرها دون تسجيل أو مزامنة سحابية.

بناه فلاد · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — رموزك، جهازك؛ رسم توضيحي للواجهة">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="تحميل Windows 11"></a>&nbsp;&nbsp;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="ما هو الجديد"></a>

Windows 11 · x64 · الواجهة الإنجليزية

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="الميزات: TOTP وHOTP، قبو محلي، استيراد، بحث، نسخ احتياطي وعدم وجود مزامنة سحابية">

<details>
<summary><b>المزيد عن الميزات</b></summary>

### رموز لمرة واحدة

RFC 6238 TOTP و RFC 4226 HOTP؛ SHA-1/256/512; 6 أو 8 أرقام. إضافة وتعديل وإزالة ونسخ الحسابات والأكواد. البحث والمفضلة يبقي الإدخال الصحيح في متناول اليد.

### أحضروا حساباتكم

استيراد URIs otpauth، وURIs لترحيل Google Authenticator، وصور QR، وAegis JSON. قم بمعاينة الإدخالات قبل حفظها وتخطي الحسابات الموجودة.

### النسخ الاحتياطية المشفرة

محمول `.winotp` تستخدم الملفات كلمة مرور منفصلة. احتفظ بكلمة المرور هذه بشكل منفصل وتحقق من الاستعادة قبل حذف البيانات المصدر.

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="عناصر التحكم: إضافة وإخفاء الرموز والبحث والاستيراد والنسخ الاحتياطي والإعدادات">

<details>
<summary><b>الضوابط ولقطة شاشة التطبيق</b></summary>

| يتحكم | فعل |
| --- | --- |
| **يضيف** | إنشاء حساب |
| **إخفاء الرموز / إظهار الرموز** | إخفاء أو كشف الرموز |
| **حسابات البحث** | ابحث عن خدمة أو حساب |
| **جير → استيراد** | استيراد الحسابات مع المعاينة |
| **جير → النسخ الاحتياطي** | إنشاء نسخة احتياطية مشفرة |
| **الترس → الإعدادات** | تكوين قفل الواجهة ومهلة الحافظة؛ الإصدار في الأسفل |

قم بتمرير قائمة الحسابات باستخدام عجلة الماوس أو الإيماءات؛ شريط التمرير مخفي. تستخدم الواجهة المظلمة بشكل دائم Mica Alt الأصلي مع الألوان المشتقة من ورق الحائط عندما تسمح بذلك إعدادات Windows.

لقطة شاشة لخزنة اختبار معزولة تحتوي على بيانات نموذجية عامة:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="النافذة الرئيسية لـ WinOTP مع حساب تجريبي">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="حماية البيانات: Windows DPAPI، AES -256- GCM، قفل الواجهة وحدود الحافظة">

<details>
<summary><b>حماية البيانات وحدودها</b></summary>

Windows DPAPI يحمي القبو لمستخدم Windows الحالي. تستخدم النسخ الاحتياطية المحمولة AES -256- GCM وPBKDF2 - SHA256 مع 600000 تكرار. كلمة المرور الرئيسية تقفل **واجهة**, عدم الوصول عن طريق البرامج الضارة التي تعمل كمستخدم Windows الخاص بك. لا يمكن لمسح الحافظة مسح سجل الحافظة أو النسخ التي تم التقاطها بواسطة تطبيقات أخرى.

البيانات تعيش في `%LOCALAPPDATA%\WinOTP`. تقوم عملية الترحيل بنسخ الملفات القديمة من `%LOCALAPPDATA%\NoirAuth` دون إزالة النسخ الأصلية. احتفظ بها حتى تتحقق من المخزن الذي تم ترحيله والنسخة الاحتياطية القابلة للاستعادة. يرى [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="حالة المشروع: WinUI 3 المضغوط، وسير عمل الحساب، وورق الحائط المتبقي، وفحوصات القياس والتعبئة">

<details>
<summary><b>التثبيت والتحديث</b></summary>

1. يفتح [الإصدارات](https://github.com/sailxx/WinOTP/releases) وقراءة ملاحظات الإصدار المحدد.
2. بالنسبة للإصدارات التي تحمل الاسم الجديد، قم بالتنزيل `WinOTP-Setup.exe`.
3. قم بتشغيل برنامج الإعداد واختر مجلدًا. ليست هناك حاجة إلى حقوق المسؤول.

يتم تخزين البيانات بشكل منفصل والاحتفاظ بها عند إلغاء التثبيت. قم بإنشاء نسخة احتياطية قبل التحديث. تستخدم واجهة التطبيق والمثبت اللغة الإنجليزية.

المثبت غير موقع برمز Windows؛ قد يحذر SmartScreen. تحقق من المصدر والمجموع الاختباري قبل أن تقرر تشغيله.

</details>

<details>
<summary><b>التحقق من التنزيل الخاص بك</b></summary>

قم بتنزيل برنامج التثبيت وتشغيله:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

قارن التجزئة بقيمة SHA -256 بجوار المثبت في قائمة أصول إصدار GitHub. المصدر ليس توقيع رمز Windows أو ضمانًا لرمز خالٍ من الثغرات الأمنية. قد لا تتضمن الإصدارات الأقدم الشهادات.

</details>

<details>
<summary><b>البناء من المصدر</b></summary>

يتطلب Windows . أدوات البناء NET SDK 10 وWinUI. استبدل المسار في الأمر الأول بمجلد المشروع الخاص بك.

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

الافراج عن البوابات والتعليمات: [RELEASE.md](RELEASE.md). التغييرات: [CHANGELOG.md](CHANGELOG.md). قم بإنشاء اللوحات الرسومية باستخدام `python tools/generate_readme.py` من جذر المشروع

</details>

<details>
<summary><b>القيود المعروفة</b></summary>

- تم إعداد واجهة Avalonia Linux الأمامية ووصفات x64 deb وrpm وAppImage، في انتظار قبول Linux والموافقة عليه. [البناء والقيود](packaging/linux/README.md). لا يوجد macOS أو مزامنة سحابية.
- تحافظ Linux على التصميم المدمج والألوان مع خلفية داكنة غير شفافة وInter المجمعة؛ Windows Mica Alt غير متوفر. تقوم كلمة المرور Linux بتشفير المخزن. نقل حسابات Windows من خلال كلمة مرور مشفرة `.winotp` نسخة احتياطية.
- تعتمد Mica على إصدار Windows وسياسة الشفافية. ولا تزال هناك حاجة إلى تغيير ورق الحائط بالكامل واختبار القبول متعدد النطاقات.
- بيان MSIX عبارة عن إدخال تعبئة، وليس حزمة موقعة تم اختبارها أثناء التثبيت. Inno Setup هو تنسيق التوزيع.
- تصف ملاحظات كل إصدار حالة النشر والتحقق. النسخة المحلية المعدة ليست إصدارًا منشورًا.

</details>

<details>
<summary><b>حول والترخيص</b></summary>

تم تطويرها من قبل فلاد WinOTP ([sailxx](https://github.com/sailxx)). المصدر متاح تحت [رخصة MIT](LICENSE). الأخطاء والاقتراحات: [مشاكل](https://github.com/sailxx/WinOTP/issues).

</details>
