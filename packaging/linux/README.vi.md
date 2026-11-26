[English](README.md) · [العربية](README.ar.md) · [简体中文](README.zh-CN.md) · [繁體中文](README.zh-TW.md) · [Čeština](README.cs.md) · [Français](README.fr.md) · [Deutsch](README.de.md) · [Ελληνικά](README.el.md) · [Bahasa Indonesia](README.id.md) · [Gaeilge](README.ga.md) · [Italiano](README.it.md) · [日本語](README.ja.md) · [한국어](README.ko.md) · [Polski](README.pl.md) · [Română](README.ro.md) · [Русский](README.ru.md) · [Español](README.es.md) · [Українська](README.uk.md) · [اردو](README.ur.md) · [ئۇيغۇرچە](README.ug.md) · **Tiếng Việt**

# Xây dựng và phê duyệt Linux

Nhắm mục tiêu x86_64 Linux, ban đầu là Ubuntu 24.04 và Fedora với . NET 10 phụ thuộc gốc. Giao diện người dùng là Avalonia ; ứng dụng Windows WinUI không thay đổi. Linux sử dụng cùng một bố cục nhỏ gọn, các điểm nhấn màu lục lam và bề mặt tối màu được tô điểm nhẹ bởi điểm nhấn hệ thống (dự phòng trung tính khi không có): Windows Mica Alt và Segoe UI Variable không thể mang theo được. Inter được gói gọn; không có phông chữ Microsoft nào được phân phối lại.

Mật khẩu chính Linux mã hóa vault bằng AES -256- GCM và PBKDF2 - SHA256 (600.000 lần lặp). Nó được yêu cầu khi khởi động và không thể phục hồi được. dữ liệu: `$XDG_DATA_HOME/WinOTP` hoặc `~/.local/share/WinOTP`. Thư mục Vault là 0700 và các tệp vault mới được tạo là 0600. Các bản ghi là nguyên tử, bị khóa người viết và từ chối các bản sửa đổi cũ. Không có bí mật nào được lưu trữ trong tùy chọn. Một vault hỗ trợ tới 500 tài khoản và 14 dữ liệu được tuần tự hóa MiB (vì vậy bản sao lưu Base64 của nó phù hợp với giới hạn nhập 20 MiB); tiết kiệm quá khổ bị từ chối trước khi thay thế. Không bao giờ sao chép các tệp Windows DPAPI sang Linux : xuất tệp được mã hóa bằng mật khẩu `.winotp` sao lưu trên Windows và nhập nó trên Linux. Giữ nguồn cho đến khi việc khôi phục được xác minh.

## Phát triển địa phương

```sh
cd /path/to/WinOTP
dotnet run --project tests/Portable/Portable.csproj -c Release
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release
```

Để có bản xem trước riêng biệt chỉ sử dụng thông tin xác thực RFC công khai:

```sh
cd /path/to/WinOTP
dotnet run --project src/WinOTP.Linux/WinOTP.Linux.csproj -c Release -- --preview --screenshot "$PWD/assets/screenshots/linux-native.png"
```

## Gói

`.github/workflows/linux.yml` cài đặt các phần phụ thuộc của gói, xác minh bản tóm tắt appimagetool được ghim, xây dựng deb/rpm/ AppImage , cài đặt và khởi động bản gỡ lỗi trong Xvfb, khởi động AppImage mà không cần FUSE và tải lên các gói cùng với ảnh chụp màn hình dưới dạng `linux-packages`. Nó chạy trên PR và có thể chạy thủ công; nó không xuất bản một bản phát hành. `packaging/linux/build.sh` cũng chạy cục bộ trên máy chủ x86_64 Linux có . NET 10, fpm 1.16.0, công cụ vòng/phút và bíp; cung cấp `APPIMAGETOOL` trỏ đến tệp thực thi 1.9.1 x86_64 đã được xác minh. Tất cả nội dung được tạo vẫn ở dưới `artifacts/linux`.

Quy trình làm việc của thẻ chờ các bản dựng Linux và Windows, sau đó chuẩn bị một **bản nháp** phát hành cùng với trình cài đặt và cả ba gói Linux. GitHub hiển thị thông báo SHA -256 cho nội dung phát hành. Xem lại ảnh chụp màn hình Linux thực và được sự chấp thuận của Vlad trước khi xuất bản. Tạo thẻ hoặc đẩy các thay đổi không phải là một phần của quá trình chuẩn bị cục bộ.

## Vẫn cần phải chấp nhận

Cài đặt/gỡ bỏ/nâng cấp bản sửa lỗi trên Ubuntu và vòng/phút trên Fedora; kiểm tra AppImage trên cả hai ( FUSE hoặc `--appimage-extract-and-run`). Xác minh máy tính để bàn X11 / Wayland thực tế, chia tỷ lệ, thời gian chờ của clipboard, bộ chọn tệp, nhập QR, khóa mật khẩu, khôi phục bản sao lưu Windows và tính bền bỉ của HOTP. Hoạt động cài đặt RPM và bộ tổng hợp máy tính để bàn không được thực hiện trong công việc Ubuntu CI. Chưa triển khai tích hợp khay Linux hoặc nhập QR hình ảnh clipboard. Nhập tệp QR và nhập URI có sẵn.

`assets/screenshots/linux-ui-preview.png` là kết xuất thực tế của giao diện người dùng Avalonia được lưu trữ trên Windows, không phải là bằng chứng về thử nghiệm thời gian chạy Linux. Không có gói nào được phát hành bởi sự thay đổi này.
