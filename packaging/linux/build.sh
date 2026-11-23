#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")/../.."
version=$(dotnet msbuild src/WinOTP.Linux/WinOTP.Linux.csproj -getProperty:Version)
[[ "$version" =~ ^[0-9]+\.[0-9]+\.[0-9]+$ ]] || { echo 'Invalid package version'; exit 1; }
if [[ "${GITHUB_REF_TYPE:-}" == tag ]]; then
  [[ "$GITHUB_REF_NAME" == "v$version" ]] || { echo 'Tag does not match project version'; exit 1; }
fi
[[ $(uname -m) == x86_64 ]] || { echo 'This package recipe targets x86_64'; exit 1; }
out="$PWD/artifacts/linux"
stage="$out/stage"
rm -rf "$stage"
mkdir -p "$stage/usr/lib/winotp" "$stage/usr/bin" "$stage/usr/share/applications" "$stage/usr/share/icons/hicolor/256x256/apps" "$stage/usr/share/licenses/winotp" "$out/packages"
dotnet publish src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=false -warnaserror -o "$stage/usr/lib/winotp"
chmod 755 "$stage/usr/lib/winotp/WinOTP.Linux"
printf '#!/bin/sh\nexec /usr/lib/winotp/WinOTP.Linux "$@"\n' > "$stage/usr/bin/winotp"
chmod 755 "$stage/usr/bin/winotp"
cp packaging/linux/winotp.desktop "$stage/usr/share/applications/"
cp src/WinOTP/Assets/Branding/Square44x44Logo.targetsize-256.png "$stage/usr/share/icons/hicolor/256x256/apps/winotp.png"
cp LICENSE "$stage/usr/share/licenses/winotp/LICENSE"
common=(-s dir -n winotp -v "$version" --architecture amd64 --license MIT --maintainer 'Vlad (sailxx)' --url https://github.com/sailxx/WinOTP --description 'Local TOTP and HOTP authenticator' -C "$stage")
fpm "${common[@]}" -t deb --depends libx11-6 --depends libice6 --depends libsm6 --depends libfontconfig1 --depends libglib2.0-0 --depends libicu74 --depends libssl3 --package "$out/packages/WinOTP-${version}-linux-x64.deb" usr
fpm "${common[@]}" -t rpm --depends libX11 --depends libICE --depends libSM --depends fontconfig --depends glib2 --depends libicu --depends openssl-libs --package "$out/packages/WinOTP-${version}-linux-x64.rpm" usr
appdir="$out/WinOTP.AppDir"
rm -rf "$appdir"
mkdir -p "$appdir"
cp -a "$stage/usr" "$appdir/"
cp packaging/linux/AppRun "$appdir/AppRun"
cp packaging/linux/winotp.desktop "$appdir/"
cp "$stage/usr/share/icons/hicolor/256x256/apps/winotp.png" "$appdir/"
chmod 755 "$appdir/AppRun"
: "${APPIMAGETOOL:?Set APPIMAGETOOL to a verified appimagetool executable}"
ARCH=x86_64 "$APPIMAGETOOL" --appimage-extract-and-run "$appdir" "$out/packages/WinOTP-${version}-linux-x64.AppImage"
(cd "$out/packages" && sha256sum ./*.deb ./*.rpm ./*.AppImage > SHA256SUMS-linux.txt)
