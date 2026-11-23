"""Read-only native startup check; never prints account names, secrets or codes."""
from pathlib import Path
import hashlib
import os
import subprocess
import sys
import time

ROOT = Path(__file__).resolve().parents[1]
deps = ROOT / '.sharrowkin/python'
sys.path[:0] = [str(deps), str(deps / 'win32'), str(deps / 'win32/lib'), str(deps / 'Pythonwin')]
os.add_dll_directory(str(deps / 'pywin32_system32'))
from pywinauto import Application

exe = ROOT / 'src/WinOTP/artifacts/winotp-v040/WinOTP.exe'
data = Path(os.environ['LOCALAPPDATA']) / 'WinOTP'

def fingerprint():
    return {name: hashlib.sha256((data / name).read_bytes()).digest() if (data / name).exists() else None
            for name in ('vault.bin', 'settings.bin')}

before = fingerprint()
log = data / 'startup.log'
offset = log.stat().st_size if log.exists() else 0
process = subprocess.Popen([str(exe)], cwd=exe.parent)
window = None
try:
    app = Application(backend='uia').connect(process=process.pid, timeout=20)
    window = app.window(title='WinOTP', control_type='Window')
    window.wait('visible', timeout=20)
    time.sleep(4)
    recent = log.read_bytes()[offset:].decode('utf-8')
    assert 'Initial account list rendered' in recent, 'Initial account list was not rendered'
    assert 'STARTUP ERROR' not in recent and 'Initial screen failed' not in recent, 'Startup reported a failure'
    assert window.child_window(title='Add account', control_type='Button').exists(), 'Main controls missing'
    assert fingerprint() == before, 'Vault or settings changed during startup'
    print('PASS: normal native launch; account list rendered; main controls visible; vault and settings unchanged.')
finally:
    if process.poll() is None:
        if window is not None and window.exists():
            window.close()
        try:
            process.wait(timeout=10)
        except subprocess.TimeoutExpired:
            process.terminate()
