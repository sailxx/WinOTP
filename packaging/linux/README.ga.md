[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · **Gaeilge** · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Linux tógáil agus ceadú

Spriocanna x86_64 Linux , ar dtús Ubuntu 24.04 agus Fedora le . NET 10 spleáchas dúchais. Is é Avalonia an t-éadanas; níl an t-iarratas Windows WinUI gan athrú. Úsáideann Linux an leagan amach dlúth céanna, variant ciain agus dromchla dorcha atá dathaithe go héadrom ag blas an chórais (tuilleamh neodrach nuair nach bhfuil sé ar fáil): Windows Níl Mica Alt agus Segoe UI Athróg iniompartha. Tá Inter cuachta; níl aon chló Microsoft athdháilte.

Criptíonn máistirfhocal faire Linux an cruinneachán le AES -256- GCM agus PBKDF2 - SHA256 (600,000 atriall). Tá sé ag teastáil ag am tosaithe agus ní féidir é a aisghabháil. Sonraí: `$XDG_DATA_HOME/WinOTP` nó `~/.local/share/WinOTP`. Tá eolaire cruinneachán 0700 agus comhaid boghta nuachruthaithe 0600. Scríobhann siad adamhach, faoi ghlas ag scríbhneoir, agus diúltaíonn sean-athbhreithnithe. Ní stóráiltear aon rúin i roghanna. Tacaíonn cruinneachán suas le 500 cuntas agus 14 sonraí sraithe MiB (mar sin go n-oireann a chúltaca Base64 an teorainn allmhairithe 20 MiB); diúltaítear coigilteas rómhór roimh athsholáthar. Ná cóipeáil comhaid Windows DPAPI go Linux riamh : easpórtáil pasfhocal criptithe `.winotp` cúltaca ar Windows agus é a allmhairiú ar Linux . Coinnigh an fhoinse go dtí go bhfíoraítear athchóiriú.

## Forbairt áitiúil

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

Le haghaidh réamhamharc iargúlta ag baint úsáide as dintiúir phoiblí RFC amháin:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## Pacáistí

`.github/workflows/linux.yml` suiteálann sé na spleáchais ar an bpacáistiú, fíoraíonn sé achoimre phionála appimagetool, tógann sé deb/rpm/ AppImage , suiteálann agus tosaíonn sé an díb faoi Xvfb, tosaíonn an AppImage gan FUSE , agus uaslódálann sé pacáistí móide scáileáin scáileáin mar `linux-packages`. Ritheann sé ar PR agus is féidir é a rith de láimh; ní fhoilsíonn sé scaoileadh. `packaging/linux/build.sh` ritheann go háitiúil freisin ar óstach x86_64 Linux le . NET 10, fpm 1.16.0 , rpm agus squashfs-uirlisí; soláthar `APPIMAGETOOL` ag tagairt don 1.9.1 x86_64 inrite fíoraithe. Fanann gach ábhar ginte faoi `artifacts/linux`.

Fanann an sreabhadh oibre clibe le tógáil Linux agus Windows, ullmhaíonn sé ansin **dréacht** scaoileadh leis an suiteálaí agus na trí phacáiste Linux. Taispeánann GitHub díolama SHA -256 le haghaidh sócmhainní scaoilte. Déan athbhreithniú ar fhíorscáileáin Linux agus faigh cead Vlad sula bhfoilsítear iad. Ní cuid den ullmhúchán áitiúil é clibeanna a chruthú nó athruithe a bhrú.

## Glacadh fós ag teastáil

Suiteáil / bain / uasghrádú deb ar Ubuntu agus rpm ar Fedora; tástáil AppImage ar an dá cheann (FUSE nó `--appimage-extract-and-run`). Fíoraigh deasc X11 / Wayland iarbhír, scálaithe, teorainn ama gearrthaisce, roghnóirí comhad, allmhairiú QR, glasáil phasfhocal, athchóiriú cúltaca Windows agus marthanacht HOTP. Níl suiteáil RPM agus iompar cumadóir deisce clúdaithe ag post Ubuntu CI. Níl aon chomhtháthú tráidire Linux nó allmhairiú gearrthaisce-íomhá QR curtha i bhfeidhm go fóill. Tá allmhairiú Comhad QR agus allmhairiú URI ar fáil.

`assets/screenshots/linux-ui-preview.png` is léiriú fíor é ar aghaidh Avalonia arna óstáil ar Windows , ní cruthúnas ar thástáil ama rite Linux. Níl aon phacáiste eisithe ag an athrú seo.
