using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Domain 1 of the AZ-900 skills outline: "Describe cloud concepts" (25-30%).
// Facts sourced from chapter 1 of the study guide; wording is original.
public static partial class QuestionBank
{
    private const ExamDomain D1 = ExamDomain.CloudConcepts;
    private const string R1 = "Study guide, ch. 1: Cloud Concepts";

    private static IEnumerable<Item> CloudConcepts()
    {
        // ---------------------------------------------------------- financial models

        yield return Mc("cc-001", D1, "Describe the benefits of cloud computing", R1,
            """
            A manufacturing company currently refreshes its on-premises server hardware every
            four years. Each refresh requires a large purchase that is approved a year in
            advance and then written down over the life of the equipment.

            The company plans to move the workloads to Azure and pay only for what it uses
            each month.

            How does this change the company's spending model?
            """,
            [
                "From capital expenditure to operational expenditure.",
                "From operational expenditure to capital expenditure.",
                "From capital expenditure to a fixed annual licence fee.",
                "From operational expenditure to a depreciating asset model."
            ], "A",
            """
            Buying hardware outright is a capital expenditure (CapEx): a large up-front purchase
            of a fixed asset that is budgeted well in advance and amortised over several years.
            Paying a monthly, consumption-based bill for cloud services is an operational
            expenditure (OpEx), which spreads cost through the year and removes the up-front
            purchase.

            Moving to the cloud therefore shifts spending from CapEx to OpEx. The remaining
            options reverse that relationship or describe purchasing models that do not apply.
            """);

        yield return Mc("cc-002", D1, "Describe the benefits of cloud computing", R1,
            """
            Which two costs are examples of capital expenditure? Each correct answer presents a
            complete solution.
            """,
            [
                "Purchasing physical servers for a company-owned data centre.",
                "The monthly bill for consumed Azure virtual machine compute time.",
                "Buying perpetual licences for software installed on owned hardware.",
                "A per-user monthly subscription to Microsoft 365.",
                "Metered charges for outbound data transfer from an Azure region."
            ], "A,C",
            """
            Capital expenditure covers the acquisition of fixed assets. Buying servers and
            buying perpetual software licences are both one-time purchases of assets that are
            then depreciated, so both are CapEx.

            Metered compute time, per-user subscriptions and metered data transfer are all
            recurring operating costs billed as they are consumed, which makes them operational
            expenditure.
            """);

        yield return Mc("cc-003", D1, "Describe the benefits of cloud computing", R1,
            """
            A cloud provider buys servers and storage in very large volumes and receives a much
            lower per-unit price than any individual customer could obtain. The provider passes
            part of that saving on to its customers.

            Which principle does this describe?
            """,
            [
                "Economy of scale.",
                "Consumption-based pricing.",
                "Elasticity.",
                "Chargeback."
            ], "A",
            """
            Economy of scale is the cost advantage a provider gains from purchasing
            infrastructure in bulk and spreading it across many customers, which lowers the
            per-customer cost.

            Consumption-based pricing describes paying only for what you use, elasticity is the
            automatic adjustment of capacity, and chargeback is the internal accounting practice
            of billing a cost centre for the services it consumes.
            """);

        yield return Mc("cc-004", D1, "Describe the benefits of cloud computing", R1,
            """
            The finance team at your company wants each department's budget to be charged for
            the Azure resources that department actually consumes.

            Which practice does this describe?
            """,
            [
                "Chargeback.",
                "Amortisation.",
                "Economy of scale.",
                "True-up."
            ], "A",
            """
            Chargeback is the practice of charging a cost centre or departmental budget for the
            services that business unit used. It is much easier under a consumption-based OpEx
            model, because usage is already metered per resource.

            Amortisation spreads the cost of a purchased asset over its life, economy of scale
            is a provider-side bulk purchasing advantage, and a true-up is a licence count
            reconciliation under an Enterprise Agreement.
            """);

        yield return YesNo("cc-005", D1, "Describe the benefits of cloud computing", R1,
            """
            For each of the following statements about cloud financial models, select Yes if the
            statement is true. Otherwise, select No.
            """,
            [
                ("A consumption-based model means you are billed only for the resources you actually use.", true),
                ("Moving to a consumption-based model removes the need to plan or monitor spending.", false),
                ("Operational expenditure allows costs to be spread across the year rather than paid up front.", true)
            ],
            """
            A consumption-based model meters usage and bills for what is consumed, so the first
            statement is true, and operational expenditure does spread cost across the year
            instead of requiring a single large purchase.

            However, consumption billing makes planning and monitoring more important, not less.
            Unmonitored resources continue to accrue charges, which is why budgets, alerts and
            cost analysis exist.
            """);

        // ---------------------------------------------------------- scalability

        yield return Mc("cc-006", D1, "Describe the benefits of high availability and scalability", R1,
            """
            An Azure virtual machine that hosts a reporting application runs out of memory during
            month-end processing.

            You resolve the problem by resizing the virtual machine to a size with more memory
            and more CPU cores.

            Which type of scaling did you perform?
            """,
            [
                "Vertical scaling.",
                "Horizontal scaling.",
                "Scaling out.",
                "Scaling in."
            ], "A",
            """
            Adjusting the capacity of an existing resource, such as adding memory or CPU cores to
            a virtual machine, is vertical scaling, also called scaling up. The reverse is
            scaling down.

            Horizontal scaling, or scaling out, means adding more instances rather than making an
            existing one larger. Scaling in is the removal of instances.
            """);

        yield return Mc("cc-007", D1, "Describe the benefits of high availability and scalability", R1,
            """
            A web application runs on three identical virtual machines behind a load balancer.
            To handle a seasonal traffic increase you add four more identical virtual machines.

            Which type of scaling did you perform?
            """,
            [
                "Horizontal scaling.",
                "Vertical scaling.",
                "Scaling up.",
                "Scaling down."
            ], "A",
            """
            Adding additional systems or instances is horizontal scaling, commonly called scaling
            out. Removing them again once demand falls is called scaling in.

            Vertical scaling, or scaling up, would mean increasing the capacity of the existing
            virtual machines rather than adding more of them.
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
                    ["scaling up", "scaling down", "scaling in", "disaster recovery"], 3)
            ],
            """
            Vertical scaling changes the capacity of an existing resource: scaling up adds
            capacity and scaling down removes it.

            Horizontal scaling changes the number of resources: scaling out adds instances and
            scaling in removes them. Keeping the two axes straight is the point of the question.
            """);

        yield return Mc("cc-009", D1, "Describe the benefits of high availability and scalability", R1,
            """
            You configure a rule so that Azure automatically adds instances when average CPU
            usage exceeds a threshold, and removes them again when usage falls, with no
            administrator involvement.

            Which cloud characteristic does this demonstrate?
            """,
            [
                "Elasticity.",
                "Fault tolerance.",
                "Disaster recovery.",
                "Economy of scale."
            ], "A",
            """
            Elasticity is the automatic scaling of resources in response to measured demand, such
            as CPU, memory or storage usage, without human interaction. In Azure this is
            configured with autoscale rules and thresholds.

            Fault tolerance keeps a system running when a component fails, disaster recovery
            restores service after a major failure, and economy of scale is a pricing advantage.
            """);

        yield return Mc("cc-010", D1, "Describe the benefits of high availability and scalability", R1,
            """
            What is the difference between scalability and elasticity?
            """,
            [
                "Scalability is the ability to add resources to meet demand, and elasticity is the automatic adjustment of those resources without human interaction.",
                "Scalability applies only to storage, and elasticity applies only to compute.",
                "Scalability is always automatic, and elasticity is always manual.",
                "Scalability protects against component failure, and elasticity protects against regional failure."
            ], "A",
            """
            Scalability is the general ability to add computing resources to meet increased
            demand, and it can be performed either manually or automatically. Elasticity is
            specifically the automatic adjustment of resources based on measured demand, with no
            administrator involvement.

            Neither concept is restricted to a single resource type, and neither is a resiliency
            feature.
            """);

        yield return Mc("cc-011", D1, "Describe the benefits of high availability and scalability", R1,
            """
            Your organisation can stand up a complete test environment in Azure within an hour,
            evaluate a new product idea, and remove the environment the same week.

            Which cloud benefit does this describe?
            """,
            [
                "Agility.",
                "Fault tolerance.",
                "Governance.",
                "Data sovereignty."
            ], "A",
            """
            Cloud agility is the ability to deploy and adjust resources rapidly, and so to adapt
            quickly to changing business requirements. Being able to create and destroy a full
            environment in days rather than months is the classic example.

            Fault tolerance is about surviving component failure, governance is about enforcing
            organisational standards, and data sovereignty concerns the laws that apply to stored
            data.
            """);

        yield return YesNo("cc-012", D1, "Describe the benefits of high availability and scalability", R1,
            """
            For each of the following statements about scaling, select Yes if the statement is
            true. Otherwise, select No.
            """,
            [
                ("Scaling out adds more instances of a resource.", true),
                ("Scaling up increases the capacity of an existing resource.", true),
                ("Elasticity requires an administrator to approve each scaling action.", false)
            ],
            """
            Scaling out adds instances and scaling up increases the capacity of an existing
            resource, so the first two statements are true.

            Elasticity is defined by the absence of human interaction: Azure evaluates the
            configured rules and scales automatically, so the third statement is false.
            """);

        // ---------------------------------------------------------- availability concepts

        yield return Mc("cc-013", D1, "Describe the benefits of high availability and scalability", R1,
            """
            A service is covered by a service level agreement that guarantees 99.9 percent
            availability.

            Approximately how much unavailability does this permit over a 30-day period?
            """,
            [
                "43.2 minutes.",
                "4.32 minutes.",
                "8.76 hours.",
                "52.56 minutes."
            ], "A",
            """
            A 99.9 percent guarantee allows roughly 43.2 minutes of unavailability across a
            30-day period. The same percentage works out to about 8.76 hours across a full year.

            52.56 minutes per year corresponds to a 99.99 percent guarantee, which is a
            substantially stronger commitment.
            """);

        yield return Mc("cc-014", D1, "Describe the benefits of high availability and scalability", R1,
            """
            During a busy period an Azure-hosted application responds much more slowly than
            usual, but every request is eventually served successfully.

            How is this period treated for the purposes of the service level agreement?
            """,
            [
                "The service is considered available, because an SLA measures availability rather than performance.",
                "The service is considered unavailable, because response times exceeded the normal range.",
                "The service is considered unavailable, because the SLA guarantees a maximum response time.",
                "The service is considered available only if response times return to normal within one hour."
            ], "A",
            """
            An availability guarantee measures whether the service can be reached and used, not
            how quickly it responds. Degraded performance while the service is still serving
            requests does not count as downtime.

            To fail an availability commitment the service generally has to be completely
            unavailable, which is why performance targets are handled separately from
            availability targets.
            """);

        yield return Mc("cc-015", D1, "Describe the benefits of high availability and scalability", R1,
            """
            An application runs on two load-balanced web servers. One server fails. The
            remaining server continues to serve users, although with reduced capacity.

            Which characteristic does this describe?
            """,
            [
                "Fault tolerance.",
                "Disaster recovery.",
                "Elasticity.",
                "Vertical scaling."
            ], "A",
            """
            Fault tolerance is the ability of a system to keep functioning when one or more of
            its components fail. Losing one of two load-balanced servers while the service stays
            up is exactly that, and users may notice degradation but not an outage.

            Disaster recovery deals with recovering after multiple systems or an entire site
            fail, not with the loss of a single component.
            """);

        yield return Mc("cc-016", D1, "Describe the benefits of high availability and scalability", R1,
            """
            A fire destroys the data centre that hosts all of a company's production systems.
            The company activates a documented plan to bring those systems back online at an
            alternate site from backups.

            Which concept does this describe?
            """,
            [
                "Disaster recovery.",
                "Fault tolerance.",
                "High availability.",
                "Horizontal scaling."
            ], "A",
            """
            Disaster recovery is the process of recovering when multiple systems or services
            fail together, such as the loss of an entire site. It relies on a plan, backups and
            usually an alternate location.

            Fault tolerance addresses the failure of individual components, and high availability
            describes the ongoing uptime commitment for a service rather than the recovery
            process after a catastrophe.
            """);

        yield return Drag("cc-017", D1, "Describe the benefits of high availability and scalability", R1,
            """
            Match each description to the correct concept. Each concept may be used once, more
            than once, or not at all.
            """,
            "Concepts",
            [
                "High availability",
                "Fault tolerance",
                "Disaster recovery",
                "Elasticity"
            ],
            [
                ("A system continues to operate after a single component fails", 2),
                ("Systems and data are restored at an alternate site after a catastrophic loss", 3),
                ("A service remains usable without significant outages, backed by a percentage guarantee", 1)
            ],
            """
            Fault tolerance is component-level resilience, so it matches the system that keeps
            operating after one component fails.

            Disaster recovery is the process used after a large-scale failure, which matches
            restoring at an alternate site. High availability is the ongoing uptime commitment
            expressed as a percentage and backed by a service level agreement.
            """);

        yield return YesNo("cc-018", D1, "Describe the benefits of high availability and scalability", R1,
            """
            For each of the following statements, select Yes if the statement is true. Otherwise,
            select No.
            """,
            [
                ("High availability is normally expressed as a percentage of uptime and backed by a service level agreement.", true),
                ("Fault tolerance and disaster recovery describe the same capability.", false),
                ("A service that is reachable but slow has breached its availability guarantee.", false)
            ],
            """
            High availability is measured as a percentage of uptime and is normally backed by a
            financially supported service level agreement, so the first statement is true.

            Fault tolerance addresses individual component failures while disaster recovery
            addresses large-scale, multi-system loss, so they are not the same. And because
            availability measures reachability rather than speed, a slow but working service has
            not breached the guarantee.
            """);

        yield return Mc("cc-019", D1, "Describe the benefits of high availability and scalability", R1,
            """
            Which statement best describes capacity in the context of a cloud platform?
            """,
            [
                "Cloud capacity is finite and must be planned for, because unused resources in a region form a shared pool.",
                "Cloud capacity is unlimited, so no planning is required before a large deployment.",
                "Cloud capacity is reserved permanently for each customer when a subscription is created.",
                "Cloud capacity refers only to the storage available in a customer's subscription."
            ], "A",
            """
            A cloud provider's regions contain a finite pool of servers, power, cooling and
            networking. When one customer scales in, the released resources return to the pool
            for others to use, and a very large deployment can consume a meaningful share of a
            region.

            Because capacity is not endless, large deployments should be planned well ahead, and
            deployment plans should allow for alternate regions if a preferred region is
            constrained.
            """);

        // ---------------------------------------------------------- service models

        yield return Mc("cc-020", D1, "Describe cloud service types", R1,
            """
            Your company subscribes to Microsoft 365. Users open Word and Excel through a
            browser, and Microsoft applies application updates automatically.

            Which cloud service type does this represent?
            """,
            [
                "Software as a service (SaaS).",
                "Platform as a service (PaaS).",
                "Infrastructure as a service (IaaS).",
                "A private cloud."
            ], "A",
            """
            Software as a service is a subscription model in which the provider hosts, manages
            and updates a finished application, and the customer simply consumes it. Microsoft
            365 is the standard example.

            The customer's remaining responsibility is essentially managing user access and data,
            which makes SaaS the model with the least customer responsibility.
            """);

        yield return Mc("cc-021", D1, "Describe cloud service types", R1,
            """
            You deploy seven Azure virtual machines to host a SharePoint farm. Your team
            installs and patches the guest operating systems and the SharePoint software.
            Microsoft maintains the physical hosts, storage and networking hardware.

            Which cloud service type are you using?
            """,
            [
                "Infrastructure as a service (IaaS).",
                "Platform as a service (PaaS).",
                "Software as a service (SaaS).",
                "Serverless computing."
            ], "A",
            """
            Infrastructure as a service provides virtualised infrastructure components such as
            virtual machines. Microsoft manages the physical hardware and the virtualisation
            layer, while the customer manages the guest operating system and everything
            installed on it.

            Because the customer retains the operating system and application layers, IaaS
            carries the highest customer responsibility of the three service types.
            """);

        yield return Mc("cc-022", D1, "Describe cloud service types", R1,
            """
            A development team deploys a web application to Azure App Service. The team writes
            and deploys application code only. Microsoft provides and maintains the underlying
            virtual machines, the operating system and the application runtime.

            Which cloud service type does this represent?
            """,
            [
                "Platform as a service (PaaS).",
                "Infrastructure as a service (IaaS).",
                "Software as a service (SaaS).",
                "A hybrid cloud."
            ], "A",
            """
            Platform as a service supplies a managed application platform so developers can build
            and deploy without provisioning or maintaining servers, operating systems or
            runtimes. Azure App Service is the classic example.

            With IaaS the team would still own the operating system, and with SaaS there would be
            no custom application code to deploy at all.
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
                ("A team deploys code to a managed application platform and never patches an OS", 2),
                ("A team creates virtual machines and installs and patches the guest operating systems", 1)
            ],
            """
            Licensing a finished, provider-managed application per user is software as a service.

            Deploying code to a managed platform without touching an operating system is platform
            as a service, and creating virtual machines whose guest operating systems you patch
            yourself is infrastructure as a service.
            """);

