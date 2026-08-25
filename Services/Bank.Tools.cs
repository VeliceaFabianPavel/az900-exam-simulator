using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Domain 3, management tools portion. Sourced from chapter 8.
public static partial class QuestionBank
{
    private const string R8 = "Study guide, ch. 8: Creating and Managing Azure Resources";

    private static IEnumerable<Item> ManagementTools()
    {
        yield return Mc("mt-001", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Which Azure management tool is a web-based graphical interface that can be used from
            any device with a browser and requires no installation?
            """,
            [
                "The Azure portal.",
                "Azure PowerShell.",
                "The Azure CLI.",
                "The Azure mobile app."
            ], "A",
            """
            The Azure portal is the browser-based graphical interface for viewing, creating and
            managing resources. It requires no installation and works from Windows, macOS, Linux
            and tablet devices.

            It is well suited to simple, one-off tasks but is not scriptable, which makes it a poor
            fit for repeated bulk deployments.
            """);

        yield return Mc("mt-002", D3, "Describe features and tools for managing Azure resources", R8,
            """
            You must deploy fifty identically configured virtual machines and repeat the same
            deployment in three other subscriptions.

            Which approach is most appropriate?
            """,
            [
                "Use Azure PowerShell or the Azure CLI with a script.",
                "Use the Azure portal and repeat the creation wizard for each virtual machine.",
                "Use the Azure mobile app.",
                "Use Azure Advisor."
            ], "A",
            """
            Scripting with Azure PowerShell or the Azure CLI makes the deployment repeatable and
            fast, and the same script can be run against several subscriptions without manual
            steps.

            Repeating a portal wizard fifty times is slow and error-prone, and the mobile app is
            not intended for bulk work at all.
            """);

        yield return Mc("mt-003", D3, "Describe features and tools for managing Azure resources", R8,
            """
            What is the relationship between Azure PowerShell and the Azure CLI?
            """,
            [
                "They provide broadly equivalent capabilities using different syntax, so the choice is usually one of familiarity.",
                "The Azure CLI can perform tasks that Azure PowerShell cannot perform at all.",
                "Azure PowerShell runs only on Windows and the Azure CLI runs only on Linux.",
                "The Azure CLI is a graphical tool and Azure PowerShell is a command-line tool."
            ], "A",
            """
            Both tools call the same underlying Azure REST API and offer broadly the same
            capabilities. Azure PowerShell uses cmdlet syntax while the Azure CLI uses a Bash-like
            command syntax, so teams generally choose the one that matches their existing skills.

            Both run on Windows, Linux and macOS, and both can be used in Azure Cloud Shell.
            """);

        yield return Mc("mt-004", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Which statement about Azure Cloud Shell is correct?
            """,
            [
                "It is a browser-based shell in which you choose either Bash or PowerShell for the session, and it requires a backing storage account.",
                "It runs Bash and PowerShell simultaneously in the same session.",
                "It must be installed locally before it can be used.",
                "It can only be used from a Windows computer."
            ], "A",
            """
            Azure Cloud Shell provides an authenticated shell in the browser. You select either
            Bash or PowerShell for the session, and a storage account is required to persist files
            between sessions.

            It needs no local installation and can be reached from the Azure portal or directly,
            which makes it useful when installing tools locally is not practical.
            """);

        yield return Mc("mt-005", D3, "Describe features and tools for managing Azure resources", R8,
            """
            An administrator is away from the office and needs to check resource health, view
            alerts and restart a web app from a phone.

            Which tool should they use?
            """,
            [
                "The Azure mobile app.",
                "The Azure portal on a desktop computer.",
                "An ARM template.",
                "Azure Advisor."
            ], "A",
            """
            The Azure mobile app, available for Android and iOS, is designed for exactly this
            scenario: checking resource health and alerts and performing quick actions such as
            restarting a web app or virtual machine, and it can even run CLI or PowerShell
            commands.

            It is deliberately limited compared with the portal and is not intended for complex
            management work.
            """);

        yield return Drag("mt-006", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Match each scenario to the most appropriate Azure management tool. Each tool may be
            used once, more than once, or not at all.
            """,
            "Management tools",
            [
                "Azure portal",
                "Azure PowerShell or Azure CLI",
                "Azure mobile app",
                "ARM template"
            ],
            [
                ("Visually explore a service and change one setting on a single resource", 1),
                ("Automate a repeatable deployment of many resources from a script", 2),
                ("Check an alert and restart a virtual machine while away from a computer", 3),
                ("Declare an entire environment as code so it can be deployed identically each time", 4)
            ],
            """
            The portal suits visual, one-off changes, and the command-line tools suit scripted
            automation of many resources.

            The mobile app covers quick actions from a phone, and an Azure Resource Manager
            template declares the desired infrastructure so the same environment can be deployed
            repeatedly.
            """);

        yield return Mc("mt-007", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Which statement best describes infrastructure as code using Azure Resource Manager
            templates?
            """,
            [
                "The template declares the desired end state, and Azure determines the steps needed to reach it.",
                "The template lists each command to run, in order, to build the environment.",
                "The template is a graphical diagram that must be redrawn for each deployment.",
                "The template can only be used to create virtual machines."
            ], "A",
            """
            Azure Resource Manager templates are declarative: they describe what the environment
            should look like, and Azure works out how to achieve that state. Re-deploying a
            template converges the environment on the declared state rather than duplicating
            resources.

            An imperative approach, by contrast, specifies the exact sequence of commands to run,
            which is what a shell script does.
            """);

        yield return Mc("mt-008", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Your company must apply Azure Policy and use Azure Monitor to govern servers that run
            in an on-premises data centre and in another public cloud.

            Which service should you use?
            """,
            [
                "Azure Arc.",
                "Azure Migrate.",
                "Azure Site Recovery.",
                "Azure Virtual Desktop."
            ], "A",
            """
            Azure Arc projects non-Azure resources into Azure Resource Manager so that they can be
            managed like native Azure resources, including tagging, Azure Policy assignment,
            role-based access control and Azure Monitor.

            Azure Migrate moves workloads into Azure, and Site Recovery replicates them; neither
            provides ongoing governance of resources that stay where they are.
            """);

        yield return Mc("mt-009", D3, "Describe features and tools for managing Azure resources", R8,
            """
            How is an on-premises server onboarded to Azure Arc?
            """,
            [
                "By installing the Azure Connected Machine agent, after which the server receives an Azure Resource Manager identifier.",
                "By migrating the server into an Azure region as a virtual machine.",
                "By establishing an ExpressRoute circuit to the data centre.",
                "By deploying an ARM template into the on-premises hypervisor."
            ], "A",
            """
            Onboarding installs the Azure Connected Machine agent on the server. The server is then
            represented in Azure with its own Resource Manager identifier, a managed identity, a
            resource group and a subscription, and it appears in the portal alongside native
            resources.

            The server itself stays where it is; Arc adds a management layer rather than moving the
            workload.
            """);

        yield return YesNo("mt-010", D3, "Describe features and tools for managing Azure resources", R8,
            """
            For each of the following statements about Azure Arc, select Yes if the statement is
            true. Otherwise, select No.
            """,
            [
                ("Azure Arc can extend Azure Policy to servers running in another public cloud.", true),
                ("An Arc-enabled server is physically relocated into an Azure data centre.", false),
                ("Kubernetes clusters running outside Azure can be attached to Azure Arc.", true)
            ],
            """
            Arc extends Azure governance, including Azure Policy and Azure Monitor, to servers and
            Kubernetes clusters wherever they run, including other public clouds and edge
            locations.

            The resources are not moved. Arc registers and manages them in place, which is exactly
            what makes it a hybrid and multicloud management solution.
            """);

        yield return Mc("mt-011", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Which statement about a resource group's region is correct?
            """,
            [
                "The region determines where the resource group's metadata is stored; resources in the group can be deployed to other regions.",
                "Every resource in the group must be deployed to the resource group's region.",
                "The region determines which subscription is billed.",
                "A resource group has no region."
            ], "A",
            """
            A resource group has a location that determines where its metadata is stored, but the
            resources it contains can be deployed to any region.

            The region of the resource group can still matter for resilience, because that metadata
            must be reachable in order to manage the group.
            """);

        yield return Mc("mt-012", D3, "Describe features and tools for managing Azure resources", R8,
            """
            You delete an Azure virtual machine through the portal.

            What happens to the associated network interface, public IP address and managed disks?
            """,
            [
                "They are not deleted automatically and must be removed separately if they are no longer needed.",
                "They are always deleted along with the virtual machine.",
                "They are moved to a recycle bin for thirty days.",
                "They are converted into a snapshot automatically."
            ], "A",
            """
            Deleting a virtual machine removes the compute resource but leaves associated resources
            such as the network interface, public IP address and managed disks in place, and those
            continue to incur charges.

            Full cleanup therefore means deleting the associated resources as well, or deleting the
            whole resource group if it contains nothing else that must be kept.
            """);

        yield return Mc("mt-013", D3, "Describe features and tools for managing Azure resources", R8,
            """
            You want to stop paying compute charges for a development virtual machine overnight,
            while keeping its configuration and data intact.

            What should you do?
            """,
            [
                "Stop and deallocate the virtual machine.",
                "Delete the virtual machine.",
                "Apply a ReadOnly lock to the virtual machine.",
                "Resize the virtual machine to the smallest available size."
            ], "A",
            """
            Stopping and deallocating a virtual machine releases its compute resources so compute
            charges cease, while the disks and configuration remain so the machine can be started
            again later.

            Deleting it would remove the configuration, a lock does not affect billing, and
            resizing merely reduces the rate rather than stopping it.
            """);

        yield return Mc("mt-014", D3, "Describe features and tools for managing Azure resources", R8,
            """
            In the Azure portal, what is a blade?
            """,
            [
                "A panel that displays the settings, controls and information for a particular resource, service or task.",
                "A physical server in an Azure data centre.",
                "A command executed in Azure Cloud Shell.",
                "A template used to deploy resources."
            ], "A",
            """
            In the Azure portal, a blade is a panel or page presenting the configuration options,
            controls and monitoring information for a specific resource, service or task, and it
            serves as the entry point for working with that item.

            The term describes the portal's user interface and has nothing to do with server
            hardware.
            """);

        yield return Mc("mt-015", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Which naming requirement applies when you create a storage account in the Azure portal?
            """,
            [
                "The name must be globally unique and consist only of lowercase letters and numbers.",
                "The name must be unique within the resource group and may contain hyphens.",
                "The name must be unique within the subscription and may contain uppercase letters.",
                "The name has no restrictions."
            ], "A",
            """
            A storage account name forms part of a globally unique DNS name, so it must be unique
            across all Azure storage accounts and may contain only lowercase letters and digits.

            Because the namespace is global, a descriptive name is often already taken, which is
            why organisations usually adopt a naming convention with a suffix.
            """);

        yield return Mc("mt-016", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Which tool would you install on a Windows, macOS or Linux computer to browse and manage
            the contents of Azure storage accounts through a graphical interface?
            """,
            [
                "Azure Storage Explorer.",
                "AzCopy.",
                "Azure Cloud Shell.",
                "The Azure mobile app."
            ], "A",
            """
            Azure Storage Explorer is the standalone graphical application for browsing and managing
            blobs, files, queues and tables, and it is available for Windows, macOS and Linux.

            AzCopy is the command-line transfer utility that Storage Explorer uses underneath for
            data movement.
            """);

        yield return Dropdowns("mt-017", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Select the answer choice that completes each statement based on the information
            presented.
            """,
            [
                ("A browser-based shell that runs either Bash or PowerShell is",
                    ["the Azure portal", "Azure Cloud Shell", "the Azure mobile app", "an ARM template"], 2),
                ("A JSON file that declares the resources to deploy is",
                    ["the Azure portal", "Azure Cloud Shell", "the Azure CLI", "an ARM template"], 4),
                ("The service that extends Azure management to servers outside Azure is",
                    ["Azure Arc", "Azure Migrate", "Azure Advisor", "Azure Monitor"], 1)
            ],
            """
            Azure Cloud Shell is the authenticated browser shell, and an Azure Resource Manager
            template is the JSON document that declares the desired resources.

            Azure Arc is the service that brings servers, Kubernetes clusters and data services
            outside Azure under Azure management and governance.
            """);

        yield return Mc("mt-018", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Which statement describes the difference between a declarative and an imperative
            approach to deploying infrastructure?
            """,
            [
                "A declarative approach states the desired end state, whereas an imperative approach specifies the sequence of commands to reach it.",
                "A declarative approach specifies the sequence of commands, whereas an imperative approach states the desired end state.",
                "A declarative approach can only be used in the Azure portal.",
                "An imperative approach cannot be automated."
            ], "A",
            """
            Declarative deployment, as used by Azure Resource Manager templates and Bicep, describes
            what the result should be and lets the platform work out how to get there.

            Imperative deployment, as used by a PowerShell or CLI script, lists the operations to
            perform in order. Both can be automated; they differ in how the intent is expressed.
            """);

        yield return Mc("mt-019", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Which authoring language is designed as a more concise alternative to JSON Azure
            Resource Manager templates and is transpiled into them before deployment?
            """,
            ["Bicep.", "YAML.", "Kusto Query Language.", "Terraform HCL."], "A",
            """
            Bicep is a domain-specific language for declaring Azure infrastructure with far less
            syntax than raw JSON. Bicep files are transpiled into standard Azure Resource Manager
            templates, so they gain the same deployment behaviour.

            Kusto Query Language is used for querying logs, and Terraform is a third-party tool
            rather than a native template language.
            """);

        yield return Mc("mt-020", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Which Azure Arc mode allows data services to be managed locally with only limited Azure
            integration, so that data remains within a required geographic location?
            """,
            [
                "Disconnected mode.",
                "Connected mode.",
                "Preview mode.",
                "Read-only mode."
            ], "A",
            """
            Disconnected mode keeps Arc-enabled data services under local management and does not
            automatically send data to Azure, which supports data residency requirements while
            still allowing metadata and billing information to be exported periodically.

            Connected mode provides the full experience, with direct management in the Azure portal
            and continuous monitoring and inventory.
            """);
    }
}
