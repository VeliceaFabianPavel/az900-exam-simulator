using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Chapter 2 of the study guide: Azure Core Services (pages 90-133).
// Original wording written against the factual content of that chapter.
public static partial class TrainingCatalog
{
    private const string M2 = "Study guide, ch. 2: Azure Core Services";

    private static TrainingModule CoreServicesModule() => new()
    {
        Id = "m2",
        Title = "Azure core services",
        Domain = AzureDomains.ArchitectureAndServices,
        Reference = M2,
        Pages = "ch. 2, p90-133",
        Blurb = "How Azure is laid out geographically and organisationally, and the compute "
              + "and data services you build on top of it.",
        Lessons =
        [
            new Lesson
            {
                Id = "m2-l1",
                Title = "Geographies, regions and region pairs",
                Objective = "Describe the core architectural components of Azure",
                Pages = "p90-94",
                Intro = Para("""
                    Azure's physical footprint is described at three scales. Getting them in the
                    right order settles most questions on the topic, because each one is defined
                    in terms of the one above it.
                    """),
                Points =
                [
                    "A geography is a discrete market. It often aligns to a single country, but it can span several, and Europe is the standard example of the multi-country case.",
                    "A geography is the boundary that preserves data residency and compliance commitments.",
                    "A region is a set of data centres within a geography, and it is what you choose when you decide where a resource lives.",
                    "Regions are paired with another region to support availability, fault tolerance and redundancy. The pairing is defined by Microsoft, not chosen by the customer.",
                    "Both halves of a pair sit inside the same geography, which is what keeps residency commitments intact during a failover.",
                    "Sovereign regions are physically isolated instances of Azure for particular jurisdictions, such as Azure Government and Azure operated by 21Vianet in China."
                ],
                Essentials =
                [
                    "A geography does not always correspond to exactly one country. That over-simplification is a favourite exam distractor.",
                    "A region is not a single data centre. It is a group of them.",
                    "Pairing supports recovery and staged platform updates. It does not by itself replicate any of your data: replication is a property of the service you deploy, such as choosing geo-redundant storage."
                ]
            },

            new Lesson
            {
                Id = "m2-l2",
                Title = "Availability zones and data centres",
                Objective = "Describe the core architectural components of Azure",
                Pages = "p94-98",
                Intro = Para("""
                    Region pairs protect against losing a region. Availability zones protect
                    against losing part of one. The distinction is entirely about scope.
                    """),
                Points =
                [
                    "An availability zone is a physically separate location inside a region, with its own power, cooling and network.",
                    "That independence means an incident affecting one zone should not affect resources in another.",
                    "A zone can span more than one physical data centre.",
                    "A region that supports zones offers at least three of them, and not every region supports them, so zone availability has to be confirmed for the region you intend to use.",
                    "Spreading two or more virtual machine instances across two or more zones reaches the highest single-region availability commitment, 99.99 percent."
                ],
                Essentials =
                [
                    "Everything a zone offers stops at the region boundary. Surviving the loss of a whole region needs a second region, not a second zone.",
                    "The zone answer requires two things at once: more than one instance, and those instances in more than one zone. A single instance never reaches 99.99 percent, however good its disks."
                ]
            },

            new Lesson
            {
                Id = "m2-l3",
                Title = "Resources, resource groups and Resource Manager",
                Objective = "Describe the core architectural components of Azure",
                Pages = "p98-100",
                Intro = Para("""
                    A resource group is a management container, and it is easy to credit it with
                    powers it does not have. Azure Resource Manager is the service every
                    management request passes through, whichever tool issued it.
                    """),
                Points =
                [
                    "A resource group is a logical container for grouping resources so they can be managed, and access-controlled, as a unit.",
                    "A resource belongs to exactly one resource group at a time, though it can be moved to another.",
                    "The resources in a group may sit in different regions; the group's own location only determines where its metadata is stored.",
                    "Deleting a resource group deletes everything inside it, which is why a group should hold resources that genuinely share a lifecycle.",
                    "Azure Resource Manager receives management requests from every interface and passes them to the appropriate resource provider.",
                    "Resource Manager supports declarative deployment through templates, which describe the desired result and let Azure work out the steps."
                ],
                Essentials =
                [
                    "A resource group is not a security boundary and not a region constraint. Resources in different groups can freely interact.",
                    "Tags applied to a resource group are not automatically inherited by the resources inside it.",
                    "Because every tool goes through Resource Manager, role assignments, policy, locks and tags apply consistently whether you used the portal, the CLI or PowerShell."
                ]
            },

            new Lesson
            {
                Id = "m2-l4",
                Title = "Subscriptions, management groups and the hierarchy",
                Objective = "Describe the core architectural components of Azure",
                Pages = "p100-106",
                Intro = Para("""
                    Four scopes, nested from broadest to narrowest. The order matters because
                    governance settings applied at one scope flow down to everything beneath it.
                    """),
                Points =
                [
                    "The hierarchy runs management group, subscription, resource group, resource.",
                    "A subscription is a container for resource groups and acts as a billing boundary, letting different parts of an organisation be charged for what they use.",
                    "A subscription is also an administrative and scale boundary, against which role assignments, policies and service limits apply.",
                    "Management groups sit above subscriptions and can contain both subscriptions and other management groups, so an organisation can model business units above the billing boundary.",
                    "A policy or role assignment made at one scope is inherited by every scope beneath it, and inheritance only ever flows downward.",
                    "A tenant is an instance of Microsoft Entra ID holding an organisation's accounts and groups. One tenant can be trusted by many subscriptions."
                ],
                Essentials =
                [
                    "Assigning at a management group is what makes a rule reach subscriptions that do not exist yet. A new subscription inherits it simply by being placed in the group.",
                    "A subscription is a billing and administrative boundary, not an identity provider. Authentication comes from the Entra ID tenant."
                ]
            },

            new Lesson
            {
                Id = "m2-l5",
                Title = "Billing accounts and billing scopes",
                Objective = "Describe Azure billing concepts",
                Pages = "p106-108",
                Intro = Para("""
                    Each purchasing agreement carries its own vocabulary for billing scopes.
                    Most of the work in these questions is recognising which agreement a scope
                    name belongs to.
                    """),
                Points =
                [
                    "Azure billing is tied to a billing account, and the account type follows how Azure was purchased.",
                    "The three account types are Enterprise Agreement, Microsoft Online Services Program, and Microsoft Customer Agreement.",
                    "Under an Enterprise Agreement the scopes are the billing account, an optional department grouping enrollment accounts, and the enrollment account under which subscriptions are created.",
                    "Under a Microsoft Customer Agreement the scopes are the billing account, billing profiles, and invoice sections. The billing profile carries the invoice and its payment methods; invoice sections group costs within one invoice.",
                    "Subscriptions are associated with a billing account, which is how consumption reaches an invoice."
                ],
                Essentials =
                [
                    "Departments and enrollment accounts belong to an Enterprise Agreement. Billing profiles and invoice sections belong to a Microsoft Customer Agreement. Mixing the two is the standard trap.",
                    "A resource group is not a billing scope."
                ]
            },

            new Lesson
            {
                Id = "m2-l6",
                Title = "Virtual machines, scale sets and availability sets",
                Objective = "Describe Azure compute services",
                Pages = "p108-113",
                Intro = Para("""
                    Virtual machines are the most familiar Azure service and the one with the
                    most surrounding vocabulary. Two constructs sit alongside them, and they
                    solve different problems: one scales, one survives.
                    """),
                Points =
                [
                    "A virtual machine is a guest operating system running on a physical host. One host can run both Windows and Linux guests.",
                    "A virtual machine scale set manages a group of identical machines built from one image, load balances across them, and adjusts the instance count to meet demand.",
                    "Because every instance comes from the same image, a scale set also makes it easy to roll out many machines at once.",
                    "An availability set distributes machines across fault domains and update domains.",
                    "A fault domain is hardware sharing a power source and network switch, so spreading across fault domains survives an unplanned rack-level failure.",
                    "An update domain is a group rebooted together during planned maintenance, so spreading across update domains lets the platform be patched without the whole set going down."
                ],
                Essentials =
                [
                    "A scale set changes the number of instances; an availability set never does. An availability set is a resilience construct only.",
                    "Fault domains answer unplanned failures, update domains answer planned maintenance. They are genuinely different groupings, not one idea described twice."
                ]
            },

            new Lesson
            {
                Id = "m2-l7",
                Title = "App Service, containers and functions",
                Objective = "Describe Azure compute services",
                Pages = "p113-124",
                Intro = Para("""
                    Above virtual machines sit hosting options that hand progressively more of
                    the stack to Azure. Several of them can technically run the same workload,
                    so these questions are usually decided by proportionality and by cost shape.
                    """),
                Points =
                [
                    "Azure App Service is a platform-as-a-service offering for web applications. It handles the underlying infrastructure, deployment, load balancing and scaling so the team can focus on the application.",
                    "A container is a virtualised environment packaging an application with what it needs to run. Azure Container Instances creates and manages containers with no cluster to operate.",
                    "Azure Kubernetes Service is the container orchestration service, used to monitor, schedule and manage large numbers of containers across cluster nodes.",
                    "Azure Functions runs a small piece of code in response to a trigger, without you managing the servers behind it.",
                    "Azure Logic Apps builds multi-step workflows from prebuilt connectors in a visual designer, and the two services are complementary rather than competing.",
                    "Azure Virtual Desktop delivers Windows desktop and application sessions from Azure to a wide range of client devices, and supports multi-session Windows so several users can share one host.",
                    "Azure Marketplace is the online store for Azure solutions, managed services and consulting services, billed through your Azure account. Microsoft AppSource is the equivalent store for business applications across Dynamics 365, Microsoft 365 and Power Platform."
                ],
                Essentials =
                [
                    "Container Instances suits short-lived or occasional work because nothing is billed between runs. Kubernetes Service suits a large estate, and its cluster nodes are billed whether or not work arrives.",
                    "With Kubernetes Service, managed refers to the control plane. The node pools and the workloads on them remain yours.",
                    "Marketplace purchases appear on the Azure invoice. That billing detail is what separates it from AppSource in a question."
                ]
            },

            new Lesson
            {
                Id = "m2-l8",
                Title = "Core data services",
                Objective = "Describe Azure compute and data services",
                Pages = "p118-124",
                Intro = Para("""
                    Azure offers a managed database for most shapes of data. The exam mostly
                    wants you to match the shape of the data, and the compatibility required,
                    to the right service.
                    """),
                Points =
                [
                    "Structured data fits a predefined schema, such as rows in a relational table. Semi-structured data carries tags or markers imposing a hierarchy, such as JSON. Unstructured data has no predefined structure, such as video or scanned documents.",
                    "Azure SQL Database is the fully managed single-database relational service, with no server or operating system for the customer to maintain.",
                    "Azure SQL Managed Instance provides close compatibility with a full SQL Server instance, for migrations that depend on instance-level features.",
                    "Azure Database for MySQL and Azure Database for PostgreSQL are the managed services for those engines, used when the application must keep speaking its existing dialect.",
                    "Azure Cosmos DB is the globally distributed, multi-model database, offering very low response times and several APIs including MongoDB, Cassandra, Gremlin and Table."
                ],
                Essentials =
                [
                    "Relational and fully managed describes both Azure SQL Database and Managed Instance. What separates them is whether instance-level compatibility is needed.",
                    "A managed database still leaves you responsible for who may read the data. Managed refers to running the engine, not to access control."
                ]
            }
        ]
    };
}
