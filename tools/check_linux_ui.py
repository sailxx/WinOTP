"""Run the actual Avalonia frontend on Windows using public preview accounts only."""
from pathlib import Path
import sys, os, subprocess, time
sys.stdout.reconfigure(encoding='utf-8')
root=Path(__file__).resolve().parents[1]
deps=root/'.sharrowkin/python'
sys.path[:0]=[str(deps),str(deps/'win32'),str(deps/'win32/lib'),str(deps/'Pythonwin')]
os.add_dll_directory(str(deps/'pywin32_system32'))
from pywinauto import Application
p=subprocess.Popen(['dotnet',str(root/'src/WinOTP.Linux/bin/Release/net10.0/WinOTP.Linux.dll'),'--preview'],cwd=root)
try:
    app=Application(backend='uia').connect(process=p.pid,timeout=20)
    w=app.window(title='WinOTP');w.wait('visible',timeout=20);time.sleep(2)
    def find(name,kind):
        matches=[e for e in w.descendants() if e.element_info.name==name and e.element_info.control_type==kind]
        assert len(matches)==1,(name,kind,[(e.element_info.name,e.element_info.control_type) for e in w.descendants()])
        return matches[0]
    find('Hide codes','Button').invoke();time.sleep(.5)
    assert any(e.window_text()=='••••••' for e in w.descendants(control_type='Text'))
    find('Show codes','Button').invoke();time.sleep(.5)
    edits=w.descendants(control_type='Edit');assert len(edits)==1
    edits[0].set_edit_text('no-match-native-check');time.sleep(.5)
    find('No matching accounts','Text')
    edits[0].set_edit_text('');time.sleep(.5)
    find('Google','Text');find('GitHub','Text');find('Microsoft','Text')
    find('Add','Button').invoke();time.sleep(.5)
    find('Add account','Window')
    fields=w.descendants(control_type='Edit')
    assert len(fields)==6
    fields[0].set_edit_text('Acceptance service');fields[1].set_edit_text('public test');fields[2].set_edit_text('GEZDGNBVGY3TQOJQGEZDGNBVGY3TQOJQ')
    find('Save','Button').invoke();time.sleep(.7)
    find('Acceptance service','Text')
    find('Settings','Button').invoke();time.sleep(.5)
    find('Settings','MenuItem').click_input();time.sleep(.7)
    find('Version 0.4.0','Text')
    find('Cancel','Button').invoke();time.sleep(.5)
    print('PASS: Avalonia native launch, hide/show, search, Add/save public account, Settings and version.')
finally:
    if p.poll() is None:
        try:w.close();p.wait(timeout=5)
        except Exception:p.terminate()
