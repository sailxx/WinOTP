[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · **Français** · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Construction et approbation du Linux

Cible x86_64 Linux, initialement Ubuntu 24.04 et Fedora avec . NET 10 dépendances natives. L'interface est Avalonia ; l'application Windows WinUI est inchangée. Linux utilise la même disposition compacte, des accents cyan et une surface sombre légèrement teintée par l'accent système (repli neutre en cas d'indisponibilité) : Windows Mica Alt et Segoe UI Variable ne sont pas portables. L'Inter est groupé ; aucune police Microsoft n'est redistribuée.

Le mot de passe principal Linux chiffre le coffre-fort avec AES -256- GCM et PBKDF2 - SHA256 (600 000 itérations). Il est requis au démarrage et ne peut pas être récupéré. Données: `$XDG_DATA_HOME/WinOTP` ou `~/.local/share/WinOTP`. Le répertoire du coffre-fort est 0700 et les fichiers du coffre-fort nouvellement créés sont 0600. Les écritures sont atomiques, verrouillées par l'auteur et rejettent les révisions obsolètes. Aucun secret n'est stocké dans les préférences. Un coffre-fort prend en charge jusqu'à 500 comptes et 14 Mio de données sérialisées (sa sauvegarde Base64 correspond donc à la limite d'importation de 20 Mio) ; les sauvegardes surdimensionnées sont rejetées avant leur remplacement. Ne copiez jamais les fichiers Windows DPAPI vers Linux : exportez un fichier chiffré par mot de passe `.winotp` sauvegardez sur Windows et importez-la sur Linux. Conservez la source jusqu'à ce que la restauration soit vérifiée.

## Développement local

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

Pour un aperçu isolé utilisant uniquement les informations d'identification publiques RFC:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## Forfaits

`.github/workflows/linux.yml` installe les dépendances d'empaquetage, vérifie un résumé appimagetool épinglé, construit deb/rpm/ AppImage , installe et démarre le deb sous Xvfb, démarre le AppImage sans FUSE et télécharge les packages ainsi que les captures d'écran comme `linux-packages`. Il fonctionne sur des PR et peut être exécuté manuellement ; il ne publie pas de communiqué. `packaging/linux/build.sh` s'exécute également localement sur un hôte x86_64 Linux avec . NET 10, fpm 1.16.0, outils rpm et squashfs ; fournir `APPIMAGETOOL` pointant vers l’exécutable 1.9.1 x86_64 vérifié. Tout le contenu généré reste sous `artifacts/linux`.

Le workflow de balises attend les builds Linux et Windows, puis prépare un **brouillon** version avec le programme d'installation et les trois packages Linux. GitHub affiche les résumés SHA -256 pour les ressources de version. Passez en revue les véritables captures d'écran du Linux et obtenez l'approbation de Vlad avant de les publier. La création de balises ou l'envoi de modifications ne font pas partie de la préparation locale.

## Acceptation toujours requise

Installer/supprimer/mettre à niveau deb sur Ubuntu et RPM sur Fedora ; testez AppImage sur les deux ( FUSE ou `--appimage-extract-and-run`). Vérifiez le bureau X11 / Wayland réel, la mise à l'échelle, le délai d'expiration du presse-papiers, les sélecteurs de fichiers, l'importation QR, le verrouillage par mot de passe, la restauration de sauvegarde Windows et la persistance HOTP. L'installation de RPM et le comportement du compositeur de bureau ne sont pas couverts par le travail Ubuntu CI. Aucune intégration de plateau Linux ni importation QR d'image de presse-papiers n'est encore implémentée. L'importation de fichiers QR et URI est disponible.

`assets/screenshots/linux-ui-preview.png` est un rendu réel de l'interface Avalonia hébergée sur Windows, et non une preuve d'un test d'exécution Linux. Aucun paquet n'a été publié suite à ce changement.
