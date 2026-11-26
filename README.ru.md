[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · **Русский** · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="Логотип WinOTP">

# WinOTP

**Ваши коды. Ваше устройство. Аутентификатор для Windows 11.**

TOTP и HOTP в компактном тёмном окне с оттенком обоев. Поиск, импорт и зашифрованные резервные копии — без регистрации и облачной синхронизации.

Разрабатывает Влад · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — локальный аутентификатор для Windows 11; иллюстрация интерфейса">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="Скачать для Windows 11"></a>&nbsp;&nbsp;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="Что нового"></a>

Windows 11 · x64 · Интерфейс на английском

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="Возможности: TOTP и HOTP, локальное хранилище, импорт, поиск, резервные копии, без облачной синхронизации">

<details>
<summary><b>Подробнее о возможностях</b></summary>

### Одноразовые коды

TOTP (RFC 6238) и HOTP (RFC 4226), SHA-1/256/512, 6 или 8 цифр. Добавляйте, редактируйте, удаляйте и копируйте аккаунты и коды. Избранное и поиск помогают найти нужную запись.

### Импорт аккаунтов

Поддерживаются otpauth URI, Google Authenticator migration URI, QR-изображения и Aegis JSON. Перед сохранением можно просмотреть записи; уже добавленные аккаунты исключаются.

### Резервные копии

Переносимые файлы `.winotp` шифруются отдельным паролем. Храните пароль отдельно от файла и проверяйте возможность восстановления до удаления исходных данных.

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="Управление: Add, Hide codes, Search, Import, Backup, Settings">

<details>
<summary><b>Управление и снимки приложения</b></summary>

| Элемент | Действие |
| --- | --- |
| **Add** | Добавить аккаунт |
| **Hide codes / Show codes** | Скрыть или показать коды |
| **Search accounts** | Найти сервис или аккаунт |
| **Шестерёнка → Import** | Открыть импорт с предпросмотром |
| **Шестерёнка → Backup** | Создать зашифрованную резервную копию |
| **Шестерёнка → Settings** | Настроить блокировку и очистку буфера; версия находится в конце |

Список прокручивается колёсиком и жестами; полоса прокрутки скрыта. Постоянно тёмное оформление использует нативный Mica Alt с оттенком обоев, если это разрешено настройками Windows.

Снимок отдельного тестового хранилища с публичными демонстрационными данными:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="Главное окно WinOTP с тестовым аккаунтом">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="Защита данных: Windows DPAPI, AES-256-GCM, блокировка интерфейса и ограничения буфера обмена">

<details>
<summary><b>Защита данных и её ограничения</b></summary>

Хранилище защищено Windows DPAPI текущего пользователя. Резервные копии используют AES-256-GCM и PBKDF2-SHA256 с 600 000 итерациями. Мастер-пароль блокирует **интерфейс**, но не защищает от вредоносной программы, запущенной под той же учётной записью Windows. Очистка буфера не удаляет копии из истории и сторонних приложений.

Данные находятся в `%LOCALAPPDATA%\WinOTP`. При переносе из `%LOCALAPPDATA%\NoirAuth` исходные файлы сохраняются. Не удаляйте их, пока не проверите новое хранилище и резервную копию. Подробности: [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="Состояние проекта: компактный WinUI 3, основные сценарии, оставшиеся проверки обоев, масштабов и упаковки">

<details>
<summary><b>Установка и обновление</b></summary>

1. Откройте [релизы](https://github.com/sailxx/WinOTP/releases) и проверьте описание выбранной версии.
2. Для выпусков с новым названием скачайте `WinOTP-Setup.exe`.
3. Запустите установщик и выберите папку. Права администратора не требуются.

Данные хранятся отдельно от программы и сохраняются при удалении. Перед обновлением сделайте резервную копию. Интерфейс приложения и установщик используют английский язык.

Установщик не подписан цифровой подписью Windows; SmartScreen может показать предупреждение. Проверяйте источник и контрольную сумму, прежде чем решать, запускать ли файл.

</details>

<details>
<summary><b>Проверка загрузки</b></summary>

Скачайте установщик и выполните:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

Сравните хеш со значением SHA-256 рядом с установщиком в списке файлов на GitHub. Подтверждение происхождения не заменяет подпись Windows и не гарантирует отсутствие уязвимостей. Старые релизы могут не содержать аттестацию.

</details>

<details>
<summary><b>Сборка из исходников</b></summary>

Нужны Windows, .NET SDK 10 и инструменты сборки WinUI. Замените путь в первой команде на папку проекта.

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

Порядок выпуска и обязательные проверки: [RELEASE.md](RELEASE.md). Изменения: [CHANGELOG.md](CHANGELOG.md). Графические плашки создаются командой `python tools/generate_readme.py` из корня проекта.

</details>

<details>
<summary><b>Известные ограничения</b></summary>

- Добавлена Linux-версия на Avalonia и подготовка пакетов deb, rpm и AppImage (x64); выпуск ожидает проверки на Linux и утверждения. [Сборка и ограничения](packaging/linux/README.md). macOS и облачной синхронизации нет.
- На Linux сохранены компактная компоновка и цвета, но Mica Alt недоступен; используется тёмный фон и шрифт Inter. Пароль шифрует Linux-хранилище; перенос с Windows — через парольную `.winotp`-копию.
- Mica зависит от версии Windows и системной политики прозрачности. Полная проверка смены обоев и разных масштабов ещё необходима.
- MSIX-манифест — входной файл упаковки, а не подписанный и проверенный установочный пакет. Основной формат распространения — Inno Setup.
- Состояние публикации и проверки каждого выпуска указаны в его описании; подготовленная локально версия не означает опубликованный релиз.

</details>

<details>
<summary><b>Об авторе и лицензии</b></summary>

WinOTP разрабатывает Влад ([sailxx](https://github.com/sailxx)). Исходный код распространяется по [лицензии MIT](LICENSE). Ошибки и предложения: [Issues](https://github.com/sailxx/WinOTP/issues).

</details>