        yield return Mc("cc-024", D1, "Describe cloud service types", R1,
            """
            Which cloud service type gives the customer the greatest control over the operating
            system and installed software?
            """,
            [
                "IaaS.",
                "PaaS.",
                "SaaS.",
                "All three provide identical control."
            ], "A",
            """
            Infrastructure as a service hands the customer a virtual machine and leaves the guest
            operating system, the installed software and their configuration under customer
            control. That control comes with the corresponding management burden.

            PaaS abstracts the operating system away, and SaaS abstracts the entire application
            stack, so both offer progressively less control.
            """);

        yield return Mc("cc-025", D1, "Describe cloud service types", R1,
            """
            Which cloud service type requires the least management effort from the customer?
            """,
            [
                "SaaS.",
                "PaaS.",
                "IaaS.",
                "Private cloud."
            ], "A",
            """
            Software as a service leaves the provider responsible for the application, the
            platform and all of the underlying infrastructure, including updates. The customer's
            duties reduce to managing user access, licensing and their own data.

            PaaS still requires the customer to build and maintain an application, and IaaS adds
            operating system management on top of that.
            """);

        yield return Dropdowns("cc-026", D1, "Describe cloud service types", R1,
            """
            Select the answer choice that completes each statement based on the information
            presented.
            """,
            [
                ("The service type in which the customer manages the guest operating system is",
                    ["SaaS", "PaaS", "IaaS", "none of them"], 3),
                ("The service type designed for developers to deploy applications without managing servers is",
                    ["SaaS", "PaaS", "IaaS", "none of them"], 2),
                ("The service type in which the provider manages application updates for the customer is",
                    ["SaaS", "PaaS", "IaaS", "none of them"], 1)
            ],
            """
            IaaS leaves the guest operating system with the customer, PaaS provides a managed
            platform aimed at application developers, and SaaS delivers a finished application
            that the provider updates.

            Reading the three rows together gives the standard responsibility ladder, from most
            customer responsibility in IaaS to least in SaaS.
            """);

