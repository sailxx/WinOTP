[English](README.md) · [العربية](README.ar.md) · **简体中文** · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

<div align="center">

<img src="assets/winotp-icon.svg" width="96" alt="WinOTP 标志">

# WinOTP

**你的代码。你的设备。您的 Windows 11 验证器。**

TOTP 和 HOTP 位于紧凑的深色窗口中，颜色源自壁纸。搜索、导入和加密备份，无需注册或云同步。

由弗拉德建造 · [sailxx](https://github.com/sailxx).


![Windows 11](https://img.shields.io/badge/Windows-11-2E9BFF)
![WinUI 3](https://img.shields.io/badge/WinUI-3-2E9BFF)
[![MIT](https://img.shields.io/badge/license-MIT-2E9BFF)](LICENSE)

<br>
<img src="assets/readme/hero.svg" width="100%" alt="WinOTP — 您的代码，您的设备；界面图">

<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/download.svg" height="52" alt="下载 Windows 11"></a>&nbsp;;<a href="https://github.com/sailxx/WinOTP/releases"><img src="assets/readme/whats-new.svg" height="52" alt="什么是新的"></a>

Windows 11 · x64 · 英文界面

</div>

<br>
<img src="assets/readme/features.svg" width="100%" alt="功能：TOTP 和 HOTP、本地保管库、导入、搜索、备份，无云同步">

<details>
<summary><b>有关功能的更多信息</b></summary>

### 一次性代码

RFC 6238 TOTP 和 RFC 4226 HOTP ； SHA -1/256/512； 6 或 8 位数字。添加、编辑、删除和复制帐户和代码。搜索和收藏夹让正确的条目触手可及。

### 带上你的账户

导入 otpauth URI、Google Authenticator 迁移 URI、QR 图像和 Aegis JSON 。保存前预览条目并跳过现有帐户。

### 加密备份

便携的 `.winotp` 文件使用单独的密码。单独保存该密码并在删除源数据之前验证恢复情况。

</details>

<br>
<img src="assets/readme/controls.svg" width="100%" alt="控件：添加、隐藏代码、搜索、导入、备份和设置">

<details>
<summary><b>控件和应用程序屏幕截图</b></summary>

| 控制 | 行动 |
| --- | --- |
| **添加** | 创建一个帐户 |
| **隐藏代码/显示代码** | 隐藏或透露代码 |
| **搜索账户** | 查找服务或帐户 |
| **齿轮 → 进口** | 导入帐户并预览 |
| **齿轮 → 备份** | 创建加密备份 |
| **齿轮 → 设置** | 配置界面锁定和剪贴板超时；版本在底部 |

通过鼠标滚轮或手势滚动账户列表；滚动条被隐藏。在 Windows 设置允许的情况下，永久黑暗的界面使用原生 Mica Alt 和壁纸衍生的颜色。

带有公共示例数据的独立测试库的屏幕截图:

<img src="assets/screenshots/winotp-compact-mica.png" width="540" alt="WinOTP 带有测试帐户的主窗口">

</details>

<br>
<img src="assets/readme/security.svg" width="100%" alt="数据保护：Windows DPAPI、AES -256- GCM、界面锁定和剪贴板限制">

<details>
<summary><b>数据保护及其局限性</b></summary>

Windows DPAPI 保护当前 Windows 用户的保管库。便携式备份使用 AES -256- GCM 和 PBKDF2 - SHA256 进行 600,000 次迭代。主密码锁定 **界面**, 不会被以 Windows 用户身份运行的恶意软件访问。剪贴板清除无法删除剪贴板历史记录或其他应用程序捕获的副本。

数据存在于 `%LOCALAPPDATA%\WinOTP`。迁移从以下位置复制旧文件 `%LOCALAPPDATA%\NoirAuth` 无需删除原件。保留它们，直到您验证了迁移的保管库和可恢复的备份。看 [SECURITY.md](SECURITY.md).

</details>

<br>
<img src="assets/readme/roadmap.svg" width="100%" alt="项目状态：紧凑型 WinUI 3、帐户工作流程和剩余壁纸、缩放和打包检查">

<details>
<summary><b>安装和更新</b></summary>

1. 打开 [发布](https://github.com/sailxx/WinOTP/releases) 并阅读所选版本的注释。
2. 对于带有新名称的版本，请下载 `WinOTP-Setup.exe`.
3. 运行安装程序并选择一个文件夹。不需要管理员权限。

数据单独存储并在卸载时保留。更新前创建备份。应用程序界面和安装程序使用英语。

安装程序未经过 Windows 代码签名； SmartScreen 可能会发出警告。在决定是否运行之前检查源和校验和。

</details>

<details>
<summary><b>验证您的下载</b></summary>

下载安装程序并运行:

```powershell
cd $HOME\Downloads
gh attestation verify WinOTP-Setup.exe --repo sailxx/WinOTP
Get-FileHash .\WinOTP-Setup.exe -Algorithm SHA256
```

将哈希值与 GitHub 发布资产列表中安装程序旁边的 SHA -256 值进行比较。出处不是 Windows 代码签名或无漏洞代码的保证。较旧的版本可能不包含证明。

</details>

<details>
<summary><b>从源代码构建</b></summary>

需要 Windows , . NET SDK 10 和 WinUI 构建工具。将第一个命令中的路径替换为您的项目文件夹。

```cmd
cd /d C:\path\to\WinOTP
dotnet run --project tests/OtpVectors/OtpVectors.csproj -c Release
dotnet build src/WinOTP/WinOTP.csproj -c Release -p:Platform=x64 -warnaserror
```

释放门和说明: [RELEASE.md](RELEASE.md)。变化: [CHANGELOG.md](CHANGELOG.md)。生成图形面板 `python tools/generate_readme.py` 从项目根目录。

</details>

<details>
<summary><b>已知的限制</b></summary>

- Avalonia Linux 前端和 x64 deb、rpm 和 AppImage 配方已准备就绪，等待 Linux 接受和批准。 [构建和限制](packaging/linux/README.md)。没有 macOS 或云同步。
- Linux 保持紧凑的布局和颜色，带有不透明的深色背景和捆绑的 Inter； Windows Mica Alt 不可用。 Linux 密码对保管库进行加密。通过密码加密转账Windows账户 `.winotp` 备份。
- Mica 取决于 Windows 版本和透明度政策。仍然需要进行全面的壁纸更换和多尺度验收测试。
- MSIX 清单是打包输入，而不是经过签名、安装测试的包。 Inno Setup 是分发格式。
- 每个版本的注释描述了其发布和验证状态。准备好的本地版本不是已发布的版本。

</details>

<details>
<summary><b>关于和许可</b></summary>

WinOTP由Vlad开发 ([sailxx](https://github.com/sailxx))。来源可在 [MIT 许可证](LICENSE)。错误和建议: [问题](https://github.com/sailxx/WinOTP/issues).

</details>
