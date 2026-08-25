import re

txt = open("_book.txt", encoding="utf-8").read()
pages = re.split(r"\n===== PAGE (\d+) =====\n", txt)
# pages[0] is preamble; then (num, body) pairs
items = [(int(pages[i]), pages[i + 1]) for i in range(1, len(pages) - 1, 2)]

TARGETS = [
    "Cloud Concepts", "Azure Core Services", "Azure Storage and Migration",
    "Azure Core Networking Services", "Identity, Access, and Security",
    "Azure Monitoring, Governance, and Compliance",
    "Azure Pricing, Service Levels, and Lifecycle",
    "Creating and Managing Azure Resources",
    "Assessment Test", "Answers to Assessment Test",
    "Exam Essentials", "Review Questions", "Summary", "Introduction",
]

for num, body in items:
    for line in body.split("\n"):
        s = line.strip()
        if s in TARGETS:
            print(f"{num:>4}  {s}")
