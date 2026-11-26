[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · **繁體中文** · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="WinOTP 標誌">

# WinOTP

**你的代碼。你的設備。您的 Windows 11 驗證器。**

TOTP 和 HOTP 位於緊湊的深色視窗中，顏色源自於壁紙。搜尋、匯入和加密備份，無需註冊或雲端同步。

由弗拉德建造 · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — 您的程式碼，您的裝置；介面圖">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="下載 Windows 11"></a>&nbsp;;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="什麼是新的"></a>

Windows 11 · x64 · 英文介面

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="功能：TOTP 和 HOTP、本機保管庫、匯入、搜尋、備份，無雲端同步">

<details>
<summary><b>有關功能的更多信息</b></summary>

### 免洗程式碼

RFC 6238 TOTP 和 RFC 4226 HOTP ； SHA -1/256/512； 6 或 8 位數。新增、編輯、刪除和複製帳戶和程式碼。搜尋和收藏夾讓正確的條目觸手可及。

### 帶上你的帳戶

匯入 otpauth URI、Google Authenticator 遷移 URI、QR 影像和 Aegis JSON 。儲存前預覽條目並跳過現有帳戶。

### 加密備份

便攜的 `.winotp` 文件使用單獨的密碼。單獨儲存該密碼並在刪除來源資料之前驗證復原情況。

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="控制項：新增、隱藏程式碼、搜尋、匯入、備份和設置">

<details>
<summary><b>控制項和應用程式螢幕截圖</b></summary>

| 控制 | 行動 |
| --- | --- |
| **添加** | 建立一個帳戶 |
| **隱藏代碼/顯示代碼** | 隱藏或透露程式碼 |
| **搜尋帳戶** | 尋找服務或帳戶 |
| **齒輪 → 進口** | 導入帳戶並預覽 |
| **齒輪 → 備份** | 建立加密備份 |
| **齒輪 → 設定** | 配置介面鎖定和剪貼簿逾時；版本在底部 |

透過滑鼠滾輪或手勢滾動帳戶清單；滾動條被隱藏。在 Windows 設定允許的情況下，永久黑暗的介面使用原生 Mica Alt 和壁紙衍生的顏色。

帶有公共範例資料的獨立測試庫的螢幕截圖:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="WinOTP 帶有測試帳戶的主窗口">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="資料保護：Windows DPAPI、AES -256- GCM、介面鎖定與剪貼簿限制">

<details>
<summary><b>資料保護及其局限性</b></summary>

Windows DPAPI 保護目前 Windows 使用者的保管庫。便攜式備份使用 AES -256- GCM 和 PBKDF2 - SHA256 進行 600,000 次迭代。主密碼鎖定 **介面**, 不會被以 Windows 使用者身分執行的惡意軟體存取。剪貼簿清除無法刪除剪貼簿歷史記錄或其他應用程式擷取的副本。

數據存在於 `%LOCALAPPDATA%\WinOTP`。遷移從以下位置複製舊文件 `%LOCALAPPDATA%\NoirAuth` 無需刪除原件。保留它們，直到您驗證了遷移的保管庫和可還原的備份。看 [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="專案狀態：緊湊型 WinUI 3、帳戶工作流程和剩餘桌布、縮放和打包檢查">

<details>
<summary><b>安裝和更新</b></summary>

1. 打開 [發布](https://github.com/sailxx/WinOTP/releases) 並閱讀所選版本的註釋。
2. 對於帶有新名稱的版本，請下載 `WinOTP-Setup.exe`.
3. 運行安裝程式並選擇一個資料夾。不需要管理員權限。

資料單獨儲存並在卸載時保留。更新前建立備份。應用程式介面和安裝程式使用英語。

安裝程式未經過 Windows 程式碼簽署； SmartScreen 可能會發出警告。在決定是否運行之前檢查來源和校驗和。

</details>

<details>
<summary><b>驗證您的下載</b></summary>

下載安裝程式並執行:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

將雜湊值與 GitHub 發布資產清單中安裝程式旁的 SHA -256 值進行比較。來源不是 Windows 程式碼簽署或無漏洞程式碼的保證。較舊的版本可能不包含證明。

</details>

<details>
<summary><b>從原始碼構建</b></summary>

需要 Windows , . NET SDK 10 和 WinUI 建置工具。將第一個命令中的路徑替換為您的專案資料夾。

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

釋放門和說明: [RELEASE.md](RELEASE.md)。變化: [CHANGELOG.md](CHANGELOG.md)。產生圖形面板 `python tools/generate_readme.py` 從專案根目錄。

</details>

<details>
<summary><b>已知的限制</b></summary>

- Avalonia Linux 前端和 x64 deb、rpm 和 AppImage 配方已準備就緒，等待 Linux 接受和批准。 [建置和限制](packaging/linux/README.md)。沒有 macOS 或雲端同步。
- Linux 保持緊湊的佈局和顏色，帶有不透明的深色背景和捆綁的 Inter； Windows Mica Alt 不可用。 Linux 密碼對保管庫進行加密。透過密碼加密轉帳Windows帳戶 `.winotp` 備份。
- Mica 取決於 Windows 版本和透明度政策。仍需要進行全面的壁紙更換和多尺度驗收測試。
- MSIX 清單是打包輸入，而不是經過簽名、安裝測試的套件。 Inno Setup 是分發格式。
- 每個版本的註釋描述了其發布和驗證狀態。準備好的本地版本不是已發布的版本。

</details>

<details>
<summary><b>關於和許可</b></summary>

WinOTP由Vlad開發 ([sailxx](https://github.com/sailxx))。來源可在 [MIT 許可證](LICENSE)。錯誤和建議: [問題](https://github.com/sailxx/WinOTP/issues).

</details>