        yield return Mc("cc-027", D1, "Describe cloud service types", R1,
            """
            A development team builds a solution by assembling prebuilt components in a visual
            designer, writing only a small amount of custom code. No servers are provisioned or
            managed.

            Which approach does this describe?
            """,
            [
                "Low-code serverless development.",
                "No-code serverless development.",
                "Infrastructure as a service.",
                "A lift-and-shift migration."
            ], "A",
            """
            Serverless development lets teams build without deploying or managing infrastructure.
            A no-code approach relies purely on prebuilt components assembled visually, whereas a
            low-code approach supplements those components with some developer-written code.

            Because the team writes a small amount of custom code here, this is low-code. A
            lift-and-shift migration moves existing workloads to virtual machines unchanged.
            """);

        yield return Mc("cc-028", D1, "Describe cloud service types", R1,
            """
            How does serverless computing relate to platform as a service?
            """,
            [
                "Serverless computing is a form of PaaS aimed at low-code and no-code scenarios, whereas traditional PaaS targets full-code development.",
                "Serverless computing replaces PaaS entirely and is unrelated to it.",
                "Serverless computing is a form of IaaS in which virtual machines start on demand.",
                "Serverless computing is a form of SaaS in which the provider writes the application code."
            ], "A",
            """
            Both serverless computing and traditional PaaS abstract away the infrastructure
            needed to run an application, so serverless is best understood as a category of PaaS.
            The difference is one of complexity: traditional PaaS supports full, high-code
            development, while serverless is oriented toward low-code and no-code scenarios.

            Serverless is not a virtual machine offering and does not mean the provider supplies
            the business logic.
            """);

