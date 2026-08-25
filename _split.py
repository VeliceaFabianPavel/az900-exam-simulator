import re, os

txt = open("_book.txt", encoding="utf-8").read()
parts = re.split(r"\n===== PAGE (\d+) =====\n", txt)
pages = {int(parts[i]): parts[i + 1] for i in range(1, len(parts) - 1, 2)}

CHAPTERS = {
    "00-frontmatter-assessment": (15, 49),
    "01-cloud-concepts": (50, 80),
    "02-core-services": (81, 120),
    "03-storage-migration": (121, 146),
    "04-networking-EXCLUDED": (147, 167),
    "05-identity-access-security": (168, 209),
    "06-monitor-governance-compliance": (210, 236),
    "07-pricing-sla-lifecycle": (237, 260),
    "08-managing-resources": (261, 312),
    "09-answers-review-questions": (313, 346),
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
