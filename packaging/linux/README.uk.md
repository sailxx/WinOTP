[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · **Українська** · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Збірка та схвалення Linux

Цілі x86_64 Linux, спочатку Ubuntu 24.04 і Fedora з . NET 10 нативних залежностей. Інтерфейс — Avalonia ; програма Windows WinUI не змінилася. Linux використовує той самий компактний макет, блакитні акценти та темну поверхню, злегка відтінену системним акцентом (нейтральний запасний варіант, коли недоступний): Windows Mica Alt і Segoe UI Variable не портативні. Інтер в комплекті; жоден шрифт Microsoft не розповсюджується.

Головний пароль Linux шифрує сховище за допомогою AES -256- GCM і PBKDF2 - SHA256 (600 000 ітерацій). Він потрібен під час запуску та не може бути відновлений. дані: `$XDG_DATA_HOME/WinOTP` або `~/.local/share/WinOTP`. Каталог сховища – 0700, а нещодавно створені файли сховища – 0600. Запис є атомарним, блокується записом і відхиляє застарілі версії. У налаштуваннях не зберігаються секрети. Сховище підтримує до 500 облікових записів і 14 МіБ серіалізованих даних (тому його резервна копія Base64 відповідає обмеженню імпорту в 20 МіБ); надлишкові збереження відкидаються перед заміною. Ніколи не копіюйте файли Windows DPAPI до Linux: експортуйте файли, зашифровані паролем `.winotp` створіть резервну копію на Windows та імпортуйте його на Linux. Зберігайте джерело, доки не буде перевірено відновлення.

## Місцевий розвиток

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

Для ізольованого попереднього перегляду, використовуючи лише публічні облікові дані RFC:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## пакети

`.github/workflows/linux.yml` встановлює залежності пакувань, перевіряє закріплений дайджест appimagetool, збирає deb/rpm/ AppImage, встановлює та запускає deb під Xvfb, запускає AppImage без FUSE і завантажує пакунки та знімки екрана як `linux-packages`. Він працює на PR і може бути запущений вручну; він не публікує випуск. `packaging/linux/build.sh` також працює локально на хості x86_64 Linux з . NET 10, fpm 1.16.0 , rpm та squashfs-інструменти; постачання `APPIMAGETOOL` вказує на перевірений виконуваний файл 1.9.1 x86_64. Увесь створений вміст залишається в списку `artifacts/linux`.

Робочий процес тегів очікує збірок Linux і Windows, а потім готує **проект** випуск із інсталятором і всіма трьома пакетами Linux. GitHub показує дайджести SHA -256 для активів випуску. Перегляньте справжні скріншоти Linux і отримайте схвалення Влада перед публікацією. Створення тегів або просування змін не є частиною локальної підготовки.

## Ще потрібне прийняття

Встановити/видалити/оновити deb на Ubuntu та rpm на Fedora; перевірити AppImage на обох ( FUSE або `--appimage-extract-and-run`). Перевірте фактичний робочий стіл X11 / Wayland, масштабування, час очікування буфера обміну, засоби вибору файлів, імпорт QR, блокування паролем, відновлення резервної копії Windows і збереження HOTP. Встановлення RPM і поведінка композитора на робочому столі не охоплюються завданням Ubuntu CI. Інтеграція лотка Linux або імпорт зображень буфера обміну QR ще не реалізовані. Доступний імпорт файлів QR та URI.

`assets/screenshots/linux-ui-preview.png` є реальним відтворенням інтерфейсу Avalonia, розміщеного на Windows, а не доказом тесту часу виконання Linux. Ця зміна не випустила пакети.
