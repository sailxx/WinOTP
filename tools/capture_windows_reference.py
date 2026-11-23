"""Capture only an isolated preview of the Windows reference build."""
from pathlib import Path
import sys,os,time,subprocess
root=Path(__file__).resolve().parents[1];deps=root/'.sharrowkin/python'
sys.path[:0]=[str(deps),str(deps/'win32'),str(deps/'win32/lib'),str(deps/'Pythonwin')]
os.add_dll_directory(str(deps/'pywin32_system32'))
from pywinauto import Application
exe=root/'src/WinOTP/artifacts/winotp-ui/WinOTP.exe'
p=subprocess.Popen([str(exe),'--preview'],cwd=exe.parent)
try:
    app=Application(backend='uia').connect(process=p.pid,timeout=25)
    w=app.window(title='WinOTP');w.wait('visible',timeout=25);time.sleep(3)
    import ctypes,win32gui,win32ui
    from PIL import Image
    hwnd=w.handle
    left,top,right,bottom=win32gui.GetWindowRect(hwnd);width,height=right-left,bottom-top
    dc=win32gui.GetWindowDC(hwnd);src=win32ui.CreateDCFromHandle(dc);dest=src.CreateCompatibleDC()
    bitmap=win32ui.CreateBitmap();bitmap.CreateCompatibleBitmap(src,width,height);dest.SelectObject(bitmap)
    try:
        assert ctypes.windll.user32.PrintWindow(hwnd,dest.GetSafeHdc(),2)
        Image.frombuffer('RGB',(width,height),bitmap.GetBitmapBits(True),'raw','BGRX',0,1).save(root/'assets/screenshots/windows-reference-current.png')
    finally:
        win32gui.DeleteObject(bitmap.GetHandle());dest.DeleteDC();src.DeleteDC();win32gui.ReleaseDC(hwnd,dc)
    print('Captured isolated Windows reference window.')
finally:
    if p.poll() is None:
        try:w.close();p.wait(timeout=5)
        except Exception:p.terminate()
