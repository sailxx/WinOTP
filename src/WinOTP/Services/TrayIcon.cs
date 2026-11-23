using System.Runtime.InteropServices;

namespace WinOTP.Services;

// A native notification icon; clicking it restores the window. No secrets enter shell metadata.
internal sealed class TrayIcon : IDisposable
{
    private const uint Callback = 0x8000 + 71;
    private readonly nint _window;
    private readonly WindowProcedure _procedure;
    private readonly Action _restore;
    private readonly nint _previous;
    private NotifyIconData _data;
    private bool _disposed;
    public TrayIcon(nint window, string iconPath, Action restore)
    {
        _window = window;
        _restore = restore;
        _procedure = HandleMessage;
        _previous = SetWindowLongPtrW(window, -4, Marshal.GetFunctionPointerForDelegate(_procedure));
        _data = new NotifyIconData
        {
            Size = (uint)Marshal.SizeOf<NotifyIconData>(), Window = window, Id = 1,
            Flags = 1 | 2 | 4, Message = Callback,
            Icon = LoadImageW(0, iconPath, 1, 32, 32, 0x10), Tip = "WinOTP — open authenticator"
        };
        if (_data.Icon != 0) Shell_NotifyIconW(0, ref _data);
    }
    private nint HandleMessage(nint hwnd, uint message, nuint wParam, nint lParam)
    {
        if (message == Callback && ((long)lParam == 0x202 || (long)lParam == 0x203)) _restore();
        return CallWindowProcW(_previous, hwnd, message, wParam, lParam);
    }
    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;
        Shell_NotifyIconW(2, ref _data);
        SetWindowLongPtrW(_window, -4, _previous);
        if (_data.Icon != 0) DestroyIcon(_data.Icon);
        GC.KeepAlive(_procedure);
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct NotifyIconData
    {
        public uint Size;
        public nint Window;
        public uint Id, Flags, Message;
        public nint Icon;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)] public string Tip;
        public uint State, StateMask;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] public string Info;
        public uint Timeout;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] public string InfoTitle;
        public uint InfoFlags;
        public Guid Guid;
        public nint BalloonIcon;
    }
    [UnmanagedFunctionPointer(CallingConvention.Winapi)] private delegate nint WindowProcedure(nint hwnd, uint message, nuint wParam, nint lParam);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)] private static extern nint SetWindowLongPtrW(nint hwnd, int index, nint value);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)] private static extern nint CallWindowProcW(nint previous, nint hwnd, uint message, nuint wParam, nint lParam);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)] private static extern nint LoadImageW(nint instance, string path, uint type, int width, int height, uint flags);
    [DllImport("user32.dll")] private static extern bool DestroyIcon(nint icon);
    [DllImport("shell32.dll", CharSet = CharSet.Unicode)] private static extern bool Shell_NotifyIconW(uint action, ref NotifyIconData data);
}
