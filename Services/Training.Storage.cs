using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Chapter 3 of the study guide: Azure Storage and Migration (pages 134-162).
// Original wording written against the factual content of that chapter.
public static partial class TrainingCatalog
{
    private const string M3 = "Study guide, ch. 3: Azure Storage and Migration";

    private static TrainingModule StorageModule() => new()
    {
        Id = "m3",
        Title = "Storage and migration",
        Domain = ExamDomain.ArchitectureAndServices,
        Reference = M3,
        Pages = "ch. 3, p134-162",
        Blurb = "The storage services, how many copies Azure keeps and where, and how to get "
              + "existing data into Azure.",
        Lessons =
        [
            new Lesson
            {
                Id = "m3-l1",
                Title = "Comparing the storage services",
                Objective = "Describe Azure storage services",
                Pages = "p134-142",
                Intro = Para("""
                    Azure offers several storage services and they are not interchangeable.
                    Each question on this topic gives you a shape of data and an access pattern;
                    match those to the service built for them.
                    """),
                Points =
                [
                    "Blob storage holds large amounts of unstructured data, text or binary, with no restriction on file type or structure. It is reachable by URL over HTTP and HTTPS.",
                    "Disk storage presents a disk attached to a virtual machine. The three disk roles are the OS disk, data disks, and the temporary disk.",
                    "Azure Files provides managed file shares reachable over SMB and NFS, so on-premises machines and Azure services can mount the same share.",
                    "Table storage holds schema-flexible structured data in a NoSQL datastore. Azure Cosmos DB for Table is the premium alternative, adding features such as single-digit millisecond latency.",
                    "Queue storage holds messages of 64 KB or less, used to decouple components so work can be processed asynchronously."
                ],
                Essentials =
                [
                    "The temporary disk is not persistent. Its contents can be lost during a maintenance event, so nothing durable belongs on it.",
                    "The 64 KB limit is per message, not per queue. A larger payload goes into blob storage and the message carries a reference to it.",
                    "Table storage sounds structured because of its name, but rows in one table can carry different properties, which makes it semi-structured."
                ],
                Table = new LessonTable(
                    "Pick by shape of data",
                    ["Requirement", "Service"],
                    [
                        ["Images, video, logs, backups reached by URL", "Blob storage"],
                        ["A share mounted by several machines over SMB", "Azure Files"],
                        ["A virtual disk attached to one VM", "Disk storage"],
                        ["Schema-flexible entity records", "Table storage"],
                        ["Small messages between components", "Queue storage"]
                    ])
            },

            new Lesson
            {
                Id = "m3-l2",
                Title = "Blob access tiers",
                Objective = "Describe Azure storage services",
                Pages = "p142-146",
                Intro = Para("""
                    Blob storage has four access tiers, each priced for a different access
                    frequency. Storage gets cheaper as you go down the ladder and access gets
                    more expensive, which is the whole trade.
                    """),
                Points =
                [
                    "The four tiers are hot, cool, cold and archive.",
                    "Hot is for frequently accessed data: highest storage cost, lowest access cost.",
                    "Cool and cold are online tiers offering progressively cheaper storage in exchange for higher access charges.",
                    "Archive stores data offline at the lowest storage cost. Reading it requires rehydration, which takes hours and carries the highest retrieval cost.",
                    "Each cheaper tier carries a minimum retention period: 30 days for cool, 90 days for cold, 180 days for archive. Hot has none.",
                    "A blob's tier can be set at upload and changed later, and lifecycle management policies can move blobs between tiers automatically as they age."
                ],
                Essentials =
                [
                    "Archive is not forbidden for data that may be read. It is simply slow and expensive to read, which suits records kept for compliance and almost never opened.",
                    "Deleting from a tier before its minimum retention elapses triggers an early deletion charge, which is invisible until the bill arrives."
                ]
            },

            new Lesson
            {
                Id = "m3-l3",
                Title = "Redundancy options",
                Objective = "Describe Azure storage services",
                Pages = "p146-150",
                Intro = Para("""
                    The redundancy options differ in how many copies of the data exist and where
                    they sit. Work from the failure you have to survive: a rack, a zone, or a
                    whole region.
                    """),
                Points =
                [
                    "Locally redundant storage keeps three copies inside a single physical location. It is the cheapest and does not survive the loss of that location.",
                    "Zone-redundant storage writes copies across availability zones in the primary region, so losing one zone leaves the data available.",
                    "Geo-redundant storage keeps three copies in the primary region and replicates to a paired secondary region where three more are kept: six in total.",
                    "Geo-zone-redundant storage does the same across regions, but spreads the primary copies across availability zones as well.",
                    "The secondary copy under GRS and GZRS is not readable by default. The read-access variants, RA-GRS and RA-GZRS, expose it for reading during normal operation.",
                    "The secondary region is determined by the Microsoft-defined pairing, not chosen by the customer."
                ],
                Essentials =
                [
                    "Reaching a plain GRS secondary requires a failover, which is a recovery action. If a reporting workload needs to read it routinely, that is what the RA variants are for.",
                    "A residency requirement rules out every geo option, however attractive its zone protection, because those copy data to another region."
                ]
            },

            new Lesson
            {
                Id = "m3-l4",
                Title = "Storage accounts",
                Objective = "Describe Azure storage services",
                Pages = "p150-153",
                Intro = Para("""
                    Every storage service lives inside a storage account, and the account name
                    becomes part of a public DNS name. That single fact explains all of the
                    naming rules.
                    """),
                Points =
                [
                    "A storage account is required before you can create storage, and each account name must be unique across all of Azure.",
                    "The name must be 3 to 24 characters and use only lowercase letters and digits.",
                    "You can create up to 250 storage accounts per region per subscription, or up to 500 with a quota increase.",
                    "Each service in an account has its own endpoint suffix on the same account name: blob, file, queue, table, and dfs for Data Lake Storage.",
                    "Managed disks are encrypted at rest by default through server-side encryption, and in-guest encryption can be layered on top."
                ],
                Essentials =
                [
                    "Uniqueness is global, not per subscription or resource group. That is why obvious names are already taken and organisations adopt a naming convention.",
                    "The account name is shared across every service in the account, so the endpoint suffix is the only part identifying which service you are addressing."
                ]
            },

            new Lesson
            {
                Id = "m3-l5",
                Title = "Moving files and migrating workloads",
                Objective = "Describe Azure storage services",
                Pages = "p153-162",
                Intro = Para("""
                    Getting data into Azure splits into two questions: is the constraint
                    bandwidth or effort, and does the workload need to keep running afterwards.
                    """),
                Points =
                [
                    "AzCopy is the scriptable command-line tool for copying blobs and files to and from a storage account.",
                    "Azure Storage Explorer is the graphical application for browsing and managing blobs, files, queues and tables, and it uses AzCopy underneath for transfers.",
                    "Azure File Sync is an agent installed on Windows Server that synchronises it with an Azure file share, so frequently used files stay cached locally while the rest live in Azure.",
                    "Azure Migrate is the hub for discovering, assessing and migrating servers, databases and web applications, using an on-premises appliance to collect real configuration and performance data.",
                    "The Azure Data Box family moves bulk data physically when the network would take too long: Data Box Disk for the smallest transfers, the standard Data Box in 120 TB and 525 TB capacities, and Data Box Heavy at roughly a petabyte.",
                    "Azure Site Recovery replicates servers to a secondary location so a workload can be failed over, which serves disaster recovery as well as migration."
                ],
                Essentials =
                [
                    "Azure Migrate ends when the workload has moved. Site Recovery maintains an ongoing replica you can fail over to and back from.",
                    "Sizing decides the Data Box variant. Know which capacity belongs to which device, because the numbers are the whole question."
                ]
            }
        ]
    };
}