        // ---------------------------------------------------------- shared responsibility

        yield return Mc("cc-029", D1, "Describe the shared responsibility model", R1,
            """
            Which statement correctly describes the shared responsibility model?
            """,
            [
                "Responsibility for managing a workload is divided between the customer and the cloud provider, and the split depends on the service type used.",
                "The cloud provider is responsible for everything once a workload runs in the cloud.",
                "The customer is responsible for everything except the physical building.",
                "Responsibility is divided equally between the customer and the provider for every service."
            ], "A",
            """
            Under the shared responsibility model, some duties belong to Microsoft and others
            remain with the customer, and where the line falls depends on which service type is
            in use. IaaS leaves the most with the customer and SaaS the least.

            The split is never all-or-nothing and it is not a fixed equal division.
            """);

        yield return Mc("cc-030", D1, "Describe the shared responsibility model", R1,
            """
            Your company runs workloads on Azure virtual machines.

            Which task remains the responsibility of your company?
            """,
            [
                "Applying operating system security updates to the virtual machines.",
                "Replacing failed physical disks in the Azure data centre.",
                "Maintaining the physical network switches and cabling.",
                "Providing power and cooling to the host servers."
            ], "A",
            """
            With infrastructure as a service, Microsoft is responsible for the physical facility,
            the hardware and the virtualisation layer. Everything from the guest operating system
            upward, including patching it, remains the customer's responsibility.

            Physical disks, network hardware, power and cooling are all part of the data centre
            that Microsoft operates.
            """);

