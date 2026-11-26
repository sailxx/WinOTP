[English](README.md) · **العربية** · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# بناء Linux والموافقة عليه

يستهدف x86_64 Linux، في البداية Ubuntu 24.04 و Fedora مع . NET 10 تبعيات أصلية. الواجهة الأمامية هي Avalonia؛ تطبيق Windows WinUI لم يتغير. يستخدم Linux نفس التصميم المدمج، واللكنات السماوية والسطح الداكن الملون قليلاً بلكنة النظام (احتياطي محايد عند عدم توفره): Windows Mica Alt وSegoe UI Variable غير محمولين. تم تجميع الإنتر؛ يتم إعادة توزيع أي خط Microsoft.

تعمل كلمة المرور الرئيسية Linux على تشفير المخزن باستخدام AES -256- GCM وPBKDF2 - SHA256 (600000 تكرار). إنه مطلوب عند بدء التشغيل ولا يمكن استعادته. بيانات: `$XDG_DATA_HOME/WinOTP` أو `~/.local/share/WinOTP`. دليل Vault هو 0700 وملفات Vault التي تم إنشاؤها حديثًا هي 0600. عمليات الكتابة ذرية ومقفلة على الكاتب وترفض المراجعات القديمة. لا يتم تخزين أي أسرار في التفضيلات. يدعم المخزن ما يصل إلى 500 حساب و14 ميجابايت من البيانات المتسلسلة (وبالتالي فإن النسخة الاحتياطية Base64 الخاصة به تتناسب مع حد الاستيراد البالغ 20 ميجابايت)؛ يتم رفض عمليات الحفظ كبيرة الحجم قبل الاستبدال. لا تقم مطلقًا بنسخ ملفات Windows DPAPI إلى Linux: قم بتصدير ملف مشفر بكلمة مرور `.winotp` النسخ الاحتياطي على Windows واستيراده على Linux. احتفظ بالمصدر حتى يتم التحقق من الاستعادة.

## التنمية المحلية

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

للحصول على معاينة معزولة باستخدام بيانات اعتماد RFC العامة فقط:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## الحزم

`.github/workflows/linux.yml` تثبيت تبعيات الحزمة، والتحقق من ملخص appimagetool المثبت، وإنشاء deb/rpm/ AppImage، وتثبيت deb وبدء تشغيله ضمن Xvfb، وبدء تشغيل AppImage بدون FUSE، وتحميل الحزم بالإضافة إلى لقطات الشاشة كـ `linux-packages`. يتم تشغيله على العلاقات العامة ويمكن تشغيله يدويًا؛ لا ينشر بيانا. `packaging/linux/build.sh` يعمل أيضًا محليًا على مضيف x86_64 Linux مع . NET 10، fpm 1.16.0، أدوات rpm وsquashfs؛ إمداد `APPIMAGETOOL` يشير إلى الملف القابل للتنفيذ 1.9.1 x86_64 الذي تم التحقق منه. يبقى كل المحتوى الذي تم إنشاؤه تحت `artifacts/linux`.

ينتظر سير عمل العلامة إنشاء Linux وWindows، ثم يقوم بتحضير ملف **مسودة** قم بالإصدار باستخدام برنامج التثبيت وجميع حزم Linux الثلاث. يعرض GitHub ملخص SHA -256 لأصول الإصدار. قم بمراجعة لقطات شاشة Linux الحقيقية واحصل على موافقة فلاد قبل النشر. لا يعد إنشاء العلامات أو دفع التغييرات جزءًا من الإعداد المحلي.

## القبول لا يزال مطلوبا

تثبيت/إزالة/ترقية deb على Ubuntu وrpm على Fedora؛ اختبر AppImage على كليهما (FUSE أو `--appimage-extract-and-run`). تحقق من سطح المكتب X11 / Wayland الفعلي، والقياس، ومهلة الحافظة، ومنتقي الملفات، واستيراد QR، وقفل كلمة المرور، واستعادة النسخ الاحتياطي Windows، واستمرار HOTP. لا تتم تغطية تثبيت RPM وسلوك مؤلف سطح المكتب بواسطة مهمة Ubuntu CI. لم يتم تنفيذ أي تكامل لدرج Linux أو استيراد صورة الحافظة QR حتى الآن. يتوفر استيراد ملف QR واستيراد URI.

`assets/screenshots/linux-ui-preview.png` هو عرض حقيقي للواجهة الأمامية Avalonia المستضافة على Windows، وليس دليلاً على اختبار وقت تشغيل Linux. لم يتم إصدار أية حزم بواسطة هذا التغيير.
