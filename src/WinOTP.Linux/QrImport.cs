using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Platform.Storage;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using ZXing;
using ZXing.Common;
using FormatException = System.FormatException;
namespace WinOTP.Linux;
public sealed partial class MainWindow
{
    private async Task<string?> ReadQr()
    {
        var files=await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions {Title="Open QR image",FileTypeFilter=[new FilePickerFileType("QR image") {Patterns=["*.png","*.jpg","*.jpeg","*.bmp"]}]});
        if(files.Count==0)return null;
        await using var stream=await files[0].OpenReadAsync();if(stream.Length>25*1024*1024)throw new FormatException();
        using var bitmap=new Bitmap(stream);var size=bitmap.PixelSize;
        if(size.Width<=0||size.Height<=0||(long)size.Width*size.Height>16_000_000)throw new FormatException();
        var stride=checked(size.Width*4);var bytes=new byte[checked(stride*size.Height)];var pin=GCHandle.Alloc(bytes,GCHandleType.Pinned);
        try
        {
            using var converted=new WriteableBitmap(size,new Vector(96,96),PixelFormat.Bgra8888,AlphaFormat.Opaque);
            using(var frame=converted.Lock())bitmap.CopyPixels(frame,AlphaFormat.Opaque);
            using(var frame=converted.Lock())
            {
                for(int row=0;row<size.Height;row++)Marshal.Copy(frame.Address+row*frame.RowBytes,bytes,row*stride,stride);
            }
            var reader=new BarcodeReaderGeneric {AutoRotate=true,Options=new DecodingOptions {TryHarder=true,PossibleFormats=[BarcodeFormat.QR_CODE]}};
            return reader.Decode(bytes,size.Width,size.Height,RGBLuminanceSource.BitmapFormat.BGRA32)?.Text??throw new FormatException();
        }
        finally {pin.Free();CryptographicOperations.ZeroMemory(bytes);}
    }
}