        yield return YesNo("cc-031", D1, "Describe the shared responsibility model", R1,
            """
            A company deploys an application to Azure App Service.

            For each of the following statements, select Yes if the statement is true. Otherwise,
            select No.
            """,
            [
                ("Microsoft is responsible for patching the underlying operating system.", true),
                ("The company is responsible for the application code it deploys.", true),
                ("The company is responsible for maintaining the physical servers that run the platform.", false)
            ],
            """
            Azure App Service is a platform as a service offering, so Microsoft maintains the
            physical hardware, the virtualisation layer, the operating system and the runtime.
            Patching the operating system is therefore Microsoft's responsibility.

            The customer remains responsible for the application it writes and deploys, along
            with its data and access configuration, but never for the physical servers.
            """);

        yield return Mc("cc-032", D1, "Describe the shared responsibility model", R1,
            """
            Which responsibility always remains with the customer, regardless of whether a
            workload uses IaaS, PaaS or SaaS?
            """,
            [
                "Managing the accounts and access rights of its own users.",
                "Patching the host virtualisation layer.",
                "Maintaining the physical data centre.",
                "Replacing failed storage hardware."
            ], "A",
            """
            Identity and access management, including who the users are and what they are
            permitted to do, stays with the customer under every service type. The customer also
            always retains responsibility for its own data.

            The virtualisation layer, the data centre and the physical hardware belong to
            Microsoft in all three service types.
            """);

        yield return Drag("cc-033", D1, "Describe the shared responsibility model", R1,
            """
            A company deploys virtual machines in Azure.

            Match each responsibility to the party that owns it. Each party may be used once,
            more than once, or not at all.
            """,
            "Parties",
            [
                "Microsoft",
                "The customer"
            ],
            [
                ("Physical security of the data centre", 1),
                ("Configuring the guest operating system firewall", 2),
                ("Maintaining the hypervisor", 1),
                ("Installing application updates inside the virtual machine", 2)
            ],
            """
            Microsoft owns the physical facility and the virtualisation layer, so data centre
            security and hypervisor maintenance are Microsoft's responsibilities.

            In an IaaS deployment the customer owns everything from the guest operating system
            upward, which includes configuring the guest firewall and updating the applications
            installed on the virtual machine.
            """);

        yield return Mc("cc-034", D1, "Describe the shared responsibility model", R1,
            """
            Which statement about shared responsibility is true?
            """,
            [
                "Shared responsibility extends beyond resource management to include monitoring workload health and tracking service lifecycle changes.",
                "Once a workload is deployed, no further customer action is required because Azure services never change.",
                "Microsoft notifies each customer individually before any service behaviour changes.",
                "Shared responsibility applies only to infrastructure as a service."
            ], "A",
            """
            Shared responsibility is not limited to who patches what. The customer is also
            expected to monitor the health of its own solutions and to track announced changes
            and retirements so that it can plan for continuity.

            Azure services do evolve and can eventually be deprecated, so a deploy-and-forget
            approach is not viable, and the model applies to every service type.
            """);

        // ---------------------------------------------------------- deployment models

        yield return Mc("cc-035", D1, "Describe cloud computing", R1,
            """
            A company hosts all of its workloads in Azure. Its services are shared on
            infrastructure that other Microsoft customers also use, with logical boundaries
            keeping each customer's data separate.

            Which cloud deployment model is the company using?
            """,
            [
                "Public cloud.",
                "Private cloud.",
                "Hybrid cloud.",
                "Community cloud."
            ], "A",
            """
            In a public cloud the provider's infrastructure is shared among many organisations
            and reached over the internet, with physical and logical boundaries isolating each
            tenant. Azure is a public cloud.

            "Public" describes the shared, internet-delivered nature of the platform, not that
            the customer's own data or services are exposed to the public.
            """);

        yield return Mc("cc-036", D1, "Describe cloud computing", R1,
            """
            A government agency requires that its cloud infrastructure be dedicated to its own
            use so that it can apply controls that a shared platform cannot offer.

            Which cloud deployment model best meets this requirement?
            """,
            [
                "Private cloud.",
                "Public cloud.",
                "Hybrid cloud.",
                "Software as a service."
            ], "A",
            """
            A private cloud serves a single organisation, whether it is hosted in the
            organisation's own data centre or by a third party on dedicated hardware. That
            exclusivity is what allows extra controls and processes to satisfy regulatory
            requirements.

            The trade-off is cost: because the hardware is dedicated rather than shared, a
            private cloud is often no cheaper than running on-premises.
            """);

        yield return Mc("cc-037", D1, "Describe cloud computing", R1,
            """
            A company keeps a SQL Server cluster in its own data centre. Applications hosted in
            Azure query that cluster across a secure connection, and the cluster returns results
            to them.

            Which cloud deployment model does this describe?
            """,
            [
                "Hybrid cloud.",
                "Public cloud.",
                "Private cloud.",
                "Multi-cloud."
            ], "A",
            """
            A hybrid cloud exists when on-premises services and cloud services actually interact
            with one another as part of a combined solution. Azure-hosted applications querying
            an on-premises database is exactly that interaction.

            Simply owning both on-premises systems and cloud subscriptions is not enough; without
            service interaction it is not a hybrid deployment.
            """);

        yield return Mc("cc-038", D1, "Describe cloud computing", R1,
            """
            A company uses Microsoft 365 for email and productivity. It also runs an accounting
            system on servers in its own office. The two environments do not exchange data or
            interact in any way.

            Which cloud deployment model does the company use?
            """,
            [
                "Public cloud.",
                "Hybrid cloud.",
                "Private cloud.",
                "Community cloud."
            ], "A",
            """
            The differentiator for a hybrid cloud is service interaction between the on-premises
            environment and the cloud environment. Here the two run entirely independently, so
            despite the company owning both, this is not a hybrid deployment.

            The cloud portion is a shared, provider-hosted platform, which makes this a public
            cloud scenario.
            """);

