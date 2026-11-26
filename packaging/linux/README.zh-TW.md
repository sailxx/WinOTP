[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · **繁體中文** · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Linux 建置與核准

目標為 x86_64 Linux，最初是 Ubuntu 24.04 和 Fedora。 NET 10 個本機相依性。前端是Avalonia；Windows WinUI 應用程式未更改。 Linux 使用相同的緊湊佈局、青色色調和由系統色調輕微著色的深色表面（不可用時中性回退）：Windows Mica Alt 和 Segoe UI Variable 不可移植。國際米蘭是捆綁的；沒有重新分發 Microsoft 字體。

Linux 主密碼使用 AES -256- GCM 和 PBKDF2 - SHA256 加密保管庫（600,000 次迭代）。它在啟動時需要並且無法恢復。數據: `$XDG_DATA_HOME/WinOTP` 或者 `~/.local/share/WinOTP`。 Vault 目錄為 0700，新建立的 Vault 檔案為 0600。寫入是原子的、寫入器鎖定的，並拒絕過時的修訂。首選項中不儲存任何秘密。一個保管庫支援最多 500 個帳戶和 14 MiB 序列化資料（因此其 Base64 備份符合 20 MiB 導入限制）；替換前，過大的保存將被拒絕。切勿將 Windows DPAPI 檔案複製到 Linux ：匯出密碼加密 `.winotp` 在Windows上備份並在Linux上匯入。保留來源，直到驗證恢復為止。

## 當地發展

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

對於僅使用公共 RFC 憑證的獨立預覽:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## 套餐

`.github/workflows/linux.yml` 安裝打包依賴項，驗證固定的 appimagetool 摘要，建置 deb/rpm/ AppImage ，在 Xvfb 下安裝並啟動 deb，啟動不帶 FUSE 的 AppImage ，並上傳套件和螢幕截圖，如下所示 `linux-packages`。它運行在 PR 上，並且可以手動運行；它不發布版本。 `packaging/linux/build.sh` 也可在 x86_64 Linux 主機上以 . NET 10、fpm 1.16.0、rpm 和 squashfs 工具；供應 `APPIMAGETOOL` 指向經過驗證的 1.9.1 x86_64 可執行檔。所有產生的內容都保留在 `artifacts/linux`.

標籤工作流程等待 Linux 和 Windows 構建，然後準備 **草稿** 與安裝程式和所有三個 Linux 軟體包一起發布。 GitHub 顯示發布資產的 SHA -256 摘要。在發布之前查看真實的 Linux 螢幕截圖並獲得 Vlad 的批准。建立標籤或推送變更不是本地準備的一部分。

## 仍需驗收

在 Ubuntu 上安裝/刪除/升級 deb，在 Fedora 上安裝/刪除/升級 rpm；在兩者上測試 AppImage（FUSE 或 `--appimage-extract-and-run`)。驗證實際的 X11 / Wayland 桌面、縮放、剪貼簿逾時、檔案選擇器、QR 匯入、密碼鎖定、Windows 備份還原和 HOTP 持久性。 Ubuntu CI 作業不涵蓋 RPM 安裝和桌面合成器行為。尚未實現 Linux 托盤整合或剪貼簿影像 QR 導入。可以導入檔案QR和URI。

`assets/screenshots/linux-ui-preview.png` 是 Windows 上託管的 Avalonia 前端的真實渲染，而不是 Linux 運行時測試的證明。此更改尚未發布任何軟體包。
