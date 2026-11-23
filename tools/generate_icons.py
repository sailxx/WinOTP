"""Rebuild WinOTP assets from the geometry and colours in assets/winotp-icon.svg.
Run: cd /d C:\\Users\\Vlad\\sx\\winotp && python tools/generate_icons.py
Requires Pillow; no fonts or external artwork.
"""
from pathlib import Path
import xml.etree.ElementTree as ET
from PIL import Image, ImageDraw

ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / 'src/WinOTP/Assets/Branding'
OUT.mkdir(parents=True, exist_ok=True)
svg = ET.parse(ROOT / 'assets/winotp-icon.svg').getroot()
ns = '{http://www.w3.org/2000/svg}'

def icon(size):
    scale = size * 4 / 256
    image = Image.new('RGBA', (size * 4, size * 4))
    draw = ImageDraw.Draw(image)
    for node in svg:
        if node.tag == ns + 'rect':
            x, y, w, h, r = (float(node.get(k, 0)) * scale for k in ('x', 'y', 'width', 'height', 'rx'))
            draw.rounded_rectangle((x, y, x+w, y+h), radius=r,
                fill=node.get('fill') if node.get('fill', 'none') != 'none' else None,
                outline=node.get('stroke'), width=max(1, round(float(node.get('stroke-width', 1))*scale)))
        for circle in ([node] if node.tag == ns + 'circle' else list(node)):
            if circle.tag != ns + 'circle':
                continue
            x, y, r = (float(circle.get(k))*scale for k in ('cx', 'cy', 'r'))
            draw.ellipse((x-r, y-r, x+r, y+r), fill=circle.get('fill', node.get('fill')))
    return image.resize((size, size), Image.Resampling.LANCZOS)

sizes = [16, 20, 24, 32, 40, 48, 64, 96, 128, 256]
for path in (ROOT/'src/WinOTP/Assets/WinOTP.ico', OUT/'Tray.ico', ROOT/'assets/readme/favicon.ico'):
    icon(256).save(path, sizes=[(s, s) for s in sizes])
icon(256).save(OUT/'AppIcon.png')
for name, width, height in [('Square44x44Logo',44,44), ('Square150x150Logo',150,150), ('Wide310x150Logo',310,150), ('StoreLogo',50,50), ('SplashScreen',620,300)]:
    for percent in (100,125,150,200,400):
        w, h = round(width*percent/100), round(height*percent/100)
        canvas = Image.new('RGBA', (w,h))
        mark = icon(min(w,h))
        canvas.alpha_composite(mark, ((w-mark.width)//2,(h-mark.height)//2))
        canvas.save(OUT/f'{name}.scale-{percent}.png')
for s in sizes:
    for suffix in ('', '_altform-unplated'):
        icon(s).save(OUT/f'Square44x44Logo.targetsize-{s}{suffix}.png')
for path in OUT.glob('*.png'):
    with Image.open(path) as image:
        image.verify()
print(f'Generated and decoded {len(list(OUT.glob("*.png")))} PNG assets and 3 multi-resolution ICO files.')
