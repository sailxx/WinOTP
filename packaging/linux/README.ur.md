[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · **اردو** · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Linux تعمیر اور منظوری

ہدف x86_64 Linux، ابتدائی طور پر Ubuntu 24.04 اور Fedora کے ساتھ۔ NET 10 مقامی انحصار۔ فرنٹ اینڈ Avalonia ہے؛ Windows WinUI ایپلیکیشن میں کوئی تبدیلی نہیں ہے۔ Linux وہی کمپیکٹ لے آؤٹ، سائین لہجے اور ایک تاریک سطح کا استعمال کرتا ہے جسے سسٹم کے لہجے سے ہلکے سے رنگ دیا جاتا ہے (غیر دستیاب ہونے پر غیر جانبدار فال بیک): Windows Mica Alt اور Segoe UI ویری ایبل پورٹیبل نہیں ہیں۔ انٹر بنڈل ہے؛ کوئی مائیکروسافٹ فونٹ دوبارہ تقسیم نہیں کیا گیا ہے۔

Linux ماسٹر پاس ورڈ AES -256- GCM اور PBKDF2 - SHA256 (600,000 تکرار) کے ساتھ والٹ کو خفیہ کرتا ہے۔ یہ آغاز پر ضروری ہے اور بازیافت نہیں کیا جا سکتا۔ ڈیٹا: `$XDG_DATA_HOME/WinOTP` یا `~/.local/share/WinOTP`. والٹ ڈائرکٹری 0700 ہے اور نئی تخلیق شدہ والٹ فائلیں 0600۔ تحریریں ایٹم، رائٹر لاکڈ، اور پرانی نظرثانی کو مسترد کرتی ہیں۔ ترجیحات میں کوئی راز محفوظ نہیں ہے۔ ایک والٹ 500 اکاؤنٹس اور 14 ایم آئی بی سیریلائزڈ ڈیٹا کو سپورٹ کرتا ہے (لہذا اس کا بیس 64 بیک اپ 20 ایم آئی بی کی درآمد کی حد پر فٹ بیٹھتا ہے)؛ بڑے سائز کی بچت کو تبدیل کرنے سے پہلے مسترد کر دیا جاتا ہے۔ کبھی بھی Windows DPAPI فائلوں کو Linux میں کاپی نہ کریں : پاس ورڈ سے خفیہ کردہ برآمد کریں `.winotp` Windows پر بیک اپ لیں اور اسے Linux پر درآمد کریں۔ بحالی کی تصدیق ہونے تک ماخذ کو رکھیں۔

## مقامی ترقی

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

صرف عوامی RFC اسناد کا استعمال کرتے ہوئے الگ تھلگ پیش نظارہ کے لیے:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## پیکجز

`.github/workflows/linux.yml` پیکیجنگ کے انحصار کو انسٹال کرتا ہے، ایک پن شدہ appimagetool ڈائجسٹ کی تصدیق کرتا ہے، deb/rpm/ AppImage بناتا ہے، Xvfb کے تحت ڈیب کو انسٹال اور شروع کرتا ہے، FUSE کے بغیر AppImage شروع کرتا ہے، اور پیکجوں کے علاوہ اسکرین شاٹس کو بطور اپ لوڈ کرتا ہے۔ `linux-packages`. یہ PRs پر چلتا ہے اور دستی طور پر چلایا جا سکتا ہے۔ یہ ایک ریلیز شائع نہیں کرتا. `packaging/linux/build.sh` مقامی طور پر ایک x86_64 Linux میزبان پر بھی چلتا ہے۔ NET 10، fpm 1.16.0، rpm اور squashfs-tools؛ فراہمی `APPIMAGETOOL` تصدیق شدہ 1.9.1 x86_64 قابل عمل کی طرف اشارہ کرنا۔ تمام تیار کردہ مواد کے تحت رہتا ہے۔ `artifacts/linux`.

ٹیگ ورک فلو Linux اور Windows کی تعمیر کا انتظار کرتا ہے، پھر ایک تیار کرتا ہے **مسودہ** انسٹالر اور تینوں Linux پیکیجز کے ساتھ ریلیز کریں۔ GitHub ریلیز اثاثوں کے لیے SHA -256 ڈائجسٹ دکھاتا ہے۔ اصلی Linux اسکرین شاٹس کا جائزہ لیں اور شائع کرنے سے پہلے ولاد کی منظوری حاصل کریں۔ ٹیگ بنانا یا تبدیلیوں کو آگے بڑھانا مقامی تیاری کا حصہ نہیں ہے۔

## قبولیت اب بھی درکار ہے۔

Ubuntu پر deb اور Fedora پر rpm کو انسٹال/ہٹائیں/اپ گریڈ کریں؛ AppImage دونوں پر ٹیسٹ کریں ( FUSE یا `--appimage-extract-and-run`). اصل X11 / Wayland ڈیسک ٹاپ، اسکیلنگ، کلپ بورڈ ٹائم آؤٹ، فائل پکرز، QR امپورٹ، پاس ورڈ لاکنگ، Windows بیک اپ بحالی اور HOTP استقامت کی تصدیق کریں۔ RPM انسٹالیشن اور ڈیسک ٹاپ کمپوزر رویے Ubuntu CI جاب میں شامل نہیں ہیں۔ ابھی تک کوئی Linux ٹرے انضمام یا کلپ بورڈ امیج QR درآمد نہیں کیا گیا ہے۔ فائل QR درآمد اور URI درآمد دستیاب ہیں۔

`assets/screenshots/linux-ui-preview.png` Windows پر میزبان Avalonia فرنٹ اینڈ کی حقیقی رینڈرنگ ہے، Linux رن ٹائم ٹیسٹ کا ثبوت نہیں۔ اس تبدیلی سے کوئی پیکج جاری نہیں کیا گیا ہے۔
