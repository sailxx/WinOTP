[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · **日本語** · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Linux のビルドと承認

x86_64 Linux をターゲットとし、当初は Ubuntu 24.04 および を備えた Fedora をターゲットとします。 NET 10 のネイティブ依存関係。フロントエンドは Avalonia です。 Windows WinUI アプリケーションは変更されていません。 Linux は、同じコンパクトなレイアウト、シアンのアクセント、およびシステム アクセントによって軽く着色された暗い表面を使用しています (使用できない場合はニュートラル フォールバック): Windows Mica Alt および Segoe UI Variable は移植できません。インターはバンドルされています。 Microsoft フォントは再配布されません。

Linux マスター パスワードは、AES -256- GCM および PBKDF2 - SHA256 (600,000 回の反復) でボールトを暗号化します。これは起動時に必要であり、回復することはできません。データ: `$XDG_DATA_HOME/WinOTP` または `~/.local/share/WinOTP`。 Vault ディレクトリは 0700 で、新しく作成された Vault ファイルは 0600 です。書き込みはアトミックでライターロックされており、古いリビジョンは拒否されます。シークレットは設定に保存されません。コンテナーは最大 500 のアカウントと 14 MiB のシリアル化データをサポートします (そのため、Base64 バックアップは 20 MiB のインポート制限に適合します)。サイズ超過の保存は置換前に拒否されます。 Windows DPAPI ファイルを Linux にコピーしないでください。パスワードで暗号化されたファイルをエクスポートします。 `.winotp` Windows でバックアップし、それを Linux にインポートします。復元が確認されるまでソースを保管してください。

## 地域発展

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

パブリック RFC 資格情報のみを使用した分離プレビューの場合:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## パッケージ

`.github/workflows/linux.yml` パッケージの依存関係をインストールし、固定された appimagetool ダイジェストを検証し、 deb/rpm/ AppImage をビルドし、 Xvfb の下に deb をインストールして開始し、 FUSE なしで AppImage を開始し、パッケージとスクリーンショットを次のようにアップロードします。 `linux-packages`。 PR 上で実行され、手動で実行することもできます。リリースは公開されません。 `packaging/linux/build.sh` は、x86_64 Linux ホスト上でもローカルで実行されます。 NET 10、fpm 1.16.0、rpm および squashfs-tools;供給 `APPIMAGETOOL` 検証済みの 1.9.1 x86_64 実行可能ファイルを指します。生成されたすべてのコンテンツは以下に残ります `artifacts/linux`.

タグ ワークフローは、Linux および Windows のビルドを待機してから、 **下書き** インストーラーと 3 つの Linux パッケージすべてとともにリリースされます。 GitHub は、リリース アセットの SHA -256 ダイジェストを表示します。公開する前に、実際の Linux のスクリーンショットを確認し、Vlad の承認を得てください。タグの作成や変更のプッシュは、ローカルの準備には含まれません。

## 引き続き承認が必要です

Ubuntu では deb を、Fedora では rpm をインストール/削除/アップグレードします。両方で AppImage をテストします (FUSE または `--appimage-extract-and-run`)。実際の X11 / Wayland デスクトップ、スケーリング、クリップボード タイムアウト、ファイル ピッカー、QR インポート、パスワード ロック、Windows バックアップ復元、および HOTP 永続性を検証します。 RPM のインストールとデスクトップ コンポジターの動作は、Ubuntu CI ジョブの対象外です。 Linux トレイの統合やクリップボード画像の QR インポートはまだ実装されていません。ファイルQRインポート、URIインポートが可能です。

`assets/screenshots/linux-ui-preview.png` これは、 Windows でホストされている Avalonia フロントエンドの実際のレンダリングであり、Linux ランタイム テストの証拠ではありません。この変更によりリリースされたパッケージはありません。
