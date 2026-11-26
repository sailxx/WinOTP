[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · **Español** · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Construcción y aprobación de Linux

Apunta a x86_64 Linux, inicialmente Ubuntu 24.04 y Fedora con . NET 10 dependencias nativas. La interfaz es Avalonia; la aplicación Windows WinUI no ha cambiado. Linux utiliza el mismo diseño compacto, detalles en cian y una superficie oscura ligeramente teñida por el acento del sistema (respaldo neutral cuando no está disponible): Windows Mica Alt y Segoe UI Variable no son portátiles. El Inter está incluido; no se redistribuye ninguna fuente de Microsoft.

La contraseña maestra Linux cifra la bóveda con AES -256- GCM y PBKDF2 - SHA256 (600.000 iteraciones). Es necesario al inicio y no se puede recuperar. Datos: `$XDG_DATA_HOME/WinOTP` o `~/.local/share/WinOTP`. El directorio de Vault es 0700 y los archivos de Vault recién creados son 0600. Las escrituras son atómicas, están bloqueadas por el escritor y rechazan las revisiones obsoletas. No se almacenan secretos en las preferencias. Una bóveda admite hasta 500 cuentas y 14 MiB de datos serializados (por lo que su copia de seguridad Base64 se ajusta al límite de importación de 20 MiB); los ahorros de gran tamaño se rechazan antes de reemplazarlos. Nunca copie archivos Windows DPAPI a Linux: exporte una contraseña cifrada `.winotp` haga una copia de seguridad en Windows e impórtela en Linux. Conserve la fuente hasta que se verifique la restauración.

## Desarrollo local

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

Para una vista previa aislada usando solo credenciales públicas de RFC:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## Paquetes

`.github/workflows/linux.yml` instala las dependencias del paquete, verifica un resumen de appimagetool anclado, compila deb/rpm/AppImage, instala e inicia deb en Xvfb, inicia AppImage sin FUSE y carga paquetes más capturas de pantalla como `linux-packages`. Se ejecuta en PR y se puede ejecutar manualmente; no publica un comunicado. `packaging/linux/build.sh` También se ejecuta localmente en un host x86_64 Linux con . NET 10, fpm 1.16.0, rpm y squashfs-tools; suministrar `APPIMAGETOOL` apuntando al ejecutable 1.9.1 x86_64 verificado. Todo el contenido generado permanece bajo `artifacts/linux`.

El flujo de trabajo de etiquetas espera las compilaciones de Linux y Windows y luego prepara un **borrador** libere con el instalador y los tres paquetes Linux. GitHub muestra resúmenes de SHA -256 de los activos de lanzamiento. Revise las capturas de pantalla reales de Linux y obtenga la aprobación de Vlad antes de publicarlas. Crear etiquetas o impulsar cambios no es parte de la preparación local.

## Aún se requiere aceptación

Instalar/eliminar/actualizar deb en Ubuntu y rpm en Fedora; Pruebe AppImage en ambos (FUSE o `--appimage-extract-and-run`). Verifique el escritorio actual del X11/Wayland, el escalado, el tiempo de espera del portapapeles, los selectores de archivos, la importación del QR, el bloqueo de contraseña, la restauración de la copia de seguridad del Windows y la persistencia del HOTP. La instalación de RPM y el comportamiento del compositor de escritorio no están cubiertos por el trabajo de Ubuntu CI. Aún no se ha implementado la integración de la bandeja Linux ni la importación de imágenes del portapapeles QR. Los archivos de importación QR e importación URI están disponibles.

`assets/screenshots/linux-ui-preview.png` es una representación real de la interfaz Avalonia alojada en Windows, no una prueba de una prueba de tiempo de ejecución de Linux. Este cambio no ha publicado ningún paquete.
