"""Inspect whether a Linux runtime is already available; never installs anything."""
import subprocess
p=subprocess.run(['wsl.exe','--list','--quiet'],capture_output=True,timeout=20)
for data in (p.stdout,p.stderr):
    if data: print(data.decode('utf-16-le' if b'\x00' in data else 'utf-8',errors='replace'))
print('Exit:',p.returncode)
