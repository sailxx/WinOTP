[English](README.md) · [العربية](README.ar.md) · **简体中文** · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Linux 构建和批准

目标为 x86_64 Linux，最初是 Ubuntu 24.04 和 Fedora。 NET 10 个本机依赖项。前端是Avalonia； Windows WinUI 应用程序未更改。 Linux 使用相同的紧凑布局、青色色调和由系统色调轻微着色的深色表面（不可用时中性回退）：Windows Mica Alt 和 Segoe UI Variable 不可移植。国际米兰是捆绑的；没有重新分发 Microsoft 字体。

Linux 主密码使用 AES -256- GCM 和 PBKDF2 - SHA256 加密保管库（600,000 次迭代）。它在启动时需要并且无法恢复。数据: `$XDG_DATA_HOME/WinOTP` 或者 `~/.local/share/WinOTP`。 Vault 目录为 0700，新创建的 Vault 文件为 0600。写入是原子的、写入器锁定的，并拒绝过时的修订。首选项中不存储任何秘密。一个保管库支持最多 500 个帐户和 14 MiB 序列化数据（因此其 Base64 备份符合 20 MiB 导入限制）；替换前，过大的保存将被拒绝。切勿将 Windows DPAPI 文件复制到 Linux ：导出密码加密 `.winotp` 在Windows上备份并在Linux上导入。保留源，直到验证恢复为止。

## 当地发展

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

对于仅使用公共 RFC 凭据的独立预览:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## 套餐

`.github/workflows/linux.yml` 安装打包依赖项，验证固定的 appimagetool 摘要，构建 deb/rpm/ AppImage ，在 Xvfb 下安装并启动 deb，启动不带 FUSE 的 AppImage ，并上传包和屏幕截图，如下所示 `linux-packages`。它运行在 PR 上，并且可以手动运行；它不发布版本。 `packaging/linux/build.sh` 也可在 x86_64 Linux 主机上以 . NET 10、fpm 1.16.0、rpm 和 squashfs 工具；供应 `APPIMAGETOOL` 指向经过验证的 1.9.1 x86_64 可执行文件。所有生成的内容都保留在 `artifacts/linux`.

标签工作流程等待 Linux 和 Windows 构建，然后准备 **草稿** 与安装程序和所有三个 Linux 软件包一起发布。 GitHub 显示发布资产的 SHA -256 摘要。在发布之前查看真实的 Linux 屏幕截图并获得 Vlad 的批准。创建标签或推送更改不是本地准备的一部分。

## 仍需验收

在 Ubuntu 上安装/删除/升级 deb，在 Fedora 上安装/删除/升级 rpm；在两者上测试 AppImage（FUSE 或 `--appimage-extract-and-run`)。验证实际的 X11 / Wayland 桌面、缩放、剪贴板超时、文件选择器、QR 导入、密码锁定、Windows 备份恢复和 HOTP 持久性。 Ubuntu CI 作业不涵盖 RPM 安装和桌面合成器行为。尚未实现 Linux 托盘集成或剪贴板图像 QR 导入。可以导入文件QR和URI。

`assets/screenshots/linux-ui-preview.png` 是 Windows 上托管的 Avalonia 前端的真实渲染，而不是 Linux 运行时测试的证明。此更改尚未发布任何软件包。
