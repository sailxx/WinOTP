[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · **Bahasa Indonesia** · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Pembuatan dan persetujuan Linux

Menargetkan x86_64 Linux, awalnya Ubuntu 24.04 dan Fedora dengan . NET 10 dependensi asli. Bagian depannya adalah Avalonia ; aplikasi Windows WinUI tidak berubah. Linux menggunakan tata letak ringkas yang sama, aksen cyan, dan permukaan gelap yang diberi sedikit warna oleh aksen sistem (penggantian netral jika tidak tersedia): Windows Mica Alt dan Segoe UI Variable tidak portabel. Inter dibundel; tidak ada font Microsoft yang didistribusikan ulang.

Kata sandi utama Linux mengenkripsi brankas dengan AES -256- GCM dan PBKDF2 - SHA256 (600.000 iterasi). Ini diperlukan saat startup dan tidak dapat dipulihkan. Data: `$XDG_DATA_HOME/WinOTP` atau `~/.local/share/WinOTP`. Direktori Vault adalah 0700 dan file vault yang baru dibuat adalah 0600. Penulisan bersifat atomik, dikunci oleh penulis, dan menolak revisi yang sudah usang. Tidak ada rahasia yang disimpan dalam preferensi. Vault mendukung hingga 500 akun dan 14 MiB data serial (sehingga cadangan Base64-nya sesuai dengan batas impor 20 MiB); simpanan yang terlalu besar ditolak sebelum penggantian. Jangan pernah menyalin file Windows DPAPI ke Linux : ekspor yang dienkripsi kata sandi `.winotp` cadangan di Windows dan impor di Linux. Simpan sumbernya sampai restorasi diverifikasi.

## Pembangunan lokal

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

Untuk pratinjau terisolasi hanya menggunakan kredensial RFC publik:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## Paket

`.github/workflows/linux.yml` menginstal dependensi pengemasan, memverifikasi intisari appimagetool yang disematkan, membangun deb/rpm/ AppImage , menginstal dan memulai deb di bawah Xvfb, memulai AppImage tanpa FUSE , dan mengunggah paket plus tangkapan layar sebagai `linux-packages`. Ini berjalan pada PR dan dapat dijalankan secara manual; itu tidak menerbitkan rilis. `packaging/linux/build.sh` juga berjalan secara lokal pada host x86_64 Linux dengan . NET 10, fpm 1.16.0, rpm dan alat squashfs; memasok `APPIMAGETOOL` menunjuk ke executable 1.9.1 x86_64 yang terverifikasi. Semua konten yang dihasilkan tetap berada di bawah `artifacts/linux`.

Alur kerja tag menunggu pembuatan Linux dan Windows, lalu menyiapkan a **draf** rilis dengan penginstal dan ketiga paket Linux. GitHub menunjukkan intisari SHA -256 untuk aset rilis. Tinjau tangkapan layar Linux yang asli dan dapatkan persetujuan Vlad sebelum dipublikasikan. Membuat tag atau mendorong perubahan bukan bagian dari persiapan lokal.

## Penerimaan masih diperlukan

Instal/hapus/upgrade deb di Ubuntu dan rpm di Fedora; uji AppImage pada keduanya ( FUSE atau `--appimage-extract-and-run`). Verifikasi desktop X11 / Wayland yang sebenarnya, penskalaan, batas waktu clipboard, pemilih file, impor QR, penguncian kata sandi, pemulihan cadangan Windows, dan persistensi HOTP. Instalasi RPM dan perilaku kompositor desktop tidak tercakup dalam pekerjaan Ubuntu CI. Belum ada integrasi baki Linux atau impor gambar papan klip QR yang diterapkan. Impor file QR dan impor URI tersedia.

`assets/screenshots/linux-ui-preview.png` adalah rendering nyata dari frontend Avalonia yang dihosting di Windows , bukan bukti uji runtime Linux. Tidak ada paket yang dirilis oleh perubahan ini.
