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
            A regulator requires that a company customer records never leave the country it
            operates in. The company wants a second location for resilience.

            Which Azure concept guarantees the residency boundary the regulator cares about?
            """,
            [
                "A geography, which is a discrete market containing two or more regions and which preserves data residency and compliance boundaries.",
                "A region pair, because pairing two regions creates the residency boundary.",
                "An availability zone, because zones are physically separate locations.",
                "A resource group, because it is the boundary Azure applies policy against."
            ], "A",
            """
            A geography is the compliance and residency boundary. It typically contains two or
            more regions and usually aligns to a country, which is exactly what a regulator
            demanding that data stay in-country is asking about.

            Region pairs are the near miss and worth understanding: pairs sit inside a geography,
            so they respect the boundary rather than creating it. Availability zones are separation
            within a single region, and a resource group is a management container with no bearing
            on where data physically sits.
            """,
            """
            Two of these options genuinely relate to where data lives. Ask which one defines the
            boundary and which one merely operates inside it.
            """);

        yield return Mc("as-002", D2, "Describe the core architectural components of Azure", R2,
            """
            A workload is deployed across three availability zones in one region. A fire in a
            single Azure data centre takes one zone offline, and later a network fault affects the
            entire region.

            What protection did the zonal deployment provide?
            """,
            [
                "It protected against the loss of the zone, because each zone has independent power, cooling and networking, but not against the loss of the region.",
                "It protected against both, because zones in the same region fail independently of the region itself.",
                "It protected against neither, because availability zones share power and cooling within a region.",
                "It protected against the regional fault only, because zones are designed for regional rather than local isolation."
            ], "A",
            """
            An availability zone is a physically separate location inside a region with its own
            power, cooling and networking, and it may span more than one data centre. That
            independence is what contains the first failure.

            It does nothing for the second. A zone is a unit of separation within a region, so
            everything about it stops at the region boundary; surviving the loss of a whole region
            requires a deployment in another region.
            """,
            """
            The scenario contains two failures at different scales. Work out the largest thing a
            zone is separated from before you judge either one.
            """);

        yield return Mc("as-003", D2, "Describe the core architectural components of Azure", R2,
            """
            An architect plans a zone-redundant deployment and asks two questions: how many zones
            a supporting region provides, and whether the chosen region will have them.

            Which answer is correct?
            """,
            [
                "At least three zones, and zone support must be confirmed for the specific region, because not every region offers them.",
                "At least three zones, and every Azure region offers them, so no check is needed.",
                "Exactly two zones, and every Azure region offers them.",
                "At least three zones, and zones can be requested through support in any region that lacks them."
            ], "A",
            """
            A region that supports availability zones provides a minimum of three, which is what
            makes a zone-redundant deployment possible: a quorum survives losing one.

            The second half is the operational point. Zone support is a property of the region, it
            is not universal, and it cannot be added by request, so it belongs on the checklist
            before a region is chosen rather than after.
            """,
            """
            The count is the easy half. The other half decides whether the design is even
            available where you want to build it.
            """);

        yield return Mc("as-004", D2, "Describe the core architectural components of Azure", R2,
            """
            A team assumes that because its primary region has a paired region, its data is
            already being copied there.

            Which statement about Azure region pairs is correct?
            """,
            [
                "Microsoft defines the pairing and applies planned updates to one region of a pair at a time, but replication only happens for services the team configures to use it.",
                "Microsoft defines the pairing and automatically replicates all customer data to the paired region.",
                "Customers choose which region their primary region is paired with, and replication then starts automatically.",
                "Both regions of a pair sit in different geographies, which is what makes the pairing useful for recovery."
            ], "A",
            """
            Pairings are set by Microsoft, not chosen, and both halves sit inside the same
            geography so that residency commitments survive a failover. Planned platform updates
            are deliberately rolled out serially, one region of the pair at a time, so a bad update
            cannot take out both.

            None of that copies anything by itself. Replication is a property of the service you
            deploy, such as choosing geo-redundant storage, so the assumption in the stem is the
            error being tested.
            """,
            """
            Everything the platform does with a pair is about sequencing and residency. Ask
            whether any of it moves your data without you asking.
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
                    ["a region pair", "an availability set", "a scale set", "a tenant"], 1),
                ("Protecting a workload against the loss of an entire region requires",
                    ["a second availability zone", "a second region", "a second availability set", "a second resource group"], 2)
            ],
            """
            The hierarchy runs from geographies, which are the residency and compliance boundary,
            down to regions, and then to availability zones inside a region. A region pair is the
            Microsoft-defined relationship between two regions in one geography.

            The last row is what the hierarchy is for. Every construct inside a region, zone,
            availability set or resource group alike, stops at the region boundary, so surviving
            the loss of a region takes another region.
            """,
            """
            The first three rows are definitions. The fourth asks you to use them, so start by
            deciding which of the constructs live inside a single region.
            """);

        yield return Mc("as-006", D2, "Describe the core architectural components of Azure", R2,
            """
            You must deploy a workload so that it is covered by the highest single-region virtual
            machine availability commitment Azure offers.

            What should you do?
            """,
            [
                "Deploy two or more instances spread across two or more availability zones in the same region.",
                "Deploy one instance into an availability zone and give it Premium SSD disks.",
                "Deploy two or more instances into a single availability set.",
                "Deploy two or more instances into the same availability zone."
            ], "A",
            """
            The commitment ladder rewards separation, and the top rung requires both things at
            once: more than one instance, and those instances in more than one zone. That reaches
            99.99 percent, because the instances no longer share power, cooling or networking.

            A single instance never reaches it, however good its disks, since the whole machine is
            still a single point of failure; Premium SSD on one instance is 99.9 percent. Two
            instances in one availability set is 99.95 percent, and two instances in the same zone
            gets no zonal benefit at all.
            """,
            """
            The top of the ladder has two requirements, not one. Check every option against both
            before choosing.
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
                "99.5 percent",
                "95 percent"
            ],
            [
                ("Two or more instances spread across two or more availability zones", 1),
                ("Two or more instances in the same availability set", 2),
                ("A single instance using Premium SSD disks for all disks", 3),
                ("A single instance using Standard SSD disks for all disks", 4),
                ("A single instance using Standard HDD disks for all disks", 5)
            ],
            """
            The ladder rewards separation first and storage quality second. Spreading instances
            across availability zones gives 99.99 percent and grouping instances in an
            availability set gives 99.95 percent.

            A single instance still earns a commitment, but it is set by the slowest disk attached
            to it: Premium SSD reaches 99.9 percent, Standard SSD 99.5 percent, and Standard HDD
            95 percent. Notice how much wider the gaps become once redundancy is gone.
            """,
            """
            Two rows are decided by how instances are spread and three by what disks they use.
            Sort the rows into those two groups first.
            """);

        yield return Mc("as-008", D2, "Describe the core architectural components of Azure", R2,
            """
            An availability set distributes virtual machines across fault domains and update
            domains.

            Which pairing is correct?
            """,
            [
                "A fault domain is hardware sharing a power source and network switch; an update domain is a group rebooted together during planned maintenance.",
                "A fault domain is a group rebooted together during planned maintenance; an update domain is hardware sharing a power source and network switch.",
                "A fault domain is a physically separate zone within a region; an update domain is a second region in the pair.",
                "Both terms describe the same grouping, viewed from the perspective of unplanned and planned events respectively."
            ], "A",
            """
            The two domains protect against two different events, which is why an availability set
            uses both. A fault domain is a logical grouping of hardware sharing a power source and
            a network switch, typically a rack, so spreading across fault domains survives an
            unplanned rack failure.

            An update domain is a grouping that is rebooted together during planned maintenance,
            so spreading across update domains means Azure can patch the platform without taking
            the whole set down at once. Option D is tempting but wrong: they are genuinely
            different groupings, not one grouping described two ways.
            """,
            """
            One of these domains is about something breaking and the other about something planned.
            Match each definition to the kind of event it protects against.
            """);

        yield return YesNo("as-009", D2, "Describe the core architectural components of Azure", R2,
            """
            For each of the following statements about availability sets and availability zones,
            select Yes if the statement is true. Otherwise, select No.
            """,
            [
                ("An availability set distributes virtual machines across fault domains and update domains.", true),
                ("An availability zone protects a workload against the failure of an entire region.", false),
                ("Deploying two or more instances across zones can raise the commitment to 99.99 percent.", true),
                ("An availability set spans multiple availability zones by default.", false)
            ],
            """
            Availability sets exist to spread instances across fault and update domains, and a
            multi-instance, multi-zone deployment does reach 99.99 percent.

            The two false statements are the two halves of the same misunderstanding. A zone is
            separation within a region, so it stops at the region boundary, and an availability set
            is separation within a single data centre footprint rather than across zones. They are
            different tools at different scales, not one feature with two names.
            """,
            """
            Two of these statements ask how far a construct reaches. Fix the scope of a zone and
            of an availability set in your mind, then read them again.
            """);

        // ---------------------------------------------------------- resource hierarchy

        yield return Mc("as-010", D2, "Describe the core architectural components of Azure", R2,
            """
            A team creates a resource group in West Europe and wants to place a storage account in
            East US inside it.

            Which statement is correct?
            """,
            [
                "This is allowed, because a resource group can contain resources from different regions and its own location only determines where its metadata is stored.",
                "This is not allowed, because every resource in a group must be deployed to the group region.",
                "This is allowed, and the storage account will be moved to West Europe automatically.",
                "This is allowed only if the storage account is also added to a second resource group in East US."
            ], "A",
            """
            A resource group is a management container, not a geographic constraint. Its location
            determines only where the metadata about the group is stored, so resources inside it
            can live in any region.

            Two related rules are worth pinning down at the same time: a resource belongs to
            exactly one resource group at a time, though it can be moved, and a resource group
            belongs to exactly one subscription. So the option suggesting a second group is
            impossible as well as unnecessary.
            """,
            """
            Ask what a resource group location is actually used for. It is a smaller thing than
            most people assume.
            """);

        yield return Mc("as-011", D2, "Describe the core architectural components of Azure", R2,
            """
            You attempt to delete a resource group containing a virtual machine, a storage account
            and a managed disk. One of the resources carries a CanNotDelete lock.

            What happens?
            """,
            [
                "The deletion fails, because a lock on any resource in the group blocks deleting the group and nothing is removed.",
                "All three resources are deleted, because a lock applies only to direct deletion of the locked resource.",
                "The unlocked resources are deleted and the locked one is left behind in the group.",
                "The deletion succeeds after the lock is automatically removed."
            ], "A",
            """
            Deleting a resource group deletes everything in it, which is why groups should hold
            resources that genuinely share a lifecycle. A CanNotDelete lock on any contained
            resource stops the whole operation: the group deletion is not partial, so nothing is
            removed until the lock is deliberately taken off.

            That behaviour is the reason locks are the standard protection for production
            resources. Azure never removes a lock for you, and there is no default group that
            orphaned resources fall into.
            """,
            """
            The question is not only whether the group can be deleted, but whether Azure would
            ever do half of it.
            """);

        yield return Mc("as-012", D2, "Describe the core architectural components of Azure", R2,
            """
            An Azure Policy assignment is created at a management group. Later a role assignment is
            created at a subscription inside it.

            Which statement about scope and inheritance is correct?
            """,
            [
                "The order of scopes is management group, subscription, resource group, resource, and both assignments are inherited by everything beneath the scope they were made at.",
                "The order of scopes is subscription, management group, resource group, resource, and assignments apply only at the exact scope they are created at.",
                "The order of scopes is management group, subscription, resource group, resource, and assignments apply only at the exact scope they are created at.",
                "The order of scopes is management group, resource group, subscription, resource, and inheritance flows upward from resource to management group."
            ], "A",
            """
            Management groups sit at the top and can contain subscriptions and other management
            groups. Each subscription contains resource groups, and each resource group contains
            resources.

            Inheritance is what makes the ordering matter. A policy or role assignment made at one
            scope flows down to everything beneath it, which is why the policy at the management
            group reaches every subscription under it and the role at the subscription reaches
            every resource group and resource inside that subscription. It never flows upward.
            """,
            """
            Getting the four scopes in order is only half the answer. The other half is which
            direction an assignment travels once it is made.
            """);

        yield return Mc("as-013", D2, "Describe the core architectural components of Azure", R2,
            """
            Which two purposes does an Azure subscription serve? Each correct answer presents a
            complete solution.
            """,
            [
                "It is a billing boundary that determines how consumption is invoiced.",
                "It is an administrative and scale boundary against which role assignments, policies and service limits apply.",
                "It defines the region every contained resource must run in.",
                "It provides the directory that authenticates user sign-in.",
                "It removes the need for resource groups."
            ], "A,B",
            """
            A subscription does two jobs at once. It ties consumption to a payment agreement, and
            it acts as the administrative boundary and scale unit that role assignments, policies
            and per-subscription service limits are measured against.

            Resources inside a subscription can sit in many regions, resource groups are still
            required, and authentication comes from a Microsoft Entra ID tenant. The tenant
            distinction is worth holding on to: one tenant can back many subscriptions.
            """,
            """
            One distractor names something a subscription is closely associated with but does not
            itself provide. Ask which component actually signs users in.
            """);

        yield return Mc("as-014", D2, "Describe the core architectural components of Azure", R2,
            """
            An organisation has four Azure subscriptions and also uses Microsoft 365. Users sign in
            to all of them with the same account.

            Which statement about the relationship between tenants and subscriptions is correct?
            """,
            [
                "One Microsoft Entra ID tenant can be trusted by many subscriptions, and it can serve Azure, Microsoft 365 and Dynamics 365 at the same time.",
                "Each subscription requires its own tenant, so the organisation must have four tenants.",
                "A tenant is a billing agreement, so the four subscriptions are consolidated into one tenant invoice.",
                "A tenant is a logical container for resources, so subscriptions live inside it the way resources live inside a resource group."
            ], "A",
            """
            A tenant is a dedicated instance of Microsoft Entra ID holding an organisation
            accounts and groups, and it provides authentication. Several subscriptions can trust
            the same tenant, which is exactly why one account signs a user in to all of them and to
            Microsoft 365 as well.

            The distractors each swap the tenant for something else: a tenant is not the billing
            agreement, which is the subscription, and it is not a resource container, which is the
            resource group.
            """,
            """
            The single sign-in described in the scenario is the clue. Ask what the four
            subscriptions must have in common for it to work.
            """);

        yield return Mc("as-015", D2, "Describe the core architectural components of Azure", R2,
            """
            A governance lead worries that a resource created with the Azure CLI might escape a
            policy that was tested in the portal.

            Which statement about Azure Resource Manager addresses that concern?
            """,
            [
                "Every request from the portal, CLI, PowerShell and REST clients passes through Resource Manager, so policy, RBAC, locks and tags apply consistently whichever tool is used.",
                "Policy is evaluated separately by each tool, so the CLI must be configured to enforce it.",
                "Resource Manager applies policy to portal requests only, and CLI requests are audited afterwards.",
                "Resource Manager is a monitoring service, so it reports the violation rather than preventing it."
            ], "A",
            """
            Azure Resource Manager is the single control plane. Whichever interface issues a
            management request, it arrives at Resource Manager and is routed to the resource
            provider from there.

            That single path is the whole point for governance. Because there is no way round it,
            role-based access control, policy, locks and tags are evaluated the same way for every
            tool, so the governance lead concern does not arise. Monitoring is Azure Monitor, a
            separate service.
            """,
            """
            Answering this means knowing not what Resource Manager is called, but how many ways
            there are to reach a resource without going through it.
            """);

        yield return Mc("as-016", D2, "Describe the core architectural components of Azure", R2,
            """
            A team writes its infrastructure in Bicep and asks what Azure actually receives when
            the file is deployed.

            Which statement is correct?
            """,
            [
                "Bicep is transpiled into a JSON Azure Resource Manager template, so Resource Manager receives JSON either way.",
                "Bicep is sent to Resource Manager as YAML, which is the native template format.",
                "Bicep replaces Resource Manager templates entirely and is deployed by a separate service.",
                "Bicep files are converted to XML, the original template format, before deployment."
            ], "A",
            """
            Azure Resource Manager templates are JSON documents that declare the resources to
            deploy and their properties, which makes infrastructure repeatable and reviewable in
            version control.

            Bicep is an authoring language, not a different deployment path. It is more concise to
            write and read, and it is transpiled to the same JSON template before Resource Manager
            ever sees it, so nothing about the underlying deployment model changes.
            """,
            """
            The question is what arrives at Resource Manager, not what the author typed. Ask
            whether Bicep is a new format or a friendlier way to produce the existing one.
            """);

        yield return YesNo("as-017", D2, "Describe the core architectural components of Azure", R2,
            """
            For each of the following statements about resource groups, select Yes if the statement
            is true. Otherwise, select No.
            """,
            [
                ("Resources in different resource groups can interact with one another.", true),
                ("A tag applied to a resource group is automatically inherited by the resources inside it.", false),
                ("A resource group can contain resources deployed to more than one region.", true),
                ("A resource group is a security boundary that prevents access from outside the group.", false)
            ],
            """
            A resource group is a management container, not an isolation boundary. An application
            server in one group can freely reach a database in another, and a group can hold
            resources from several regions.

            The two false statements are the two ways people over-read the container. Tags do not
            flow down automatically, which surprises most people the first time they use them for
            cost reporting, and Azure Policy is the usual way to propagate them. Nor does grouping
            restrict access: that is role-based access control, which a group is merely a
            convenient scope for.
            """,
            """
            Two statements assume that putting resources in a group does something to them. Ask
            what a resource group actually enforces on its own.
            """);

        // ---------------------------------------------------------- billing scopes

        yield return Mc("as-018", D2, "Describe Azure billing concepts", R2,
            """
            Your organisation purchases Azure through an Enterprise Agreement and wants to group
            several enrollment accounts so that costs can be reported per business unit.

            Which billing scope should you use?
            """,
            [
                "A department, which is an optional grouping of enrollment accounts inside an Enterprise Agreement.",
                "A billing profile, which groups enrollment accounts and carries the invoice.",
                "An invoice section, which groups enrollment accounts within the billing account.",
                "A resource group, which is the billing scope beneath a subscription."
            ], "A",
            """
            An Enterprise Agreement billing account is organised into optional departments, which
            group enrollment accounts, and it is under an enrollment account that subscriptions are
            created.

            The two strongest distractors come from the other agreement type entirely. Billing
            profiles and invoice sections belong to the Microsoft Customer Agreement structure, so
            recognising which agreement a scope name belongs to is most of the work. A resource
            group is not a billing scope at all.
            """,
            """
            Each agreement type has its own vocabulary for billing scopes. Decide which agreement
            is in play, then discard every name that belongs to the other one.
            """);

        yield return Mc("as-019", D2, "Describe Azure billing concepts", R2,
            """
            Under a Microsoft Customer Agreement, at which billing scope is an invoice generated,
            and what is the scope beneath it used for?
            """,
            [
                "The billing profile generates the invoice, and the invoice sections beneath it group costs within that invoice.",
                "The billing account generates the invoice, and the billing profiles beneath it group costs within it.",
                "The invoice section generates the invoice, and the billing profile beneath it holds the payment method.",
                "The enrollment account generates the invoice, and the department beneath it groups costs."
            ], "A",
            """
            A Microsoft Customer Agreement billing account is organised into billing profiles, and
            each billing profile carries an invoice and its payment methods. Invoice sections sit
            beneath a profile and group line items within that one invoice, which is how a single
            bill is broken down by team or project.

            Enrollment accounts and departments belong to the Enterprise Agreement structure, so
            the last option is describing a different agreement altogether.
            """,
            """
            One of these scopes produces the bill and the other organises what is printed on it.
            Getting the order right settles the question.
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
                ("Department", 1),
                ("The scope that carries the invoice and its payment methods", 2)
            ],
            """
            Departments and enrollment accounts are the optional and required groupings inside an
            Enterprise Agreement billing account: a department groups enrollment accounts, and
            subscriptions are created under an enrollment account.

            Billing profiles and invoice sections are the Microsoft Customer Agreement equivalents.
            The final row identifies the billing profile by what it does rather than by name, which
            is the same scope as the second row and the reason one agreement type is used more
            often than the other here.
            """,
            """
            The last row does not name a scope, it describes one. Work out which named scope it is
            before placing it.
            """);

        // ---------------------------------------------------------- compute

        yield return Mc("as-021", D2, "Describe Azure compute services", R2,
            """
            You need a group of identical, load-balanced virtual machines whose instance count
            rises and falls automatically with demand.

            Which service should you use, and why is the closest alternative wrong?
            """,
            [
                "A virtual machine scale set, because an availability set improves resilience but never changes the instance count.",
                "An availability set, because it distributes instances across fault domains and adds instances when they are busy.",
                "A virtual machine scale set, because an availability set cannot load balance traffic between instances.",
                "Azure Container Instances, because a scale set cannot automatically scale."
            ], "A",
            """
            A virtual machine scale set creates and manages a group of identical virtual machines
            built from one image, load balances across them, and adjusts the instance count
            automatically in response to demand.

            The distinction to hold on to is that an availability set is a resilience construct
            only: it spreads a fixed set of instances across fault and update domains and has no
            scaling behaviour whatsoever. Option C states a true-sounding but wrong reason, which
            is why reading the justification matters as much as the service name.
            """,
            """
            Two options name the right service with different reasoning. Check the reason as
            carefully as the name.
            """);

        yield return Mc("as-022", D2, "Describe Azure compute services", R2,
            """
            A team plans a virtual machine scale set built from a custom image and expects to grow
            well beyond 600 instances.

            Which statement is correct?
            """,
            [
                "A scale set supports up to 1,000 instances from a platform image, but a custom image caps it at 600.",
                "A scale set supports up to 1,000 instances regardless of whether the image is custom.",
                "A scale set supports up to 600 instances regardless of the image, so the plan is already at the limit.",
                "A scale set has no instance limit, so the plan needs no adjustment."
            ], "A",
            """
            A scale set supports up to 1,000 standard virtual machine instances. Building the set
            from a custom image lowers that ceiling to 600.

            That is the whole point of the scenario: the team plan is not merely near a limit, it
            crosses one that only applies because of the image choice, so the design has to change
            either the image or the number of scale sets.
            """,
            """
            There are two limits here, not one, and the scenario mentions the exact detail that
            decides which of them applies.
            """);

        yield return Mc("as-023", D2, "Describe Azure compute services", R2,
            """
            A team must deploy a Python web application. It does not want to create or patch
            virtual machines, and it needs built-in load balancing and automatic scaling. The
            application is a single web tier with no containers involved.

            Which service should the team use?
            """,
            [
                "Azure App Service.",
                "Azure Kubernetes Service.",
                "Azure Virtual Machines.",
                "Azure Virtual Desktop."
            ], "A",
            """
            Azure App Service is the platform service for web applications, REST APIs and mobile
            back ends. It supports Python among other languages, runs on Windows and Linux, and
            provides load balancing, autoscaling and automated platform patching out of the box.

            Kubernetes Service is the distractor to reason past rather than dismiss: it would meet
            every stated requirement, but it brings cluster orchestration a single web tier does
            not need, so it is the wrong fit rather than the wrong capability. Virtual machines
            reintroduce the patching the team wants to avoid.
            """,
            """
            More than one option here could technically host the application. Let the last sentence
            of the scenario decide which one is proportionate.
            """);

        yield return Mc("as-024", D2, "Describe Azure compute services", R2,
            """
            You must run a single containerised batch job that starts, processes a file for a few
            minutes and exits. There is no cluster, and you want to pay only for the CPU and memory
            the container consumes while it runs.

            Which service should you use?
            """,
            [
                "Azure Container Instances.",
                "Azure Kubernetes Service.",
                "Azure App Service.",
                "Azure Virtual Machines."
            ], "A",
            """
            Azure Container Instances runs a container with no cluster to create or manage and
            bills for the CPU and memory actually consumed, which is what makes it the natural fit
            for short-lived or occasional work.

            Kubernetes Service would require a cluster whose nodes are billed whether or not the
            job runs, which is precisely the cost the scenario is trying to avoid. App Service is
            oriented towards long-running web workloads, and a virtual machine bills for the whole
            machine.
            """,
            """
            Every option here can run a container. The deciding words are about how long the work
            lasts and what you are willing to pay for between runs.
            """);

        yield return Mc("as-025", D2, "Describe Azure compute services", R2,
            """
            Your company runs hundreds of containers that must be scheduled across a pool of nodes,
            restarted automatically when they fail, and scaled as a group.

            Which service should you use, and what does choosing it add to your responsibilities?
            """,
            [
                "Azure Kubernetes Service, and you take on managing the node pools and the workloads running on them.",
                "Azure Kubernetes Service, and Microsoft manages the nodes as well as the control plane, so nothing is added.",
                "Azure Container Instances, and you take on scheduling containers across nodes yourself.",
                "Azure App Service, and you take on managing the underlying operating system."
            ], "A",
            """
            Azure Kubernetes Service provides managed container orchestration: it schedules
            workloads across cluster nodes, watches container health and scales them, which is what
            an estate of this size needs.

            Managed refers to the control plane, and that is the half people forget. Microsoft
            operates and secures the Kubernetes control plane, while the node pools, their sizing,
            their upgrades and the workloads on them remain yours. Container Instances has no
            orchestration to offer at this scale.
            """,
            """
            The service name is the easy half. The other half asks exactly which part of a
            Kubernetes cluster the word "managed" is covering.
            """);

        yield return Mc("as-026", D2, "Describe Azure compute services", R2,
            """
            Your organisation wants remote staff to reach a full Windows desktop and its
            line-of-business applications from their own macOS and iOS devices, with several users
            sharing one Windows host to control cost.

            Which service should you use?
            """,
            [
                "Azure Virtual Desktop.",
                "Azure Virtual Machines, one per user.",
                "Azure App Service.",
                "Azure Container Instances."
            ], "A",
            """
            Azure Virtual Desktop delivers Windows desktop and application sessions from Azure to
            Windows, macOS, iOS, Linux and browser clients, so personal hardware becomes a thin
            client and no corporate laptop has to be shipped.

            The detail that rules out the alternative is multi-session. Azure Virtual Desktop
            supports multi-session Windows, letting several users share one host, whereas
            dedicating a virtual machine per user gives up exactly the cost saving the scenario
            asks for.
            """,
            """
            A per-user virtual machine could also deliver a Windows desktop. One requirement in the
            scenario is there specifically to eliminate it.
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
                "Azure Virtual Desktop",
                "Azure Container Instances"
            ],
            [
                ("Host a web application without managing an operating system", 2),
                ("Orchestrate a large fleet of containers across cluster nodes", 3),
                ("Run a legacy application that needs a kernel-mode driver installed", 1),
                ("Give staff Windows desktop sessions on their own devices", 4),
                ("Run one short-lived container per uploaded file, with no cluster", 5)
            ],
            """
            App Service hosts web applications without operating system management, and Kubernetes
            Service orchestrates large container estates across nodes.

            The two rows that need care are the container ones. A short-lived container with no
            cluster is Container Instances, not Kubernetes, because a cluster would bill whether or
            not work arrived. And a kernel-mode driver forces a virtual machine, since no managed
            platform gives access at that depth.
            """,
            """
            Two rows describe running containers and the right answers differ. Look at how long
            each container lives and whether a cluster is wanted.
            """);

        yield return Mc("as-028", D2, "Describe Azure compute services", R2,
            """
            In Azure Container Instances, what is a container group?
            """,
            [
                "A set of containers scheduled onto the same host that share a lifecycle, local network, storage, and a single IP address and DNS name.",
                "A Kubernetes cluster made up of several worker nodes.",
                "A resource group that is permitted to contain only container resources.",
                "A set of containers replicated across several Azure regions for resilience."
            ], "A",
            """
            A container group is the unit of deployment in Container Instances. Its containers land
            on the same host, share an operating system, a lifecycle, local network and storage
            volumes, and are reached through one IP address and DNS name, which is what makes a
            sidecar pattern possible without a cluster.

            Container groups are a Linux feature; Windows support in Container Instances has been
            limited to single container instances.
            """,
            """
            The word "group" here is doing the same job as a pod does elsewhere. Ask what those
            containers have to share for that to work.
            """);

        // ---------------------------------------------------------- data services

        yield return Mc("as-029", D2, "Describe Azure compute and data services", R2,
            """
            You must deploy a relational database to Azure. You do not want to install SQL Server,
            manage an operating system or apply patches, and you need a 99.99 percent availability
            commitment. The application uses a single database and no instance-level features.

            Which service should you use?
            """,
            [
                "Azure SQL Database.",
                "Azure SQL Managed Instance.",
                "SQL Server installed on an Azure virtual machine.",
                "Azure Cosmos DB."
            ], "A",
            """
            Azure SQL Database is the fully managed, single-database relational service. Microsoft
            handles upgrades, patching and monitoring, and it carries a 99.99 percent availability
            commitment, leaving you responsible only for the database objects.

            Managed Instance is the distractor that requires a reason rather than a dismissal: it
            is also fully managed, but it exists to provide instance-level compatibility that the
            stem explicitly says is not needed. SQL Server on a virtual machine hands the operating
            system back to you, and Cosmos DB is not a SQL Server-compatible relational engine.
            """,
            """
            Two options are both fully managed relational services. The last sentence of the
            scenario is what separates them.
            """);

        yield return Mc("as-030", D2, "Describe Azure compute and data services", R2,
            """
            You plan to migrate an on-premises SQL Server instance to Azure. The applications depend
            on linked servers, change data capture and common language runtime integration, and the
            team does not want to patch an operating system.

            Which service should you use?
            """,
            [
                "Azure SQL Managed Instance.",
                "Azure SQL Database.",
                "SQL Server installed on an Azure virtual machine.",
                "Azure Database for MySQL."
            ], "A",
            """
            Azure SQL Managed Instance exists for exactly this migration: near-complete
            compatibility with a full SQL Server instance, including linked servers, change data
            capture and common language runtime integration, while Microsoft still runs the
            operating system and the engine.

            Azure SQL Database is a single-database service without that instance-level surface,
            and SQL Server on a virtual machine would deliver the compatibility at the cost of the
            patching the team wants to avoid. MySQL is a different engine entirely.
            """,
            """
            Two options can deliver the instance-level features. Only one of them also satisfies
            the requirement in the final clause.
            """);

        yield return Mc("as-031", D2, "Describe Azure compute and data services", R2,
            """
            An application must be readable and writable from several continents with millisecond
            response times, and an existing component already speaks the MongoDB wire protocol.

            Which service should you use?
            """,
            [
                "Azure Cosmos DB.",
                "Azure SQL Database with geo-replication.",
                "Azure Database for PostgreSQL.",
                "Azure Table storage."
            ], "A",
            """
            Azure Cosmos DB is the multi-model, globally distributed database. It scales out across
            regions worldwide, targets millisecond response times, and exposes several APIs
            including MongoDB, Cassandra, Gremlin and Table, so the existing MongoDB component can
            keep speaking the protocol it already uses.

            Geo-replicated Azure SQL Database is the option worth thinking through rather than
            skipping: it distributes data, but its secondaries are read-only and it is not
            MongoDB-compatible, so it fails both of the specific requirements in the stem.
            """,
            """
            The scenario sets two requirements that a single-region relational service cannot both
            meet. Identify both before you compare the options.
            """);

        yield return Mc("as-032", D2, "Describe Azure compute and data services", R2,
            """
            A company migrates a web application that runs on a LAMP stack to Azure. It wants a
            managed database service rather than a virtual machine, and it does not want to change
            any application code.

            Which service should the company use?
            """,
            [
                "Azure Database for MySQL.",
                "Azure Database for PostgreSQL.",
                "Azure SQL Database.",
                "Azure Cosmos DB with the Table API."
            ], "A",
            """
            The M in LAMP is MySQL, so the direct match is the managed MySQL platform service. It
            removes the server and the patching while leaving the engine, and therefore the
            application queries, untouched.

            The final clause is what rules the others out. PostgreSQL, Azure SQL Database and
            Cosmos DB are all perfectly good managed services and all speak a different dialect, so
            each of them would mean changing exactly the code the company said it would not change.
            """,
            """
            Expand the acronym in the stem. One letter of it names the engine, and one clause at
            the end forbids replacing it.
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
                ("A JSON document whose tags define a hierarchy of fields", 2),
                ("A collection of video files and scanned documents", 3),
                ("Log lines with no schema, stored as plain text blobs", 3),
                ("Entities in Azure Table storage, where rows in one table may carry different properties", 2)
            ],
            """
            Structured data conforms to a predefined schema, such as columns in a relational table.
            Semi-structured data has no rigid model but still carries tags or markers that impose a
            hierarchy, which is what JSON and XML do. Unstructured data has no predefined structure
            at all.

            The last row is the interesting one. Table storage is often called a NoSQL table and
            sounds structured because of the word table, but rows in it can each carry different
            properties, which is the definition of semi-structured.
            """,
            """
            One row names something that sounds structured because of what it is called. Ask
            whether every row in it must have the same fields.
            """);

        // ---------------------------------------------------------- serverless

        yield return Mc("as-034", D2, "Describe Azure compute services", R2,
            """
            You must run a small block of C# code each time a message arrives on a queue. The code
            runs for a few seconds, there is no state to carry between runs, and you want to pay
            only for the time it executes.

            Which service should you use?
            """,
            [
                "Azure Functions.",
                "Azure Logic Apps.",
                "Azure App Service on a Basic plan.",
                "Azure Container Instances."
            ], "A",
            """
            Azure Functions hosts a single method that runs in response to a trigger such as a
            queue message, an HTTP request or a timer, scales automatically, and on the consumption
            plan bills only for the resources used while the function actually executes.

            App Service is the distractor worth pricing out: it could run this code, but a Basic
            plan bills for the plan continuously whether or not a message arrives, which is the
            cost the last clause rules out. Logic Apps is designed for connector-based workflows
            rather than a block of C#.
            """,
            """
            Several of these can run the code. Only one of them stops charging you between
            messages.
            """);

        yield return Mc("as-035", D2, "Describe Azure compute services", R2,
            """
            A business analyst must automate a multi-step approval workflow that connects several
            software as a service applications. The analyst does not write code and wants to build
            it in a visual designer using prebuilt connectors.

            Which service should the analyst use, and how does it relate to the alternative?
            """,
            [
                "Azure Logic Apps, and it can call an Azure Function when a step needs custom code.",
                "Azure Logic Apps, and it replaces Azure Functions, which cannot be used together with it.",
                "Azure Functions, and its visual designer covers connector-based workflows.",
                "Azure Functions, and Logic Apps is only for scheduled batch jobs."
            ], "A",
            """
            Azure Logic Apps is the workflow service: a web-based designer connects triggers to
            actions through prebuilt connectors, which is what makes no-code and low-code
            automation of business processes possible.

            The relationship is the second half of the answer. The two services are complementary
            rather than competing, so when one step of a workflow needs logic no connector
            provides, the Logic App calls an Azure Function and carries on. Functions is code-first
            and has no connector designer.
            """,
            """
            Picking the service is straightforward. The rest of each option claims something about
            how the two services coexist, and only one of those claims is true.
            """);

        yield return YesNo("as-036", D2, "Describe Azure compute services", R2,
            """
            For each of the following statements about Azure Functions and Azure Logic Apps, select
            Yes if the statement is true. Otherwise, select No.
            """,
            [
                ("Azure Functions are stateless by default.", true),
                ("State can be maintained across a chain of functions using Durable Functions.", true),
                ("Azure Functions cannot be invoked from an Azure Logic App.", false),
                ("Azure Logic Apps requires the workflow author to write code.", false)
            ],
            """
            Functions execute statelessly by default, and the Durable Functions extension exists
            precisely to lift that restriction, chaining functions together and preserving state
            between them. Both of the first two statements are therefore true, and they are two
            halves of the same fact rather than a contradiction.

            The services are complementary: a Logic App can call a Function and a Function can
            start a Logic App. And Logic Apps is built around a visual designer and connectors, so
            no code is required of the author.
            """,
            """
            The first two statements look as though they contradict each other. Work out whether
            one of them describes an option that removes the default.
            """);

        yield return Mc("as-037", D2, "Describe Azure compute services", R2,
            """
            An architect wants to buy a third-party network appliance and some consulting hours,
            and wants both to appear on the existing Azure invoice rather than on a separate
            purchase order.

            Which online store should the architect use?
            """,
            [
                "Azure Marketplace.",
                "Microsoft AppSource.",
                "Microsoft Store.",
                "Azure Advisor."
            ], "A",
            """
            Azure Marketplace lists Azure-focused solutions, managed services and consulting
            offerings, and purchases made there are billed through the customer Azure account,
            which is exactly the requirement about the invoice.

            Microsoft AppSource is the near miss and the reason to read the scenario: it is also a
            Microsoft store of third-party solutions, but it targets business applications for
            Dynamics 365, Microsoft 365 and Power Platform. Azure Advisor produces recommendations
            and sells nothing.
            """,
            """
            Two Microsoft stores sell third-party software. Let the sentence about the invoice
            decide which one belongs here.
            """);

        yield return Mc("as-038", D2, "Describe Azure compute services", R2,
            """
            You must replicate on-premises servers to Azure so the workload can be brought online
            there if the primary site is lost. A colleague suggests Azure Migrate instead.

            Which service fits, and what does the other one do?
            """,
            [
                "Azure Site Recovery, because it replicates servers continuously for failover, whereas Azure Migrate assesses and orchestrates a one-way move.",
                "Azure Migrate, because replication for disaster recovery is one of its assessment features.",
                "Azure Site Recovery, because Azure Migrate works only with physical servers.",
                "Azure Backup, because a replicated server is simply a scheduled backup with a shorter interval."
            ], "A",
            """
            Site Recovery replicates virtual machines and physical servers to a secondary location
            and can fail the workload over, which serves both disaster recovery and moving a
            running workload between regions.

            The comparison is the point. Azure Migrate is about discovery, assessment and
            executing a migration that ends when the workload has moved, whereas Site Recovery
            maintains an ongoing replica you can fail over to and back from. Backup restores point
            in time copies rather than standing a workload up elsewhere.
            """,
            """
            Both named services move servers to Azure. Ask which one leaves you with something you
            can fail over to next month.
            """);

        yield return HotImage("as-039", D2, "Describe the core architectural components of Azure", R2,
            """
            The exhibit shows the Azure scope hierarchy. An assignment made at one scope is
            inherited by every scope drawn beneath it.

            A policy must apply to every current and future subscription in the organisation,
            using a single assignment. Select the scope at which it should be assigned.
            """,
            "Azure scope hierarchy",
            "images/azure-scope-hyerarchy.png",
            "A diagram of the Azure scope hierarchy: a management group at the top, two "
                + "subscriptions beneath it, three resource groups beneath those, and "
                + "individual resources at the bottom.",
            [
                ("Management group", 2, 5.82, 96, 14.55),
                ("Subscription", 2, 29.82, 96, 16.36),
                ("Resource group", 2, 58.18, 96, 14.18),
                ("Resource", 2, 82.91, 96, 12.0)
            ], 1,
            """
            Read the diagram from the top down and the answer follows the inheritance: only the
            management group has every subscription beneath it, so only an assignment made there
            reaches all of them at once.

            The word future is what rules out assigning per subscription. A subscription created
            next year inherits the policy simply by being placed in the management group, with
            nobody repeating the assignment. Anything assigned at a subscription, a resource
            group or a resource reaches only that branch of the tree.
            """,
            """
            The diagram already shows you what sits beneath what. Find the highest level that
            still has every subscription under it, including ones that do not exist yet.
            """);

        yield return Build("as-040", D2, "Describe the core architectural components of Azure", R2,
            """
            An organisation nests one management group inside another before its subscriptions.

            Arrange the scopes in order, beginning with the broadest.
            """,
            "Scopes",
            [
                "Root management group",
                "Child management group",
                "Subscription",
                "Resource group",
                "Resource"
            ],
            [1, 2, 3, 4, 5],
            """
            Management groups can contain other management groups as well as subscriptions, which
            is what lets an organisation model business units above the billing boundary. Beneath
            the lowest management group sits the subscription, then the resource group, then the
            individual resource.

            Each level contains the one below it, and governance settings such as policy and role
            assignments flow downward through every level of the chain, including from one
            management group into another.
            """,
            """
            The familiar list has four levels. This organisation has added one more at the top of
            it, not at the bottom.
            """);
    }

    // ================================================================ storage

    private const string R3 = "Study guide, ch. 3: Azure Storage and Migration";

    private static IEnumerable<Item> StorageServices()
    {
        yield return Mc("st-001", D2, "Describe Azure storage services", R3,
            """
            You must store several million images, videos and log files that have no fixed schema,
            retrieve any of them over HTTPS by URL, and move older ones to cheaper storage
            automatically as they age.

            Which Azure storage service should you use?
            """,
            [
                "Blob storage.",
                "Azure Files.",
                "Azure Table storage.",
                "Azure managed disks."
            ], "A",
            """
            Blob storage is built for very large volumes of unstructured data such as images,
            video, audio, logs, telemetry and backups. Each blob is addressable by URL over HTTP
            and HTTPS as well as through the REST API, CLI, PowerShell and client libraries.

            The requirement about ageing is what makes it decisive rather than merely suitable.
            Access tiers and lifecycle management policies are a blob storage feature, so blobs can
            move to cool, cold or archive automatically. Azure Files provides shared file access,
            Table storage holds structured entities, and managed disks attach to one virtual
            machine.
            """,
            """
            More than one service could hold these files. The clause about older files moving to
            cheaper storage on their own points at a feature only one of them has.
            """);

        yield return Mc("st-002", D2, "Describe Azure storage services", R3,
            """
            You must replace an ageing on-premises file server. On-premises servers and Azure
            virtual machines have to mount the same share concurrently over SMB, and existing
            applications use drive letters and UNC paths that must keep working.

            Which service should you use?
            """,
            [
                "Azure Files.",
                "Blob storage with a lifecycle policy.",
                "Azure managed disks attached to a file server virtual machine.",
                "Azure Table storage."
            ], "A",
            """
            Azure Files exposes fully managed file shares over the industry-standard SMB and NFS
            protocols, so on-premises clients and Azure services can mount the same share at the
            same time and existing drive letters and UNC paths continue to work.

            A managed disk is the closest alternative in spirit and fails on the requirement to
            share: a disk attaches to a single virtual machine, so you would be rebuilding a file
            server rather than replacing one. Blob storage is addressed by URL rather than mounted
            as a file share.
            """,
            """
            Two options could serve files. Only one of them can be mounted by more than one machine
            at the same time.
            """);

        yield return Mc("st-003", D2, "Describe Azure storage services", R3,
            """
            A team wants to pass 2 MB image files between two components using Azure Queue storage.

            Which statement is correct?
            """,
            [
                "A queue message is limited to 64 KB, so the image should be written to blob storage and the message should carry a reference to it.",
                "A queue message is limited to 64 KB, so the image must be split across 32 messages and reassembled by the consumer.",
                "A queue message can be up to 4 MB, so the image fits in a single message.",
                "A queue holds a maximum of 64 KB in total, so only one small message can be queued at a time."
            ], "A",
            """
            An Azure Queue storage message can be up to 64 KB, and the queue itself can hold any
            number of messages, limited only by the storage account capacity. So the last option
            confuses a per-message limit with a per-queue one.

            The claim-check pattern in the correct answer is the standard way round the limit: put
            the payload in blob storage and put a pointer to it in the message. Splitting the image
            across messages would work in theory and creates ordering and reassembly problems that
            nobody wants.
            """,
            """
            The limit is per message, not per queue. Once you know it, ask what you would put in
            the message instead of the file.
            """);

        yield return Mc("st-004", D2, "Describe Azure storage services", R3,
            """
            You need a low-cost datastore for millions of device inventory records. Each record has
            a handful of properties, but different device types carry different properties, and the
            application never joins across records.

            Which service fits, and what would you use instead if the same data needed single-digit
            millisecond latency worldwide?
            """,
            [
                "Azure Table storage, and Azure Cosmos DB for Table for the global, low-latency case.",
                "Azure Table storage, and Azure SQL Database for the global, low-latency case.",
                "Azure SQL Database, and Azure Table storage for the global, low-latency case.",
                "Azure Queue storage, and Azure Cosmos DB for Table for the global, low-latency case."
            ], "A",
            """
            Table storage is a non-relational, schema-flexible key-value store queried through a
            clustered index. Records with differing properties and no joins describe it exactly,
            and it is the cheapest of the options.

            The second half is the upgrade path worth knowing: Azure Cosmos DB for Table offers the
            same programming model with global distribution and single-digit millisecond latency,
            so an application can move up without a rewrite. A relational database would impose the
            schema and joins this data does not want.
            """,
            """
            Two clauses in the stem, differing properties and no joins, point away from a
            relational engine. The second half of the question is about the premium version of
            whatever you chose.
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
                ("Provide an SMB share that on-premises servers and Azure VMs can mount at once", 2),
                ("Decouple a web front end from a slow back end using 64 KB messages", 4),
                ("Store schema-flexible entities such as device inventory records", 3),
                ("Hold a 2 MB payload that a queue message will point to", 1)
            ],
            """
            Blob storage handles large unstructured objects, Azure Files provides shared access
            over SMB or NFS, Queue storage carries small messages for asynchronous work, and Table
            storage holds schema-flexible entities.

            The last row is the claim-check pattern and the reason blob storage appears twice.
            Because a queue message caps at 64 KB, the payload goes to blob storage and the message
            carries only a reference to it.
            """,
            """
            One service is the right answer for two rows. The last row describes what happens when
            something is too large for the service named in the row above it.
            """);

        // ---------------------------------------------------------- access tiers

        yield return Mc("st-006", D2, "Describe Azure storage services", R3,
            """
            A company must retain audit records for seven years. The records are effectively never
            read, but an auditor may request one at short notice a few times a decade. Storage cost
            must be as low as possible.

            Which blob access tier should you use, and what should the company expect on retrieval?
            """,
            [
                "Archive, and the auditor request will need rehydration, which takes hours and costs the most of any tier.",
                "Archive, and the record can be read immediately because the tier is online.",
                "Cool, because archive cannot be used for data that will ever be read.",
                "Hot, because the unpredictable timing of an audit request rules out any other tier."
            ], "A",
            """
            Archive stores data offline at the lowest storage cost, which is what seven years of
            unread audit records call for. Hot, cool and cold are all online tiers offering
            progressively cheaper storage in exchange for progressively higher access costs.

            The trade-off is the second half of the answer. Reading archived data requires
            rehydration, which is measured in hours and carries the highest retrieval cost, so a
            few requests a decade is acceptable but a weekly report would not be. Archive is not
            forbidden for data that may be read; it is simply expensive to read.
            """,
            """
            The tier is the easy half. Ask what actually happens when the auditor calls, and
            whether a few times a decade makes that acceptable.
            """);

        yield return Mc("st-007", D2, "Describe Azure storage services", R3,
            """
            Data is written to the cold blob access tier and deleted 40 days later.

            What is the consequence, and what is the minimum retention period for that tier?
            """,
            [
                "An early deletion charge applies, because the cold tier has a 90-day minimum retention period.",
                "No charge applies, because the cold tier has a 30-day minimum retention period.",
                "An early deletion charge applies, because the cold tier has a 180-day minimum retention period.",
                "No charge applies, because minimum retention periods apply only to the archive tier."
            ], "A",
            """
            The cold tier carries a 90-day minimum retention period, so deleting at 40 days
            triggers an early deletion charge for the remaining 50 days as though the data had
            stayed.

            The full set is worth memorising because these charges are invisible until the bill
            arrives: hot has no minimum, cool is 30 days, cold is 90 days and archive is 180 days.
            The minimums are not exclusive to archive.
            """,
            """
            The cheaper tiers each buy their discount with a commitment. Recall the ladder of
            minimums and check where 40 days falls.
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
                ("The blob access tier with a 90-day minimum retention period is",
                    ["hot", "cool", "cold", "archive"], 3),
                ("The blob access tier with no minimum retention period is",
                    ["hot", "cool", "cold", "archive"], 1)
            ],
            """
            Archive is the only offline tier and its data must be rehydrated before it can be read.
            Hot is designed for frequently accessed data, so it carries the highest storage cost,
            the lowest access cost and, as the last row confirms, no retention commitment at all.

            The two cost axes always move in opposite directions: as storage gets cheaper down the
            ladder, access gets more expensive and the retention commitment gets longer, running
            30 days for cool, 90 for cold and 180 for archive.
            """,
            """
            Two rows point at the same tier from opposite directions, one about cost and one about
            commitment. That is not a mistake in the question.
            """);

        yield return YesNo("st-009", D2, "Describe Azure storage services", R3,
            """
            For each of the following statements about blob access tiers, select Yes if the
            statement is true. Otherwise, select No.
            """,
            [
                ("The access tier of an existing blob can be changed after upload.", true),
                ("Data in the archive tier can be read immediately without rehydration.", false),
                ("The hot tier has a lower storage cost than the archive tier.", false),
                ("A lifecycle management policy can move blobs between tiers automatically based on age.", true)
            ],
            """
            A blob access tier can be set at upload and changed afterwards, and lifecycle
            management policies exist precisely to automate that: move to cool after 30 days, to
            archive after 180, delete after seven years, without anyone touching a blob.

            Archive data is offline and must be rehydrated before reading, and archive is the
            cheapest tier to store in, not the most expensive. The third statement inverts the
            whole ladder.
            """,
            """
            The first and last statements are related: one says a change is possible, the other
            asks whether it can happen without a person.
            """);

        // ---------------------------------------------------------- redundancy

        yield return Mc("st-010", D2, "Describe Azure storage services", R3,
            """
            A storage account holds derived data that can be regenerated from source systems within
            an hour. Cost is the main concern.

            Which redundancy option fits, and what does it not protect against?
            """,
            [
                "Locally redundant storage, which keeps three copies in one physical location and does not survive the loss of that location.",
                "Locally redundant storage, which keeps three copies across three availability zones and does not survive a regional outage.",
                "Zone-redundant storage, which is the cheapest option and does not survive the loss of a single rack.",
                "Geo-redundant storage, which is required for any production data regardless of cost."
            ], "A",
            """
            Locally redundant storage keeps three copies inside a single physical location. That
            covers disk and rack failure and nothing larger: lose the data centre and you lose the
            data. It is the least expensive option, which is exactly the right trade when the data
            can simply be regenerated.

            Option B describes zone-redundant storage under the wrong name, which is the substitution
            to watch for. Zone-redundant storage is not the cheapest, and no rule requires
            geo-redundancy for all production data.
            """,
            """
            Each option pairs a name with a description. Check that the description actually
            belongs to the name in front of it.
            """);

        yield return Mc("st-011", D2, "Describe Azure storage services", R3,
            """
            A storage account must stay available if an entire availability zone in the primary
            region fails. Replication to a second region is explicitly not wanted, because of a
            data residency requirement.

            Which redundancy option should you choose?
            """,
            [
                "Zone-redundant storage (ZRS).",
                "Locally redundant storage (LRS).",
                "Geo-zone-redundant storage (GZRS).",
                "Read-access geo-zone-redundant storage (RA-GZRS)."
            ], "A",
            """
            Zone-redundant storage writes three copies across three or more availability zones in
            the primary region, so losing one zone leaves the data available and nothing crosses a
            regional boundary.

            The two geo-zone options are the trap: they add exactly the zone resilience being asked
            for, and they also copy data to a paired region, which the residency requirement
            forbids. Locally redundant storage would not survive the zone failure at all.
            """,
            """
            Three options provide zone resilience. Only one of them keeps every copy inside the
            primary region.
            """);

        yield return Mc("st-012", D2, "Describe Azure storage services", R3,
            """
            You configure a storage account to use geo-redundant storage (GRS).

            How many copies exist in total, where are they, and who chooses the secondary region?
            """,
            [
                "Six copies, three in the primary region and three in the paired secondary region, and Microsoft chooses the pairing.",
                "Six copies, three in the primary region and three in the paired secondary region, and the customer chooses the secondary region.",
                "Three copies in the primary region only, with the secondary created on failover, and Microsoft chooses the pairing.",
                "Two copies, one in each region, and the customer chooses the secondary region."
            ], "A",
            """
            Geo-redundant storage keeps three copies in the primary region and replicates the data
            to the paired secondary region, where a further three are kept: six in total, and they
            exist continuously rather than being created at failover time.

            The pairing is defined by Microsoft rather than selected by the customer, which is the
            detail that separates the two six-copy options. And the secondary copy is not readable
            unless the read-access variant is enabled.
            """,
            """
            Two options agree on the number and the placement. What separates them is who decided
            where the second region is.
            """);

        yield return Mc("st-013", D2, "Describe Azure storage services", R3,
            """
            You use geo-redundant storage (GRS). A reporting application should read a slightly
            stale copy of the data from the secondary region during normal operation, to take load
            off the primary.

            What should you configure?
            """,
            [
                "Read-access geo-redundant storage (RA-GRS), because with plain GRS the secondary is unreadable until a failover occurs.",
                "Nothing, because the GRS secondary is already readable through a separate endpoint.",
                "A manual failover to the secondary region, so the reporting application can read it.",
                "Zone-redundant storage, which distributes reads across availability zones."
            ], "A",
            """
            With plain geo-redundant storage the secondary copy exists but cannot be read. Reaching
            it requires a failover, which repoints DNS and is a recovery action, not something to
            do for a reporting workload.

            The read-access variants, RA-GRS and RA-GZRS, expose a secondary endpoint that
            applications can read during normal operation, accepting that it lags the primary
            slightly. That eventual consistency is why the stem says "slightly stale".
            """,
            """
            One option achieves the goal in a way nobody would choose twice. Ask what a failover is
            actually for.
            """);

        yield return Mc("st-014", D2, "Describe Azure storage services", R3,
            """
            What distinguishes geo-zone-redundant storage (GZRS) from geo-redundant storage (GRS)?
            """,
            [
                "GZRS spreads the primary region copies across availability zones, whereas GRS keeps them in one location. Both replicate to a paired secondary region.",
                "GZRS replicates to two secondary regions, whereas GRS replicates to one.",
                "GZRS makes the secondary region readable by default, whereas GRS does not.",
                "GZRS keeps three copies in total, whereas GRS keeps six."
            ], "A",
            """
            Both options replicate to a paired secondary region and both offer the same very high
            durability. The only difference is what happens in the primary region: GZRS distributes
            the primary copies across availability zones, while GRS keeps them within a single
            location.

            Readability of the secondary is controlled separately, by the RA prefix, and applies
            equally to GRS and GZRS. That independence is what makes option C wrong even though it
            describes a real feature.
            """,
            """
            One letter in each acronym differs, and it refers to the primary region rather than the
            secondary. Work out what the other letters have in common.
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
                ("Must survive the loss of one availability zone, and data must not leave the region", 2),
                ("Must survive the loss of the primary region, with the secondary copy readable at all times", 4),
                ("Must survive the loss of the primary region; the secondary need not be readable", 3),
                ("Must survive the loss of one availability zone and the loss of the primary region", 4)
            ],
            """
            Locally redundant storage is the cheapest and suits data that can be regenerated.
            Zone-redundant storage covers the loss of a zone without leaving the region, which is
            what a residency requirement needs.

            The last two geo rows are separated by one word. Plain geo-redundant storage covers
            regional loss but keeps the primary copies in one location, so it does not cover zone
            loss as well; the geo-zone variant covers both, and the RA prefix additionally makes
            the secondary readable. That is why one option answers two different rows.
            """,
            """
            Two rows mention regional loss and only one of them also mentions a zone. That second
            requirement changes the answer.
            """);

        // ---------------------------------------------------------- accounts and endpoints

        yield return Mc("st-016", D2, "Describe Azure storage services", R3,
            """
            A deployment fails with an invalid name error for a storage account called
            Contoso_Data_01.

            Which rule was broken?
            """,
            [
                "Storage account names must be 3 to 24 characters and contain only lowercase letters and numbers, so the uppercase letters and underscores are invalid.",
                "Storage account names must not exceed 15 characters, and this name is too long.",
                "Storage account names must begin with a letter, and this one does not.",
                "Storage account names must be unique only within the resource group, and this one is duplicated."
            ], "A",
            """
            A storage account name becomes part of a globally unique DNS name, which is why the
            rules are so tight: 3 to 24 characters, lowercase letters and digits only. This name
            breaks the rule twice over, with uppercase letters and underscores.

            The DNS connection is also why the name has to be globally unique rather than unique
            within a resource group, so the last option is wrong about the scope of uniqueness as
            well as about the cause.
            """,
            """
            The name breaks more than one rule at once. Recall where a storage account name ends up
            being used, and the restrictions follow from it.
            """);

        yield return Mc("st-017", D2, "Describe Azure storage services", R3,
            """
            An application must reach the file share service of a storage account named
            contosodata.

            Which endpoint should it use?
            """,
            [
                "https://contosodata.file.core.windows.net",
                "https://contosodata.blob.core.windows.net",
                "https://contosodata.queue.core.windows.net",
                "https://contosodata.table.core.windows.net"
            ], "A",
            """
            Each service in a storage account has its own endpoint suffix within the same account
            name: blob for blob storage, file for Azure Files, queue for Queue storage, table for
            Table storage and dfs for Data Lake Storage.

            The account name is shared across all of them, so the suffix is the only part that
            identifies which service you are addressing.
            """,
            """
            Every option has the correct account name, so the account is not what is being tested.
            Look at the word immediately after it.
            """);

        yield return Drag("st-018", D2, "Describe Azure storage services", R3,
            """
            Match each storage feature to its endpoint suffix. Each suffix may be used once, more
            than once, or not at all.
            """,
            "Endpoint suffixes",
            [
                "blob.core.windows.net",
                "file.core.windows.net",
                "queue.core.windows.net",
                "table.core.windows.net",
                "dfs.core.windows.net"
            ],
            [
                ("Blob storage", 1),
                ("Azure Files", 2),
                ("Queue storage", 3),
                ("Table storage", 4),
                ("Data Lake Storage Gen2 hierarchical namespace access", 5)
            ],
            """
            Storage endpoints follow one pattern in which the service name forms the first label
            after the account name, so the account name alone never tells you which service is
            being addressed.

            The Data Lake row is the one worth remembering. A storage account with a hierarchical
            namespace can be reached through both the blob endpoint and the dfs endpoint, and dfs
            is the one that exposes true directory operations rather than a flat namespace with
            slashes in the names.
            """,
            """
            One of these suffixes belongs to a service that also answers on another suffix in the
            list. Ask which one has two ways in.
            """);

        yield return Mc("st-019", D2, "Describe Azure storage services", R3,
            """
            An administrator moves a SQL Server database file onto the D: drive of an Azure virtual
            machine because it is fast and appears to cost nothing.

            What is wrong with this, and which disk survives a maintenance event?
            """,
            [
                "The D: drive is the temporary disk, whose contents can be lost during a maintenance event; the OS disk and any data disks are persistent managed disks.",
                "Nothing is wrong, because the temporary disk is a managed disk like any other.",
                "The D: drive is a data disk, and data disks are the only disks not retained through maintenance.",
                "Nothing is wrong, because Azure automatically backs up the temporary disk before maintenance."
            ], "A",
            """
            The temporary disk provides fast local scratch space and is not persistent: its
            contents can disappear during host maintenance or a redeploy, and nothing backs it up.
            It is a genuinely useful disk for page files and scratch space, and a bad one for
            anything you would miss.

            Persistent managed disks are the OS disk and any attached data disks, which survive
            reboots and redeployment.
            """,
            """
            The drive letter in the scenario identifies which disk this is. Once you know that,
            ask what "temporary" is warning you about.
            """);

        yield return YesNo("st-020", D2, "Describe Azure storage services", R3,
            """
            For each of the following statements about Azure managed disks, select Yes if the
            statement is true. Otherwise, select No.
            """,
            [
                ("Server-side encryption of data at rest is enabled by default.", true),
                ("A data disk retains its contents when the virtual machine is restarted.", true),
                ("The temporary disk is the recommended location for a database data file.", false),
                ("Because disks are encrypted at rest by default, no further encryption option exists.", false)
            ],
            """
            Managed disks are encrypted at rest by default through server-side encryption, and data
            disks are persistent across restarts. The temporary disk is not persistent, so durable
            data does not belong on it.

            The last statement is the one that matters in a design discussion. Encryption at rest
            by default is a floor, not a ceiling: in-guest encryption with BitLocker on Windows or
            DM-Crypt on Linux can be layered on top, and customer-managed keys can replace the
            platform-managed ones.
            """,
            """
            The last statement draws a conclusion from the first. Ask whether "on by default"
            really means "and nothing more is available".
            """);

        // ---------------------------------------------------------- migration

        yield return Mc("st-021", D2, "Describe Azure storage services", R3,
            """
            A company must move 800 TB of data to Azure. Its internet connection would take many
            months to transfer that volume.

            Which option should it use?
            """,
            [
                "Azure Data Box Heavy.",
                "Azure Data Box.",
                "Azure Data Box Disk.",
                "AzCopy over the existing connection."
            ], "A",
            """
            Data Box Heavy is the largest member of the family, at roughly one petabyte, and is
            built for exactly this case: an offline transfer where bandwidth, not effort, is the
            constraint.

            Sizing is the whole question here. The standard Data Box comes in 120 TB and 525 TB
            capacities, so 800 TB exceeds even the larger one, and Data Box Disk tops out at 40 TB
            across five disks. Any network tool runs into the same slow link.
            """,
            """
            Work out the capacity of each device in the family before choosing. One of them is
            large but still not large enough.
            """);

        yield return Mc("st-022", D2, "Describe Azure storage services", R3,
            """
            A team wants to script a nightly copy of a few thousand files into a storage account
            from a build server.

            Which tool fits, and what is its relationship to Azure Storage Explorer?
            """,
            [
                "AzCopy, and Storage Explorer is the graphical application that uses AzCopy underneath.",
                "AzCopy, and Storage Explorer is an unrelated tool that cannot transfer files.",
                "Azure Storage Explorer, because it can be scripted from the command line.",
                "Azure File Sync, because it is the only supported way to script a transfer."
            ], "A",
            """
            AzCopy is the scriptable command-line tool for uploading, downloading and copying blobs
            and files, which is what a nightly job on a build server needs.

            The relationship is worth knowing because it explains why the two tools behave
            identically: Azure Storage Explorer is a graphical front end that drives AzCopy for its
            transfers. Storage Explorer itself is not the thing you script. File Sync is a
            continuous synchronisation agent, not a transfer tool.
            """,
            """
            The tool choice is straightforward. The second half asks how the two tools are related,
            and they are not independent.
            """);

        yield return Mc("st-023", D2, "Describe Azure storage services", R3,
            """
            A branch office needs its Windows file server to keep only recently used files locally
            while everything else lives in an Azure file share, with users still seeing every file
            in the folder listing.

            Which service should you use, and what is the feature called?
            """,
            [
                "Azure File Sync, and the feature is cloud tiering.",
                "Azure File Sync, and the feature is geo-replication.",
                "AzCopy on a scheduled task, and the feature is cloud tiering.",
                "Azure Data Box Gateway, and the feature is cloud tiering."
            ], "A",
            """
            Azure File Sync installs an agent on Windows Server and synchronises it with an Azure
            file share. Cloud tiering is the feature that keeps hot files on local disk while cold
            files stay in Azure, leaving a pointer behind so the folder listing still shows
            everything.

            That last detail is what rules out a scheduled copy: AzCopy would move bytes but would
            never make a file appear present while it is actually in Azure. Geo-replication is a
            storage redundancy concept, not a caching one.
            """,
            """
            The requirement that users still see every file is the one a plain copy tool cannot
            meet. Find the feature named for that behaviour.
            """);

        yield return Mc("st-024", D2, "Describe Azure storage services", R3,
            """
            Before a migration, a team must inventory its on-premises servers, size the Azure
            equivalents from real performance data, and build a cost case.

            Which service should it use?
            """,
            [
                "Azure Migrate, using an appliance deployed on-premises to collect configuration and performance data.",
                "Azure Site Recovery, using its replication data to build the assessment.",
                "Azure Advisor, which analyses on-premises servers once they are registered.",
                "Azure Arc, which assesses servers as part of onboarding them."
            ], "A",
            """
            Azure Migrate is the hub for the whole migration process, and the appliance is the part
            that makes it more than a spreadsheet: it watches real configuration and performance
            over time, so the sizing and cost estimates reflect how the servers actually behave
            rather than how they were specified.

            Site Recovery replicates for failover rather than assessing, Advisor analyses resources
            already in Azure, and Arc extends Azure management to outside servers without producing
            a migration assessment.
            """,
            """
            The words "from real performance data" rule out anything that only reads a
            configuration. Ask which service puts something on-premises to watch.
            """);

        yield return Mc("st-025", D2, "Describe Azure storage services", R3,
            """
            Which two capacities are available for the standard Azure Data Box device? Each correct
            answer presents a complete solution.
            """,
            ["120 TB.", "525 TB.", "1 PB.", "40 TB.", "8 TB."], "A,B",
            """
            The standard Azure Data Box ships in 120 TB and 525 TB capacities, covering medium to
            large offline transfers.

            The other three numbers belong to the rest of the family, which is why they are here:
            roughly one petabyte is Data Box Heavy, and Data Box Disk ships as one to five
            encrypted solid-state disks of 8 TB each, up to 40 TB in total. Knowing which number
            goes with which device is what the question is testing.
            """,
            """
            Every number here is a real Data Box figure. The task is to attach each one to the
            right member of the family.
            """);

        yield return Mc("st-026", D2, "Describe Azure storage services", R3,
            """
            A team defends its choice of locally redundant storage for a media transcoding cache by
            saying the source files exist elsewhere and can be re-rendered.

            Which response is correct?
            """,
            [
                "The choice is sound: LRS is the cheapest option and is appropriate precisely because the data can be regenerated.",
                "The choice is unsound: production data always requires at least geo-redundant storage.",
                "The choice is unsound: LRS keeps only one copy, so a single disk failure loses the cache.",
                "The choice is sound, and it also protects against the loss of the data centre."
            ], "A",
            """
            Redundancy is a business decision about consequence, not a rule to be applied
            uniformly. When losing the data means re-running a job rather than losing information,
            the cheapest option is the right one, and that is the reasoning the team has applied.

            The two unsound options misstate facts: there is no rule requiring geo-redundancy for
            all production data, and LRS keeps three copies rather than one. It does not, however,
            survive the loss of the data centre, so the last option overstates it.
            """,
            """
            Three options claim something factual about LRS or about policy. Check each claim
            before judging the team reasoning.
            """);

        yield return Mc("st-027", D2, "Describe Azure storage services", R3,
            """
            Which blob type is designed for frequent random read and write operations, and backs
            virtual hard disk files?
            """,
            ["Page blobs.", "Block blobs.", "Append blobs.", "Archive blobs."], "A",
            """
            Page blobs are collections of 512-byte pages optimised for frequent random reads and
            writes, which is exactly the access pattern of a running operating system, so they back
            virtual hard disk files.

            Block blobs are the default and suit sequential upload and download of whole objects,
            and append blobs are optimised for adding to the end. Archive is an access tier rather
            than a blob type, which makes the last option a category error rather than a wrong
            answer.
            """,
            """
            One of these four is not a blob type at all. Eliminating it first leaves three, sorted
            by access pattern.
            """);

        yield return Mc("st-028", D2, "Describe Azure storage services", R3,
            """
            An application writes a continuous stream of log entries, always adding to the end of
            the file and never modifying what is already written.

            Which blob type is optimised for this, and which would be the wrong choice?
            """,
            [
                "Append blobs are optimised for it; page blobs would be wrong, because they are built for random read and write.",
                "Append blobs are optimised for it; block blobs would be wrong, because they cannot be read sequentially.",
                "Page blobs are optimised for it, because a log grows continuously like a virtual disk.",
                "Block blobs are optimised for it, because logs are uploaded as complete objects."
            ], "A",
            """
            Append blobs exist for exactly this pattern: data is only ever added to the end, which
            makes them the natural home for log and telemetry files.

            Page blobs are the wrong tool because they optimise for random reads and writes across
            512-byte pages, which a log never performs. The reasoning in option B is false as
            well, since block blobs read sequentially perfectly well; they are simply not optimised
            for repeated appends.
            """,
            """
            Two options name the right blob type and give different reasons. One of those reasons
            states something untrue about a different blob type.
            """);
    }
}
