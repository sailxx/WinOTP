[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · **Français** · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="Logo WinOTP">

# WinOTP

**Vos codes. Votre appareil. Votre authentificateur pour Windows 11.**

TOTP et HOTP dans une fenêtre sombre et compacte avec une couleur dérivée du papier peint. Recherchez, importez et sauvegardes cryptées sans inscription ni synchronisation cloud.

Construit par Vlad · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — vos codes, votre appareil ; une illustration de l&#x27;interface">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="Télécharger pour Windows 11"></a>&nbsp;;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="Quoi de neuf"></a>

Windows 11 · x64 · Interface anglaise

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="Caractéristiques : TOTP et HOTP, coffre-fort local, importation, recherche, sauvegardes et pas de synchronisation cloud">

<details>
<summary><b>En savoir plus sur les fonctionnalités</b></summary>

### Codes à usage unique

RFC 6238 TOTP et RFC 4226 HOTP ; SHA-1/256/512 ; 6 ou 8 chiffres. Ajoutez, modifiez, supprimez et copiez des comptes et des codes. La recherche et les favoris gardent la bonne entrée à portée de main.

### Apportez vos comptes

Importez les URI otpauth, les URI de migration Google Authenticator, les images QR et Aegis JSON. Prévisualisez les entrées avant de sauvegarder et ignorez les comptes existants.

### Sauvegardes cryptées

Portable `.winotp` les fichiers utilisent un mot de passe distinct. Conservez ce mot de passe séparément et vérifiez la restauration avant de supprimer les données sources.

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="Contrôles : Ajouter, Masquer les codes, Rechercher, Importer, Sauvegarde et Paramètres">

<details>
<summary><b>Commandes et capture d'écran de l'application</b></summary>

| Contrôle | Action |
| --- | --- |
| **Ajouter** | Créer un compte |
| **Masquer les codes / Afficher les codes** | Cacher ou révéler des codes |
| **Rechercher des comptes** | Trouver un service ou un compte |
| **Équipement → Importer** | Importer des comptes avec un aperçu |
| **Équipement → Sauvegarde** | Créer une sauvegarde chiffrée |
| **Équipement → Paramètres** | Configurer le verrouillage de l'interface et le délai d'expiration du presse-papiers ; la version est en bas |

Faites défiler la liste des comptes avec la molette de la souris ou des gestes ; la barre de défilement est masquée. L'interface sombre en permanence utilise Mica Alt natif avec des couleurs dérivées du papier peint lorsque les paramètres Windows le permettent.

Capture d'écran d'un coffre-fort de test isolé avec des exemples de données publiques:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="Fenêtre principale WinOTP avec un compte de test">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="Protection des données : Windows DPAPI , AES -256- GCM , verrouillage de l&#x27;interface et limites du presse-papiers">

<details>
<summary><b>La protection des données et ses limites</b></summary>

Windows DPAPI protège le coffre-fort pour l'utilisateur actuel de Windows. Les sauvegardes portables utilisent AES -256- GCM et PBKDF2 - SHA256 avec 600 000 itérations. Le mot de passe principal verrouille le **interface**, pas d'accès par des logiciels malveillants exécutés en tant qu'utilisateur Windows. La suppression du Presse-papiers ne peut pas effacer l'historique du Presse-papiers ni les copies capturées par d'autres applications.

Les données vivent dans `%LOCALAPPDATA%\WinOTP`. La migration copie les fichiers hérités de `%LOCALAPPDATA%\NoirAuth` sans retirer les originaux. Conservez-les jusqu'à ce que vous ayez vérifié le coffre-fort migré et une sauvegarde restaurable. Voir [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="État du projet : WinUI 3 compact, flux de travail du compte et papier peint restant, contrôles de mise à l&#x27;échelle et d&#x27;emballage">

<details>
<summary><b>Installer et mettre à jour</b></summary>

1. Ouvrir [Sorties](https://github.com/sailxx/WinOTP/releases) et lisez les notes de la version sélectionnée.
2. Pour les versions portant le nouveau nom, téléchargez `WinOTP-Setup.exe`.
3. Exécutez le programme d'installation et choisissez un dossier. Aucun droit d'administrateur n'est requis.

Les données sont stockées séparément et conservées lors de la désinstallation. Créez une sauvegarde avant la mise à jour. L'interface de l'application et le programme d'installation utilisent l'anglais.

Le programme d'installation n'est pas signé par le code Windows ; SmartScreen peut avertir. Vérifiez la source et la somme de contrôle avant de décider de l'exécuter.

</details>

<details>
<summary><b>Vérifiez votre téléchargement</b></summary>

Téléchargez le programme d'installation et exécutez:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

Comparez le hachage avec la valeur SHA -256 à côté du programme d'installation dans la liste des actifs de la version GitHub. La provenance n'est pas une signature de code Windows ni une garantie de code sans vulnérabilité. Les versions plus anciennes peuvent ne pas inclure d'attestations.

</details>

<details>
<summary><b>Construire à partir des sources</b></summary>

Nécessite Windows , . Outils de construction NET SDK 10 et WinUI. Remplacez le chemin dans la première commande par votre dossier de projet.

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

Libérer les portes et les instructions: [RELEASE.md](RELEASE.md). Changements: [CHANGELOG.md](CHANGELOG.md). Générez les panneaux graphiques avec `python tools/generate_readme.py` à partir de la racine du projet.

</details>

<details>
<summary><b>Limites connues</b></summary>

- Une interface Avalonia Linux et des recettes x64 deb, rpm et AppImage sont préparées, en attendant l'acceptation et l'approbation du Linux. [Construction et limites](packaging/linux/README.md). Pas de macOS ou de synchronisation cloud.
- Linux conserve la mise en page et les couleurs compactes avec un fond sombre opaque et un Inter groupé ; Windows Mica Alt n’est pas disponible. Le mot de passe Linux crypte le coffre-fort. Transférez les comptes Windows via un mot de passe crypté `.winotp` sauvegarde.
- Mica dépend de la version Windows et de la politique de transparence. Un changement complet de fond d’écran et des tests d’acceptation à plusieurs échelles sont encore nécessaires.
- Le manifeste MSIX est une entrée d’empaquetage et non un package signé et testé pour l’installation. Inno Setup est le format de distribution.
- Les notes de chaque version décrivent son statut de publication et de vérification. Une version locale préparée n'est pas une version publiée.

</details>

<details>
<summary><b>À propos et licence</b></summary>

WinOTP est développé par Vlad ([sailxx](https://github.com/sailxx)). La source est disponible sous le [Licence MIT](LICENSE). Bogues et suggestions: [Problèmes](https://github.com/sailxx/WinOTP/issues).

</details>
