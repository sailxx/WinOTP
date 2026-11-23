"""Native WinUI acceptance check using public test credentials and --preview isolation.
Requires pywinauto installed in .sharrowkin/python; never opens the user's vault.
"""
from pathlib import Path
import sys, os, time, subprocess, json
ROOT = Path(__file__).resolve().parents[1]
deps = ROOT/'.sharrowkin/python'
sys.path[:0] = [str(deps), str(deps/'win32'), str(deps/'win32/lib'), str(deps/'Pythonwin')]
os.add_dll_directory(str(deps/'pywin32_system32'))
from pywinauto import Application
from PIL import ImageGrab
exe = ROOT/'src/WinOTP/artifacts/winotp-v040/WinOTP.exe'
shots = ROOT/'assets/screenshots'
shots.mkdir(parents=True, exist_ok=True)
process = subprocess.Popen([str(exe), '--preview'], cwd=exe.parent)
try:
    app = Application(backend='uia').connect(process=process.pid, timeout=30)
    window = app.window(title='WinOTP')
    window.wait('visible', timeout=30)
    time.sleep(3)
    window = app.window(handle=window.handle)
    print('VISIBLE:', window.window_text())
    window.child_window(title='Add account', control_type='Button').invoke()
    for _ in range(30):
        edits = window.descendants(control_type='Edit')
        if any(e.element_info.name == 'Service' for e in edits): break
        time.sleep(0.5)
    print('FORM EDITS:', [(e.element_info.name, e.element_info.class_name) for e in edits])
    # Use UI Automation labels inspected above; the form contains service, account, secret and period.
    for label, text in [('Service', 'RFC example'), ('Account / email', 'demo@example.test'), ('Secret key (Base32)', 'GEZDGNBVGY3TQOJQGEZDGNBVGY3TQOJQ')]:
        candidates = [e for e in edits if label in e.element_info.name]
        if len(candidates) != 1:
            raise RuntimeError('Missing unambiguous input: '+label)
        candidates[0].set_edit_text(text)
    window.child_window(title='Save', control_type='Button').invoke()
    time.sleep(2)
    print('AFTER SAVE:', [(e.element_info.name,e.element_info.control_type) for e in window.descendants()])
    assert window.child_window(title='RFC example', control_type='Text').exists(), 'Saved account not visible'
    window = app.window(handle=window.handle)
    time.sleep(1)
    import win32gui, win32ui, ctypes
    from PIL import Image
    hwnd = window.handle
    left, top, right, bottom = win32gui.GetWindowRect(hwnd)
    width, height = right-left, bottom-top
    dc = win32gui.GetWindowDC(hwnd)
    src = win32ui.CreateDCFromHandle(dc)
    dest = src.CreateCompatibleDC()
    bitmap = win32ui.CreateBitmap()
    bitmap.CreateCompatibleBitmap(src, width, height)
    dest.SelectObject(bitmap)
    assert ctypes.windll.user32.PrintWindow(hwnd, dest.GetSafeHdc(), 2), 'Native screenshot capture failed'
    Image.frombuffer('RGB', (width,height), bitmap.GetBitmapBits(True), 'raw', 'BGRX', 0, 1).save(shots/'winotp-desktop.png')
    win32gui.DeleteObject(bitmap.GetHandle()); dest.DeleteDC(); src.DeleteDC(); win32gui.ReleaseDC(hwnd,dc)
    print('PASS: native startup and adding a test account; screenshot saved. Further interactions require manual acceptance.')
    print('TEXT:', [x.window_text() for x in window.descendants(control_type='Text')])
finally:
    if process.poll() is None:
        try:
            window.close()
            process.wait(timeout=10)
        except Exception:
            process.terminate()
