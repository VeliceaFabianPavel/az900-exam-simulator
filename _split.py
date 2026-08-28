import re, os

txt = open("_book.txt", encoding="utf-8").read()
parts = re.split(r"\n===== PAGE (\d+) =====\n", txt)
pages = {int(parts[i]): parts[i + 1] for i in range(1, len(parts) - 1, 2)}

CHAPTERS = {
    # Page ranges for the STUDY-GUIDE.pdf edition (385 pages).
    "00-frontmatter-assessment": (16, 55),
    "01-cloud-concepts": (56, 89),
    "02-core-services": (90, 133),
    "03-storage-migration": (134, 162),
    "04-networking-EXCLUDED": (163, 185),
    "05-identity-access-security": (186, 232),
    "06-monitor-governance-compliance": (233, 261),
    "07-pricing-sla-lifecycle": (262, 288),
    "08-managing-resources": (289, 345),
    "09-answers-review-questions": (346, 385),
}

os.makedirs("_chapters", exist_ok=True)
for name, (a, b) in CHAPTERS.items():
    buf = []
    for p in range(a, b + 1):
        if p in pages:
            buf.append(f"[p{p}]\n{pages[p].strip()}")
    body = "\n\n".join(buf)
    path = os.path.join("_chapters", name + ".txt")
    open(path, "w", encoding="utf-8", newline="\n").write(body)
    print(f"{name:38} p{a}-{b}  {len(body):>7} chars")
