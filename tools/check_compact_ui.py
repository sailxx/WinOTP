"""Exercise the compact native UI in a separate preview vault, never the user's data."""
from pathlib import Path
import sys, os, time, subprocess, ctypes
ROOT = Path(__file__).resolve().parents[1]
deps = ROOT / '.sharrowkin/python'
sys.path[:0] = [str(deps), str(deps/'win32'), str(deps/'win32/lib'), str(deps/'Pythonwin')]
os.add_dll_directory(str(deps/'pywin32_system32'))
from pywinauto import Application
from PIL import Image
import win32gui, win32ui
exe = ROOT/'src/WinOTP/artifacts/winotp-ui/WinOTP.exe'
shots = ROOT/'assets/screenshots'
shots.mkdir(parents=True, exist_ok=True)
def capture(window, name):
    hwnd = window.handle
    left, top, right, bottom = win32gui.GetWindowRect(hwnd)
    width, height = right-left, bottom-top
    dc = win32gui.GetWindowDC(hwnd)
    src = win32ui.CreateDCFromHandle(dc)
    dest = src.CreateCompatibleDC()
    bitmap = win32ui.CreateBitmap()
    bitmap.CreateCompatibleBitmap(src, width, height)
    dest.SelectObject(bitmap)
    try:
        assert ctypes.windll.user32.PrintWindow(hwnd, dest.GetSafeHdc(), 2)
        Image.frombuffer('RGB', (width,height), bitmap.GetBitmapBits(True), 'raw', 'BGRX', 0, 1).save(shots/name)
    finally:
        win32gui.DeleteObject(bitmap.GetHandle())
        dest.DeleteDC(); src.DeleteDC(); win32gui.ReleaseDC(hwnd,dc)
p = subprocess.Popen([str(exe), '--preview'], cwd=exe.parent)
try:
    app = Application(backend='uia').connect(process=p.pid, timeout=30)
    window = app.window(title='WinOTP')
    window.wait('visible', timeout=30)
    hwnd = window.handle
    class NativeTree:
        def __init__(self, wrapper):
            self.wrapper = wrapper
        def __getattr__(self, name):
            return getattr(self.wrapper, name)
        def child_window(self, title=None, control_type=None, title_re=None):
            import re
            matches = [e for e in self.wrapper.descendants() if (control_type is None or e.element_info.control_type == control_type) and (title is None or e.element_info.name == title) and (title_re is None or re.fullmatch(title_re, e.element_info.name))]
            assert len(matches) == 1, (title, control_type, len(matches))
            class Found:
                def __getattr__(self, name):
                    return getattr(matches[0], name)
                def exists(self):
                    return matches[0].is_visible()
            return Found()
    def fresh():
        return NativeTree(app.window(handle=hwnd).wrapper_object())
    time.sleep(3)
    assert fresh().child_window(title='WinOTP', control_type='Text').exists()
    gear = fresh().child_window(title='Settings', control_type='Button').rectangle()
    search_rect = fresh().child_window(title='Search accounts', control_type='Edit').rectangle()
    scale = ctypes.windll.user32.GetDpiForWindow(hwnd) / 96
    assert gear.width() <= 38 * scale and gear.height() <= 38 * scale, gear
    assert search_rect.top - fresh().rectangle().top <= 48 * scale, search_rect
    window.child_window(title='Add account', control_type='Button').invoke()
    time.sleep(2)
    capture(fresh(), 'winotp-compact-form.png')
    print('FORM:', [(e.element_info.name, e.element_info.control_type) for e in fresh().descendants()])
    for label, value in [('Service', 'RFC example'), ('Account / email', 'demo@example.test'), ('Secret key (Base32)', 'GEZDGNBVGY3TQOJQGEZDGNBVGY3TQOJQ')]:
        fresh().child_window(title=label, control_type='Edit').set_edit_text(value)
    fresh().child_window(title='Save', control_type='Button').invoke()
    time.sleep(2)
    assert fresh().child_window(title='RFC example', control_type='Text').exists()
    texts = [x.window_text() for x in fresh().descendants(control_type='Text')]
    assert not any('Protected on this device' in t for t in texts)
    assert not any(t.startswith('v0.') for t in texts)
    toggle = fresh().child_window(title_re='Hide codes|Show codes', control_type='Button')
    if toggle.window_text() == 'Show codes':
        toggle.invoke(); time.sleep(.7)
    fresh().child_window(title='Hide codes', control_type='Button').invoke()
    time.sleep(.7)
    assert any('••••••' == x.window_text() for x in fresh().descendants(control_type='Text'))
    fresh().child_window(title='Show codes', control_type='Button').invoke()
    time.sleep(.7)
    search = fresh().child_window(title='Search accounts', control_type='Edit')
    search.set_edit_text('no-match-acceptance')
    time.sleep(.7)
    assert fresh().child_window(title='No matching accounts', control_type='Text').exists()
    fresh().child_window(title='Search accounts', control_type='Edit').set_edit_text('')
    time.sleep(.7)
    capture(fresh(), 'winotp-compact-mica.png')
    fresh().child_window(title='Settings', control_type='Button').invoke()
    time.sleep(.8)
    print('MENU:', [(e.window_text(), e.element_info.control_type) for e in fresh().descendants(control_type='MenuItem')])
    for label in ('Import', 'Backup', 'Settings'):
        assert fresh().child_window(title=label, control_type='MenuItem').exists(), label
    capture(fresh(), 'winotp-compact-menu.png')
    fresh().child_window(title='Import', control_type='MenuItem').invoke()
    time.sleep(.8)
    assert fresh().child_window(title='Import accounts', control_type='Text').exists()
    fresh().child_window(title='Cancel', control_type='Button').invoke()
    time.sleep(.8)
    fresh().child_window(title='Settings', control_type='Button').invoke()
    time.sleep(.5)
    fresh().child_window(title='Backup', control_type='MenuItem').invoke()
    time.sleep(.8)
    assert fresh().child_window(title='Backup password', control_type='Text').exists()
    fresh().child_window(title='Cancel', control_type='Button').invoke()
    time.sleep(.8)
    fresh().child_window(title='Settings', control_type='Button').invoke()
    time.sleep(.5)
    fresh().child_window(title='Settings', control_type='MenuItem').invoke()
    time.sleep(.8)
    assert fresh().child_window(title='Version 0.4.2', control_type='Text').exists()
    capture(fresh(), 'winotp-compact-settings.png')
    fresh().child_window(title='Cancel', control_type='Button').invoke()
    print('PASS: native launch, add account, hide/show, search, Import/Backup menu, settings version and screenshots.')
finally:
    if p.poll() is None:
        try:
            fresh().close(); p.wait(timeout=10)
        except Exception:
            p.terminate()
