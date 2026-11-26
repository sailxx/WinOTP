[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · **Español** · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="Logotipo WinOTP">

# WinOTP

**Tus códigos. Tu dispositivo. Su autenticador para Windows 11.**

TOTP y HOTP en una ventana oscura compacta con color derivado del papel tapiz. Busque, importe y cifre copias de seguridad sin registro ni sincronización en la nube.

Construido por Vlad · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — tus códigos, tu dispositivo; una ilustración de interfaz">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="Descargar para Windows 11"></a>&nbsp;;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="Qué hay de nuevo"></a>

Windows 11 · x64 · Interfaz en inglés

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="Funciones: TOTP y HOTP, bóveda local, importación, búsqueda, copias de seguridad y sin sincronización en la nube">

<details>
<summary><b>Más sobre las características</b></summary>

### Códigos de un solo uso

RFC 6238 TOTP y RFC 4226 HOTP; SHA -1/256/512; 6 u 8 dígitos. Agregue, edite, elimine y copie cuentas y códigos. La búsqueda y los favoritos mantienen la entrada correcta a su alcance.

### trae tus cuentas

Importe URI de otpauth, URI de migración de Google Authenticator, imágenes QR y Aegis JSON. Obtenga una vista previa de las entradas antes de guardarlas y omita las cuentas existentes.

### Copias de seguridad cifradas

Portátil `.winotp` Los archivos utilizan una contraseña separada. Guarde esa contraseña por separado y verifique la restauración antes de eliminar los datos de origen.

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="Controles: Agregar, Ocultar códigos, Buscar, Importar, Copia de seguridad y Configuración">

<details>
<summary><b>Controles y captura de pantalla de la aplicación.</b></summary>

| Control | Acción |
| --- | --- |
| **Agregar** | Crea una cuenta |
| **Ocultar códigos / Mostrar códigos** | Ocultar o revelar códigos |
| **Buscar cuentas** | Encuentra un servicio o cuenta |
| **Equipo → Importar** | Importar cuentas con una vista previa |
| **Equipo → Copia de seguridad** | Crear una copia de seguridad cifrada |
| **Engranaje → Configuración** | Configurar el bloqueo de la interfaz y el tiempo de espera del portapapeles; la versión está en la parte inferior |

Desplácese por la lista de cuentas con la rueda del mouse o con gestos; la barra de desplazamiento está oculta. La interfaz permanentemente oscura utiliza Mica Alt nativa con color derivado del fondo de pantalla cuando lo permite la configuración de Windows.

Captura de pantalla de una bóveda de prueba aislada con datos de ejemplo públicos:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="Ventana principal de WinOTP con una cuenta de prueba">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="Protección de datos: Windows DPAPI, AES -256- GCM, bloqueo de interfaz y límites del portapapeles">

<details>
<summary><b>La protección de datos y sus límites</b></summary>

Windows DPAPI protege la bóveda para el usuario actual de Windows. Las copias de seguridad portátiles utilizan AES -256- GCM y PBKDF2 - SHA256 con 600.000 iteraciones. La contraseña maestra bloquea el **interfaz**, no acceda mediante malware que se ejecute como su usuario Windows. La limpieza del portapapeles no puede borrar el historial del portapapeles ni las copias capturadas por otras aplicaciones.

Los datos viven en `%LOCALAPPDATA%\WinOTP`. La migración copia archivos heredados de `%LOCALAPPDATA%\NoirAuth` sin quitar los originales. Consérvelos hasta que haya verificado la bóveda migrada y una copia de seguridad restaurable. Ver [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="Estado del proyecto: WinUI 3 compacto, flujos de trabajo de cuentas y comprobaciones de papel tapiz, escala y embalaje restantes">

<details>
<summary><b>Instalar y actualizar</b></summary>

1. Abierto [Lanzamientos](https://github.com/sailxx/WinOTP/releases) y lea las notas de la versión seleccionada.
2. Para lanzamientos que llevan el nuevo nombre, descargue `WinOTP-Setup.exe`.
3. Ejecute la configuración y elija una carpeta. No se requieren derechos de administrador.

Los datos se almacenan por separado y se conservan durante la desinstalación. Cree una copia de seguridad antes de actualizar. La interfaz de la aplicación y el instalador utilizan el inglés.

El instalador no tiene la firma del código Windows; SmartScreen puede avisar. Verifique la fuente y la suma de verificación antes de decidir si ejecutarlo.

</details>

<details>
<summary><b>Verifica tu descarga</b></summary>

Descargue el instalador y ejecútelo:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

Compare el hash con el valor SHA -256 junto al instalador en la lista de activos de lanzamiento de GitHub. La procedencia no es la firma del código Windows ni una garantía de código libre de vulnerabilidades. Es posible que las versiones anteriores no incluyan certificaciones.

</details>

<details>
<summary><b>Construir desde la fuente</b></summary>

Requiere Windows, . Herramientas de construcción NET SDK 10 y WinUI. Reemplace la ruta en el primer comando con la carpeta de su proyecto.

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

Liberación de puertas e instrucciones.: [RELEASE.md](RELEASE.md). Cambios: [CHANGELOG.md](CHANGELOG.md). Generar los paneles gráficos con `python tools/generate_readme.py` desde la raíz del proyecto.

</details>

<details>
<summary><b>Limitaciones conocidas</b></summary>

- Se preparan una interfaz Avalonia Linux y recetas x64 deb, rpm y AppImage, en espera de la aceptación y aprobación de Linux. [Construcción y limitaciones](packaging/linux/README.md). Sin macOS ni sincronización en la nube.
- Linux mantiene el diseño compacto y los colores con un fondo oscuro opaco y el Inter incluido; Windows Mica Alt no está disponible. La contraseña Linux cifra la bóveda. Transfiera cuentas Windows a través de una contraseña cifrada `.winotp` respaldo.
- La mica depende de la versión Windows y de la política de transparencia. Aún se necesitan cambios completos de fondo de pantalla y pruebas de aceptación a múltiples escalas.
- El manifiesto MSIX es una entrada de paquete, no un paquete firmado y probado en instalación. Inno Setup es el formato de distribución.
- Las notas de cada versión describen su estado de publicación y verificación. Una versión local preparada no es una versión publicada.

</details>

<details>
<summary><b>Acerca de y licencia</b></summary>

WinOTP es desarrollado por Vlad ([sailxx](https://github.com/sailxx)). La fuente está disponible en [Licencia MIT](LICENSE). Errores y sugerencias: [Asuntos](https://github.com/sailxx/WinOTP/issues).

</details>
