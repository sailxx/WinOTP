[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · **Українська** · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="Логотип WinOTP">

# WinOTP

**Ваші коди. Ваш пристрій. Ваш автентифікатор для Windows 11.**

TOTP і HOTP у компактному темному вікні з кольором шпалер. Пошук, імпорт і зашифровані резервні копії без реєстрації та хмарної синхронізації.

Побудував Влад · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — ваші коди, ваш пристрій; ілюстрація інтерфейсу">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="Завантажити для Windows 11"></a>&nbsp; &nbsp;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="Що нового"></a>

Windows 11 · x64 · Англійський інтерфейс

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="Особливості: TOTP і HOTP, локальне сховище, імпорт, пошук, резервне копіювання та відсутність хмарної синхронізації">

<details>
<summary><b>Детальніше про особливості</b></summary>

### Одноразові коди

RFC 6238 TOTP і RFC 4226 HOTP ; SHA -1/256/512; 6 або 8 цифр. Додавати, редагувати, видаляти та копіювати облікові записи та коди. Пошук і вибране тримають потрібний запис під рукою.

### Принесіть свої рахунки

Імпортуйте URI otpauth, URI міграції Google Authenticator, зображення QR і Aegis JSON. Перегляньте записи перед збереженням і пропустіть наявні облікові записи.

### Зашифровані резервні копії

Портативний `.winotp` файли використовують окремий пароль. Зберігайте цей пароль окремо та перевірте відновлення перед видаленням вихідних даних.

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="Елементи керування: Додати, Приховати коди, Пошук, Імпорт, Резервне копіювання та Налаштування">

<details>
<summary><b>Елементи керування та скріншот програми</b></summary>

| КОНТРОЛЬ | Дія |
| --- | --- |
| **додати** | Створіть обліковий запис |
| **Приховати коди / Показати коди** | Приховати або відкрити коди |
| **Пошук облікових записів** | Знайдіть службу або обліковий запис |
| **Gear → Імпорт** | Імпорт облікових записів із попереднім переглядом |
| **Gear → Резервне копіювання** | Створіть зашифровану резервну копію |
| **Шестерня → Налаштування** | Налаштувати блокування інтерфейсу та тайм-аут буфера обміну; версія знаходиться внизу |

Прокручуйте список облікових записів коліщатком миші або жестами; смуга прокрутки прихована. Постійно темний інтерфейс використовує оригінальний Mica Alt із кольором фонового зображення, якщо це дозволено налаштуваннями Windows.

Знімок екрана ізольованого тестового сховища з загальнодоступними прикладами даних:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="Головне вікно WinOTP з тестовим обліковим записом">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="Захист даних: Windows DPAPI , AES -256- GCM , обмеження блокування інтерфейсу та буфера обміну">

<details>
<summary><b>Захист даних та його межі</b></summary>

Windows DPAPI захищає сховище для поточного користувача Windows. Портативні резервні копії використовують AES -256- GCM і PBKDF2 - SHA256 з 600 000 ітерацій. Головний пароль блокує **інтерфейс**, не має доступу зловмисне програмне забезпечення, запущене від імені користувача Windows. Очищення буфера обміну не може стерти історію буфера обміну чи копії, зроблені іншими програмами.

Дані живуть `%LOCALAPPDATA%\WinOTP`. Міграція копіює застарілі файли з `%LOCALAPPDATA%\NoirAuth` не видаляючи оригінали. Зберігайте їх, доки не перевірите переміщене сховище та резервну копію, яку можна відновити. див [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="Статус проекту: компактний WinUI 3, робочі процеси облікового запису та інші шпалери, перевірки масштабування та упаковки">

<details>
<summary><b>Встановити та оновити</b></summary>

1. ВІДЧИНЕНО [Релізи](https://github.com/sailxx/WinOTP/releases) і прочитайте примітки до вибраної версії.
2. Для випусків з новою назвою завантажте `WinOTP-Setup.exe`.
3. Запустіть установку та виберіть папку. Права адміністратора не потрібні.

Дані зберігаються окремо та зберігаються під час видалення. Перед оновленням створіть резервну копію. Інтерфейс програми та інсталятор використовуються англійською мовою.

Інсталятор не має кодового підпису Windows; SmartScreen може попереджати. Перевірте джерело та контрольну суму, перш ніж вирішити, чи запускати його.

</details>

<details>
<summary><b>Підтвердьте завантаження</b></summary>

Завантажте інсталятор і запустіть:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

Порівняйте хеш зі значенням SHA -256 поруч із інсталятором у списку активів випуску GitHub. Походження не є підписом коду Windows або гарантією відсутності вразливостей у коді. Старіші версії можуть не містити атестацій.

</details>

<details>
<summary><b>Збірка з джерела</b></summary>

Потрібен Windows , . NET SDK 10 і WinUI інструменти для збирання. Замініть шлях у першій команді папкою проекту.

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

Відпустіть ворота та інструкції: [RELEASE.md](RELEASE.md). Зміни: [CHANGELOG.md](CHANGELOG.md). Створіть графічні панелі за допомогою `python tools/generate_readme.py` з кореня проекту.

</details>

<details>
<summary><b>Відомі обмеження</b></summary>

- Інтерфейс Avalonia Linux і x64 deb, rpm і рецепти AppImage підготовлені, очікуючи прийняття та затвердження Linux. [Конструкція та обмеження](packaging/linux/README.md). Немає macOS або хмарної синхронізації.
- Linux зберігає компактний макет і кольори з непрозорим темним фоном і вбудованим Inter; Windows Mica Alt недоступний. Пароль Linux шифрує сховище. Передача облікових записів Windows через зашифрований пароль `.winotp` резервне копіювання.
- Слюда залежить від версії Windows і політики прозорості. Потрібна повна зміна фонового малюнка та багатомасштабне приймальне тестування.
- Маніфест MSIX — це вхідні дані для пакування, а не підписаний пакет, перевірений установкою. Inno Setup — це формат розповсюдження.
- Примітки до кожного випуску описують його публікацію та статус перевірки. Підготовлена ​​локальна версія не є опублікованою версією.

</details>

<details>
<summary><b>Про та ліцензію</b></summary>

WinOTP розроблений Владом ([sailxx](https://github.com/sailxx)). Джерело доступне під [Ліцензія MIT](LICENSE). Помилки та пропозиції: [Питання](https://github.com/sailxx/WinOTP/issues).

</details>
