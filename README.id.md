[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · **Bahasa Indonesia** · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="Logo WinOTP">

# WinOTP

**Kode Anda. Perangkat Anda. Pengautentikator Anda untuk Windows 11.**

TOTP dan HOTP dalam jendela gelap kompak dengan warna yang berasal dari wallpaper. Cari, impor, dan cadangan terenkripsi tanpa registrasi atau sinkronisasi cloud.

Dibangun oleh Vlad · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — kode Anda, perangkat Anda; ilustrasi antarmuka">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="Unduh untuk Windows 11"></a>&nbsp; & nbsp;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="Apa yang baru"></a>

Windows 11 · x64 · Antarmuka bahasa Inggris

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="Fitur: TOTP dan HOTP, brankas lokal, impor, pencarian, pencadangan, dan tanpa sinkronisasi cloud">

<details>
<summary><b>Lebih lanjut tentang fiturnya</b></summary>

### Kode satu kali

RFC 6238 TOTP dan RFC 4226 HOTP ; SHA -1/256/512; 6 atau 8 digit. Tambahkan, edit, hapus, dan salin akun dan kode. Pencarian dan favorit membuat entri yang tepat tetap mudah dijangkau.

### Bawa akun Anda

Impor URI otpauth, URI migrasi Google Authenticator, gambar QR, dan Aegis JSON . Pratinjau entri sebelum menyimpan dan lewati akun yang ada.

### Cadangan terenkripsi

Portabel `.winotp` file menggunakan kata sandi terpisah. Simpan kata sandi tersebut secara terpisah dan verifikasi pemulihan sebelum menghapus data sumber.

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="Kontrol: Tambah, Sembunyikan kode, Pencarian, Impor, Cadangan, dan Pengaturan">

<details>
<summary><b>Kontrol dan tangkapan layar aplikasi</b></summary>

| Kontrol | Tindakan |
| --- | --- |
| **Menambahkan** | Buat akun |
| **Sembunyikan kode / Tampilkan kode** | Menyembunyikan atau mengungkapkan kode |
| **Cari akun** | Temukan layanan atau akun |
| **Perlengkapan → Impor** | Impor akun dengan pratinjau |
| **Perlengkapan → Cadangan** | Buat cadangan terenkripsi |
| **Perlengkapan → Pengaturan** | Konfigurasikan kunci antarmuka dan batas waktu clipboard; versi ada di bagian bawah |

Gulir daftar akun dengan roda mouse atau gerakan; bilah gulir disembunyikan. Antarmuka gelap permanen menggunakan Mica Alt asli dengan warna yang berasal dari wallpaper jika diizinkan oleh pengaturan Windows.

Cuplikan layar brankas pengujian terisolasi dengan data contoh publik:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="Jendela utama WinOTP dengan akun uji">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="Perlindungan data: Windows DPAPI, AES -256- GCM, kunci antarmuka dan batas clipboard">

<details>
<summary><b>Perlindungan data dan batasannya</b></summary>

Windows DPAPI melindungi brankas untuk pengguna Windows saat ini. Backup portabel menggunakan AES -256- GCM dan PBKDF2 - SHA256 dengan 600.000 iterasi. Kata sandi utama mengunci **antarmuka**, tidak diakses oleh malware yang berjalan sebagai pengguna Windows Anda. Pembersihan papan klip tidak dapat menghapus riwayat papan klip atau salinan yang diambil oleh aplikasi lain.

Data ada di dalamnya `%LOCALAPPDATA%\WinOTP`. Migrasi menyalin file lama dari `%LOCALAPPDATA%\NoirAuth` tanpa menghapus aslinya. Simpan data tersebut hingga Anda memverifikasi brankas yang dimigrasi dan cadangan yang dapat dipulihkan. Melihat [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="Status proyek: WinUI 3 ringkas, alur kerja akun dan wallpaper yang tersisa, penskalaan dan pemeriksaan pengemasan">

<details>
<summary><b>Instal dan perbarui</b></summary>

1. Membuka [Rilis](https://github.com/sailxx/WinOTP/releases) dan membaca catatan versi yang dipilih.
2. Untuk rilis yang membawa nama baru, unduh `WinOTP-Setup.exe`.
3. Jalankan Setup dan pilih folder. Tidak diperlukan hak administrator.

Data disimpan secara terpisah dan disimpan saat menguninstall. Buat cadangan sebelum memperbarui. Antarmuka aplikasi dan installer menggunakan bahasa Inggris.

Pemasang tidak diberi kode Windows; SmartScreen mungkin memperingatkan. Periksa sumber dan checksum sebelum memutuskan apakah akan menjalankannya.

</details>

<details>
<summary><b>Verifikasi unduhan Anda</b></summary>

Unduh penginstal dan jalankan:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

Bandingkan hash dengan nilai SHA -256 di sebelah penginstal dalam daftar aset rilis GitHub. Asalnya bukanlah penandatanganan kode Windows atau jaminan kode bebas kerentanan. Rilisan lama mungkin tidak menyertakan pengesahan.

</details>

<details>
<summary><b>Bangun dari sumber</b></summary>

Memerlukan Windows, . Alat pembuatan NET SDK 10 dan WinUI. Ganti jalur pada perintah pertama dengan folder proyek Anda.

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

Lepaskan gerbang dan instruksi: [RELEASE.md](RELEASE.md). Perubahan: [CHANGELOG.md](CHANGELOG.md). Hasilkan panel grafis dengan `python tools/generate_readme.py` dari akar proyek.

</details>

<details>
<summary><b>Keterbatasan yang diketahui</b></summary>

- Frontend Avalonia Linux dan deb x64, rpm, dan resep AppImage disiapkan, menunggu penerimaan dan persetujuan Linux. [Membangun dan membatasi](packaging/linux/README.md). Tidak ada macOS atau sinkronisasi cloud.
- Linux mempertahankan tata letak dan warna yang ringkas dengan latar belakang gelap buram dan paket Inter; Windows Mika Alt tidak tersedia. Kata sandi Linux mengenkripsi brankas. Transfer akun Windows melalui kata sandi yang dienkripsi `.winotp` cadangan.
- Mica bergantung pada versi Windows dan kebijakan transparansi. Pengujian perubahan wallpaper penuh dan penerimaan multi-skala masih diperlukan.
- Manifes MSIX adalah masukan pengemasan, bukan paket yang ditandatangani dan telah diuji instalasinya. Inno Setup adalah format distribusi.
- Catatan setiap rilis menjelaskan status publikasi dan verifikasinya. Versi lokal yang disiapkan bukanlah rilis yang dipublikasikan.

</details>

<details>
<summary><b>Tentang dan lisensi</b></summary>

WinOTP dikembangkan oleh Vlad ([sailxx](https://github.com/sailxx)). Sumber tersedia di bawah [Lisensi MIT](LICENSE). Bug dan saran: [Masalah](https://github.com/sailxx/WinOTP/issues).

</details>
