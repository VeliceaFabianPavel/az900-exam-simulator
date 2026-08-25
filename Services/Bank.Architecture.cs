using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Domain 2 of the AZ-900 skills outline: "Describe Azure architecture and services" (35-40%).
public static partial class QuestionBank
{
    private const ExamDomain D2 = ExamDomain.ArchitectureAndServices;

    private static IEnumerable<Item> ArchitectureAndServices()
    {
        foreach (var i in CoreArchitectureAndCompute()) yield return i;
        foreach (var i in StorageServices()) yield return i;
        foreach (var i in IdentityAndSecurity()) yield return i;
    }

    private const string R2 = "Study guide, ch. 2: Azure Core Services";

    private static IEnumerable<Item> CoreArchitectureAndCompute()
    {
        // ---------------------------------------------------------- global infrastructure

        yield return Mc("as-001", D2, "Describe the core architectural components of Azure", R2,
            """
            Which term describes a discrete market, typically containing two or more Azure
            regions, that preserves data residency and compliance boundaries?
            """,
            [
                "A geography.",
                "A region pair.",
                "An availability zone.",
                "A resource group."
            ], "A",
            """
            An Azure geography is a discrete market that usually contains two or more regions and
            exists to preserve data residency and compliance boundaries. Geographies frequently
            align to a country, although they are not strictly limited to one.

            A region pair links two regions inside a geography, an availability zone is a
            physically separate location inside a single region, and a resource group is a logical
            container for resources.
            """);

        yield return Mc("as-002", D2, "Describe the core architectural components of Azure", R2,
            """
            What is an Azure availability zone?
            """,
            [
                "A physically separate location within a region that has its own power, cooling and networking.",
                "A second Azure region located in the same geography as the primary region.",
                "A logical container used to group resources that share a lifecycle.",
                "A boundary that determines which subscription is billed for a resource."
            ], "A",
            """
            An availability zone is a physically separate location inside a region with
            independent power, cooling and networking, so a failure affecting one zone should not
            affect another. A zone may encompass more than one data centre.

            A paired region in the same geography is a region pair, a logical grouping of
            resources is a resource group, and billing boundaries are set by subscriptions.
            """);

        yield return Mc("as-003", D2, "Describe the core architectural components of Azure", R2,
            """
            What is the minimum number of availability zones in an Azure region that supports
            availability zones?
            """,
            ["Three.", "One.", "Two.", "Six."], "A",
            """
            A region that supports availability zones provides at least three of them, which is
            what makes zone-redundant deployments possible.

            Not every Azure region offers availability zones, so zone support has to be confirmed
            for the specific region a workload will use.
            """);

        yield return Mc("as-004", D2, "Describe the core architectural components of Azure", R2,
            """
            Which statement about Azure region pairs is correct?
            """,
            [
                "Microsoft defines the pairing, and planned updates are rolled out to only one region of the pair at a time.",
                "Customers select which region their primary region is paired with.",
                "Both regions of a pair are always located in different geographies.",
                "Region pairs are updated simultaneously to keep them identical."
            ], "A",
            """
            Region pairings are defined by Microsoft rather than chosen by the customer, and both
            regions of a pair sit within the same geography so that data residency commitments are
            preserved.

            Planned platform updates are deliberately applied serially, to one region at a time,
            so that a faulty update cannot take down both halves of a pair at once.
            """);

        yield return Dropdowns("as-005", D2, "Describe the core architectural components of Azure", R2,
            """
            Select the answer choice that completes each statement based on the information
            presented.
            """,
            [
                ("A discrete market that preserves data residency boundaries is called",
                    ["a region", "a geography", "an availability zone", "a resource group"], 2),
                ("A physically separate location within a region with independent power and cooling is called",
                    ["a region pair", "a geography", "an availability zone", "a fault domain"], 3),
                ("Two regions in the same geography that Microsoft updates one at a time are called",
                    ["a region pair", "an availability set", "a scale set", "a tenant"], 1)
            ],
            """
            The hierarchy runs from geographies, which are compliance and residency boundaries,
            down to regions, and then to availability zones inside a region.

            A region pair is the Microsoft-defined relationship between two regions in one
            geography that governs how platform updates and recovery are sequenced.
            """);

        yield return Mc("as-006", D2, "Describe the core architectural components of Azure", R2,
            """
            You must deploy two virtual machines so that the workload is covered by a 99.99
            percent availability commitment.

            What should you do?
            """,
            [
                "Deploy the virtual machines across two or more availability zones in the same region.",
                "Deploy both virtual machines into a single availability set.",
                "Deploy a single virtual machine that uses Premium SSD disks.",
                "Deploy both virtual machines to the same availability zone."
            ], "A",
            """
            Spreading two or more virtual machine instances across two or more availability zones
            in the same region provides the highest single-region commitment, 99.99 percent,
            because the instances no longer share power, cooling or networking.

            Two instances in one availability set reach 99.95 percent, and a single instance with
            Premium SSD disks reaches only 99.9 percent.
            """);

        yield return Drag("as-007", D2, "Describe the core architectural components of Azure", R2,
            """
            Match each virtual machine deployment to the availability commitment it achieves. Each
            commitment may be used once, more than once, or not at all.
            """,
            "Availability commitments",
            [
                "99.99 percent",
                "99.95 percent",
                "99.9 percent",
                "95 percent"
            ],
            [
                ("Two or more instances spread across two or more availability zones", 1),
                ("Two or more instances in the same availability set", 2),
                ("A single instance using Premium SSD disks for all disks", 3),
                ("A single instance using Standard HDD disks for all disks", 4)
            ],
            """
            The commitment ladder rewards separation. Spreading instances across availability
            zones gives 99.99 percent, and grouping instances in an availability set gives 99.95
            percent.

            A single instance can still qualify for a commitment based on its disk type: Premium
            SSD reaches 99.9 percent, Standard SSD reaches 99.5 percent, and Standard HDD reaches
            95 percent.
            """);

        yield return Mc("as-008", D2, "Describe the core architectural components of Azure", R2,
            """
            An availability set distributes virtual machines across fault domains and update
            domains.

            What does a fault domain represent?
            """,
            [
                "A group of hardware that shares a common power source and network switch.",
                "A group of hardware that is rebooted together during planned maintenance.",
                "A physically separate zone within a region.",
                "A logical container for resources that share a lifecycle."
            ], "A",
            """
            A fault domain is a logical grouping of hardware that shares a power source and a
            network switch, typically a physical rack. Distributing instances across fault domains
            protects against the loss of any single rack.

            An update domain is the grouping that is rebooted together during planned maintenance,
            which is what allows an availability set to be patched without taking the whole set
            offline.
            """);

        yield return YesNo("as-009", D2, "Describe the core architectural components of Azure", R2,
            """
            For each of the following statements about availability sets and availability zones,
            select Yes if the statement is true. Otherwise, select No.
            """,
            [
                ("An availability set distributes virtual machines across fault domains and update domains.", true),
                ("An availability zone protects a workload against the failure of an entire region.", false),
                ("Deploying across availability zones can raise the virtual machine availability commitment to 99.99 percent.", true)
            ],
            """
            Availability sets exist precisely to spread instances across fault domains and update
            domains, and zone-spanning deployments do raise the commitment to 99.99 percent.

            Availability zones protect against failures inside a region, not against the loss of
            the whole region. Regional protection requires deploying to a second region.
            """);

        // ---------------------------------------------------------- resource hierarchy

        yield return Mc("as-010", D2, "Describe the core architectural components of Azure", R2,
            """
            Which statement about Azure resource groups is correct?
            """,
            [
                "A resource can belong to only one resource group at a time, although it can be moved to another group.",
                "A resource can belong to several resource groups at the same time.",
                "All resources in a resource group must be deployed to the same region.",
                "A resource group can span multiple subscriptions."
            ], "A",
            """
            A resource belongs to exactly one resource group, though it can be moved between
            groups. A resource group itself lives in exactly one subscription.

            Resources inside a group may be deployed to different regions; the group's own
            location is metadata that determines where its management data is stored.
            """);

        yield return Mc("as-011", D2, "Describe the core architectural components of Azure", R2,
            """
            You delete a resource group that contains a virtual machine, a storage account and a
            managed disk.

            What is the result?
            """,
            [
                "All three resources are deleted.",
                "The resource group is deleted and the resources are moved to the default group.",
                "The deletion fails because the resource group is not empty.",
                "Only the resource group metadata is deleted and the resources remain."
            ], "A",
            """
            Deleting a resource group deletes every resource it contains. This is why groups
            should contain resources that genuinely share a lifecycle, and why delete locks exist.

            There is no default group that orphaned resources fall back to, and Azure does not
            block the operation simply because the group has contents.
            """);

        yield return Mc("as-012", D2, "Describe the core architectural components of Azure", R2,
            """
            Place the following Azure scopes in order, from the broadest to the narrowest.
            """,
            [
                "Management group, subscription, resource group, resource.",
                "Subscription, management group, resource group, resource.",
                "Resource group, subscription, management group, resource.",
                "Management group, resource group, subscription, resource."
            ], "A",
            """
            Management groups sit at the top and can contain subscriptions and other management
            groups. Each subscription contains resource groups, and each resource group contains
            resources.

            This ordering matters because policies and role assignments applied at a higher scope
            are inherited by everything beneath them.
            """);

        yield return Mc("as-013", D2, "Describe the core architectural components of Azure", R2,
            """
            Which two purposes does an Azure subscription serve? Each correct answer presents a
            complete solution.
            """,
            [
                "It acts as a billing boundary that determines how consumption is invoiced.",
                "It acts as an administrative boundary for access control and policy.",
                "It defines the physical region in which every contained resource must run.",
                "It replaces the need for resource groups.",
                "It provides the authentication directory for user sign-in."
            ], "A,B",
            """
            A subscription is both a billing boundary, tying consumption to a payment agreement,
            and an administrative and scale boundary against which role assignments, policies and
            service limits apply.

            Resources in a subscription can be placed in many regions, resource groups remain
            required, and authentication is provided by a Microsoft Entra ID tenant rather than by
            the subscription itself.
            """);

        yield return Mc("as-014", D2, "Describe the core architectural components of Azure", R2,
            """
            What is an Azure tenant?
            """,
            [
                "A specific instance of Microsoft Entra ID that contains an organisation's accounts and groups.",
                "A logical container for resources that share a lifecycle.",
                "A billing agreement between an organisation and Microsoft.",
                "A physically separate location within an Azure region."
            ], "A",
            """
            A tenant is a dedicated instance of Microsoft Entra ID holding an organisation's user
            accounts and groups, and it provides authentication for cloud resources.

            A single tenant can back multiple subscriptions and can serve Azure, Microsoft 365 and
            Dynamics 365 together.
            """);

        yield return Mc("as-015", D2, "Describe the core architectural components of Azure", R2,
            """
            What is Azure Resource Manager?
            """,
            [
                "The deployment and management service that brokers requests from tools such as the portal, CLI and PowerShell to the resource providers.",
                "A monitoring service that collects metrics and logs from Azure resources.",
                "A physical appliance installed on-premises to manage hybrid resources.",
                "A billing service that produces invoices for each subscription."
            ], "A",
            """
            Azure Resource Manager is the service that receives management requests from every
            interface, including the portal, Azure CLI, Azure PowerShell and REST clients, and
            routes them to the appropriate resource providers.

            Because everything passes through it, features such as role-based access control,
            locks, tags and template deployment apply consistently no matter which tool is used.
            """);

        yield return Mc("as-016", D2, "Describe the core architectural components of Azure", R2,
            """
            In which format are Azure Resource Manager templates written?
            """,
            ["JSON.", "XML.", "YAML.", "CSV."], "A",
            """
            Azure Resource Manager templates are JSON documents that declare the resources to
            deploy and their properties, which makes infrastructure repeatable and suitable for
            version control.

            Bicep offers a more concise authoring language, but it is transpiled into the same
            JSON template before deployment.
            """);

        yield return YesNo("as-017", D2, "Describe the core architectural components of Azure", R2,
            """
            For each of the following statements about resource groups, select Yes if the
            statement is true. Otherwise, select No.
            """,
            [
                ("Resources in different resource groups can interact with one another.", true),
                ("A tag applied to a resource group is automatically inherited by the resources inside it.", false),
                ("A resource group can contain resources deployed to more than one region.", true)
            ],
            """
            Resource groups are a management convenience rather than an isolation boundary, so an
            application server in one group can freely use a database in another, and a group can
            hold resources from several regions.

            Tags applied to a resource group are not automatically inherited by the resources it
            contains; resources carry their own tags unless a policy is used to propagate them.
            """);

        // ---------------------------------------------------------- billing scopes

        yield return Mc("as-018", D2, "Describe Azure billing concepts", R2,
            """
            Your organisation purchases Azure through an Enterprise Agreement.

            Which billing scope is an optional grouping of enrollment accounts?
            """,
            ["A department.", "A billing profile.", "An invoice section.", "A resource group."], "A",
            """
            Under an Enterprise Agreement the billing scopes are the billing account, an optional
            department that groups enrollment accounts, and the enrollment account under which
            subscriptions are created.

            Billing profiles and invoice sections belong to the Microsoft Customer Agreement
            structure, and resource groups are not a billing scope at all.
            """);

        yield return Mc("as-019", D2, "Describe Azure billing concepts", R2,
            """
            Under a Microsoft Customer Agreement, at which billing scope are invoices generated?
            """,
            ["The billing profile.", "The billing account.", "The invoice section.", "The enrollment account."], "A",
            """
            A Microsoft Customer Agreement billing account is structured into billing profiles and
            invoice sections. The billing profile carries the invoice and its payment methods, so
            invoices are generated at that scope.

            An invoice section groups costs within an invoice, and enrollment accounts belong to
            the Enterprise Agreement structure instead.
            """);

        yield return Drag("as-020", D2, "Describe Azure billing concepts", R2,
            """
            Match each billing scope to the agreement type it belongs to. Each agreement type may
            be used once, more than once, or not at all.
            """,
            "Agreement types",
            [
                "Enterprise Agreement",
                "Microsoft Customer Agreement"
            ],
            [
                ("Enrollment account", 1),
                ("Billing profile", 2),
                ("Invoice section", 2),
                ("Department", 1)
            ],
            """
            Departments and enrollment accounts are the optional and required groupings used
            inside an Enterprise Agreement billing account.

            Billing profiles and invoice sections are the equivalent structures inside a Microsoft
            Customer Agreement, where the profile carries the invoice and the section groups costs
            within it.
            """);

        // ---------------------------------------------------------- compute

        yield return Mc("as-021", D2, "Describe Azure compute services", R2,
            """
            You need to run a group of identical, load-balanced virtual machines that
            automatically increases and decreases in size as demand changes.

            What should you use?
            """,
            [
                "A virtual machine scale set.",
                "An availability set.",
                "Azure Container Instances.",
                "Azure Virtual Desktop."
            ], "A",
            """
            A virtual machine scale set creates and manages a group of identical, load-balanced
            virtual machines built from the same image, and it can automatically scale the
            instance count in response to demand.

            An availability set improves resilience but does not scale anything, and the container
            and desktop services solve different problems entirely.
            """);

        yield return Mc("as-022", D2, "Describe Azure compute services", R2,
            """
            What is the maximum number of standard virtual machine instances supported in a
            virtual machine scale set?
            """,
            ["1,000.", "100.", "600.", "5,000."], "A",
            """
            A scale set supports up to 1,000 standard virtual machine instances. If the scale set
            is built from a custom image, the maximum drops to 600 instances.

            Knowing both numbers, and which one applies to custom images, is the point of this
            distinction.
            """);

        yield return Mc("as-023", D2, "Describe Azure compute services", R2,
            """
            A development team needs to deploy a web application written in Python. The team does
            not want to create or patch virtual machines, and it needs built-in load balancing and
            automatic scaling.

            Which service should the team use?
            """,
            [
                "Azure App Service.",
                "Azure Virtual Machines.",
                "Azure Virtual Desktop.",
                "Azure Kubernetes Service."
            ], "A",
            """
            Azure App Service is the platform as a service offering for web applications, REST
            APIs and mobile back ends. It supports several languages including Python, runs on
            Windows and Linux, and provides load balancing, automatic scaling and automated
            platform patching.

            Virtual machines would leave the team patching an operating system, and Kubernetes
            adds orchestration complexity that this scenario does not call for.
            """);

        yield return Mc("as-024", D2, "Describe Azure compute services", R2,
            """
            You need to run a small containerised application quickly, paying only for the CPU
            and memory the container consumes. Orchestration across many nodes is not required.

            Which service should you use?
            """,
            [
                "Azure Container Instances.",
                "Azure Kubernetes Service.",
                "Azure Virtual Machines.",
                "Azure App Service."
            ], "A",
            """
            Azure Container Instances runs containers without any cluster to manage and bills for
            the CPU and memory the container actually consumes, which suits simple or short-lived
            workloads.

            Azure Kubernetes Service is the right answer when many containers must be orchestrated,
            monitored and scaled together.
            """);

        yield return Mc("as-025", D2, "Describe Azure compute services", R2,
            """
            Your company must deploy and manage hundreds of containers, with automated health
            monitoring, scaling and scheduling across a cluster of nodes.

            Which service should you use?
            """,
            [
                "Azure Kubernetes Service.",
                "Azure Container Instances.",
                "Azure App Service.",
                "Azure Virtual Machine Scale Sets."
            ], "A",
            """
            Azure Kubernetes Service provides managed container orchestration. It monitors
            container health, schedules workloads across cluster nodes and scales them, which is
            what large container estates require.

            Azure Container Instances is aimed at simple, single-container or small-group
            scenarios and does not orchestrate a cluster.
            """);

        yield return Mc("as-026", D2, "Describe Azure compute services", R2,
            """
            Your organisation wants remote staff to run a full Windows desktop and line-of-business
            applications from low-cost devices, including macOS and iOS hardware, without shipping
            corporate laptops.

            Which service should you use?
            """,
            [
                "Azure Virtual Desktop.",
                "Azure App Service.",
                "Azure Container Instances.",
                "Azure Virtual Machine Scale Sets."
            ], "A",
            """
            Azure Virtual Desktop delivers Windows desktop and application sessions from Azure to
            a wide range of client devices, including Windows, macOS, iOS, Linux and browsers, and
            supports multi-session Windows.

            It removes the need to provision and refresh physical hardware for each user, which is
            exactly the requirement described.
            """);

        yield return Drag("as-027", D2, "Describe Azure compute services", R2,
            """
            Match each requirement to the most appropriate Azure compute service. Each service may
            be used once, more than once, or not at all.
            """,
            "Compute services",
            [
                "Azure Virtual Machines",
                "Azure App Service",
                "Azure Kubernetes Service",
                "Azure Virtual Desktop"
            ],
            [
                ("Host a web application without managing an operating system", 2),
                ("Orchestrate a large fleet of containers across cluster nodes", 3),
                ("Run a legacy application that requires full control of the guest operating system", 1),
                ("Provide remote Windows desktop sessions to staff on personal devices", 4)
            ],
            """
            App Service handles web applications without operating system management, and
            Kubernetes Service orchestrates large container estates.

            A legacy application needing full operating system control belongs on a virtual
            machine, and remote Windows sessions on personal devices are exactly what Azure Virtual
            Desktop delivers.
            """);

        yield return Mc("as-028", D2, "Describe Azure compute services", R2,
            """
            In Azure Container Instances, what is a container group?
            """,
            [
                "A collection of containers that run on the same host and share a lifecycle, local network and storage.",
                "A Kubernetes cluster consisting of multiple worker nodes.",
                "A resource group that contains only container resources.",
                "A set of containers replicated across multiple Azure regions."
            ], "A",
            """
            A container group is a set of containers scheduled onto the same host that share an
            operating system, a lifecycle, local network, storage and a single IP address and DNS
            name.

            Container groups are supported for Linux containers; Windows support in Container
            Instances has been limited to single container instances.
            """);

        // ---------------------------------------------------------- data services

        yield return Mc("as-029", D2, "Describe Azure compute and data services", R2,
            """
            You must deploy a relational database to Azure. You do not want to install SQL Server,
            manage an operating system, or apply patches, and you need a 99.99 percent availability
            commitment.

            Which service should you use?
            """,
            [
                "Azure SQL Database.",
                "SQL Server installed on an Azure virtual machine.",
                "Azure Cosmos DB.",
                "Azure Table storage."
            ], "A",
            """
            Azure SQL Database is a fully managed relational platform service. Microsoft handles
            upgrades, patching and monitoring, and the service carries a 99.99 percent availability
            commitment, leaving the customer to manage only the database objects.

            SQL Server on a virtual machine puts the operating system back under customer control,
            and Cosmos DB and Table storage are not relational SQL Server-compatible offerings.
            """);

        yield return Mc("as-030", D2, "Describe Azure compute and data services", R2,
            """
            You plan to migrate an on-premises SQL Server instance to Azure. The applications
            depend on linked servers, change data capture and common language runtime integration.

            Which service should you use?
            """,
            [
                "Azure SQL Managed Instance.",
                "Azure SQL Database.",
                "Azure Database for MySQL.",
                "Azure Cosmos DB."
            ], "A",
            """
            Azure SQL Managed Instance is designed for migrations that need close compatibility
            with a full SQL Server instance, including linked servers, change data capture and
            common language runtime integration, while remaining a managed platform service.

            Azure SQL Database is a single-database service that does not offer that same
            instance-level feature surface.
            """);

        yield return Mc("as-031", D2, "Describe Azure compute and data services", R2,
            """
            You need a globally distributed, multi-model database that provides millisecond
            response times and supports MongoDB, Cassandra and Gremlin APIs.

            Which service should you use?
            """,
            [
                "Azure Cosmos DB.",
                "Azure SQL Database.",
                "Azure Database for PostgreSQL.",
                "Azure Queue storage."
            ], "A",
            """
            Azure Cosmos DB is a multi-model database that scales out across Azure regions
            worldwide, offers millisecond response times, and exposes several APIs including
            Cassandra, MongoDB, Gremlin and Table.

            The Gremlin API in particular supports graph workloads with very large numbers of
            vertices and edges.
            """);

        yield return Mc("as-032", D2, "Describe Azure compute and data services", R2,
            """
            A company plans to migrate a web application that runs on a LAMP stack to Azure, and
            wants a managed database service rather than a virtual machine.

            Which service should the company use?
            """,
            [
                "Azure Database for MySQL.",
                "Azure Database for PostgreSQL.",
                "Azure SQL Database.",
                "Azure Table storage."
            ], "A",
            """
            The M in a LAMP stack stands for MySQL, so a managed MySQL platform service is the
            direct match. Azure Database for MySQL removes the need to run and patch a server
            while keeping the application's database engine unchanged.

            PostgreSQL and Azure SQL Database are different engines and would require application
            changes.
            """);

        yield return Drag("as-033", D2, "Describe Azure compute and data services", R2,
            """
            Match each data description to the correct classification. Each classification may be
            used once, more than once, or not at all.
            """,
            "Classifications",
            [
                "Structured data",
                "Semi-structured data",
                "Unstructured data"
            ],
            [
                ("Rows in a relational table defined by a fixed schema", 1),
                ("A JSON document containing tags that define a hierarchy of fields", 2),
                ("A collection of video files and scanned documents", 3)
            ],
            """
            Structured data conforms to a predefined schema, such as columns in a relational
            table.

            Semi-structured data is not bound to a rigid data model but still carries tags or
            markers that impose a hierarchy, which is what JSON and XML do. Unstructured data,
            such as video and scanned documents, has no predefined structure at all.
            """);

        // ---------------------------------------------------------- serverless

        yield return Mc("as-034", D2, "Describe Azure compute services", R2,
            """
            You need to run a small block of C# code each time a message arrives on a queue. The
            code runs for a few seconds and you want to pay only for the time it executes.

            Which service should you use?
            """,
            [
                "Azure Functions.",
                "Azure Logic Apps.",
                "Azure App Service.",
                "Azure Kubernetes Service."
            ], "A",
            """
            Azure Functions hosts a single method that runs in response to a trigger such as a
            queued message, an HTTP request or a timer. It scales automatically and bills only for
            the resources consumed while the function executes.

            Logic Apps targets multi-step workflow orchestration rather than a single short block
            of code.
            """);

        yield return Mc("as-035", D2, "Describe Azure compute services", R2,
            """
            A business analyst must automate a multi-step approval workflow that connects several
            software as a service applications, using a visual designer rather than writing code.

            Which service should the analyst use?
            """,
            [
                "Azure Logic Apps.",
                "Azure Functions.",
                "Azure Virtual Machines.",
                "Azure Container Instances."
            ], "A",
            """
            Azure Logic Apps provides a web-based visual designer in which triggers are connected
            to actions through prebuilt connectors, which suits no-code and low-code automation of
            business processes.

            Azure Functions is code-first and better suited to discrete tasks; the two services can
            call each other when a workflow needs custom logic.
            """);

        yield return YesNo("as-036", D2, "Describe Azure compute services", R2,
            """
            For each of the following statements about Azure Functions and Azure Logic Apps,
            select Yes if the statement is true. Otherwise, select No.
            """,
            [
                ("Azure Functions are stateless by default.", true),
                ("Azure Logic Apps are designed primarily for visual, connector-based workflows.", true),
                ("Azure Functions cannot be invoked from an Azure Logic App.", false)
            ],
            """
            Functions execute statelessly by default, although the Durable Functions extension can
            chain functions together and maintain state. Logic Apps is the visual, connector-driven
            workflow service.

            The two are complementary: a Logic App can call a Function, and a Function can start a
            Logic App, so the third statement is false.
            """);

        yield return Mc("as-037", D2, "Describe Azure compute services", R2,
            """
            Which online store is used to find and purchase third-party solutions, managed
            services and consulting services that are billed through your Azure account?
            """,
            [
                "Azure Marketplace.",
                "Microsoft AppSource.",
                "Microsoft Store.",
                "Azure Advisor."
            ], "A",
            """
            Azure Marketplace lists Azure-focused solutions, managed services and consulting
            offerings, and purchases are billed through the customer's Azure account.

            Microsoft AppSource targets business application solutions for products such as
            Dynamics 365, Microsoft 365 and Power Platform.
            """);

        yield return Mc("as-038", D2, "Describe Azure compute services", R2,
            """
            You must replicate an on-premises server to Azure so that the workload can be brought
            online in Azure if the primary site is lost.

            Which service should you use?
            """,
            [
                "Azure Site Recovery.",
                "Azure Migrate.",
                "Azure Data Box.",
                "Azure Advisor."
            ], "A",
            """
            Azure Site Recovery replicates virtual machines and physical servers from a primary
            site to a secondary location, which supports both disaster recovery and moving a
            running workload between regions.

            Azure Migrate assesses and orchestrates migrations, Data Box physically transports
            bulk data, and Advisor produces recommendations.
            """);

        yield return Hot("as-039", D2, "Describe the core architectural components of Azure", R2,
            """
            The work area shows the Azure resource hierarchy.

            Select the scope at which a policy assignment would apply to every subscription
            beneath it.
            """,
            "Azure scope hierarchy",
            [
                "Management group",
                "Subscription",
                "Resource group",
                "Resource"
            ], 1,
            """
            A management group sits above subscriptions and can contain both subscriptions and
            other management groups. An assignment made there is inherited by every subscription
            underneath.

            Assigning at a subscription, resource group or resource scope would limit the effect to
            that branch of the hierarchy only.
            """);

        yield return Build("as-040", D2, "Describe the core architectural components of Azure", R2,
            """
            You need to describe the Azure management hierarchy to a colleague.

            Arrange the scopes in order, beginning with the broadest.
            """,
            "Scopes",
            [
                "Management group",
                "Subscription",
                "Resource group",
                "Resource"
            ],
            [1, 2, 3, 4],
            """
            The hierarchy runs management group, subscription, resource group and finally the
            individual resource.

            Each level contains the one below it, and governance settings such as policy
            assignments and role assignments flow downward through the chain.
            """);
    }

