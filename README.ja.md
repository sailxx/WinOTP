[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · **日本語** · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="WinOTPロゴ">

# WinOTP

**あなたのコード。あなたのデバイス。 Windows 11 の認証システム。**

壁紙由来の色のコンパクトなダークウィンドウの TOTP と HOTP。登録やクラウド同期を行わずに、バックアップを検索、インポート、暗号化できます。

ヴラドが建てた · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — コード、デバイス。インターフェイスの図">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="Windows11用ダウンロード"></a>&nbsp;&nbsp;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="新着情報"></a>

Windows 11・x64・英語インターフェース

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="機能: TOTP および HOTP 、ローカルボルト、インポート、検索、バックアップ、クラウド同期なし">

<details>
<summary><b>機能の詳細</b></summary>

### ワンタイムコード

RFC 6238 TOTP および RFC 4226 HOTP ; SHA -1/256/512; 6桁または8桁。アカウントとコードを追加、編集、削除、コピーします。検索とお気に入りにより、適切なエントリをすぐにアクセスできるようになります。

### アカウントを持参してください

otpauth URI、Google Authenticator 移行 URI、QR イメージ、および Aegis JSON をインポートします。保存する前にエントリをプレビューし、既存のアカウントをスキップします。

### 暗号化されたバックアップ

ポータブル `.winotp` ファイルには別のパスワードが使用されます。そのパスワードを別に保管し、ソース データを削除する前に復元を確認してください。

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="コントロール: コードの追加、非表示、検索、インポート、バックアップ、設定">

<details>
<summary><b>コントロールとアプリケーションのスクリーンショット</b></summary>

| コントロール | アクション |
| --- | --- |
| **追加** | アカウントを作成する |
| **コードを隠す / コードを表示する** | コードを隠すか明らかにする |
| **アカウントを検索する** | サービスまたはアカウントを探す |
| **ギア → インポート** | プレビューを使用してアカウントをインポートする |
| **ギア→バックアップ** | 暗号化されたバックアップを作成する |
| **ギア→設定** | インターフェースのロックとクリップボードのタイムアウトを構成します。バージョンは一番下にあります |

マウス ホイールまたはジェスチャを使用してアカウント リストをスクロールします。スクロールバーが非表示になります。永久に暗いインターフェイスは、Windows 設定で許可されている場合、壁紙由来の色を持つネイティブの Mica Alt を使用します。

公開サンプル データを含む分離されたテスト ボールトのスクリーンショット:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="テスト アカウントを含む WinOTP メイン ウィンドウ">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="データ保護: Windows DPAPI 、 AES -256- GCM 、インターフェース ロックおよびクリップボード制限">

<details>
<summary><b>データ保護とその限界</b></summary>

Windows DPAPI は、現在の Windows ユーザーのボールトを保護します。ポータブル バックアップには、600,000 回の反復で AES -256- GCM および PBKDF2 ～ SHA256 を使用します。マスターパスワードによりロックされます。 **インタフェース**, Windows ユーザーとして実行されるマルウェアによるアクセスはありません。クリップボードをクリアしても、クリップボードの履歴や他のアプリによってキャプチャされたコピーは消去できません。

データが存在する `%LOCALAPPDATA%\WinOTP`。移行によりレガシー ファイルがコピーされます `%LOCALAPPDATA%\NoirAuth` 原稿を取り出さずに。移行されたコンテナーと復元可能なバックアップを確認するまで、これらを保管しておいてください。見る [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="プロジェクトのステータス: コンパクト WinUI 3、アカウント ワークフローと残りの壁紙、スケーリングとパッケージングのチェック">

<details>
<summary><b>インストールとアップデート</b></summary>

1. 開ける [リリース](https://github.com/sailxx/WinOTP/releases) 選択したバージョンのメモを読みます。
2. 新しい名前のリリースについては、ダウンロードしてください `WinOTP-Setup.exe`.
3. セットアップを実行し、フォルダーを選択します。管理者権限は必要ありません。

データは個別に保存され、アンインストール時にも保持されます。アップデートする前にバックアップを作成してください。アプリケーションのインターフェースとインストーラーは英語を使用します。

インストーラーは Windows コード署名されていません。 SmartScreen が警告する場合があります。実行するかどうかを決定する前に、ソースとチェックサムを確認してください。

</details>

<details>
<summary><b>ダウンロードを確認する</b></summary>

インストーラーをダウンロードして実行します:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

ハッシュを、GitHub リリース アセット リストのインストーラーの横にある SHA -256 値と比較します。来歴は、Windows コード署名や脆弱性のないコードの保証ではありません。古いリリースには証明書が含まれていない場合があります。

</details>

<details>
<summary><b>ソースからビルドする</b></summary>

Windows が必要です。 NET SDK 10 および WinUI ビルド ツール。最初のコマンドのパスをプロジェクト フォルダーに置き換えます。

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

ゲートと指示を解除する: [RELEASE.md](RELEASE.md)。変更点: [CHANGELOG.md](CHANGELOG.md)。グラフィックパネルを生成するには `python tools/generate_readme.py` プロジェクトのルートから。

</details>

<details>
<summary><b>既知の制限事項</b></summary>

- Avalonia Linux フロントエンドと x64 deb、rpm、および AppImage レシピが準備されており、Linux の承認と承認が保留されています。 [ビルドと制限事項](packaging/linux/README.md)。 macOSやクラウド同期はありません。
- Linux は、コンパクトなレイアウトと色を保ち、不透明な暗い背景とバンドルされたインターを備えています。 Windows マイカ アルトは使用できません。 Linux パスワードはボールトを暗号化します。パスワードで暗号化されたパスワードを介して Windows アカウントを転送します `.winotp` バックアップ。
- マイカはWindowsのバージョンと透明度ポリシーに依存します。壁紙の完全な変更と複数規模の受け入れテストが依然として必要です。
- MSIX マニフェストはパッケージ化入力であり、署名済みのインストールテスト済みパッケージではありません。配布形式はInno Setupです。
- 各リリースのノートには、その公開と検証のステータスが記載されています。準備されたローカル バージョンは公開されたリリースではありません。

</details>

<details>
<summary><b>概要とライセンス</b></summary>

WinOTPはヴラドが開発 ([sailxx](https://github.com/sailxx))。ソースは以下から入手できます [MITライセンス](LICENSE)。バグと提案: [問題](https://github.com/sailxx/WinOTP/issues).

</details>
