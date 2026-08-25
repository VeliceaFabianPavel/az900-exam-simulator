import sys
from pypdf import PdfReader

src = "Microsoft Certified Azure Fundamentals - AZ900 - Study Guide.pdf"
r = PdfReader(src)

FIX = {
    "\x00": "fi", "\x01": "fl", "\x02": "ff", "\x03": "ffi", "\x04": "ffl",
    "\ufb00": "ff", "\ufb01": "fi", "\ufb02": "fl", "\ufb03": "ffi", "\ufb04": "ffl",
    "\u2018": "'", "\u2019": "'", "\u201c": '"', "\u201d": '"',
    "\u2013": "-", "\u2014": "-", "\u00a0": " ",
}

out = []
for i, p in enumerate(r.pages, 1):
    t = p.extract_text() or ""
    for k, v in FIX.items():
        t = t.replace(k, v)
    t = "".join(ch for ch in t if ch in "\n\t" or ord(ch) >= 32)
    out.append(f"\n===== PAGE {i} =====\n{t}")

txt = "\n".join(out)
with open("_book.txt", "w", encoding="utf-8", newline="\n") as f:
    f.write(txt)
print("chars", len(txt), file=sys.stderr)
