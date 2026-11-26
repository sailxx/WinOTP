[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · **한국어** · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · [Tiếng Việt](README.vi.md)

# Linux 빌드 및 승인

x86_64 Linux, 처음에는 Ubuntu 24.04 및 . NET 10 기본 종속성. 프런트엔드는 Avalonia 입니다. Windows WinUI 애플리케이션은 변경되지 않았습니다. Linux는 동일한 컴팩트 레이아웃, 청록색 액센트 및 시스템 액센트로 살짝 착색된 어두운 표면을 사용합니다(사용할 수 없는 경우 중립 대체). Windows Mica Alt 및 Segoe UI Variable은 이식 가능하지 않습니다. 인터는 번들로 제공됩니다. Microsoft 글꼴은 재배포되지 않습니다.

Linux 마스터 비밀번호는 AES -256- GCM 및 PBKDF2 - SHA256(600,000회 반복)로 저장소를 암호화합니다. 시작 시 필요하며 복구할 수 없습니다. 데이터: `$XDG_DATA_HOME/WinOTP` 또는 `~/.local/share/WinOTP`. Vault 디렉토리는 0700이고 새로 생성된 Vault 파일은 0600입니다. 쓰기는 원자성, 작성자 잠금 및 오래된 개정 거부입니다. 기본 설정에는 비밀이 저장되지 않습니다. Vault는 최대 500개의 계정과 14MiB의 직렬 데이터를 지원합니다(따라서 Base64 백업은 20MiB 가져오기 제한에 맞습니다). 크기 초과 저장은 교체 전에 거부됩니다. Windows DPAPI 파일을 Linux로 복사하지 마십시오. 비밀번호로 암호화된 파일을 내보냅니다. `.winotp` Windows에 백업하고 Linux에 가져옵니다. 복원이 확인될 때까지 소스를 보관하세요.

## 지역 발전

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

공개 RFC 자격 증명만 사용하는 격리된 미리 보기의 경우:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## 패키지

`.github/workflows/linux.yml` 패키징 종속성을 설치하고, 고정된 appimagetool 다이제스트를 확인하고, deb/rpm/ AppImage를 빌드하고, Xvfb에서 deb를 설치 및 시작하고, FUSE 없이 AppImage를 시작하고, 패키지와 스크린샷을 다음과 같이 업로드합니다. `linux-packages`. PR에서 실행되며 수동으로 실행할 수 있습니다. 릴리스를 게시하지 않습니다. `packaging/linux/build.sh` 또한 x86_64 Linux 호스트에서 로컬로 실행됩니다. NET 10, fpm 1.16.0 , rpm 및 squashfs-tools; 공급 `APPIMAGETOOL` 확인된 1.9.1 x86_64 실행 파일을 가리킵니다. 생성된 모든 콘텐츠는 다음과 같이 유지됩니다. `artifacts/linux`.

태그 워크플로는 Linux 및 Windows 빌드를 기다린 다음 **초안** 설치 프로그램과 세 가지 Linux 패키지를 모두 사용하여 릴리스하세요. GitHub는 릴리스 자산에 대한 SHA -256 다이제스트를 표시합니다. 실제 Linux 스크린샷을 검토하고 게시하기 전에 Vlad의 승인을 얻으세요. 태그를 생성하거나 변경 사항을 푸시하는 것은 로컬 준비의 일부가 아닙니다.

## 여전히 동의가 필요합니다

Ubuntu에서는 deb를 설치/제거/업그레이드하고 Fedora에서는 rpm을 설치합니다. 둘 다에서 AppImage를 테스트하십시오(FUSE 또는 `--appimage-extract-and-run`). 실제 X11/Wayland 데스크톱, 크기 조정, 클립보드 시간 초과, 파일 선택기, QR 가져오기, 비밀번호 잠금, Windows 백업 복원 및 HOTP 지속성을 확인합니다. RPM 설치 및 데스크탑 컴포지터 동작은 Ubuntu CI 작업에서 다루지 않습니다. Linux 트레이 통합이나 클립보드 이미지 QR 가져오기는 아직 구현되지 않았습니다. 파일 QR 가져오기 및 URI 가져오기가 가능합니다.

`assets/screenshots/linux-ui-preview.png` Linux 런타임 테스트의 증거가 아니라 Windows에서 호스팅되는 Avalonia 프런트엔드의 실제 렌더링입니다. 이번 변경으로 출시된 패키지는 없습니다.
