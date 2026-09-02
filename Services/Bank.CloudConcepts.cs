using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Domain 1 of the AZ-900 skills outline: "Describe cloud concepts" (25-30%).
// Facts sourced from chapter 1 of the study guide; wording is original.
public static partial class QuestionBank
{
    private static readonly ExamDomain D1 = AzureDomains.CloudConcepts;
    private const string R1 = "Study guide, ch. 1: Cloud Concepts";

    private static IEnumerable<Item> CloudConcepts()
    {
        // ---------------------------------------------------------- financial models

        yield return Mc("cc-001", D1, "Describe the benefits of cloud computing", R1,
            """
            A manufacturing company refreshes its on-premises server hardware every four years.
            Each refresh is a single large purchase, approved a year in advance and written down
            over the life of the equipment.

            The company moves the workloads to Azure. To reduce the bill it also pays up front
            for a three-year reserved virtual machine instance, and pays metered rates for
            everything else.

            Which statement best describes the company spending after the move?
            """,
            [
                "It is all operational expenditure, because a reservation pre-pays for a metered service rather than buying an asset.",
                "It is all capital expenditure, because the reservation is a single large up-front purchase.",
                "The reservation is capital expenditure and the metered usage is operational expenditure.",
                "It remains capital expenditure until the reservation term ends, and becomes operational expenditure afterwards."
            ], "A",
            """
            What separates capital expenditure from operational expenditure is not the size or the
            timing of the payment, it is whether the money buys an asset you own and depreciate.
            Buying servers does. Pre-paying for three years of a virtual machine does not: the
            company owns nothing at the end of the term, it has simply bought a discount on a
            service it is still consuming.

            So the whole Azure bill, reservation included, is operational expenditure. The
            remaining options all let the up-front payment decide the answer, which is the trap.
            """,
            """
            Do not let the size or the timing of the payment decide this for you. Ask what the
            company still owns once the three years are up.
            """);

        yield return Mc("cc-002", D1, "Describe the benefits of cloud computing", R1,
            """
            Which two costs are examples of capital expenditure? Each correct answer presents a
            complete solution.
            """,
            [
                "Purchasing physical servers for a company-owned data centre.",
                "Paying up front for a one-year Azure reserved virtual machine instance.",
                "Buying perpetual licences for software installed on owned hardware.",
                "An annual support contract renewed each January.",
                "Metered charges for outbound data transfer from an Azure region."
            ], "A,C",
            """
            Capital expenditure buys a fixed asset that is then depreciated over its useful life.
            Servers and perpetual licences both qualify: the organisation owns them, and still
            owns them after the accounting period ends.

            The reserved instance is the distractor worth studying. It is paid up front, in one
            large sum, and it still is not capital expenditure, because it buys a discounted rate
            on a service rather than an asset. An annual support contract and metered data
            transfer are recurring costs of running the business, so both are operational
            expenditure as well.
            """,
            """
            Three of these are paid in a single lump sum. Only two of those leave the organisation
            owning something afterwards.
            """);

        yield return Dropdowns("cc-003", D1, "Describe the benefits of cloud computing", R1,
            """
            A cloud provider buys servers and storage in very large volumes, obtains a far lower
            per-unit price than any single customer could, and passes part of that saving on.
            Customers are billed only for the hours their virtual machines actually run.

            Select the answer choice that completes each statement.
            """,
            [
                ("The lower per-unit hardware price the provider obtains is an example of",
                    ["consumption-based pricing", "economy of scale", "elasticity", "chargeback"], 2),
                ("Billing customers only for the hours their machines run is an example of",
                    ["economy of scale", "amortisation", "consumption-based pricing", "a true-up"], 3),
                ("Sharing that saving with customers is possible because the provider",
                    ["spreads one pool of infrastructure across many tenants", "depreciates each customer hardware separately", "guarantees a fixed monthly fee", "transfers ownership of the hardware to the customer"], 1)
            ],
            """
            Economy of scale is a supply-side advantage: buying in bulk lowers the provider unit
            cost. Consumption-based pricing is a demand-side billing model: the customer pays for
            measured usage rather than for capacity. The two are related but they describe
            different sides of the transaction.

            The third statement is what connects them. Multi-tenancy is what makes the saving
            shareable, because one pool of hardware serves many customers instead of sitting
            part-idle in each customer own rack. Nothing here transfers ownership, and a metered
            model is by definition not a fixed fee.
            """,
            """
            One of these statements is about what the provider pays and one is about what the
            customer pays. Sort out which is which before you choose.
            """);

        yield return Mc("cc-004", D1, "Describe the benefits of cloud computing", R1,
            """
            The finance team wants each department own budget to absorb the cost of the Azure
            resources that department consumed last month, using the usage figures Azure already
            meters for every resource.

            Which practice does this describe, and what makes it practical in Azure?
            """,
            [
                "Chargeback, because consumption is already metered per resource and can be attributed with tags.",
                "Showback, because the departments see their usage but the central IT budget still absorbs the cost.",
                "Amortisation, because the cost of shared infrastructure is spread over its useful life.",
                "A true-up, because licence counts are reconciled against actual consumption at the end of the period."
            ], "A",
            """
            Chargeback moves the cost onto the consuming department budget. It is practical in
            Azure because usage is metered per resource and resources can be tagged with a cost
            centre, so the bill can be split on measured figures rather than estimates.

            Showback is the near miss, and the reason to read the stem closely: showback reports
            exactly the same figures but leaves the cost with central IT, whereas here finance
            explicitly wants the department budget charged. Amortisation spreads an asset cost
            over its life, and a true-up reconciles licence counts under an Enterprise Agreement.
            """,
            """
            Two of these involve reporting departmental usage from the same meters. Only one of
            them actually moves the money.
            """);

        yield return YesNo("cc-005", D1, "Describe the benefits of cloud computing", R1,
            """
            For each of the following statements about cloud financial models, select Yes if the
            statement is true. Otherwise, select No.
            """,
            [
                ("A consumption-based model bills only for the resources actually used.", true),
                ("Moving to a consumption-based model reduces the need to plan and monitor spending.", false),
                ("A stopped but not deallocated virtual machine can still incur compute charges.", true),
                ("Operational expenditure spreads cost across the year rather than requiring it up front.", true)
            ],
            """
            Consumption billing meters usage, and operational expenditure does spread cost through
            the year instead of demanding one large purchase, so the first and last statements are
            true.

            The middle two are where candidates lose the item. Metered billing makes planning and
            monitoring more important, not less, because nothing stops charges accruing on
            forgotten resources. And in the portal a virtual machine that is merely stopped still
            holds its compute allocation; only deallocating it releases that allocation and ends
            the compute charge, though storage is still billed either way.
            """,
            """
            One statement turns on a distinction the portal makes between two words that sound
            interchangeable. Consider what "stopped" actually releases.
            """);

        // ---------------------------------------------------------- scalability

        yield return Mc("cc-006", D1, "Describe the benefits of high availability and scalability", R1,
            """
            An Azure virtual machine hosting a reporting application runs out of memory during
            month-end processing. The application is single-threaded and holds the entire dataset
            in memory, so its work cannot be split across machines.

            You resize the virtual machine to a size with more memory and more CPU cores.

            Which type of scaling did you perform, and why was the alternative unsuitable?
            """,
            [
                "Vertical scaling, because the workload cannot be distributed across additional instances.",
                "Horizontal scaling, because you increased the total resources available to the application.",
                "Vertical scaling, because scaling out is supported only for platform as a service workloads.",
                "Horizontal scaling, because resizing a virtual machine creates a replacement instance behind the scenes."
            ], "A",
            """
            Changing the capacity of an existing resource is vertical scaling, also called scaling
            up. It is the right lever here precisely because the application is single-threaded
            and memory-bound: more machines would give it more total resources and no way to use
            them.

            Horizontal scaling means running more instances, which only helps a workload that can
            spread across them. Scaling out is not restricted to platform as a service, and
            resizing changes the existing instance rather than adding one.
            """,
            """
            The detail that decides this is not what you did to the machine. It is the sentence
            describing what the application cannot do.
            """);

        yield return Mc("cc-007", D1, "Describe the benefits of high availability and scalability", R1,
            """
            A web application runs on three identical virtual machines behind a load balancer.
            Ahead of a seasonal peak you add four more identical virtual machines to the pool. A
            month later, when traffic returns to normal, you remove those four again.

            Which two terms correctly describe what you did? Each correct answer presents part of
            the solution.
            """,
            [
                "Adding the four machines was scaling out.",
                "Adding the four machines was scaling up.",
                "Removing them again was scaling in.",
                "Removing them again was scaling down.",
                "The whole cycle was vertical scaling."
            ], "A,C",
            """
            Horizontal scaling changes the number of instances: adding them is scaling out and
            removing them is scaling in.

            Vertical scaling changes the capacity of an existing instance: adding capacity is
            scaling up and reducing it is scaling down. Every machine here stayed exactly the same
            size and only the count changed, so the up and down pair does not apply.
            """,
            """
            Two axes, two pairs of words. Decide first whether the machines changed size or
            changed number, then use only the pair belonging to that axis.
            """);

        yield return Dropdowns("cc-008", D1, "Describe the benefits of high availability and scalability", R1,
            """
            Select the answer choice that completes each statement based on the information
            presented.
            """,
            [
                ("Adding CPU cores and memory to an existing virtual machine is known as",
                    ["scaling out", "scaling up", "scaling in", "elasticity"], 2),
                ("Adding more virtual machine instances to a workload is known as",
                    ["scaling out", "scaling up", "scaling down", "fault tolerance"], 1),
                ("Removing instances automatically when demand falls is known as",
                    ["scaling up", "scaling down", "scaling in", "disaster recovery"], 3),
                ("Resizing a running virtual machine normally requires",
                    ["no interruption at all", "a restart of the virtual machine", "a redeployment to another region", "a new subscription"], 2)
            ],
            """
            Vertical scaling changes the capacity of an existing resource: scaling up adds it and
            scaling down removes it. Horizontal scaling changes the number of resources: scaling
            out adds instances and scaling in removes them. Keeping those two axes apart is the
            point of the first three rows.

            The fourth row is the practical consequence. Because vertical scaling changes the
            machine itself, it normally means a restart and therefore an interruption, which is a
            large part of why horizontal scaling is preferred for workloads that must stay up.
            """,
            """
            The first three rows are vocabulary. The fourth asks what actually happens to the
            workload, and it is the reason architects lean one way rather than the other.
            """);

        yield return Mc("cc-009", D1, "Describe the benefits of high availability and scalability", R1,
            """
            You configure a rule so that Azure adds instances when average CPU usage exceeds a
            threshold and removes them again when usage falls. No administrator is involved at the
            moment either action happens.

            A colleague argues that this is simply scalability, not elasticity. Which statement is
            correct?
            """,
            [
                "It is elasticity, which is the subset of scalability where the adjustment happens automatically in response to measured demand.",
                "The colleague is right, because elasticity refers only to storage capacity growing automatically.",
                "It is elasticity, which is a separate capability from scalability and does not involve adding resources.",
                "The colleague is right, because configuring a threshold in advance means an administrator made the scaling decision."
            ], "A",
            """
            Scalability is the broad ability to add or remove resources to meet demand, whether a
            person does it by hand or a rule does it automatically. Elasticity is the narrower
            case: the adjustment is driven by measured demand with nobody in the loop at the time
            it happens.

            So both words apply, and elasticity is the more precise one. Setting a threshold in
            advance does not make the scaling manual, elasticity is not limited to storage, and it
            is not a separate capability that somehow avoids adding resources.
            """,
            """
            Both terms genuinely apply to this scenario. The real question is which is more
            precise, and how the two relate to each other.
            """);

        yield return YesNo("cc-010", D1, "Describe the benefits of high availability and scalability", R1,
            """
            An operations team is drafting definitions for its runbook. For each of the following
            statements, select Yes if the statement is accurate. Otherwise, select No.
            """,
            [
                ("Every elastic system is scalable, but not every scalable system is elastic.", true),
                ("A workload that an engineer resizes by hand each quarter is still scalable.", true),
                ("Elasticity guarantees that a workload will never run short of capacity.", false),
                ("Scalability applies to storage and compute, but elasticity applies only to compute.", false)
            ],
            """
            Elasticity is automatic, demand-driven scaling, which makes it a subset of
            scalability: elastic implies scalable, but a workload resized by hand each quarter is
            scalable without being elastic. That settles the first two statements.

            Elasticity does not guarantee sufficiency. A rule takes time to trigger, an instance
            takes time to start, and subscription quotas still apply, so a sharp spike can outrun
            the autoscaler. Neither term is restricted to a single resource type.
            """,
            """
            Ask whether one of these terms sits inside the other, and what has to happen between a
            threshold being crossed and a new instance actually serving traffic.
            """);

        yield return Mc("cc-011", D1, "Describe the benefits of high availability and scalability", R1,
            """
            Your organisation can stand up a complete test environment in Azure within an hour,
            evaluate a new product idea, and tear the environment down the same week. The same
            experiment previously required a hardware purchase and a three-month lead time.

            Which cloud benefit does this primarily describe?
            """,
            [
                "Agility.",
                "Elasticity.",
                "High availability.",
                "Economy of scale."
            ], "A",
            """
            Agility is the speed at which you can provision, change and retire resources, and
            therefore how quickly the business can act on an idea. Three months down to an hour is
            the textbook illustration.

            Elasticity is the closest distractor, but it describes capacity adjusting itself to
            measured demand inside a running workload, not the speed of creating and destroying
            whole environments. High availability concerns uptime, and economy of scale is a
            pricing advantage.
            """,
            """
            Elasticity and agility both describe things happening fast. One is a running workload
            resizing itself; the other is how quickly you can create and destroy an environment.
            """);

        yield return YesNo("cc-012", D1, "Describe the benefits of high availability and scalability", R1,
            """
            For each of the following statements about scaling, select Yes if the statement is
            true. Otherwise, select No.
            """,
            [
                ("Scaling out adds more instances of a resource.", true),
                ("Scaling up increases the capacity of an existing resource.", true),
                ("Elasticity requires an administrator to approve each scaling action.", false),
                ("Horizontal scaling has no practical upper limit, so it suits stateless workloads best.", true)
            ],
            """
            Scaling out adds instances and scaling up increases the capacity of an existing
            resource, so the first two are true. Elasticity is defined by the absence of a human
            in the loop, so the third is false.

            The fourth is true and worth understanding rather than memorising. Vertical scaling
            stops at the largest available machine size, while adding instances has no comparable
            ceiling. That only helps when requests can go to any instance, which is why stateless
            designs are the ones that benefit.
            """,
            """
            The last statement joins a limit to a design style. Ask what caps each kind of
            scaling, and what a workload must avoid holding on to for the uncapped one to work.
            """);

        // ---------------------------------------------------------- availability concepts

        yield return Mc("cc-013", D1, "Describe the benefits of high availability and scalability", R1,
            """
            A service is covered by a service level agreement that guarantees 99.9 percent
            availability.

            Approximately how much unavailability does this permit over a 30-day month, and over a
            full year?
            """,
            [
                "About 43 minutes per month and about 8.8 hours per year.",
                "About 4.3 minutes per month and about 53 minutes per year.",
                "About 43 minutes per month and about 53 minutes per year.",
                "About 7.2 hours per month and about 3.7 days per year."
            ], "A",
            """
            A 99.9 percent guarantee allows 0.1 percent downtime. Over a 30-day month that is
            roughly 43 minutes, and over a 365-day year roughly 8.8 hours.

            The other figures belong to neighbouring guarantees, which is exactly why they are
            worth recognising: about 4.3 minutes a month and 53 minutes a year is 99.99 percent,
            and about 7.2 hours a month is 99 percent. Each extra nine divides the allowance by
            ten. Option C mixes the monthly figure of one tier with the yearly figure of another.
            """,
            """
            Work from the percentage that is missing rather than the one quoted, then check that
            the monthly and yearly figures in an option are consistent with each other.
            """);

        yield return Mc("cc-014", D1, "Describe the benefits of high availability and scalability", R1,
            """
            During a busy period an Azure-hosted application responds far more slowly than usual.
            Every request is eventually served successfully and none returns an error.

            The service is covered by an availability service level agreement. How is this period
            treated?
            """,
            [
                "As available, because an availability SLA measures whether the service can be reached and used, not how fast it responds.",
                "As unavailable, because sustained degradation counts as partial downtime and is credited pro rata.",
                "As unavailable, because Azure availability SLAs set a maximum response time for each service.",
                "As available only if the provider publishes a service health advisory for the period."
            ], "A",
            """
            An availability commitment is about reachability. If requests are being accepted and
            answered then the service is available, however slowly it answers. Performance targets
            are stated separately, as service-specific latency percentiles, and are not what an
            availability percentage measures.

            The other options invent mechanisms that do not exist for this purpose: there is no
            universal response-time bound in an availability SLA, no pro rata credit for slowness,
            and a health advisory records an incident rather than defining availability.
            """,
            """
            Read the guarantee literally. Which single word is the percentage attached to, and
            does a slow but successful answer break that word?
            """);

        yield return Mc("cc-015", D1, "Describe the benefits of high availability and scalability", R1,
            """
            An application runs on two load-balanced web servers in the same region. One server
            fails. The remaining server keeps serving users, at reduced capacity, until the failed
            server is replaced. No plan was activated and nothing was restored.

            Which characteristic does this best describe?
            """,
            [
                "Fault tolerance.",
                "Disaster recovery.",
                "Elasticity.",
                "Scaling in."
            ], "A",
            """
            Fault tolerance is a system continuing to function when one of its components fails.
            One of two load-balanced servers dropping out while the service stays up is exactly
            that, and the giveaway is the last sentence: nothing had to be recovered and nobody had
            to act.

            Disaster recovery is what follows a large-scale loss, and it involves a plan, a
            restore and usually a second site. Elasticity would mean capacity responding to demand
            rather than to a failure, and scaling in is the deliberate removal of instances.
            """,
            """
            More than one of these could loosely fit "a machine is gone and the service is still
            up". Let the final sentence of the scenario break the tie.
            """);

        yield return Mc("cc-016", D1, "Describe the benefits of high availability and scalability", R1,
            """
            A fire destroys the data centre hosting all of a company production systems. The
            company activates a documented plan, brings those systems back online at an alternate
            site from backups, and accepts the loss of the last four hours of transactions.

            Which concept does this describe, and what does the four-hour loss represent?
            """,
            [
                "Disaster recovery, and the four hours is the recovery point objective.",
                "Disaster recovery, and the four hours is the recovery time objective.",
                "Fault tolerance, and the four hours is the recovery point objective.",
                "High availability, and the four hours is the downtime permitted by the service level agreement."
            ], "A",
            """
            Recovering multiple systems at another site after a catastrophic loss is disaster
            recovery, not fault tolerance: fault tolerance absorbs the failure of a component
            without anyone activating anything.

            The two recovery objectives are easy to swap. The recovery point objective is how much
            data you can afford to lose, measured backwards from the moment of failure, which is
            what four hours of transactions describes. The recovery time objective is how long you
            can afford to be down, measured forwards from it.
            """,
            """
            One of these objectives is measured in lost data and the other in lost time. Which one
            does "the last four hours of transactions" describe?
            """);

        yield return Drag("cc-017", D1, "Describe the benefits of high availability and scalability", R1,
            """
            Match each situation to the concept it best illustrates. Each concept may be used
            once, more than once, or not at all.
            """,
            "Concepts",
            [
                "High availability",
                "Fault tolerance",
                "Disaster recovery",
                "Elasticity"
            ],
            [
                ("One of four web servers loses a disk and users notice nothing", 2),
                ("A flood closes a region and the team rebuilds the workload elsewhere from backups", 3),
                ("A contract promises 99.95 percent uptime and credits the customer if it is missed", 1),
                ("Instance count rises from 4 to 11 overnight without a change request", 4)
            ],
            """
            The first three are the classic trio and they are separated by scope and by who acts.
            A single component failing while the service carries on is fault tolerance. Rebuilding
            elsewhere after a site is lost is disaster recovery. A contractual uptime percentage
            with a credit attached is high availability.

            The fourth row is the one that catches people out. Nothing has failed at all: capacity
            is tracking demand without a human request, which is elasticity, not resilience.
            """,
            """
            Three of these are about something breaking. Check whether that is true of every row
            before you assume the fourth concept is unused.
            """);

        yield return YesNo("cc-018", D1, "Describe the benefits of high availability and scalability", R1,
            """
            For each of the following statements, select Yes if the statement is true. Otherwise,
            select No.
            """,
            [
                ("A workload can be fault tolerant and still fail its availability commitment.", true),
                ("Fault tolerance and disaster recovery are the same capability described at different scales.", false),
                ("A service that is reachable but very slow has breached its availability guarantee.", false),
                ("Deploying across two regions improves disaster recovery but does not by itself raise the SLA of a single virtual machine.", true)
            ],
            """
            Fault tolerance protects against component failure, but a workload can still miss its
            uptime percentage for reasons that have nothing to do with a failed component, such as
            a bad deployment or an expired certificate, so the first statement is true.

            The second is a common but wrong simplification: disaster recovery is a process
            involving a plan and a restore, not simply fault tolerance at larger scale.
            Availability measures reachability, not speed. And a second region is a recovery
            capability, not a change to the single-instance SLA, which is set by the disk and
            deployment configuration of that instance.
            """,
            """
            Two of these turn on the difference between what a percentage promises and what an
            architecture protects against. They are not the same thing.
            """);

        yield return Mc("cc-019", D1, "Describe the benefits of high availability and scalability", R1,
            """
            A team plans to deploy several thousand virtual machine cores into a single Azure
            region on a fixed date.

            Which statement about cloud capacity should shape that plan?
            """,
            [
                "Regional capacity is finite and shared, so a deployment of that size should be raised with Microsoft in advance and should allow for an alternate region.",
                "Cloud capacity is effectively unlimited, so no advance planning is required for any deployment size.",
                "Capacity is reserved permanently for each customer when the subscription is created, so the cores are already set aside.",
                "Capacity limits apply only to storage, so a compute deployment of any size will succeed."
            ], "A",
            """
            A region is a finite pool of servers, power, cooling and network. When one customer
            scales in, the released capacity returns to the pool for others; when one customer
            asks for several thousand cores at once, it can consume a meaningful share of what is
            free. Subscription quotas exist on top of that and are not raised instantly.

            So a deployment of this size wants advance notice and a fallback region. Capacity is
            not unlimited, nothing is set aside at subscription creation, and the limits are not
            confined to storage.
            """,
            """
            The size and the fixed date in the stem are the point. Ask what could make a
            deployment that big fail on the day even though everything is configured correctly.
            """);

        // ---------------------------------------------------------- service models

        yield return Mc("cc-020", D1, "Describe cloud service types", R1,
            """
            Your company subscribes to Microsoft 365. Users open Word and Excel through a browser
            and Microsoft applies application updates automatically.

            Which service type is this, and what does your company still have to manage?
            """,
            [
                "SaaS, and the company still manages its user accounts, its licence assignments and its own data.",
                "SaaS, and the company manages nothing at all once the subscription is active.",
                "PaaS, and the company still manages the runtime that Word and Excel execute in.",
                "IaaS, and the company still manages the virtual machines that deliver the applications."
            ], "A",
            """
            Software as a service means the provider hosts, manages, patches and updates a
            finished application. Microsoft 365 is the standard example, and the customer never
            sees the virtual machines or the runtime.

            The residual responsibility is the part worth remembering, because it is the one
            option here that is easy to skim past. Identity, access and the customer own data
            never transfer to the provider under any service type, so "manages nothing at all" is
            wrong even for SaaS.
            """,
            """
            Naming the service type is the easy half. The harder half is that one of these options
            claims a responsibility disappears entirely, and none of them ever does.
            """);

        yield return Mc("cc-021", D1, "Describe cloud service types", R1,
            """
            You deploy seven Azure virtual machines to host a SharePoint farm. Your team installs
            and patches the guest operating systems and the SharePoint software. Microsoft
            maintains the physical hosts, storage and networking hardware.

            A colleague says that because Microsoft runs SharePoint Online as a service, this
            deployment is also SaaS. Why is that wrong?
            """,
            [
                "Because the service type is decided by what you manage in this deployment, and here you manage the guest operating systems and the software.",
                "Because SaaS applies only to applications that Microsoft itself did not write.",
                "Because SharePoint can never be delivered as software as a service.",
                "Because a deployment of more than five virtual machines is always classified as IaaS."
            ], "A",
            """
            The same product can be consumed under different service types. SharePoint Online is
            SaaS because Microsoft runs and patches it. SharePoint installed by you on virtual
            machines you patch is infrastructure as a service, because the boundary is drawn by
            who manages which layer, not by the name of the software.

            That makes IaaS the model with the highest customer responsibility here. The other
            options invent rules about authorship, product eligibility and instance counts that do
            not exist.
            """,
            """
            The same application can appear under more than one service type. Ask what actually
            draws the line between them.
            """);

        yield return Mc("cc-022", D1, "Describe cloud service types", R1,
            """
            A development team deploys a web application to Azure App Service. The team writes and
            deploys application code only. Microsoft provides and maintains the underlying virtual
            machines, the operating system and the application runtime.

            The team now needs to install a third-party agent into the operating system that hosts
            the app. What does this tell you about the service type in use?
            """,
            [
                "It is PaaS, and installing arbitrary software into the host operating system is exactly the control PaaS gives up.",
                "It is PaaS, and PaaS gives the same operating system access as IaaS, so the agent can simply be installed.",
                "It is IaaS, because the team is responsible for anything installed on the host.",
                "It is SaaS, because the team does not manage the virtual machines."
            ], "A",
            """
            Platform as a service supplies a managed application platform so a team can build and
            deploy without provisioning servers, operating systems or runtimes. Azure App Service
            is the classic example, and the trade for that convenience is control: you do not get
            to install whatever you like into the host operating system.

            That trade is the whole point of the question. It is not IaaS, because the team does
            not own the operating system, and it is not SaaS, because the team is deploying its
            own application code.
            """,
            """
            You already know which service type this is. The question is what that choice costs
            you, and this new requirement is the bill arriving.
            """);

        yield return Drag("cc-023", D1, "Describe cloud service types", R1,
            """
            Match each scenario to the cloud service type it represents. Each service type may be
            used once, more than once, or not at all.
            """,
            "Service types",
            [
                "IaaS",
                "PaaS",
                "SaaS"
            ],
            [
                ("A team licenses a finished email and productivity suite per user", 3),
                ("A team deploys its own code to Azure App Service and never patches an OS", 2),
                ("A team lifts and shifts an existing server into Azure and keeps patching it", 1),
                ("A team uses Azure SQL Database and never applies a database engine update", 2)
            ],
            """
            Licensing a finished, provider-managed application per user is software as a service.
            Deploying your own code to a managed platform without touching an operating system is
            platform as a service.

            The last two rows are the ones that separate candidates. A lift and shift keeps the
            server, and therefore the patching, so it is IaaS. Azure SQL Database is a managed
            platform service, so it is PaaS even though the customer never writes application code
            for it: what matters is that Microsoft owns the engine and the operating system
            beneath it.
            """,
            """
            Do not sort these by whether the team writes code. Sort them by the highest layer the
            provider still owns.
            """);

        yield return Mc("cc-024", D1, "Describe cloud service types", R1,
            """
            An application needs a legacy kernel-mode driver installed and the patching window
            controlled by the operations team.

            Which service type meets that requirement, and what does choosing it cost?
            """,
            [
                "IaaS, at the cost of owning guest operating system patching, configuration and backup.",
                "PaaS, at the cost of a longer deployment time for the application code.",
                "SaaS, at the cost of a per-user licence for every operator.",
                "PaaS, at no cost, because the platform grants driver-level access on request."
            ], "A",
            """
            Only infrastructure as a service gives control at that depth. A kernel-mode driver and
            a chosen patching window both require ownership of the guest operating system, which
            is precisely the layer IaaS hands over.

            The cost is the other half of the answer and the half candidates skip: the same
            ownership that makes the driver possible makes patching, hardening, configuration and
            backup of that operating system your problem. PaaS never grants driver-level access,
            on request or otherwise.
            """,
            """
            Two requirements in the stem point at the same layer of the stack. Work out which
            layer, then remember that control and responsibility arrive together.
            """);

        yield return Mc("cc-025", D1, "Describe cloud service types", R1,
            """
            A company must keep running a custom line-of-business application it wrote itself. It
            wants to manage as little infrastructure as possible and has no appetite for patching
            operating systems.

            Which service type best fits?
            """,
            [
                "PaaS.",
                "SaaS.",
                "IaaS.",
                "A private cloud."
            ], "A",
            """
            Software as a service genuinely requires the least management effort of the three, and
            that is what makes it the trap here. SaaS delivers a finished application chosen by
            the provider, so it has nowhere to put a custom application the company wrote itself.

            Platform as a service is the fit: the company deploys its own code and Microsoft owns
            the servers, the operating system and the runtime, so nobody patches an OS. IaaS would
            work but reintroduces exactly the patching the company wants to avoid, and a private
            cloud adds infrastructure rather than removing it.
            """,
            """
            The lowest-effort option overall is not automatically the right one. Check each
            candidate against the requirement the company cannot drop.
            """);

        yield return Dropdowns("cc-026", D1, "Describe cloud service types", R1,
            """
            Select the answer choice that completes each statement based on the information
            presented.
            """,
            [
                ("The service type in which the customer patches the guest operating system is",
                    ["SaaS", "PaaS", "IaaS", "all three"], 3),
                ("The service type in which the customer deploys its own code but not an operating system is",
                    ["SaaS", "PaaS", "IaaS", "all three"], 2),
                ("The service type in which the customer still owns its identities and its data is",
                    ["SaaS only", "PaaS only", "IaaS only", "all three"], 4)
            ],
            """
            IaaS leaves the guest operating system with the customer and PaaS provides a managed
            platform for the customer own code, which gives the familiar responsibility ladder
            from most customer effort in IaaS to least in SaaS.

            The third row breaks the pattern deliberately. Identity and data never move to the
            provider, whichever service type is in use, so the answer is all three rather than any
            single one. Answering it by reflex is the mistake the row is testing for.
            """,
            """
            The first two rows follow the ladder you would expect. Read the third one on its own
            terms rather than continuing the pattern.
            """);

        yield return Mc("cc-027", D1, "Describe cloud service types", R1,
            """
            A team builds a solution by assembling prebuilt components in a visual designer. Most
            of the behaviour comes from those components, but a developer adds a short custom
            expression to transform one field. No servers are provisioned or managed.

            Which approach does this describe?
            """,
            [
                "Low-code development.",
                "No-code development.",
                "Full-code development on infrastructure as a service.",
                "A lift-and-shift migration."
            ], "A",
            """
            Both low-code and no-code assemble prebuilt components visually and both avoid
            managing servers, so the visual designer does not distinguish them. The single
            deciding detail is the custom expression: no-code means literally no developer-written
            code, so the moment a developer writes any, the approach is low-code.

            Full-code development would mean writing the application itself, and a lift-and-shift
            migration moves existing workloads onto virtual machines unchanged.
            """,
            """
            Two of these options match almost every sentence in the scenario. Exactly one clause
            separates them, and it is a short one.
            """);

        yield return Mc("cc-028", D1, "Describe cloud service types", R1,
            """
            How does serverless computing relate to platform as a service?
            """,
            [
                "Serverless is a category of PaaS: both abstract the infrastructure away, and serverless leans towards event-driven, low-code and no-code scenarios.",
                "Serverless replaces PaaS entirely and is unrelated to it.",
                "Serverless is a category of IaaS in which virtual machines are started on demand and billed per second.",
                "Serverless is a category of SaaS in which the provider supplies the application logic."
            ], "A",
            """
            Both serverless computing and traditional platform as a service hide the
            infrastructure needed to run an application, which is why serverless is best
            understood as sitting inside the PaaS category rather than beside it. The difference
            is emphasis: traditional PaaS hosts full high-code applications, while serverless
            targets event-driven work and low-code or no-code building.

            The name is the trap. There are still servers, you simply do not see or manage them,
            so it is not an on-demand virtual machine offering, and the customer still supplies
            the logic.
            """,
            """
            Ask whether these two are rivals or whether one contains the other, and do not read
            the word "serverless" too literally.
            """);

        // ---------------------------------------------------------- shared responsibility

        yield return Mc("cc-029", D1, "Describe the shared responsibility model", R1,
            """
            Which statement correctly describes the shared responsibility model?
            """,
            [
                "Duties are divided between customer and provider, the boundary moves with the service type, and a few duties never move to the provider at all.",
                "The provider is responsible for everything once a workload runs in the cloud.",
                "The boundary is fixed for all Azure services, so the same duties always belong to the same party.",
                "Responsibility is divided equally between customer and provider for every service."
            ], "A",
            """
            Two ideas have to be held together. First, the boundary moves: IaaS leaves the most
            with the customer and SaaS the least. Second, some responsibilities do not move at
            all, whatever the service type, and the customer own data, accounts and access rights
            are the standard examples.

            Option C states the first idea backwards, and the split is never all-or-nothing or a
            fixed equal division.
            """,
            """
            A correct answer here has to be true of IaaS and SaaS at the same time. Test each
            option against both ends of the range.
            """);

        yield return Mc("cc-030", D1, "Describe the shared responsibility model", R1,
            """
            Your company runs a workload on Azure virtual machines. Azure Backup protects the
            machines and Microsoft Defender for Cloud reports on their configuration.

            Which task remains your company responsibility?
            """,
            [
                "Applying operating system security updates inside the virtual machines.",
                "Replacing failed physical disks in the Azure data centre.",
                "Maintaining the physical network switches and cabling.",
                "Providing power and cooling to the host servers."
            ], "A",
            """
            With infrastructure as a service, Microsoft owns the facility, the hardware and the
            virtualisation layer. Everything from the guest operating system upward stays with the
            customer, and patching it is the clearest example.

            The extra services named in the stem are there to test whether they change the
            boundary, and they do not. Azure Backup and Defender for Cloud help you meet a
            responsibility you still own; enabling a tool does not transfer the duty to Microsoft.
            """,
            """
            Ask whether the two Azure services mentioned in the scenario move the boundary, or
            just make one side of it easier to carry out.
            """);

        yield return YesNo("cc-031", D1, "Describe the shared responsibility model", R1,
            """
            A company deploys an application to Azure App Service and stores its data in Azure SQL
            Database.

            For each of the following statements, select Yes if the statement is true. Otherwise,
            select No.
            """,
            [
                ("Microsoft is responsible for patching the operating system beneath App Service.", true),
                ("The company is responsible for vulnerabilities in the application code it deploys.", true),
                ("Because Azure SQL Database is a managed service, Microsoft is responsible for who can read the data in it.", false),
                ("The company is responsible for maintaining the physical servers that run the platform.", false)
            ],
            """
            App Service and Azure SQL Database are both platform as a service, so Microsoft owns
            the hardware, the virtualisation layer, the operating system and the engine, and the
            customer owns the code it deploys along with any flaw in it.

            The third statement is the one designed to catch a candidate reading quickly. A
            managed service means Microsoft runs the software; it never means Microsoft decides
            who may read the customer data. Access control and the data itself stay with the
            customer under every service type.
            """,
            """
            Three of these are about running software. One is about who may read data, which is a
            different question with a different answer.
            """);

        yield return Mc("cc-032", D1, "Describe the shared responsibility model", R1,
            """
            Which two responsibilities always remain with the customer, whether a workload uses
            IaaS, PaaS or SaaS? Each correct answer presents part of the solution.
            """,
            [
                "The accounts and access rights of its own users.",
                "The data the organisation puts into the service.",
                "Patching the host virtualisation layer.",
                "Maintaining the physical data centre.",
                "Patching the guest operating system."
            ], "A,B",
            """
            Identity and data are the two responsibilities that never transfer. Whatever the
            service type, the customer decides who its users are, what they may do, and what
            information is placed in the service.

            The virtualisation layer and the data centre are always Microsoft. Guest operating
            system patching is the near miss: it is the customer duty under IaaS, but PaaS and
            SaaS take it away, so it does not hold for every service type.
            """,
            """
            One of these is a real customer duty in some service types but not all of them. The
            question asks for the ones that hold everywhere.
            """);

        yield return Drag("cc-033", D1, "Describe the shared responsibility model", R1,
            """
            A company deploys virtual machines in Azure and also uses Azure App Service.

            Match each responsibility to the party that owns it. Each party may be used once, more
            than once, or not at all.
            """,
            "Parties",
            [
                "Microsoft",
                "The customer"
            ],
            [
                ("Physical security of the data centre", 1),
                ("Configuring the firewall inside the guest operating system of a virtual machine", 2),
                ("Patching the operating system beneath App Service", 1),
                ("Patching the operating system inside the virtual machines", 2),
                ("Deciding which users may sign in to the application", 2)
            ],
            """
            The rows are deliberately mixed across two service types, because the same words
            produce different answers depending on which one you are in. Patching an operating
            system belongs to the customer under IaaS and to Microsoft under PaaS, and both appear
            here.

            The facility is always Microsoft. The guest firewall on a virtual machine is the
            customer, since it sits above the virtualisation boundary. And identity never moves,
            so deciding who may sign in is the customer in every case.
            """,
            """
            Two rows use almost the same words about patching an operating system. Notice what
            each one is running on before you answer either.
            """);

        yield return Mc("cc-034", D1, "Describe the shared responsibility model", R1,
            """
            A workload has been running unchanged in Azure for two years. Which statement about
            the customer ongoing obligations is true?
            """,
            [
                "The customer is expected to monitor the health of its own solution and to track announced service changes and retirements.",
                "No further action is required, because Azure services do not change once a workload is deployed.",
                "Microsoft contacts each affected customer individually before changing the behaviour of any service.",
                "Shared responsibility applies only while a workload is being deployed, not while it runs."
            ], "A",
            """
            Shared responsibility is not only about who patches what on day one. Azure services
            evolve, versions of runtimes and APIs reach end of support, and features are
            eventually retired, so the customer is expected to watch its own workload health and
            to follow published lifecycle announcements.

            Change notices are published through service health and the Azure updates channel
            rather than delivered as individual contact, and the model applies for as long as the
            workload runs.
            """,
            """
            Two years of nothing changing on your side does not mean nothing changed underneath.
            Ask what that implies about a duty that never ends.
            """);

        // ---------------------------------------------------------- deployment models

        yield return Mc("cc-035", D1, "Describe cloud computing", R1,
            """
            A company hosts all of its workloads in Azure. The underlying infrastructure is shared
            with other Microsoft customers, and logical boundaries keep each tenant data separate.

            A security reviewer objects that a "public" cloud means the company data is reachable
            by the public. How should you respond?
            """,
            [
                "This is a public cloud, and the word describes shared, provider-owned infrastructure, not who can reach the workloads.",
                "The reviewer is correct, so the company should move to a private cloud to keep its data unreachable from the internet.",
                "This is a hybrid cloud, because logical boundaries separate the company resources from other tenants.",
                "This is a private cloud, because the company workloads are isolated from other tenants."
            ], "A",
            """
            Public cloud describes ownership and sharing: the provider owns the infrastructure and
            many organisations run on it, separated by physical and logical boundaries. It says
            nothing about the network exposure of any particular resource, which is decided by the
            networking and access controls you configure.

            Tenant isolation is a property of the public cloud, not evidence of a private one, and
            a hybrid cloud would require on-premises services interacting with cloud services.
            """,
            """
            The word "public" in this term is answering a question about who owns and shares the
            hardware. Check whether it is answering the reviewer question at all.
            """);

        yield return Mc("cc-036", D1, "Describe cloud computing", R1,
            """
            A government agency requires cloud infrastructure dedicated to its own use so that it
            can apply controls a shared platform cannot offer. Its finance director assumes this
            will also cut costs, because cloud is cheaper.

            Which response is correct?
            """,
            [
                "A private cloud meets the control requirement, but it usually costs more than public cloud because the hardware is dedicated rather than shared.",
                "A private cloud meets the control requirement and costs less, because the agency avoids paying a provider margin.",
                "A public cloud meets the control requirement, and dedicated hardware is never available in any cloud.",
                "A hybrid cloud meets the control requirement, because hybrid means dedicated hardware in a provider data centre."
            ], "A",
            """
            A private cloud serves a single organisation, whether hosted in its own data centre or
            by a third party on dedicated hardware, and that exclusivity is what allows the extra
            controls.

            The cost half is the point of the question. Public cloud pricing rests on sharing one
            pool of infrastructure across many tenants; take the sharing away and the economy of
            scale goes with it, so a private cloud is frequently no cheaper than staying
            on-premises. Hybrid describes interaction between environments, not dedicated hardware.
            """,
            """
            The deployment model is the easy half. The other half asks where public cloud pricing
            comes from, and whether dedicating hardware keeps that source intact.
            """);

        yield return Mc("cc-037", D1, "Describe cloud computing", R1,
            """
            A company keeps a SQL Server cluster in its own data centre. Applications hosted in
            Azure query that cluster over a private connection and receive results. The company
            also runs some unrelated workloads in a second public cloud provider.

            Which term describes the relationship between the Azure applications and the
            on-premises cluster?
            """,
            [
                "Hybrid cloud.",
                "Multi-cloud.",
                "Private cloud.",
                "Community cloud."
            ], "A",
            """
            A hybrid cloud exists when on-premises services and cloud services actually interact
            as part of one solution, which is exactly what an Azure application querying an
            on-premises database does.

            The second provider is in the stem to be filtered out. Using more than one public
            cloud is multi-cloud, and it is a separate fact about this company that says nothing
            about the Azure-to-on-premises relationship the question asks about. A company can be
            both hybrid and multi-cloud at once.
            """,
            """
            The scenario deliberately contains two different arrangements. Re-read exactly which
            relationship the question asks you to name.
            """);

        yield return Mc("cc-038", D1, "Describe cloud computing", R1,
            """
            A company uses Microsoft 365 for email and productivity. It also runs an accounting
            system on servers in its own office. The two environments share no data, no identity
            and no network path.

            Which deployment model describes the company cloud usage?
            """,
            [
                "Public cloud, because the cloud portion is shared, provider-hosted infrastructure and nothing interacts.",
                "Hybrid cloud, because the company operates both on-premises servers and cloud services.",
                "Hybrid cloud, because Microsoft 365 users also work in the office.",
                "Private cloud, because the accounting servers are dedicated to the company."
            ], "A",
            """
            Interaction is what makes a deployment hybrid, and the stem removes every route to it:
            no shared data, no shared identity, no network path. Owning both kinds of environment
            is not sufficient, which is precisely what the two hybrid options assume.

            The cloud part of the estate is shared, provider-hosted infrastructure, so it is
            public cloud. Servers in an office are on-premises rather than a private cloud, which
            implies a pooled, self-service platform rather than a rack of application servers.
            """,
            """
            One word decides whether a mixed estate is hybrid. Look for it in the scenario, and
            notice that the scenario goes out of its way to rule it out.
            """);

        yield return YesNo("cc-039", D1, "Describe cloud computing", R1,
            """
            For each of the following statements about cloud deployment models, select Yes if the
            statement is true. Otherwise, select No.
            """,
            [
                ("A hybrid cloud requires interaction between on-premises services and cloud services.", true),
                ("A private cloud is always less expensive than a public cloud.", false),
                ("Public cloud means the resources you deploy are reachable by anyone on the internet.", false),
                ("An organisation using both Azure and a second public cloud provider is multi-cloud, not hybrid.", true)
            ],
            """
            Interaction is what separates a hybrid cloud from an organisation that merely happens
            to own both kinds of environment, and dedicating hardware removes the sharing that
            makes public cloud cheap, so a private cloud is frequently more expensive.

            "Public" describes shared, provider-owned infrastructure rather than open network
            access. And two public clouds is multi-cloud: hybrid specifically means cloud plus
            on-premises, so the two terms answer different questions and an organisation can be
            both at once.
            """,
            """
            The last two statements both hinge on what a term is actually describing rather than
            what it sounds like it describes.
            """);

        yield return Drag("cc-040", D1, "Describe cloud computing", R1,
            """
            Match each characteristic to the cloud deployment model it best describes. Each model
            may be used once, more than once, or not at all.
            """,
            "Deployment models",
            [
                "Public cloud",
                "Private cloud",
                "Hybrid cloud",
                "Multi-cloud"
            ],
            [
                ("Lowest cost, because one pool of infrastructure is shared across many organisations", 1),
                ("Greatest control, because infrastructure is dedicated to one organisation", 2),
                ("On-premises systems and cloud systems interact as a single solution", 3),
                ("Workloads run with two competing cloud providers to avoid depending on either", 4),
                ("Often no cheaper than staying on-premises, because the hardware is not shared", 2)
            ],
            """
            Sharing one pool of infrastructure across many customers is what makes public cloud
            the lowest-cost model, and dedicating that infrastructure to one organisation is what
            defines a private cloud and gives it the most control.

            The last row is the same fact seen from the other side: remove the sharing and you
            remove the economy of scale, so private cloud appears twice. Interaction between
            on-premises and cloud defines hybrid, while using two providers defines multi-cloud.
            """,
            """
            One model is the right answer for two different rows. Watch for a characteristic that
            is really a consequence of one you have already placed.
            """);

        yield return Mc("cc-041", D1, "Describe cloud computing", R1,
            """
            Which two are valid reasons for an organisation to keep some workloads on-premises
            while adopting Azure for others? Each correct answer presents a complete solution.
            """,
            [
                "A legacy application would need substantial rearchitecting before it could run in Azure.",
                "Two tightly coupled systems exchange data constantly and are sensitive to added latency.",
                "Azure cannot host database workloads.",
                "Public cloud platforms provide no security boundary between customers.",
                "On-premises hosting is always less expensive than Azure."
            ], "A,B",
            """
            Rearchitecting cost and latency between tightly coupled systems are two of the
            standard, defensible reasons a workload stays where it is, alongside an unexpired data
            centre lease or a dependency that cannot run in Azure at all.

            The other three are simply untrue. Azure hosts database workloads extensively, public
            cloud platforms enforce strong tenant isolation, and neither location is universally
            cheaper: the answer depends on utilisation, and lightly used hardware bought for a
            peak is usually the expensive option.
            """,
            """
            Two of these are engineering constraints and three are assertions about Azure. Check
            whether each assertion is actually true before you weigh it.
            """);

        yield return Mc("cc-042", D1, "Describe cloud computing", R1,
            """
            A company needs per-user subscriptions covering email, documents and collaboration for
            its staff, plus a platform on which its developers can build a custom web application.

            Which two Microsoft cloud offerings does it need? Each correct answer presents part of
            the solution.
            """,
            [
                "Microsoft 365 for the per-user productivity subscriptions.",
                "Microsoft Azure for the custom application platform.",
                "Microsoft Dynamics 365 for the per-user productivity subscriptions.",
                "Azure Arc for the custom application platform.",
                "Microsoft Entra ID for the per-user productivity subscriptions."
            ], "A,B",
            """
            Microsoft 365 is the per-user productivity bundle, covering Windows, Office,
            SharePoint, Exchange and OneDrive. Azure is the platform on which an organisation
            builds and runs its own applications.

            The distractors are the neighbouring products. Dynamics 365 covers enterprise resource
            planning and customer relationship management rather than productivity, Azure Arc
            extends Azure management to servers outside Azure rather than hosting new
            applications, and Entra ID is the identity service underneath the others, not a
            productivity suite.
            """,
            """
            The scenario asks for two very different things. Match each half to the product built
            for it, and be careful with the two offerings whose names both contain 365.
            """);

        yield return Mc("cc-043", D1, "Describe cloud computing", R1,
            """
            A retailer wants a cloud application that manages its sales pipeline, customer records
            and finance processes as a finished product, rather than something its developers
            build.

            Which Microsoft cloud offering fits?
            """,
            [
                "Microsoft Dynamics 365.",
                "Microsoft 365.",
                "Microsoft Azure.",
                "Microsoft Entra ID."
            ], "A",
            """
            Dynamics 365 is the family of finished enterprise resource planning and customer
            relationship management applications, which is exactly what a sales pipeline, customer
            records and finance processes describe.

            Microsoft 365 covers end-user productivity, Azure is the platform you build on rather
            than a finished business application, and Entra ID is the cloud identity service. The
            phrase "rather than something its developers build" is what rules Azure out.
            """,
            """
            One clause in the stem eliminates the platform answer outright. Find it before you
            weigh the product names.
            """);

        yield return Mc("cc-044", D1, "Describe the benefits of cloud computing", R1,
            """
            A company wants to run a two-week proof of concept for a new analytics platform.
            Building the equivalent environment on-premises would need a large hardware purchase
            that would then sit idle.

            Which cloud benefit most directly addresses this, and what must the company still do?
            """,
            [
                "Consumption-based pricing, and the company must remember to delete the environment, because charges continue until it does.",
                "Consumption-based pricing, and nothing further, because unused resources stop billing automatically.",
                "Economy of scale, and the company must negotiate a volume discount before it starts.",
                "Elasticity, and the company must set autoscale rules to avoid being charged for the trial."
            ], "A",
            """
            A consumption-based model charges only while resources exist and run, so a two-week
            environment costs two weeks rather than a hardware purchase. That is the benefit the
            scenario is built around.

            The second half is the part people forget. Metered billing does not switch itself off:
            an idle virtual machine that nobody deallocated keeps billing, which is why the
            discipline of deleting a proof of concept matters as much as the pricing model.
            Economy of scale is the provider bulk-buying advantage, and elasticity adjusts capacity
            within a workload rather than ending a trial.
            """,
            """
            The first half of every option is a pricing concept and the second half is an
            obligation. It is the second half that separates the two strongest options.
            """);

        yield return Mc("cc-045", D1, "Describe the benefits of cloud computing", R1,
            """
            Which outcome is a realistic effect of moving infrastructure to the cloud on an
            organisation IT staffing?
            """,
            [
                "Staff move from routine hardware and platform maintenance towards service optimisation and new capability.",
                "IT staff become unnecessary, because the provider assumes every responsibility.",
                "Staffing is unaffected, because cloud adoption changes no operational task.",
                "Staffing must increase, because cloud platforms need more administrators than on-premises ones."
            ], "A",
            """
            The realistic outcome is a change of work rather than an absence of it. Racking
            hardware, replacing disks and patching hypervisors move to the provider, which frees
            existing staff for cost management, security posture, automation and delivery.

            Headcount does fall in some organisations and rise in others, but the shared
            responsibility model always leaves work with the customer, so no cloud migration
            removes the need for IT staff, and the tasks certainly do change.
            """,
            """
            Three of these options make an absolute claim about headcount. Ask whether the shared
            responsibility model leaves room for any of them.
            """);

        // ---------------------------------------------------------- mixed reinforcement

        yield return Mc("cc-046", D1, "Describe cloud service types", R1,
            """
            Your company plans to move an existing line-of-business application to Azure without
            modifying it. The application installs a Windows service and writes to a fixed path on
            the system drive, and your team must keep administrative control of the server.

            Which service type should you choose, and what is this kind of migration called?
            """,
            [
                "IaaS, and the migration is a lift and shift.",
                "PaaS, and the migration is a lift and shift.",
                "IaaS, and the migration is a refactor.",
                "SaaS, and the migration is a replacement."
            ], "A",
            """
            An unmodified application that installs a Windows service, writes to a fixed system
            path and needs administrative control of the server needs a server, which means
            infrastructure as a service.

            Moving a workload to the cloud unchanged is a lift and shift, sometimes called
            rehosting. Refactoring means changing the application to suit a managed platform,
            which the stem rules out, and replacing it with a provider product would be a SaaS
            move that is not on the table either.
            """,
            """
            The stem names three separate constraints. Check that whichever service type you pick
            can satisfy all three, not just the last one.
            """);

        yield return Mc("cc-047", D1, "Describe cloud service types", R1,
            """
            Which scenario is the best fit for platform as a service?
            """,
            [
                "A team must publish a new web API quickly and does not want to own servers, operating systems or runtimes.",
                "A company must replace its email system with a provider-hosted product.",
                "A company must run software that needs a custom, unsupported operating system configuration.",
                "A company wants per-user licences for a finished accounting package."
            ], "A",
            """
            Platform as a service exists for teams that build and publish their own applications
            without provisioning or maintaining the layers beneath them, which is precisely the
            first scenario.

            Replacing email with a hosted product and buying per-user licences for finished
            software are both software as a service. The custom, unsupported operating system
            configuration is the one that looks technical enough to be PaaS and is not: modifying
            the operating system requires owning it, which only infrastructure as a service allows.
            """,
            """
            One distractor sounds like the most technically demanding option here, which makes it
            tempting. Ask which layer it needs to change, and who owns that layer under PaaS.
            """);

        yield return YesNo("cc-048", D1, "Describe cloud service types", R1,
            """
            For each of the following statements, select Yes if the statement is true. Otherwise,
            select No.
            """,
            [
                ("With SaaS, the provider applies application updates.", true),
                ("With IaaS, the customer is responsible for the guest operating system.", true),
                ("With PaaS, the customer is responsible for patching the runtime and the operating system.", false),
                ("With PaaS, the customer is responsible for vulnerabilities in the code it deploys.", true)
            ],
            """
            Under SaaS the provider maintains and updates the application, and under IaaS the
            guest operating system belongs to the customer. Under PaaS the provider owns the
            operating system and the runtime, so the third statement is false.

            The fourth statement is the one that stops PaaS being read as "the provider handles
            security". Microsoft secures the platform; the customer still owns every line of code
            it deploys onto that platform, along with its configuration and its data.
            """,
            """
            The last two statements are both about PaaS and they have different answers. Work out
            where the boundary sits between the platform and what runs on it.
            """);

        yield return Mc("cc-049", D1, "Describe the benefits of cloud computing", R1,
            """
            A workload has unpredictable demand. On-premises it would need hardware sized for the
            highest peak anyone can foresee, which would then sit mostly idle.

            Which pair of cloud characteristics most directly removes that over-provisioning risk?
            """,
            [
                "Scalability and elasticity.",
                "Fault tolerance and high availability.",
                "Data residency and data sovereignty.",
                "Governance and compliance."
            ], "A",
            """
            Over-provisioning is a sizing problem: capacity has to be bought up front for a peak
            that may never arrive. Scalability means capacity can be added when it is actually
            needed, and elasticity means it is added and removed automatically as demand moves, so
            the two together remove the need to guess.

            The other pairs address different risks entirely. Resiliency concepts keep a workload
            running when something breaks, and residency and governance concepts address where
            data sits and how standards are enforced. Neither changes what you have to buy in
            advance.
            """,
            """
            Name the risk in the stem precisely before matching it. It is about buying the wrong
            amount, not about anything failing.
            """);

        yield return Mc("cc-050", D1, "Describe the benefits of high availability and scalability", R1,
            """
            A team is choosing between an Azure service in general availability and the preview
            release of a newer service. Availability matters to the business.

            Which statement about service level agreements should inform the decision?
            """,
            [
                "Preview services generally carry no SLA at all, so the newer service offers no availability commitment however well it performs.",
                "Preview services carry the same SLA as generally available services once they reach public preview.",
                "The SLA of a preview service guarantees a maximum response time instead of an availability percentage.",
                "Neither service has an SLA, because Azure SLAs apply only to whole subscriptions."
            ], "A",
            """
            An SLA is a financially backed commitment about availability over a defined period,
            paid out as service credits when it is missed. The key fact for this decision is that
            free tiers and preview services are generally excluded: a preview may be perfectly
            reliable in practice and still carry no commitment at all.

            SLAs cover availability rather than response time, and they are published per service
            rather than per subscription.
            """,
            """
            The decision does not turn on how well the preview service is likely to run. It turns
            on whether anything is being promised about it.
            """);

        yield return Mc("cc-051", D1, "Describe cloud computing", R1,
            """
            A company already virtualises every server in its own data centre and provisions new
            virtual machines from a self-service portal it built.

            Which characteristic still distinguishes a public cloud platform from what this
            company has?
            """,
            [
                "Resources are drawn on demand from a provider globally distributed capacity and billed by metered consumption.",
                "Virtualisation, which company-owned data centres cannot use.",
                "The absence of any customer administration.",
                "The ability to host regulated workloads."
            ], "A",
            """
            The scenario deliberately gives the company two things people often name as cloud
            characteristics, virtualisation and self-service, so neither can be the answer. What
            remains is the provider globally distributed capacity that the company still had to
            buy in advance, and metered billing instead of owned assets.

            Customer administration never disappears under shared responsibility, and regulated
            workloads run in both models with the appropriate controls.
            """,
            """
            The scenario hands the company several things that sound cloud-like. Find the one
            capability it still cannot have without a provider.
            """);

        yield return Mc("cc-052", D1, "Describe the benefits of cloud computing", R1,
            """
            Which two statements describe genuine advantages of the consumption-based model? Each
            correct answer presents a complete solution.
            """,
            [
                "Compute charges stop for a virtual machine once it is deallocated.",
                "Costs can be attributed to the department that consumed the resource, because usage is metered per resource.",
                "Costs are fixed for the duration of the subscription regardless of usage.",
                "Costs are paid entirely up front at the start of each year.",
                "Costs are the same in every region, which simplifies planning."
            ], "A,B",
            """
            Metered billing means compute charges end when a virtual machine is deallocated, and
            the same metering makes per-department attribution straightforward. Note the wording:
            deallocated, not merely shut down from inside the guest, which leaves the allocation
            and the charge in place.

            Consumption billing is variable by definition rather than fixed or prepaid, and prices
            differ between regions, so a cheaper region is a real lever rather than a
            simplification you can ignore.
            """,
            """
            One correct option depends on a precise word about stopping a virtual machine. One
            distractor claims something convenient about regions that is not true.
            """);

        yield return Dropdowns("cc-053", D1, "Describe the benefits of cloud computing", R1,
            """
            Select the answer choice that completes each statement based on the information
            presented.
            """,
            [
                ("Purchasing servers for a company data centre is an example of",
                    ["operational expenditure", "capital expenditure", "consumption-based billing", "chargeback"], 2),
                ("Paying a monthly bill for the Azure resources consumed is an example of",
                    ["operational expenditure", "capital expenditure", "amortisation", "a true-up"], 1),
                ("A provider buying hardware in bulk and lowering its per-unit cost is called",
                    ["elasticity", "agility", "economy of scale", "high availability"], 3),
                ("Paying up front for a three-year Azure reservation is an example of",
                    ["capital expenditure, because it is a single large purchase", "operational expenditure, because it pre-pays for a service rather than buying an asset", "amortisation of a fixed asset", "a capital lease"], 2)
            ],
            """
            Buying servers acquires a fixed asset, which is capital expenditure, while a metered
            monthly bill is operational expenditure. The bulk purchasing advantage that lets a
            provider lower per-unit cost is economy of scale.

            The fourth row is the one that tests whether you have understood the first two or
            merely memorised them. A reservation is paid in one large sum, which makes it look
            like capital expenditure, but it buys a discounted rate on a service rather than an
            owned asset, so it stays on the operational side.
            """,
            """
            Three of these rows follow the obvious pattern. The fourth deliberately makes an
            operating cost look like a purchase.
            """);

        yield return Mc("cc-054", D1, "Describe cloud computing", R1,
            """
            An organisation replicates an on-premises application to Azure so that service can be
            restored there if the primary site is lost. The Azure copy is idle in normal
            operation and the two environments share identity and network connectivity.

            How is this arrangement best described?
            """,
            [
                "A hybrid cloud deployment using Azure as a disaster recovery target.",
                "A public cloud deployment, because the replica runs on shared infrastructure.",
                "A private cloud deployment, because the replica is dedicated to one organisation.",
                "A multi-cloud deployment, because the workload exists in two places."
            ], "A",
            """
            The two environments are connected and interact, which makes this hybrid, and the
            purpose of the cloud half is to provide somewhere to restore service after a major
            failure. Using cloud capacity this way avoids paying for a second physical site while
            the replica sits idle.

            Azure being a public cloud is true but incomplete as a description of the arrangement.
            Dedicating a replica to one organisation does not make a private cloud, and
            multi-cloud means two cloud providers rather than two locations.
            """,
            """
            Two of these options state something true about Azure without describing the
            arrangement. Pick the one that accounts for both environments and their connection.
            """);

        yield return Mc("cc-055", D1, "Describe the benefits of high availability and scalability", R1,
            """
            A deployment of 400 virtual machine cores into a region fails with an error stating
            that the requested cores exceed an approved limit, even though the region has ample
            free hardware.

            What is the most likely cause, and what should the team do?
            """,
            [
                "A subscription quota, which the team should raise through a support request before the deployment date.",
                "A regional capacity shortage, which the team can only resolve by choosing a different region.",
                "The subscription spending limit, which the team should remove in the billing portal.",
                "An SLA restriction, which caps the number of cores covered by an availability commitment."
            ], "A",
            """
            Regional capacity and subscription quota are two different ceilings and the error
            distinguishes them. Ample free hardware plus an approved limit points at a quota: a
            per-subscription, per-region, per-family cap that exists to prevent runaway spend and
            that is raised through a support request.

            Because a quota increase is a request rather than a switch, it belongs in the plan
            well before the deployment date. A spending limit stops resources being created at all
            rather than capping cores, and SLAs say nothing about quantity.
            """,
            """
            One phrase in the error rules out the answer most people reach for first. Ask what is
            left once you accept that the hardware really is available.
            """);

        yield return YesNo("cc-056", D1, "Describe the shared responsibility model", R1,
            """
            For each of the following statements about the shared responsibility model, select Yes
            if the statement is true. Otherwise, select No.
            """,
            [
                ("The customer always retains responsibility for its own data.", true),
                ("Microsoft is always responsible for the physical security of the data centre.", true),
                ("The division of responsibility is identical for IaaS, PaaS and SaaS.", false),
                ("Enabling an Azure security service transfers the underlying responsibility to Microsoft.", false)
            ],
            """
            Data and identity stay with the customer under every service type, and physical data
            centre security is always Microsoft. The boundary between those two poles moves with
            the service type, so the third statement is false.

            The fourth is the practical trap. Tools such as Microsoft Defender for Cloud or Azure
            Backup help you discharge a responsibility you still hold; turning one on does not
            move the duty across the line.
            """,
            """
            The last statement is about what happens when you switch a protective service on. Ask
            whether a tool can change who is accountable, or only how hard the job is.
            """);

        yield return Mc("cc-057", D1, "Describe cloud service types", R1,
            """
            A team debates whether Azure SQL Database is SaaS or PaaS.

            Which statement best explains why both labels get used?
            """,
            [
                "It is fully managed, so it is consumed like a finished service, and it is also a building block that developers use inside their own applications, which is the PaaS view.",
                "It is IaaS, because it runs on virtual machines that the customer must patch.",
                "It is SaaS, because the customer must install and license SQL Server before using it.",
                "The label depends on the pricing tier, with lower tiers classified as SaaS."
            ], "A",
            """
            The service types describe how much of the stack you manage, and they are not always
            crisp at the edges. Azure SQL Database needs no server, no SQL Server installation and
            no operating system maintenance, which makes it feel like a finished service; it is
            also consumed as the data tier of an application a developer writes, which is the
            classic platform as a service role. Both descriptions are pointing at the same fact.

            The customer never patches the engine or the operating system beneath it, no
            installation or licence purchase is involved, and the pricing tier does not change any
            of this.
            """,
            """
            Rather than deciding which single label is correct, ask what the two labels are each
            noticing about the same service.
            """);

        yield return Mc("cc-058", D1, "Describe cloud computing", R1,
            """
            Which characteristic is shared by the public, private and hybrid cloud models?
            """,
            [
                "Self-service, on-demand provisioning of scalable resources.",
                "Physical infrastructure shared among multiple organisations.",
                "The removal of all customer administration.",
                "A dependency on an on-premises data centre."
            ], "A",
            """
            Self-service provisioning of scalable resources is what makes something a cloud at
            all. A private cloud aims to reproduce that experience for one organisation, and a
            hybrid deployment inherits it from the cloud side.

            Shared physical infrastructure is specific to public cloud and is precisely what a
            private cloud removes. Customer administration never disappears, and only hybrid
            necessarily involves on-premises systems.
            """,
            """
            Look for the characteristic that survives when you take the sharing away, since that
            is exactly what a private cloud does.
            """);

        yield return Mc("cc-059", D1, "Describe the benefits of cloud computing", R1,
            """
            A software company shortens its release cycle from months to days. Two things made it
            possible: test environments can be created on demand, and the production tier absorbs
            launch-day traffic without anyone provisioning hardware.

            Which two benefits does this describe? Each correct answer presents part of the
            solution.
            """,
            [
                "Agility, for the on-demand test environments.",
                "Elasticity, for the production tier absorbing launch-day traffic.",
                "Fault tolerance, for the on-demand test environments.",
                "Economy of scale, for the production tier absorbing launch-day traffic.",
                "High availability, for the shortened release cycle."
            ], "A,B",
            """
            The scenario deliberately contains two different benefits so they can be told apart.
            Creating and destroying whole environments quickly is agility, which is about speed of
            provisioning and therefore speed of the business.

            Capacity growing to meet launch traffic with nobody provisioning anything is
            elasticity, which is about a running workload tracking demand. Fault tolerance and
            high availability concern failure and uptime, and economy of scale is a provider
            pricing advantage, so none of the three describes either half.
            """,
            """
            Each half of the scenario has its own benefit, and the two are easy to blur. One is
            about creating environments, the other about a workload that is already running.
            """);

        yield return Build("cc-060", D1, "Describe cloud service types", R1,
            """
            You must order four hosting approaches by how much of the technology stack the
            customer is responsible for managing.

            Arrange them in order, beginning with the approach in which the customer manages the
            most.
            """,
            "Hosting approaches",
            [
                "On-premises",
                "IaaS",
                "PaaS",
                "SaaS"
            ],
            [1, 2, 3, 4],
            """
            On-premises sits at the top because the organisation owns everything, down to the
            building, the power and the physical servers.

            Infrastructure as a service removes the hardware and the virtualisation layer but
            leaves the guest operating system, runtime and application. Platform as a service
            removes the operating system and runtime, leaving the application and its data.
            Software as a service removes the application too, leaving users, access and data.
            """,
            """
            One of these four is not a cloud service type at all, and it belongs at one end of
            the ladder rather than being excluded from it.
            """);

        yield return HotNested("cc-061", D1, "Describe cloud service types", R1,
            """
            The work area shows how much of the stack Microsoft manages under each cloud service
            type. Each box includes everything drawn inside it, so an outer box means Microsoft
            manages more and the customer manages less.

            A vulnerability is announced in a widely used application. Select the service type in
            which Microsoft, rather than the customer, is responsible for updating the
            application to fix it.
            """,
            "What the provider manages",
            [
                "SaaS",
                "PaaS",
                "IaaS"
            ], 1,
            """
            The nesting is the responsibility ladder. IaaS sits innermost because Microsoft
            manages the least there, only the hardware and the virtualisation layer. PaaS
            contains it and adds the operating system and the runtime. SaaS contains both and
            adds the application itself.

            The application layer therefore falls inside the SaaS box only, so SaaS is the one
            service type where the fix arrives as part of the service. PaaS is the tempting near
            miss: Microsoft would patch the runtime and the operating system underneath your
            code, but never the code itself.
            """,
            """
            Work outwards. Decide which box is the first to include the application layer, and
            remember that each box also covers everything nested inside it.
            """);

        yield return Mc("cc-062", D1, "Describe cloud computing", R1,
            """
            Which statement about a private cloud is correct?
            """,
            [
                "It serves a single organisation and may be hosted either in that organisation own data centre or by a third party on dedicated hardware.",
                "It must be hosted in the organisation own data centre, otherwise it is not private.",
                "It is cheaper than an equivalent public cloud deployment, because there is no provider margin.",
                "It cannot provide scalability or elasticity, because capacity is fixed at build time."
            ], "A",
            """
            A private cloud is defined by exclusivity of use rather than by location: one
            organisation, dedicated infrastructure, wherever that infrastructure physically sits.
            A hosting provider running dedicated hardware on your behalf still counts.

            The remaining options are the three common misconceptions. Location does not define
            it; dedicating hardware removes the sharing that makes public cloud cheap, so it is
            often no cheaper than on-premises; and a private cloud can absolutely offer
            self-service scaling within the capacity that has been built.
            """,
            """
            Three of these options each fix one attribute in place: location, price, or capacity.
            Ask which attribute actually appears in the definition.
            """);
    }
}
