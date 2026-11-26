[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · **Italiano** · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Costruzione e approvazione Linux

Ha come target x86_64 Linux, inizialmente Ubuntu 24.04 e Fedora con . NET 10 dipendenze native. Il frontend è Avalonia ; l'applicazione Windows WinUI è invariata. Linux utilizza lo stesso layout compatto, accenti ciano e una superficie scura leggermente colorata dall'accento di sistema (fallback neutro quando non disponibile): Windows Mica Alt e Segoe UI Variable non sono portatili. L'Inter è impacchettata; nessun carattere Microsoft viene ridistribuito.

La password principale Linux crittografa il vault con AES -256- GCM e PBKDF2 - SHA256 (600.000 iterazioni). È richiesto all'avvio e non può essere recuperato. Dati: `$XDG_DATA_HOME/WinOTP` O `~/.local/share/WinOTP`. La directory del vault è 0700 e i file del vault appena creati 0600. Le scritture sono atomiche, bloccate dal writer e rifiutano le revisioni obsolete. Nessun segreto viene memorizzato nelle preferenze. Un insieme di credenziali supporta fino a 500 account e 14 MiB di dati serializzati (quindi il backup Base64 rientra nel limite di importazione di 20 MiB); i salvataggi sovradimensionati vengono rifiutati prima della sostituzione. Non copiare mai i file Windows DPAPI su Linux: esporta un file crittografato con password `.winotp` backup su Windows e importarlo su Linux. Conservare la fonte fino alla verifica del ripristino.

## Sviluppo locale

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

Per un'anteprima isolata utilizzando solo le credenziali pubbliche RFC:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## Pacchetti

`.github/workflows/linux.yml` installa le dipendenze del pacchetto, verifica un digest appimagetool bloccato, crea deb/rpm/ AppImage , installa e avvia deb sotto Xvfb, avvia AppImage senza FUSE e carica pacchetti più screenshot come `linux-packages`. Funziona su PR e può essere eseguito manualmente; non pubblica un comunicato. `packaging/linux/build.sh` funziona anche localmente su un host x86_64 Linux con . NET 10, fpm 1.16.0 , RPM e strumenti squashfs; fornitura `APPIMAGETOOL` puntando all'eseguibile 1.9.1 x86_64 verificato. Tutto il contenuto generato rimane in `artifacts/linux`.

Il flusso di lavoro dei tag attende le build Linux e Windows, quindi prepara un file **bozza** rilascio con il programma di installazione e tutti e tre i pacchetti Linux. GitHub mostra SHA -256 digest per le risorse di rilascio. Rivedi gli screenshot reali dello Linux e ottieni l'approvazione di Vlad prima di pubblicarli. La creazione di tag o l'invio di modifiche non fanno parte della preparazione locale.

## L'accettazione è ancora necessaria

Installa/rimuovi/aggiorna deb su Ubuntu e rpm su Fedora; testare AppImage su entrambi (FUSE o `--appimage-extract-and-run`). Verifica il desktop X11 / Wayland effettivo, il ridimensionamento, il timeout degli appunti, i selettori file, l'importazione QR, il blocco della password, il ripristino del backup Windows e la persistenza HOTP. L'installazione di RPM e il comportamento del compositore desktop non sono coperti dal lavoro Ubuntu CI. Non è ancora stata implementata l'integrazione del vassoio Linux o l'importazione dell'immagine QR negli appunti. Sono disponibili l'importazione di file QR e l'importazione di URI.

`assets/screenshots/linux-ui-preview.png` è un rendering reale del frontend Avalonia ospitato su Windows, non la prova di un test di runtime Linux. Nessun pacchetto è stato rilasciato da questa modifica.