        yield return YesNo("cc-039", D1, "Describe cloud computing", R1,
            """
            For each of the following statements about cloud deployment models, select Yes if the
            statement is true. Otherwise, select No.
            """,
            [
                ("A hybrid cloud requires interaction between on-premises services and cloud services.", true),
                ("A private cloud is always less expensive than a public cloud.", false),
                ("A public cloud means that the resources you deploy are accessible to anyone on the internet.", false)
            ],
            """
            Service interaction is precisely what distinguishes a hybrid cloud from an
            organisation that merely happens to use both on-premises and cloud systems.

            A private cloud uses dedicated hardware and is frequently more expensive than a
            public cloud, not less. And "public" refers to the shared, internet-delivered
            platform, not to your resources being open to the world.
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
                "Hybrid cloud"
            ],
            [
                ("Lowest cost, because infrastructure is shared across many organisations", 1),
                ("Greatest control, because infrastructure is dedicated to one organisation", 2),
                ("On-premises systems and cloud systems interact as one solution", 3)
            ],
            """
            Sharing infrastructure across many customers is what makes the public cloud the
            lowest-cost model.

            Dedicating infrastructure to a single organisation is the defining feature of a
            private cloud and the reason it offers the most control. Interaction between
            on-premises and cloud services defines a hybrid cloud.
            """);

        yield return Mc("cc-041", D1, "Describe cloud computing", R1,
            """
            Which is a valid reason for an organisation to keep some workloads on-premises while
            adopting Azure for others?
            """,
            [
                "A legacy application would require substantial rearchitecting before it could run in Azure.",
                "Azure cannot host database workloads.",
                "Public cloud platforms do not provide any security boundaries between customers.",
                "Keeping workloads on-premises is always less expensive than running them in Azure."
            ], "A",
            """
            Legacy applications that would need significant rearchitecting are a common and
            legitimate reason to leave a workload where it is, alongside unexpired data centre
            leases, latency between tightly coupled systems, and solutions that cannot run
            entirely in Azure.

            The other options are simply false: Azure hosts database workloads extensively, public
            cloud platforms enforce strong tenant isolation, and on-premises hosting is not
            universally cheaper.
            """);

        yield return Mc("cc-042", D1, "Describe cloud computing", R1,
            """
            Which Microsoft cloud offering primarily provides end-user productivity applications
            delivered as a subscription service?
            """,
            [
                "Microsoft 365.",
                "Microsoft Azure.",
                "Microsoft Dynamics 365.",
                "Azure Arc."
            ], "A",
            """
            Microsoft 365 bundles end-user productivity software such as Windows, Office,
            SharePoint and OneDrive, delivered on a per-user subscription basis.

            Azure is the broad cloud platform for infrastructure, data and application services,
            and Dynamics 365 provides enterprise resource planning and customer relationship
            management applications.
            """);

        yield return Mc("cc-043", D1, "Describe cloud computing", R1,
            """
            Which Microsoft cloud offering provides enterprise resource planning and customer
            relationship management applications?
            """,
            [
                "Microsoft Dynamics 365.",
                "Microsoft 365.",
                "Microsoft Azure.",
                "Microsoft Entra ID."
            ], "A",
            """
            Dynamics 365 is Microsoft's family of enterprise resource planning and customer
            relationship management applications.

            Microsoft 365 covers end-user productivity, Azure is the cloud infrastructure and
            application platform, and Microsoft Entra ID is the cloud identity service.
            """);

        yield return Mc("cc-044", D1, "Describe the benefits of cloud computing", R1,
            """
            A company wants to run a two-week proof of concept for a new analytics platform.
            Building the equivalent environment on-premises would require a large hardware
            purchase.

            Which benefit of cloud computing most directly addresses this situation?
            """,
            [
                "The consumption-based model lets the company pay only for the two weeks the environment runs.",
                "The shared responsibility model transfers all risk to Microsoft.",
                "Economy of scale guarantees the lowest possible price for every service.",
                "Data sovereignty ensures the proof of concept is compliant."
            ], "A",
            """
            A consumption-based model charges only for resources while they are running, so an
            environment can be created for a short evaluation and then removed, turning a large
            capital purchase into a small operating cost.

            Shared responsibility does not transfer risk wholesale, economy of scale is a general
            pricing advantage rather than a guarantee, and data sovereignty is a compliance
            concept unrelated to the cost of a trial.
            """);

        yield return Mc("cc-045", D1, "Describe the benefits of cloud computing", R1,
            """
            Which outcome is a realistic effect of moving infrastructure to the cloud on an
            organisation's IT staffing?
            """,
            [
                "Staff can be repurposed from routine maintenance toward more strategic work.",
                "All IT staff become unnecessary, because Microsoft assumes every responsibility.",
                "Staffing levels are unaffected, because cloud adoption changes no operational tasks.",
                "Staffing must always increase, because cloud platforms need more administrators."
            ], "A",
            """
            The most commonly recommended outcome is repurposing: because routine maintenance of
            hardware and platforms moves to the provider, existing staff can focus on optimising
            services and delivering new capability.

            Some organisations do reduce headcount and some increase it when adopting new
            services, but the shared responsibility model always leaves work for the customer, so
            eliminating IT staff entirely is not realistic.
            """);

        // ---------------------------------------------------------- mixed reinforcement

        yield return Mc("cc-046", D1, "Describe cloud service types", R1,
            """
            Your company plans to move an existing line-of-business application to Azure without
            modifying it. The application must keep running on a server that your team
            administers.

            Which cloud service type should you choose?
            """,
            [
                "IaaS.",
                "PaaS.",
                "SaaS.",
                "Serverless."
            ], "A",
            """
            Moving an application unchanged and keeping administrative control of the server
            points directly to infrastructure as a service, where the workload runs on a virtual
            machine your team manages.

            PaaS and serverless would generally require the application to be adapted to a
            managed platform, and SaaS would mean replacing the application with a provider's own
            product.
            """);

        yield return Mc("cc-047", D1, "Describe cloud service types", R1,
            """
            Which scenario is the best fit for platform as a service?
            """,
            [
                "A development team needs to publish a new web API quickly and does not want to manage servers or operating systems.",
                "A company needs to replace its email system with a provider-hosted product.",
                "A company must run software that requires a custom, unsupported operating system configuration.",
                "A company wants to buy per-user licences for a finished accounting package."
            ], "A",
            """
            PaaS is designed for teams that want to build and publish their own applications
            without provisioning or maintaining the underlying servers, operating systems and
            runtimes.

            Replacing email with a hosted product and buying per-user licences for finished
            software are SaaS scenarios, and a custom, unsupported operating system configuration
            requires the control that only IaaS provides.
            """);

        yield return YesNo("cc-048", D1, "Describe cloud service types", R1,
            """
            For each of the following statements, select Yes if the statement is true. Otherwise,
            select No.
            """,
            [
                ("With SaaS, the provider is responsible for applying application updates.", true),
                ("With IaaS, the customer is responsible for the guest operating system.", true),
                ("With PaaS, the customer is responsible for patching the runtime and the operating system.", false)
            ],
            """
            Under SaaS the provider maintains and updates the application itself, and under IaaS
            the guest operating system belongs to the customer. Both of those statements are
            true.

            Under PaaS the platform, including the operating system and the application runtime,
            is maintained by the provider; the customer is responsible only for the application
            it deploys and its data.
            """);

        yield return Mc("cc-049", D1, "Describe the benefits of cloud computing", R1,
            """
            Which pair of benefits most directly reduces the risk of over-provisioning hardware
            for a workload with unpredictable demand?
            """,
            [
                "Scalability and elasticity.",
                "Data residency and data sovereignty.",
                "Fault tolerance and disaster recovery.",
                "Governance and compliance."
            ], "A",
            """
            Over-provisioning happens when capacity must be bought up front for a peak that may
            never arrive. Scalability allows capacity to be added when it is needed, and
            elasticity does so automatically and removes it again afterwards.

            Resiliency, residency and governance concepts address other risks entirely and do not
            solve the capacity-sizing problem.
            """);

        yield return Mc("cc-050", D1, "Describe the benefits of high availability and scalability", R1,
            """
            Which statement about service level agreements is correct?
            """,
            [
                "An SLA is a financially backed commitment about service availability for a defined period.",
                "An SLA guarantees a maximum response time for every request.",
                "An SLA applies equally to every Azure service, including free and preview offerings.",
                "An SLA guarantees that a service will never become unavailable."
            ], "A",
            """
            A service level agreement is a commitment from the provider about the availability of
            a service over a stated period, and it is normally backed financially through service
            credits when the commitment is missed.

            An SLA covers availability rather than performance, free and preview offerings
            generally carry no SLA at all, and no realistic agreement promises absolute,
            uninterrupted availability.
            """);

        yield return Mc("cc-051", D1, "Describe cloud computing", R1,
            """
            What is the primary characteristic that distinguishes a cloud platform from a
            traditional company-owned data centre?
            """,
            [
                "Resources are delivered as an on-demand service from a globally distributed provider and billed by consumption.",
                "Cloud platforms use virtual machines and company-owned data centres do not.",
                "Cloud platforms never require any customer administration.",
                "Cloud platforms cannot host regulated workloads."
            ], "A",
            """
            The defining characteristics of a cloud platform are on-demand delivery of resources
            from a provider's globally distributed infrastructure, and metered, consumption-based
            billing.

            Virtualisation is used in both models, customer administration is always required
            under shared responsibility, and regulated workloads are routinely hosted in the
            cloud with the appropriate controls.
            """);

        yield return Mc("cc-052", D1, "Describe the benefits of cloud computing", R1,
            """
            Which two statements describe advantages of the consumption-based model? Each correct
            answer presents a complete solution.
            """,
            [
                "Costs stop accruing for compute when a resource is shut down.",
                "Costs can be attributed to the department that consumed the resource.",
                "Costs are fixed for the duration of the subscription regardless of usage.",
                "Costs are paid entirely up front at the start of each year.",
                "Costs are unaffected by the region in which a resource is deployed."
            ], "A,B",
            """
            Because usage is metered per resource, shutting a resource down stops the associated
            compute charges, and the same metering makes it straightforward to attribute spending
            to the department that consumed it.

            Consumption billing is by definition variable rather than fixed or prepaid, and the
            region a resource runs in does affect its price.
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
                ("A provider's ability to buy hardware in bulk and lower per-unit cost is called",
                    ["elasticity", "agility", "economy of scale", "high availability"], 3)
            ],
            """
            Buying servers acquires a fixed asset, which is capital expenditure, while a metered
            monthly bill for consumed services is operational expenditure.

            The bulk purchasing advantage that lets a provider lower per-unit cost, and pass part
            of the saving on, is economy of scale.
            """);

        yield return Mc("cc-054", D1, "Describe cloud computing", R1,
            """
            An organisation wants to improve the resiliency of an on-premises application by
            replicating it to Azure so that service can be restored there if the primary site is
            lost.

            Which use of the cloud does this describe?
            """,
            [
                "Using Azure as a disaster recovery target for on-premises systems.",
                "Using Azure as a private cloud.",
                "Replacing the application with a SaaS product.",
                "Scaling the on-premises application vertically."
            ], "A",
            """
            Using cloud capacity as the recovery destination for on-premises systems is a
            widespread pattern: it avoids paying for a second physical data centre while still
            providing somewhere to restore service after a major failure.

            Azure is a public cloud, no application is being replaced by a finished product, and
            vertical scaling addresses capacity rather than site loss.
            """);

        yield return Mc("cc-055", D1, "Describe the benefits of high availability and scalability", R1,
            """
            Your team must plan a very large deployment in a specific Azure region for a seasonal
            peak.

            What is the recommended approach with respect to regional capacity?
            """,
            [
                "Evaluate and secure capacity well in advance, and plan alternate regions in case the preferred region is constrained.",
                "Deploy on the day the capacity is needed, because cloud capacity is unlimited.",
                "Reserve the entire region for the duration of the peak.",
                "Assume capacity is guaranteed because the subscription has no spending limit."
            ], "A",
            """
            Regional capacity is finite and can be affected both by other large customers and by
            broader demand trends. Large deployments should therefore be evaluated and arranged
            well ahead of the date they are needed.

            A flexible plan that can fall back to an alternate region protects the deployment if
            the preferred region turns out to be constrained. Spending limits have nothing to do
            with capacity availability.
            """);

        yield return YesNo("cc-056", D1, "Describe the shared responsibility model", R1,
            """
            For each of the following statements about the shared responsibility model, select
            Yes if the statement is true. Otherwise, select No.
            """,
            [
                ("The customer always retains responsibility for its own data.", true),
                ("Microsoft is always responsible for the physical security of the data centre.", true),
                ("The division of responsibility is identical for IaaS, PaaS and SaaS.", false)
            ],
            """
            Data and identity remain the customer's responsibility under every service type, and
            physical data centre security is always Microsoft's.

            The boundary between the two parties moves depending on the service type, however:
            IaaS leaves the most with the customer and SaaS the least, so the third statement is
            false.
            """);

        yield return Mc("cc-057", D1, "Describe cloud service types", R1,
            """
            Which statement best describes why Azure SQL Database can be discussed as both a SaaS
            offering and a component of a PaaS solution?
            """,
            [
                "It is a fully managed service that the customer consumes without managing servers, and it is also a building block that developers use within their own applications.",
                "It runs on virtual machines that the customer must patch.",
                "It requires the customer to install and license SQL Server.",
                "It is only available to organisations with an Enterprise Agreement."
            ], "A",
            """
            Azure SQL Database can be created and used without deploying a server, installing SQL
            Server or maintaining an operating system, which gives it the character of a finished,
            provider-managed service.

            At the same time, developers commonly consume it as the data tier of a wider
            application platform, which is why it is also described as part of a PaaS solution.
            """);

        yield return Mc("cc-058", D1, "Describe cloud computing", R1,
            """
            Which characteristic is shared by public, private and hybrid cloud models?
            """,
            [
                "They can all provide scalability and self-service provisioning of resources.",
                "They all share physical infrastructure among multiple organisations.",
                "They all remove the need for any customer administration.",
                "They all require an on-premises data centre."
            ], "A",
            """
            Scalability, elasticity and on-demand, self-service provisioning are cloud
            characteristics that a private cloud aims to reproduce for a single organisation just
            as a public cloud provides them to many.

            Shared physical infrastructure is specific to the public cloud, customer
            administration is always required, and only hybrid deployments necessarily involve
            on-premises systems.
            """);

        yield return Mc("cc-059", D1, "Describe the benefits of cloud computing", R1,
            """
            Which benefit best describes an organisation's ability to release a new feature to
            customers in days rather than months because environments can be created on demand?
            """,
            [
                "Agility.",
                "Elasticity.",
                "Fault tolerance.",
                "Economy of scale."
            ], "A",
            """
            Agility is the ability to deploy and adapt resources quickly, and therefore to
            respond rapidly to changing business requirements. Shortening a release cycle from
            months to days is a direct expression of it.

            Elasticity refers specifically to automatic capacity adjustment, fault tolerance to
            surviving component failure, and economy of scale to provider pricing advantages.
            """);

        yield return Build("cc-060", D1, "Describe cloud service types", R1,
            """
            You must order the three main cloud service types by how much of the technology stack
            the customer is responsible for managing.

            Arrange the service types in order, beginning with the type in which the customer
            manages the most.
            """,
            "Service types",
            [
                "IaaS",
                "PaaS",
                "SaaS"
            ],
            [1, 2, 3],
            """
            Infrastructure as a service leaves the customer managing the guest operating system,
            the runtime and the application, which is the largest share of the stack.

            Platform as a service removes the operating system and runtime, leaving the
            application and data. Software as a service removes the application as well, leaving
            the customer responsible mainly for users, access and data.
            """);

        yield return Hot("cc-061", D1, "Describe cloud service types", R1,
            """
            The work area shows the three cloud service types arranged by customer responsibility.

            Select the service type in which Microsoft is responsible for applying updates to the
            application itself.
            """,
            "Cloud service types",
            [
                "IaaS — customer manages OS and application",
                "PaaS — customer manages application only",
                "SaaS — provider manages the application"
            ], 3,
            """
            Under software as a service the provider hosts, maintains and updates the finished
            application, and subscribers receive new features as part of the service.

            With IaaS and PaaS the customer still deploys and updates its own application code,
            so responsibility for application updates has not transferred to Microsoft.
            """);

        yield return Mc("cc-062", D1, "Describe cloud computing", R1,
            """
            Which statement about a private cloud is correct?
            """,
            [
                "It serves a single organisation and can be hosted either in that organisation's data centre or by a third party.",
                "It must always be hosted in the organisation's own data centre.",
                "It is always cheaper than an equivalent public cloud deployment.",
                "It cannot provide scalability or elasticity."
            ], "A",
            """
            A private cloud is defined by serving one organisation on dedicated infrastructure.
            That infrastructure may sit in the organisation's own facility or be operated on its
            behalf by a hosting provider.

            Because the hardware is dedicated rather than shared, a private cloud is often no
            cheaper than on-premises hosting, and it can still deliver scalability and elasticity.
            """);
    }
}
