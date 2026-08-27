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
            Which Azure management tool is a web-based graphical interface that needs no
            installation, and what is its main limitation?
            """,
            [
                "The Azure portal, whose limitation is that it is not scriptable, so it suits one-off tasks rather than repeated bulk work.",
                "The Azure portal, whose limitation is that it works only from Windows computers.",
                "Azure Cloud Shell, whose limitation is that it provides no graphical interface for resources.",
                "The Azure mobile app, whose limitation is that it requires a local installation on a desktop."
            ], "A",
            """
            The Azure portal is the browser-based graphical interface for viewing, creating and
            managing resources. It needs no installation and works from Windows, macOS, Linux and
            tablets, so the platform claim in option B is wrong.

            Its limitation is repeatability rather than reach. Every action is a manual one, so
            fifty identical deployments mean fifty passes through a wizard, which is where the
            command-line tools and templates take over.
            """,
            """
            All four options pair a tool with a limitation. Check the limitation as carefully as the
            tool, since two of them are simply untrue.
            """);

        yield return Mc("mt-002", D3, "Describe features and tools for managing Azure resources", R8,
            """
            You must deploy fifty identically configured virtual machines, repeat the same
            deployment in three other subscriptions, and be able to prove later exactly what was
            deployed.

            Which approach is most appropriate?
            """,
            [
                "Declare the environment in an ARM template or Bicep file, keep it in source control, and deploy it to each subscription.",
                "Use the Azure portal creation wizard and repeat it for each virtual machine.",
                "Use the Azure mobile app to create the machines in batches.",
                "Ask Azure Advisor to generate the deployment."
            ], "A",
            """
            A script would be a reasonable answer to the first two requirements, but the third
            requirement is what settles it. A template declares the desired end state in a file that
            can be reviewed, versioned and re-deployed, so the record of what was deployed is the
            artefact itself.

            Repeating a wizard fifty times is slow and error-prone and leaves no such record. The
            mobile app is for quick actions, and Advisor recommends changes rather than deploying
            anything.
            """,
            """
            Two of the three requirements are about repetition, which several tools handle. The
            third is about evidence, and that narrows it to one.
            """);

        yield return Mc("mt-003", D3, "Describe features and tools for managing Azure resources", R8,
            """
            A team is deciding between Azure PowerShell and the Azure CLI for its automation.

            Which statement is correct?
            """,
            [
                "Both call the same Azure REST API and offer broadly equivalent capabilities with different syntax, and both run on Windows, Linux and macOS, so the choice is largely one of familiarity.",
                "The Azure CLI can perform management tasks that Azure PowerShell cannot perform at all.",
                "Azure PowerShell runs only on Windows and the Azure CLI runs only on Linux.",
                "The Azure CLI is graphical and Azure PowerShell is command-line, so they suit different audiences."
            ], "A",
            """
            Both tools sit on the same Azure REST API, which is why their capabilities line up so
            closely. Azure PowerShell uses cmdlet syntax and returns objects; the Azure CLI uses a
            Bash-like command syntax and returns JSON by default.

            Both are cross-platform and both are available in Azure Cloud Shell, so neither the
            platform claim nor the graphical claim survives. In practice teams pick the one matching
            the skills and scripting language they already use.
            """,
            """
            Three of these options assert a hard limitation on one of the two tools. Ask whether any
            of those limitations actually exists.
            """);

        yield return Mc("mt-004", D3, "Describe features and tools for managing Azure resources", R8,
            """
            A consultant on a locked-down client laptop cannot install anything but must run Azure
            CLI commands.

            Which statement about Azure Cloud Shell is correct?
            """,
            [
                "It is an authenticated browser-based shell in which you choose either Bash or PowerShell per session, and it needs a backing storage account to persist files between sessions.",
                "It runs Bash and PowerShell simultaneously in one session, so no choice is needed.",
                "It must be installed locally before it can be used, which rules it out here.",
                "It can be used only from a Windows computer."
            ], "A",
            """
            Cloud Shell gives an already-authenticated shell inside the browser, which is exactly
            what a machine with no install rights needs. You choose Bash or PowerShell for the
            session rather than getting both at once.

            The storage account is the detail worth remembering: Cloud Shell attaches a file share
            so scripts and files survive between sessions, and it prompts to create one the first
            time you use it. Nothing is installed locally and any operating system can reach it.
            """,
            """
            Two facts define this service: what you must pick at the start of a session, and what it
            asks you to create the first time you run it.
            """);

        yield return Mc("mt-005", D3, "Describe features and tools for managing Azure resources", R8,
            """
            An administrator away from the office must check resource health, review alerts and
            restart a web app from a phone.

            Which tool should they use?
            """,
            [
                "The Azure mobile app.",
                "The Azure portal, which has no mobile-capable interface.",
                "An ARM template deployment.",
                "Azure Advisor."
            ], "A",
            """
            The Azure mobile app, for Android and iOS, is built for this: checking resource health
            and alerts and performing quick actions such as restarting a web app or virtual machine.
            It can even run CLI or PowerShell commands through an embedded Cloud Shell.

            It is deliberately narrower than the portal and is not meant for complex management. The
            claim in option B is also false, since the portal is usable on tablets and phones; the
            app is simply better suited to it.
            """,
            """
            One distractor makes a factual claim about the portal that is worth checking before you
            accept it as the reason.
            """);

        yield return Drag("mt-006", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Match each scenario to the most appropriate Azure management tool. Each tool may be used
            once, more than once, or not at all.
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
                ("Declare an entire environment as code so it deploys identically every time", 4),
                ("Re-run the same deployment and have Azure converge the environment on the declared state", 4)
            ],
            """
            The portal suits visual, one-off changes; the command-line tools suit scripted
            automation; and the mobile app covers quick actions from a phone.

            The last two rows both belong to templates, and the second of them explains why. A
            script tells Azure what to do, so running it twice may do it twice; a template tells
            Azure what should exist, so running it twice simply confirms the state. That idempotence
            is the reason templates and scripts are not interchangeable.
            """,
            """
            The final row describes a behaviour that a script does not have. Ask what happens when
            each option is run for the second time.
            """);

        yield return Mc("mt-007", D3, "Describe features and tools for managing Azure resources", R8,
            """
            A team deploys the same ARM template twice in a row to the same resource group.

            What happens, and why?
            """,
            [
                "The environment converges on the declared state rather than duplicating resources, because a template declares the desired end state and Azure works out the steps.",
                "A second copy of every resource is created, because a template lists the operations to perform.",
                "The deployment fails, because a template can only be applied to an empty resource group.",
                "Only virtual machines are affected, because templates can deploy nothing else."
            ], "A",
            """
            Azure Resource Manager templates are declarative: they describe what the environment
            should look like and leave the how to Azure. Re-deploying therefore converges the
            environment on the declared state rather than duplicating anything, which is what makes
            a template safe to run repeatedly in a pipeline.

            An imperative approach, such as a shell script, specifies the exact sequence of
            operations, and running it twice really can perform them twice.
            """,
            """
            The question is really about the difference between describing a result and listing
            steps. Which of those can safely be repeated?
            """);

        yield return Mc("mt-008", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Your company must apply Azure Policy and use Azure Monitor to govern servers that will
            remain in an on-premises data centre and in another public cloud.

            Which service should you use?
            """,
            [
                "Azure Arc.",
                "Azure Migrate.",
                "Azure Site Recovery.",
                "Azure Stack HCI."
            ], "A",
            """
            Azure Arc projects non-Azure resources into Azure Resource Manager so they can be
            managed like native ones, including tagging, Azure Policy assignment, role-based access
            control and Azure Monitor.

            The clause that rules out the alternatives is that the servers stay where they are.
            Migrate moves workloads into Azure and Site Recovery replicates them for failover, so
            both end with the workload somewhere else. Arc is the one that governs it in place.
            """,
            """
            Several services connect Azure to servers elsewhere. Only one of them leaves those
            servers exactly where they are.
            """);

        yield return Mc("mt-009", D3, "Describe features and tools for managing Azure resources", R8,
            """
            How is an on-premises server onboarded to Azure Arc, and where does the server run
            afterwards?
            """,
            [
                "The Azure Connected Machine agent is installed; the server then has an Azure Resource Manager identifier and appears in the portal, while continuing to run on-premises.",
                "The Azure Connected Machine agent is installed, after which the server is migrated into an Azure region as a virtual machine.",
                "An ExpressRoute circuit is established to the data centre, which registers the servers automatically.",
                "An ARM template is deployed into the on-premises hypervisor, which converts the server into an Azure resource."
            ], "A",
            """
            Onboarding installs the Azure Connected Machine agent. The server is then represented in
            Azure with its own Resource Manager identifier, a managed identity, a resource group and
            a subscription, and it appears in the portal alongside native resources.

            Nothing moves. Arc adds a management projection over a server that keeps running exactly
            where it was, which is the distinction between it and a migration service.
            """,
            """
            Two options start the same way and end differently. Ask whether Arc is a management tool
            or a migration tool.
            """);

        yield return YesNo("mt-010", D3, "Describe features and tools for managing Azure resources", R8,
            """
            For each of the following statements about Azure Arc, select Yes if the statement is
            true. Otherwise, select No.
            """,
            [
                ("Azure Arc can extend Azure Policy to servers running in another public cloud.", true),
                ("An Arc-enabled server is physically relocated into an Azure data centre.", false),
                ("Kubernetes clusters running outside Azure can be attached to Azure Arc.", true),
                ("An Arc-enabled server can be given a managed identity and appear in the Azure portal.", true)
            ],
            """
            Arc extends Azure governance, including Azure Policy and Azure Monitor, to servers and
            Kubernetes clusters wherever they run, including other public clouds and edge locations.

            Nothing is relocated, and that is the single fact the whole question turns on. What Arc
            creates is a representation: a Resource Manager identifier, a managed identity and an
            entry in the portal, all pointing at a machine that never left its own rack.
            """,
            """
            One statement claims something moves. Settling that answers the others, because the rest
            describe what Arc creates instead of moving anything.
            """);

        yield return Mc("mt-011", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Which statement about the region of a resource group is correct?
            """,
            [
                "It determines where the group metadata is stored; the resources inside can be deployed to other regions, though that region must be reachable to manage the group.",
                "Every resource in the group must be deployed to the group region.",
                "It determines which subscription is billed for the resources in the group.",
                "A resource group has no region at all."
            ], "A",
            """
            A resource group has a location, and it applies to the group metadata rather than
            constraining its contents, so resources inside can sit in any region.

            The second clause is the part that stops this being a trivia question. Because the
            metadata lives somewhere, an outage in the group region can affect your ability to
            manage the group even if every resource in it is healthy elsewhere, which is a genuine
            consideration when planning for resilience.
            """,
            """
            The common answer is that the region only affects metadata. Ask whether metadata being
            somewhere can ever matter operationally.
            """);

        yield return Mc("mt-012", D3, "Describe features and tools for managing Azure resources", R8,
            """
            An engineer deletes a virtual machine and is surprised that the subscription cost barely
            changes.

            What is the most likely explanation?
            """,
            [
                "The network interface, public IP address and managed disks are not removed unless they are explicitly selected for deletion, and they keep incurring charges.",
                "Deleting a virtual machine always removes its disks and IP address, so the cost must be unrelated.",
                "The resources were moved to a recycle bin and are billed there for thirty days.",
                "Azure converted the disks into snapshots automatically, which cost the same as the disks."
            ], "A",
            """
            Deleting a virtual machine removes the compute resource. Associated resources such as
            the network interface, the public IP address and the managed disks are separate
            resources and survive unless deletion is explicitly requested for them, so the storage
            and IP charges continue.

            The disks are usually the largest of those, which is why the bill barely moves. Full
            cleanup means deleting the associated resources too, or deleting the whole resource
            group if nothing else in it needs to be kept.
            """,
            """
            A virtual machine is really several resources that were created together. Ask which of
            them the delete operation actually covers.
            """);

        yield return Mc("mt-013", D3, "Describe features and tools for managing Azure resources", R8,
            """
            You want a development virtual machine to stop incurring compute charges overnight while
            keeping its configuration and data intact.

            What should you do?
            """,
            [
                "Stop and deallocate the virtual machine, accepting that disk charges continue.",
                "Shut the virtual machine down from inside the guest operating system.",
                "Delete the virtual machine and redeploy it in the morning.",
                "Resize the virtual machine to the smallest available size overnight."
            ], "A",
            """
            Deallocating releases the compute allocation so compute charges stop, while the disks
            and configuration remain and the machine can be started again in the morning. The disks
            are still billed, which is what makes the correct answer honest rather than absolute.

            A guest shutdown is the trap: the machine looks off and remains allocated, so it keeps
            billing. Deleting it would lose the configuration, and resizing only lowers the rate.
            """,
            """
            Two options stop the machine and only one stops the compute bill. The difference is what
            Azure does with the allocation.
            """);

        yield return Mc("mt-014", D3, "Describe features and tools for managing Azure resources", R8,
            """
            In the Azure portal, what is a blade?
            """,
            [
                "A panel that presents the settings, controls and information for a particular resource, service or task.",
                "A physical server chassis in an Azure data centre.",
                "A command executed in Azure Cloud Shell.",
                "A reusable JSON deployment template."
            ], "A",
            """
            In the Azure portal a blade is a panel or page presenting the configuration options,
            controls and monitoring information for a specific resource, service or task, and it is
            the entry point for working with that item.

            The term is purely about the portal interface. Blade servers are a real piece of data
            centre hardware, which is exactly why that distractor is here, and the two meanings have
            nothing to do with each other.
            """,
            """
            The word has a well-known hardware meaning as well. This question is about the interface,
            not the data centre.
            """);

        yield return Mc("mt-015", D3, "Describe features and tools for managing Azure resources", R8,
            """
            A colleague cannot understand why the storage account name "prodstorage" is rejected as
            unavailable when no such account exists in the subscription.

            Which statement explains this?
            """,
            [
                "Storage account names must be globally unique across all of Azure, because the name forms part of a public DNS name.",
                "Storage account names must be unique within the resource group, so another group in the subscription must be using it.",
                "Storage account names must be unique within the subscription, so a deleted account is still holding the name.",
                "Storage account names have no uniqueness requirement, so the error must be a transient fault."
            ], "A",
            """
            A storage account name becomes part of a globally unique DNS name, so it must be unique
            across every Azure storage account in the world, not merely within your subscription.
            Some other customer already has it.

            The same DNS origin explains the character rules: lowercase letters and digits only,
            three to twenty-four characters. It is also why organisations adopt naming conventions
            with an organisation or environment suffix, since obvious names are long gone.
            """,
            """
            The name is not being checked against anything you own. Ask where a storage account name
            ends up being used, and how wide that namespace is.
            """);

        yield return Mc("mt-016", D3, "Describe features and tools for managing Azure resources", R8,
            """
            An analyst wants to browse blobs, files, queues and tables across several storage
            accounts in a graphical interface, from a Mac.

            Which tool should they install, and what does it use underneath for transfers?
            """,
            [
                "Azure Storage Explorer, which uses AzCopy underneath for data movement.",
                "Azure Storage Explorer, which is a Windows-only application, so a virtual machine is needed.",
                "AzCopy, which provides a graphical interface on macOS.",
                "Azure Cloud Shell, which is the graphical storage browser."
            ], "A",
            """
            Azure Storage Explorer is the standalone graphical application for browsing and managing
            blobs, files, queues and tables, and it runs on Windows, macOS and Linux, so no virtual
            machine is required.

            The relationship with AzCopy is the second half: Storage Explorer drives AzCopy for its
            transfers, which is why the two behave identically and why AzCopy is the answer whenever
            the requirement is to script rather than to browse.
            """,
            """
            Two options name the right application and disagree about a platform limitation. Then
            recall which tool actually moves the bytes.
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
                    ["Azure Arc", "Azure Migrate", "Azure Advisor", "Azure Monitor"], 1),
                ("The concise language that is transpiled into that JSON file before deployment is",
                    ["Bicep", "Kusto Query Language", "YAML", "PowerShell"], 1)
            ],
            """
            Azure Cloud Shell is the authenticated browser shell, an Azure Resource Manager template
            is the JSON document declaring the desired resources, and Azure Arc brings servers,
            Kubernetes clusters and data services outside Azure under Azure management.

            The last row links back to the second. Bicep is an authoring language rather than a
            separate deployment path: it compiles to the same JSON template, so it changes the
            experience of writing infrastructure without changing how it is deployed.
            """,
            """
            The fourth row refers back to the second. Work out what the JSON file is before deciding
            what produces it.
            """);

        yield return Mc("mt-018", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Which statement describes the difference between a declarative and an imperative
            approach to deploying infrastructure?
            """,
            [
                "A declarative approach states the desired end state and lets the platform determine the steps; an imperative approach specifies the sequence of operations. Both can be automated.",
                "A declarative approach specifies the sequence of operations, whereas an imperative approach states the desired end state.",
                "A declarative approach can only be used through the Azure portal.",
                "An imperative approach cannot be automated, which is why templates exist."
            ], "A",
            """
            Declarative deployment, as used by Azure Resource Manager templates and Bicep, describes
            what the result should be. Imperative deployment, as used by a PowerShell or CLI script,
            lists the operations to perform in order.

            The final clause matters because it removes the assumption that declarative means
            automated and imperative means manual. Both are automated; they differ in how intent is
            expressed, and therefore in what happens when you run the same thing twice.
            """,
            """
            One distractor implies that scripts cannot be automated. Check that before letting it
            influence the choice.
            """);

        yield return Mc("mt-019", D3, "Describe features and tools for managing Azure resources", R8,
            """
            Which language is designed as a more concise alternative to JSON Azure Resource Manager
            templates, transpiles into them before deployment, and is authored by Microsoft?
            """,
            ["Bicep.", "Terraform HCL.", "Kusto Query Language.", "YAML."], "A",
            """
            Bicep is Microsoft own domain-specific language for declaring Azure infrastructure with
            far less syntax than raw JSON. Bicep files are transpiled into standard Azure Resource
            Manager templates, so they inherit exactly the same deployment behaviour.

            Terraform is the distractor worth being precise about: it is a genuine and widely used
            infrastructure-as-code language for Azure, but it is a third-party tool with its own
            state model rather than a native template language. Kusto queries logs, and YAML is a
            data format rather than an ARM authoring language.
            """,
            """
            Two of these really are used to declare Azure infrastructure. The last clause of the
            question separates them.
            """);

        yield return Mc("mt-020", D3, "Describe features and tools for managing Azure resources", R8,
            """
            An organisation must run Arc-enabled data services under local management because a
            residency rule prevents operational data being sent continuously to Azure.

            Which connectivity mode should it use, and what does it give up?
            """,
            [
                "The disconnected, or indirectly connected, mode, which keeps management local and exports metadata and billing information periodically instead of offering direct portal management.",
                "The disconnected mode, which offers the same direct portal management and continuous monitoring as the connected mode.",
                "The connected mode, which is the only mode that satisfies residency requirements.",
                "A read-only mode, which permits monitoring but not management."
            ], "A",
            """
            The disconnected, or indirectly connected, mode keeps Arc-enabled data services under
            local management and does not stream data to Azure continuously, which is what supports
            a residency requirement. Metadata and billing information are exported periodically
            instead.

            The trade is the second half of the answer. Connected mode gives direct management from
            the Azure portal along with continuous monitoring and inventory, and that is precisely
            what the disconnected mode gives up in exchange for keeping the data local.
            """,
            """
            Two options name the same mode and differ on what it costs you. A mode that keeps data
            local cannot also be offering continuous cloud management.
            """);
    }
}