    // ================================================================ storage

    private const string R3 = "Study guide, ch. 3: Azure Storage and Migration";

    private static IEnumerable<Item> StorageServices()
    {
        yield return Mc("st-001", D2, "Describe Azure storage services", R3,
            """
            You must store several million images, video files and log files that have no fixed
            schema, and make them retrievable over HTTPS.

            Which Azure storage service should you use?
            """,
            [
                "Blob storage.",
                "Azure Files.",
                "Azure Table storage.",
                "Azure Queue storage."
            ], "A",
            """
            Blob storage is optimised for very large volumes of unstructured data such as images,
            video, audio, logs, telemetry and backups, and it can be reached over HTTP and HTTPS
            as well as through the REST API, CLI, PowerShell and client libraries.

            Azure Files provides shared file access, Table storage holds structured NoSQL entities,
            and Queue storage carries small messages.
            """);

        yield return Mc("st-002", D2, "Describe Azure storage services", R3,
            """
            You need a storage service that on-premises servers and Azure virtual machines can
            mount concurrently using the SMB protocol, to replace an ageing on-premises file
            server.

            Which service should you use?
            """,
            [
                "Azure Files.",
                "Blob storage.",
                "Azure managed disks.",
                "Azure Table storage."
            ], "A",
            """
            Azure Files exposes fully managed file shares over the industry-standard SMB and NFS
            protocols, so on-premises clients and Azure services can mount the same share at the
            same time. That makes it a direct replacement for an on-premises file server.

            Managed disks attach to a single virtual machine, and blob storage is not mounted as a
            file share.
            """);

        yield return Mc("st-003", D2, "Describe Azure storage services", R3,
            """
            What is the maximum size of a single message in Azure Queue storage?
            """,
            ["64 KB.", "4 KB.", "256 KB.", "1 MB."], "A",
            """
            An Azure Queue storage message can be up to 64 KB. A queue can hold any number of
            messages, limited only by the capacity of the storage account.

            Queue storage exists to decouple components so that work can be processed
            asynchronously rather than in line with a user request.
            """);

        yield return Mc("st-004", D2, "Describe Azure storage services", R3,
            """
            Which storage service is a non-relational NoSQL datastore intended for large amounts
            of structured data such as user profiles and device inventories, with a flexible
            schema and no joins or stored procedures?
            """,
            [
                "Azure Table storage.",
                "Azure Queue storage.",
                "Azure Files.",
                "Azure SQL Database."
            ], "A",
            """
            Azure Table storage holds structured, schema-flexible entities and is queried through a
            clustered index. It suits contact data, device inventories, user profiles and IoT
            telemetry.

            For the same data model with global distribution and single-digit millisecond latency,
            Azure Cosmos DB for Table is the premium alternative.
            """);

        yield return Drag("st-005", D2, "Describe Azure storage services", R3,
            """
            Match each requirement to the appropriate Azure storage service. Each service may be
            used once, more than once, or not at all.
            """,
            "Storage services",
            [
                "Blob storage",
                "Azure Files",
                "Azure Table storage",
                "Azure Queue storage"
            ],
            [
                ("Store backup archives and video files", 1),
                ("Provide an SMB share reachable from on-premises and Azure", 2),
                ("Hold messages up to 64 KB for asynchronous processing", 4),
                ("Store schema-flexible entities such as device inventory records", 3)
            ],
            """
            Blob storage handles large unstructured objects, and Azure Files provides shared access
            over SMB or NFS.

            Queue storage carries small messages for asynchronous work, and Table storage holds
            structured but schema-flexible NoSQL entities.
            """);

        // ---------------------------------------------------------- access tiers

        yield return Mc("st-006", D2, "Describe Azure storage services", R3,
            """
            Your company must retain audit records for seven years. The records are almost never
            read, but they must be kept. You need the lowest possible storage cost and can accept
            a lengthy retrieval process.

            Which blob access tier should you use?
            """,
            ["Archive.", "Cold.", "Cool.", "Hot."], "A",
            """
            The archive tier stores data offline at the lowest storage cost, which suits records
            that are retained for compliance and effectively never read. The trade-off is that
            retrieving data requires rehydration, which carries the highest cost and latency of
            any tier.

            Hot, cool and cold are all online tiers offering progressively cheaper storage with
            progressively higher access costs.
            """);

        yield return Mc("st-007", D2, "Describe Azure storage services", R3,
            """
            What is the minimum retention period associated with the cold blob access tier?
            """,
            ["90 days.", "30 days.", "180 days.", "7 days."], "A",
            """
            The cold tier carries a 90-day minimum retention period. It offers lower storage costs
            than the cool tier while remaining online, at the cost of higher access charges.

            Moving data out of the tier before the minimum period elapses incurs an early deletion
            charge, which is why the threshold matters.
            """);

        yield return Dropdowns("st-008", D2, "Describe Azure storage services", R3,
            """
            Select the answer choice that completes each statement based on the information
            presented.
            """,
            [
                ("The blob access tier that stores data offline is",
                    ["hot", "cool", "cold", "archive"], 4),
                ("The blob access tier with the highest storage cost and the lowest access cost is",
                    ["hot", "cool", "cold", "archive"], 1),
                ("The blob access tier that requires a minimum retention of 90 days is",
                    ["hot", "cool", "cold", "archive"], 3)
            ],
            """
            Archive is the only offline tier, and its data must be rehydrated before it can be
            read.

            Hot is designed for frequently accessed data, so it has the highest storage cost and
            the lowest access cost. Cold sits between cool and archive and carries a 90-day minimum
            retention period.
            """);

        yield return YesNo("st-009", D2, "Describe Azure storage services", R3,
            """
            For each of the following statements about blob access tiers, select Yes if the
            statement is true. Otherwise, select No.
            """,
            [
                ("The access tier can be changed on an existing blob after it has been uploaded.", true),
                ("Data in the archive tier can be read immediately without rehydration.", false),
                ("The hot tier has a lower storage cost than the archive tier.", false)
            ],
            """
            A blob's access tier can be set during upload and changed afterwards, which is what
            makes lifecycle management possible.

            Archive data is stored offline and must be rehydrated before it can be read, and
            archive has the lowest storage cost of all the tiers, not the highest.
            """);

        // ---------------------------------------------------------- redundancy

        yield return Mc("st-010", D2, "Describe Azure storage services", R3,
            """
            Which storage redundancy option keeps three copies of data within a single physical
            location and offers the lowest cost?
            """,
            [
                "Locally redundant storage (LRS).",
                "Zone-redundant storage (ZRS).",
                "Geo-redundant storage (GRS).",
                "Read-access geo-redundant storage (RA-GRS)."
            ], "A",
            """
            Locally redundant storage keeps three copies within a single physical location, which
            protects against hardware and rack failures but not against the loss of the whole data
            centre. It is the least expensive option.

            Zone-redundant storage spreads copies across availability zones, and the geo-redundant
            options add a second region.
            """);

        yield return Mc("st-011", D2, "Describe Azure storage services", R3,
            """
            A storage account must remain available if an entire availability zone in the primary
            region fails. Replication to a second region is not required.

            Which redundancy option should you choose?
            """,
            [
                "Zone-redundant storage (ZRS).",
                "Locally redundant storage (LRS).",
                "Geo-redundant storage (GRS).",
                "Read-access geo-zone-redundant storage (RA-GZRS)."
            ], "A",
            """
            Zone-redundant storage writes three copies across three or more availability zones in
            the primary region, so the loss of one zone does not make the data unavailable.

            Locally redundant storage would not survive a zone failure, and the geo-redundant
            options add cross-region replication that the requirement explicitly does not need.
            """);

        yield return Mc("st-012", D2, "Describe Azure storage services", R3,
            """
            You configure a storage account to use geo-redundant storage (GRS).

            How many copies of the data exist in total, and where?
            """,
            [
                "Six copies: three in the primary region and three in the paired secondary region.",
                "Three copies, all in the primary region.",
                "Six copies, all in the primary region across three availability zones.",
                "Two copies: one in the primary region and one in the paired secondary region."
            ], "A",
            """
            Geo-redundant storage keeps three copies in the primary region and replicates the data
            to the paired secondary region, where a further three copies are kept, giving six in
            total.

            The secondary region is chosen by Microsoft rather than by the customer, and it is not
            readable unless the read-access variant is enabled.
            """);

        yield return Mc("st-013", D2, "Describe Azure storage services", R3,
            """
            You use geo-redundant storage (GRS) and want applications to be able to read data from
            the secondary region without waiting for a failover.

            What should you configure?
            """,
            [
                "Read-access geo-redundant storage (RA-GRS).",
                "Zone-redundant storage (ZRS).",
                "Locally redundant storage (LRS).",
                "A second storage account in the secondary region."
            ], "A",
            """
            With plain geo-redundant storage the secondary copy is not readable; access to it
            requires a failover, which updates DNS to point at the secondary region.

            The read-access variants, RA-GRS and RA-GZRS, make the secondary copy readable by
            default, so applications can read from it without a failover.
            """);

        yield return Mc("st-014", D2, "Describe Azure storage services", R3,
            """
            What distinguishes geo-zone-redundant storage (GZRS) from geo-redundant storage (GRS)?
            """,
            [
                "GZRS spreads the primary region copies across three availability zones, whereas GRS keeps them in a single location.",
                "GZRS replicates to two secondary regions, whereas GRS replicates to one.",
                "GZRS makes the secondary region readable by default, whereas GRS does not.",
                "GZRS keeps three copies in total, whereas GRS keeps six."
            ], "A",
            """
            Both options replicate to a paired secondary region and both offer the same very high
            durability. The difference is in the primary region: GZRS distributes the primary
            copies across three availability zones, while GRS keeps them within a single location.

            Readability of the secondary copy is controlled by the read-access variants, not by the
            choice between GRS and GZRS.
            """);

        yield return Drag("st-015", D2, "Describe Azure storage services", R3,
            """
            Match each requirement to the most appropriate storage redundancy option. Each option
            may be used once, more than once, or not at all.
            """,
            "Redundancy options",
            [
                "LRS",
                "ZRS",
                "GRS",
                "RA-GZRS"
            ],
            [
                ("Lowest cost, and the data can be regenerated if it is lost", 1),
                ("Must survive the loss of one availability zone, within a single region", 2),
                ("Must survive the loss of the entire primary region, with read access to the secondary copy at all times", 4),
                ("Must survive the loss of the entire primary region; secondary read access is not needed", 3)
            ],
            """
            Locally redundant storage is the cheapest and is appropriate when data can be
            regenerated. Zone-redundant storage covers the loss of an availability zone inside one
            region.

            For regional loss, geo-redundant storage suffices when the secondary copy need not be
            read, whereas the read-access geo-zone-redundant variant adds both zone resilience in
            the primary region and permanent read access to the secondary.
            """);

        // ---------------------------------------------------------- accounts and endpoints

        yield return Mc("st-016", D2, "Describe Azure storage services", R3,
            """
            Which naming rule applies to an Azure storage account name?
            """,
            [
                "It must be 3 to 24 characters long and contain only lowercase letters and numbers.",
                "It must be 3 to 24 characters long and may contain uppercase letters and hyphens.",
                "It must be 1 to 64 characters long and may contain any character.",
                "It must be 8 to 32 characters long and must begin with a letter or an underscore."
            ], "A",
            """
            A storage account name forms part of a globally unique DNS name, so it is restricted to
            3 to 24 characters using only lowercase letters and digits.

            Uppercase letters, hyphens and underscores are not permitted, which is a common source
            of deployment failures.
            """);

        yield return Mc("st-017", D2, "Describe Azure storage services", R3,
            """
            Which endpoint format is used to reach blob storage in a storage account named
            contosodata?
            """,
            [
                "https://contosodata.blob.core.windows.net",
                "https://contosodata.file.core.windows.net",
                "https://contosodata.queue.core.windows.net",
                "https://contosodata.table.core.windows.net"
            ], "A",
            """
            Each storage service has its own endpoint suffix. Blob storage uses blob, Azure Files
            uses file, Queue storage uses queue, Table storage uses table, Data Lake storage uses
            dfs, and a static website uses web.

            Recognising the service from the endpoint, and vice versa, is a common exam task.
            """);

        yield return Drag("st-018", D2, "Describe Azure storage services", R3,
            """
            Match each storage service to its endpoint suffix. Each suffix may be used once, more
            than once, or not at all.
            """,
            "Endpoint suffixes",
            [
                "blob.core.windows.net",
                "file.core.windows.net",
                "queue.core.windows.net",
                "table.core.windows.net"
            ],
            [
                ("Blob storage", 1),
                ("Azure Files", 2),
                ("Queue storage", 3),
                ("Table storage", 4)
            ],
            """
            Storage endpoints follow a consistent pattern in which the service name forms the first
            label after the account name.

            Data Lake storage uses dfs and static website hosting uses web, both of which follow
            the same convention.
            """);

        yield return Mc("st-019", D2, "Describe Azure storage services", R3,
            """
            Which disk attached to an Azure virtual machine is not guaranteed to retain its data
            through a maintenance event?
            """,
            [
                "The temporary disk.",
                "The OS disk.",
                "A data disk.",
                "A managed snapshot."
            ], "A",
            """
            The temporary disk provides fast local scratch space but is not persistent: its
            contents can be lost during maintenance events and should never hold anything that
            matters.

            The OS disk and any attached data disks are persistent managed disks and survive
            reboots and redeployment.
            """);

        yield return YesNo("st-020", D2, "Describe Azure storage services", R3,
            """
            For each of the following statements about Azure managed disks, select Yes if the
            statement is true. Otherwise, select No.
            """,
            [
                ("Server-side encryption of data at rest is enabled by default.", true),
                ("A data disk retains its contents when the virtual machine is restarted.", true),
                ("The temporary disk is the recommended location for a database data file.", false)
            ],
            """
            Managed disks are encrypted at rest by default through server-side encryption, and
            additional in-guest encryption is available using BitLocker on Windows or DM-Crypt on
            Linux. Data disks are persistent across restarts.

            The temporary disk is not persistent, so placing durable data such as a database file
            on it risks losing that data.
            """);

        // ---------------------------------------------------------- migration

        yield return Mc("st-021", D2, "Describe Azure storage services", R3,
            """
            Your company must move 800 TB of data to Azure. The available internet connection would
            take many months to transfer that volume.

            Which option should you use?
            """,
            [
                "Azure Data Box Heavy.",
                "Azure Data Box Disk.",
                "AzCopy.",
                "Azure File Sync."
            ], "A",
            """
            Azure Data Box Heavy is the largest member of the Data Box family, with roughly one
            petabyte of capacity, and is intended for very large offline transfers where network
            bandwidth is the limiting factor.

            The standard Data Box offers 120 TB or 525 TB, Data Box Disk covers much smaller
            transfers, and the network-based tools would be constrained by the same slow link.
            """);

        yield return Mc("st-022", D2, "Describe Azure storage services", R3,
            """
            Which tool is a command-line utility used to copy blobs and files to and from an Azure
            storage account?
            """,
            [
                "AzCopy.",
                "Azure Storage Explorer.",
                "Azure File Sync.",
                "Azure Data Box."
            ], "A",
            """
            AzCopy is the scriptable command-line tool for uploading, downloading and copying blobs
            and files, and it is well suited to a modest number of files.

            Azure Storage Explorer is the graphical application that uses AzCopy underneath, File
            Sync is a Windows Server agent, and Data Box is a physical shipping device.
            """);

        yield return Mc("st-023", D2, "Describe Azure storage services", R3,
            """
            You need to cache frequently used files from an Azure file share on an on-premises
            Windows Server, keeping less-used files only in Azure.

            Which service should you use?
            """,
            [
                "Azure File Sync.",
                "AzCopy.",
                "Azure Storage Explorer.",
                "Azure Data Box Gateway."
            ], "A",
            """
            Azure File Sync installs an agent on Windows Server and synchronises it with an Azure
            file share, keeping hot files cached locally while cold files remain in Azure. This is
            commonly called cloud tiering.

            AzCopy and Storage Explorer are transfer tools rather than a continuous synchronisation
            service.
            """);

        yield return Mc("st-024", D2, "Describe Azure storage services", R3,
            """
            Which service provides a central hub for discovering, assessing and migrating
            on-premises servers, databases and web applications to Azure?
            """,
            [
                "Azure Migrate.",
                "Azure Site Recovery.",
                "Azure Advisor.",
                "Azure Arc."
            ], "A",
            """
            Azure Migrate is the central hub for the whole migration process. An appliance deployed
            on-premises collects configuration and performance data, which Azure Migrate uses to
            build assessments and business cases before migration begins.

            It also brings together related tools for server, database and web application
            migration.
            """);

        yield return Mc("st-025", D2, "Describe Azure storage services", R3,
            """
            Which two capacities are available for the standard Azure Data Box device? Each correct
            answer presents a complete solution.
            """,
            ["120 TB.", "525 TB.", "1 PB.", "40 TB.", "8 TB."], "A,B",
            """
            The standard Azure Data Box is offered in 120 TB and 525 TB capacities, which covers
            medium to large offline transfers.

            Roughly one petabyte corresponds to Data Box Heavy, while much smaller transfers are
            handled by Data Box Disk, which ships as a set of one to five encrypted solid-state
            disks.
            """);

        yield return Mc("st-026", D2, "Describe Azure storage services", R3,
            """
            A storage account must hold data that can be recreated easily if it is lost, and cost
            is the primary consideration.

            Which redundancy option should you select?
            """,
            [
                "Locally redundant storage.",
                "Zone-redundant storage.",
                "Geo-redundant storage.",
                "Read-access geo-zone-redundant storage."
            ], "A",
            """
            Locally redundant storage is the least expensive option and is appropriate when the
            data can be regenerated, because the consequence of a data centre-level event is
            acceptable.

            Each step up the redundancy ladder adds resilience and cost, which is unnecessary when
            the data is easily reproducible.
            """);

        yield return Mc("st-027", D2, "Describe Azure storage services", R3,
            """
            Which blob type is designed for frequent random read and write operations, and is used
            for virtual machine disk files?
            """,
            ["Page blobs.", "Block blobs.", "Append blobs.", "Archive blobs."], "A",
            """
            Page blobs are collections of 512-byte pages optimised for frequent random reads and
            writes, which is why they back virtual hard disk files.

            Block blobs are the default and suit sequential upload and download, while append blobs
            are optimised for appending, such as writing log entries.
            """);

        yield return Mc("st-028", D2, "Describe Azure storage services", R3,
            """
            Which blob type is optimised for logging scenarios in which data is only ever added to
            the end of the blob?
            """,
            ["Append blobs.", "Block blobs.", "Page blobs.", "Managed disks."], "A",
            """
            Append blobs are optimised for append operations, which makes them a natural fit for
            log and telemetry files that grow continuously at the end.

            Block blobs suit general sequential transfer, and page blobs are for random access
            workloads such as virtual disks.
            """);
    }
}
