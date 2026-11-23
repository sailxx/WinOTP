using Avalonia.Media;
namespace WinOTP.Linux;
public sealed partial class MainWindow
{
    // Keep OTP contrast stable; only tint the dark surface with the desktop accent.
    // Desktop environments without portal color information use the neutral fallback.
    private void ApplySystemPalette()
    {
        var color=PlatformSettings?.GetColorValues().AccentColor1 ?? Color.Parse("#60DDFF");
        byte Tint(byte channel)=>(byte)Math.Clamp(29+(channel-128)*0.035,22,35);
        var background=new SolidColorBrush(Color.FromRgb(Tint(color.R),Tint(color.G),Tint(color.B)));
        Background=background;_root.Background=background;
    }
}
