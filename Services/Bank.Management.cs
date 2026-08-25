using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Domain 3 of the AZ-900 skills outline: "Describe Azure management and governance" (30-35%).
public static partial class QuestionBank
{
    private const ExamDomain D3 = ExamDomain.ManagementAndGovernance;

    private static IEnumerable<Item> ManagementAndGovernance()
    {
        foreach (var i in CostManagement()) yield return i;
        foreach (var i in GovernanceAndCompliance()) yield return i;
        foreach (var i in ManagementTools()) yield return i;
    }

    private const string R7 = "Study guide, ch. 7: Azure Pricing, Service Levels, and Lifecycle";

    private static IEnumerable<Item> CostManagement()
    {
        // ---------------------------------------------------------- cost factors

        yield return Mc("cm-001", D3, "Describe cost management in Azure", R7,
            """
            Which type of network traffic is charged in Azure?
            """,
            [
                "Egress, which is data leaving an Azure data centre.",
                "Ingress, which is data entering an Azure data centre.",
                "Both ingress and egress are charged at the same rate.",
                "Neither ingress nor egress is charged."
            ], "A",
            """
            Data moving into an Azure data centre, known as ingress, is not charged. Data leaving,
            known as egress, is charged, and it is one of the main network cost considerations in
            a solution design.

            This is why placing tightly coupled resources in the same region matters: it avoids
            generating chargeable egress between them.
            """);

        yield return Mc("cm-002", D3, "Describe cost management in Azure", R7,
            """
            Which two factors affect the cost of an Azure resource? Each correct answer presents a
            complete solution.
            """,
            [
                "The region in which the resource is deployed.",
                "The service tier or performance tier selected for the resource.",
                "The name given to the resource.",
                "The resource group the resource is placed in.",
                "The tags applied to the resource."
            ], "A,B",
            """
            Prices vary between regions for the same service, and the tier chosen, whether that is
            a performance tier, a service tier or a storage access tier, changes the rate charged.

            Names, resource group membership and tags are organisational metadata. Tags are useful
            for reporting and chargeback but do not themselves change what a resource costs.
            """);

        yield return Mc("cm-003", D3, "Describe cost management in Azure", R7,
            """
            You stop and deallocate an Azure virtual machine that you will not need for a month.

            Which statement describes the billing effect?
            """,
            [
                "Compute charges stop, but you continue to pay for the attached disk storage.",
                "All charges stop, including storage.",
                "Compute charges continue because the virtual machine still exists.",
                "You are charged a fixed monthly fee for the deallocated virtual machine."
            ], "A",
            """
            Deallocating a virtual machine releases the compute resources, so compute charges stop.
            The managed disks that hold the operating system and data still exist, so storage
            charges continue.

            To remove all charges the virtual machine and its associated resources have to be
            deleted, which also destroys the data.
            """);

        yield return YesNo("cm-004", D3, "Describe cost management in Azure", R7,
            """
            For each of the following statements about Azure costs, select Yes if the statement is
            true. Otherwise, select No.
            """,
            [
                ("Deploying the same virtual machine size in a different region can change its price.", true),
                ("Data transferred into an Azure region is charged at the same rate as data transferred out.", false),
                ("Deleting a virtual machine stops the charges for its managed disks.", false)
            ],
            """
            Regional pricing differences are real and can be significant, so region choice is a
            legitimate cost lever.

            Inbound traffic is free while outbound traffic is charged. Deleting a virtual machine
            does not automatically delete its disks, network interface or public IP address, so
            those resources keep incurring charges until they are removed separately.
            """);

        // ---------------------------------------------------------- calculators

        yield return Mc("cm-005", D3, "Describe cost management in Azure", R7,
            """
            You need to estimate the monthly cost of a proposed solution consisting of specific
            virtual machines, a database and a storage account, before you deploy anything.

            Which tool should you use?
            """,
            [
                "The Azure Pricing Calculator.",
                "The Total Cost of Ownership Calculator.",
                "Microsoft Cost Management.",
                "Azure Advisor."
            ], "A",
            """
            The Azure Pricing Calculator estimates what a specific set of Azure resources will cost.
            You select the products, specify parameters such as region, tier and instance count,
            and the estimate updates as you go. No subscription is required to use it.

            The other tools either compare on-premises costs to Azure or analyse spending that has
            already occurred.
            """);

        yield return Mc("cm-006", D3, "Describe cost management in Azure", R7,
            """
            Your organisation wants to compare the cost of continuing to run its existing
            on-premises data centre against the cost of migrating those workloads to Azure.

            Which tool is designed for this comparison?
            """,
            [
                "The Total Cost of Ownership Calculator.",
                "The Azure Pricing Calculator.",
                "Microsoft Cost Management.",
                "Azure Monitor."
            ], "A",
            """
            The Total Cost of Ownership Calculator estimates the savings from moving existing
            on-premises workloads to Azure by comparing the full cost of ownership in both places.
            Its capabilities are now delivered through Azure Migrate.

            The Pricing Calculator prices a proposed Azure configuration but does not model the
            on-premises side of the comparison.
            """);

        yield return Dropdowns("cm-007", D3, "Describe cost management in Azure", R7,
            """
            Select the answer choice that completes each statement based on the information
            presented.
            """,
            [
                ("To estimate the cost of a specific set of Azure resources before deployment, use",
                    ["the Pricing Calculator", "the TCO Calculator", "Microsoft Cost Management", "Azure Advisor"], 1),
                ("To compare on-premises costs against the cost of running the same workloads in Azure, use",
                    ["the Pricing Calculator", "the TCO Calculator", "Microsoft Cost Management", "Azure Monitor"], 2),
                ("To set a budget and receive an alert when spending crosses a threshold, use",
                    ["the Pricing Calculator", "the TCO Calculator", "Microsoft Cost Management", "Azure Policy"], 3)
            ],
            """
            The Pricing Calculator prices a planned Azure configuration, and the Total Cost of
            Ownership Calculator compares on-premises ownership costs with Azure.

            Once resources are running, Microsoft Cost Management is the tool that analyses actual
            spending and supports budgets, thresholds and alerts.
            """);

        yield return Mc("cm-008", D3, "Describe cost management in Azure", R7,
            """
            Which tool should you use to analyse spending that has already occurred, create
            budgets, and receive alerts when a subscription approaches a spending threshold?
            """,
            [
                "Microsoft Cost Management.",
                "The Azure Pricing Calculator.",
                "Azure Policy.",
                "Azure Service Health."
            ], "A",
            """
            Microsoft Cost Management brings together cost analysis, budgets, threshold alerts,
            forecasting, scheduled reports and exports for actual consumption.

            The Pricing Calculator produces estimates before deployment, Azure Policy governs
            resource configuration, and Service Health reports on the health of Azure services.
            """);

        yield return Mc("cm-009", D3, "Describe cost management in Azure", R7,
            """
            You create a budget in Microsoft Cost Management and set an alert threshold.

            What happens when spending exceeds that threshold?
            """,
            [
                "A notification is sent, but resources continue to run.",
                "All resources in the subscription are shut down immediately.",
                "New resource creation is blocked automatically.",
                "The subscription is cancelled."
            ], "A",
            """
            A budget in Microsoft Cost Management is a monitoring and notification construct. When
            spending crosses a configured threshold it raises an alert so that someone can act, but
            it does not stop resources by itself.

            Automatically shutting off consumption is the behaviour of a spending limit on a
            credit-based subscription, which is a different mechanism.
            """);

        yield return Mc("cm-010", D3, "Describe cost management in Azure", R7,
            """
            To which type of subscription is an Azure spending limit automatically applied?
            """,
            [
                "Free trial and other credit-based subscriptions.",
                "Enterprise Agreement subscriptions.",
                "All pay-as-you-go subscriptions.",
                "Cloud Solution Provider subscriptions."
            ], "A",
            """
            Spending limits are applied automatically to free trial and credit-based subscriptions.
            When the limit is reached the subscription is disabled until the next billing period,
            which prevents unexpected charges.

            The limit can be removed on credit-based subscriptions, and converting a free trial to
            pay-as-you-go also removes it.
            """);

        // ---------------------------------------------------------- saving money

        yield return Mc("cm-011", D3, "Describe cost management in Azure", R7,
            """
            Your company runs a set of virtual machines continuously and expects to keep running
            them for at least three years.

            Which option provides the greatest cost reduction?
            """,
            [
                "Purchase Azure Reservations for a three-year term.",
                "Move the virtual machines to spot pricing.",
                "Deallocate the virtual machines overnight.",
                "Move the virtual machines to a different resource group."
            ], "A",
            """
            Azure Reservations trade a one-year or three-year commitment for a large discount, and
            the longer commitment produces the deeper saving. For steady, predictable workloads
            that run continuously this is the strongest lever available.

            Spot pricing is inappropriate for workloads that must run continuously because spot
            instances can be evicted, and moving a resource between groups changes nothing about
            its cost.
            """);

        yield return Mc("cm-012", D3, "Describe cost management in Azure", R7,
            """
            Which term lengths are available for Azure Reservations?
            """,
            [
                "One year or three years.",
                "One month or twelve months.",
                "Two years or five years.",
                "Six months or eighteen months."
            ], "A",
            """
            Azure Reservations are purchased for a one-year or three-year term, and the three-year
            commitment carries the larger discount, which can reach roughly 70 percent or more
            depending on the resource.

            Reservations do not renew automatically. When the term ends, pricing reverts to
            pay-as-you-go unless a new reservation is purchased.
            """);

        yield return Mc("cm-013", D3, "Describe cost management in Azure", R7,
            """
            Your company owns Windows Server and SQL Server licences that are covered by Software
            Assurance, and it plans to run those workloads on Azure virtual machines.

            Which option lets the company reduce cost by reusing those licences?
            """,
            [
                "Azure Hybrid Benefit.",
                "Azure Reservations.",
                "Azure spot virtual machines.",
                "Azure dev/test pricing."
            ], "A",
            """
            Azure Hybrid Benefit lets an organisation apply existing Windows Server and SQL Server
            licences covered by Software Assurance to Azure workloads, so it pays only for the
            underlying compute rather than for the licence again.

            Reservations, spot pricing and dev/test pricing all reduce cost in other ways but none
            of them makes use of licences the customer already owns.
            """);

        yield return Mc("cm-014", D3, "Describe cost management in Azure", R7,
            """
            Which workload is the most appropriate candidate for Azure spot virtual machines?
            """,
            [
                "A batch processing job that can be interrupted and restarted later.",
                "A customer-facing web application with an availability commitment.",
                "A production database that must be continuously available.",
                "A domain controller that authenticates users."
            ], "A",
            """
            Spot virtual machines use spare capacity at a large discount, but they can be evicted
            with only about thirty seconds of notice and carry no availability commitment. Work
            that can be interrupted and resumed, such as batch processing, is the ideal fit.

            Anything that must stay available, including customer-facing applications, production
            databases and domain controllers, should not run on spot capacity.
            """);

        yield return Mc("cm-015", D3, "Describe cost management in Azure", R7,
            """
            How much notice does Azure give before evicting a spot virtual machine?
            """,
            ["About 30 seconds.", "About 5 minutes.", "About 1 hour.", "About 24 hours."], "A",
            """
            Azure gives roughly thirty seconds of notice before evicting a spot virtual machine,
            which is why spot workloads must be able to checkpoint or simply restart.

            The eviction policy determines what happens next: the instance is either deallocated,
            in which case storage charges continue, or deleted outright.
            """);

        yield return Drag("cm-016", D3, "Describe cost management in Azure", R7,
            """
            Match each requirement to the most appropriate cost-saving option. Each option may be
            used once, more than once, or not at all.
            """,
            "Cost-saving options",
            [
                "Azure Reservations",
                "Azure Hybrid Benefit",
                "Spot virtual machines",
                "Right-sizing"
            ],
            [
                ("Commit to steady compute usage for three years in exchange for a discount", 1),
                ("Reuse existing Software Assurance licences for Windows Server in Azure", 2),
                ("Run an interruptible batch job on spare capacity at a deep discount", 3),
                ("Reduce the size of virtual machines that are consistently underutilised", 4)
            ],
            """
            Reservations reward a term commitment on predictable usage, and Azure Hybrid Benefit
            reuses licences the organisation already owns.

            Spot pricing suits interruptible work on spare capacity, and right-sizing eliminates
            waste by matching instance size to actual consumption.
            """);

        yield return Mc("cm-017", D3, "Describe cost management in Azure", R7,
            """
            Which practice helps you attribute Azure costs to the department that consumed the
            resources?
            """,
            [
                "Apply tags to resources and review costs by tag in Microsoft Cost Management.",
                "Place all resources in a single resource group.",
                "Apply a resource lock to each resource.",
                "Assign the Reader role to each department."
            ], "A",
            """
            Tags are name and value pairs applied to resources, and Microsoft Cost Management can
            group and filter spending by tag. That makes tagging the standard mechanism for
            chargeback and showback.

            Locks protect resources from change, and role assignments control access; neither
            provides cost attribution.
            """);

        yield return Mc("cm-018", D3, "Describe cost management in Azure", R7,
            """
            A company runs SQL Server on Azure virtual machines and wants to reduce both cost and
            administrative effort.

            Which change would most directly achieve this?
            """,
            [
                "Migrate the databases to Azure SQL Database or Azure SQL Managed Instance.",
                "Increase the size of the virtual machines.",
                "Move the virtual machines to a different resource group.",
                "Apply a ReadOnly lock to the virtual machines."
            ], "A",
            """
            Moving from an infrastructure as a service deployment to a managed platform service
            removes operating system patching and server maintenance, and shifts billing to
            consumption of the database service rather than a continuously running virtual machine.

            Enlarging the virtual machines would increase cost, and neither resource group
            membership nor locks affect cost or administrative burden.
            """);

        // ---------------------------------------------------------- SLAs

        yield return Mc("cm-019", D3, "Describe Azure service level agreements", R7,
            """
            A solution chains together services with availability commitments of 99.9 percent and
            99.99 percent.

            How is the composite availability of the solution calculated?
            """,
            [
                "By multiplying the individual commitments together.",
                "By averaging the individual commitments.",
                "By taking the highest individual commitment.",
                "By adding the individual commitments and dividing by 100."
            ], "A",
            """
            When services are chained so that the failure of any one makes the solution unavailable,
            their commitments multiply. Multiplying values below one always produces a smaller
            result, so a composite commitment is always lower than the weakest single component.

            This is why adding more dependent components reduces the overall commitment rather than
            improving it.
            """);

        yield return Mc("cm-020", D3, "Describe Azure service level agreements", R7,
            """
            A solution depends on two services, one with a 99.9 percent commitment and one with a
            99.99 percent commitment. Both must be available for the solution to work.

            What is the approximate composite availability?
            """,
            ["99.89 percent.", "99.99 percent.", "99.945 percent.", "100 percent."], "A",
            """
            Multiplying the two commitments gives 0.999 multiplied by 0.9999, which is
            approximately 0.9989, or about 99.89 percent.

            The result is lower than either individual commitment, which illustrates the general
            rule that each additional dependency reduces the composite figure.
            """);

        yield return Mc("cm-021", D3, "Describe Azure service level agreements", R7,
            """
            Which change would increase the availability commitment for a virtual machine workload?
            """,
            [
                "Deploy two or more instances across two or more availability zones.",
                "Add more virtual machines to the same availability zone as the existing instance.",
                "Move the virtual machines to a cheaper region.",
                "Apply a CanNotDelete lock to the virtual machines."
            ], "A",
            """
            Spreading two or more instances across two or more availability zones raises the virtual
            machine commitment to 99.99 percent, because the instances no longer share power,
            cooling or networking.

            Adding dependent instances without separating them does not raise the commitment,
            region choice affects price rather than availability, and locks protect against
            accidental change rather than outage.
            """);

        yield return YesNo("cm-022", D3, "Describe Azure service level agreements", R7,
            """
            For each of the following statements about Azure service level agreements, select Yes
            if the statement is true. Otherwise, select No.
            """,
            [
                ("Services in preview are generally not covered by a service level agreement.", true),
                ("Free Azure products generally have no service level agreement.", true),
                ("Microsoft automatically issues a service credit when an agreement is missed.", false)
            ],
            """
            Preview services and free products are generally excluded from availability
            commitments, which is a key reason not to run production workloads on them.

            Service credits are not issued automatically. The customer must submit a billing claim,
            or work through their partner, to request one.
            """);

        yield return Mc("cm-023", D3, "Describe Azure service level agreements", R7,
            """
            Under a 99.9 percent availability commitment, approximately how much downtime is
            permitted per year?
            """,
            ["About 8.76 hours.", "About 52.56 minutes.", "About 43.2 minutes.", "About 4.38 hours."], "A",
            """
            A 99.9 percent commitment permits roughly 8.76 hours of downtime across a year, which
            corresponds to about 43.2 minutes in a 30-day month.

            A 99.99 percent commitment reduces the annual figure to roughly 52.56 minutes, an order
            of magnitude improvement.
            """);

        yield return Mc("cm-024", D3, "Describe Azure service level agreements", R7,
            """
            An Azure service is reachable but responding much more slowly than normal.

            Does this constitute a breach of the availability commitment?
            """,
            [
                "No, because availability commitments measure whether the service is available, not how fast it responds.",
                "Yes, because any degradation counts as downtime.",
                "Yes, but only if the slowdown lasts more than one hour.",
                "No, because Azure services never breach their commitments."
            ], "A",
            """
            An availability commitment measures whether the service can be reached and used.
            Degraded performance, while undesirable, does not count as downtime, so it does not by
            itself trigger a claim.

            To fail the commitment the service generally has to be completely unavailable.
            """);

        // ---------------------------------------------------------- lifecycle

        yield return Mc("cm-025", D3, "Describe Azure service level agreements", R7,
            """
            Which statement about Azure services in public preview is correct?
            """,
            [
                "They are available to all Azure customers but are not covered by a service level agreement.",
                "They are available only to invited customers and are covered by a service level agreement.",
                "They are fully supported and guaranteed to reach general availability.",
                "They are available only to customers with an Enterprise Agreement."
            ], "A",
            """
            A public preview is open to all Azure customers so that new functionality can be
            evaluated, but preview services carry no availability commitment, may not be covered by
            standard support, and are not guaranteed to reach general availability.

            A private preview, by contrast, is limited to invited organisations.
            """);

        yield return Mc("cm-026", D3, "Describe Azure service level agreements", R7,
            """
            What is the difference between a private preview and a public preview?
            """,
            [
                "A private preview is available only to invited customers, whereas a public preview is available to all Azure customers.",
                "A private preview is covered by a service level agreement, whereas a public preview is not.",
                "A private preview runs in a dedicated region, whereas a public preview runs everywhere.",
                "A private preview is free, whereas a public preview is charged."
            ], "A",
            """
            The distinction is who can access the feature. A private preview is offered to a
            selected set of organisations by invitation, while a public preview is open to any
            Azure customer who chooses to try it.

            Neither preview stage carries an availability commitment.
            """);

        yield return Dropdowns("cm-027", D3, "Describe Azure service level agreements", R7,
            """
            Select the answer choice that completes each statement based on the information
            presented.
            """,
            [
                ("A feature available only to invited organisations is in",
                    ["private preview", "public preview", "general availability", "retirement"], 1),
                ("A feature open to all customers but not covered by an availability commitment is in",
                    ["private preview", "public preview", "general availability", "retirement"], 2),
                ("A feature covered by published service level agreements and support terms is in",
                    ["private preview", "public preview", "general availability", "retirement"], 3)
            ],
            """
            Azure services progress from private preview, restricted to invited organisations, to
            public preview, open to everyone but without availability commitments.

            General availability is the point at which published service level agreements, online
            service terms and standard support all apply.
            """);

        yield return Mc("cm-028", D3, "Describe cost management in Azure", R7,
            """
            Which statement about Azure subscription quotas is correct?
            """,
            [
                "They are default limits that can often be increased up to a hard maximum by opening a support request.",
                "They are fixed limits that can never be changed.",
                "They automatically increase when spending increases.",
                "They apply only to storage accounts."
            ], "A",
            """
            Quotas, also called subscription limits, start at a default value and can often be
            raised through a support request, up to a hard maximum that cannot be exceeded.

            They are distinct from spending limits, which cap consumption cost rather than the
            number of resources that can be created.
            """);

        yield return Mc("cm-029", D3, "Describe cost management in Azure", R7,
            """
            Which purchasing option involves a partner who manages the subscription, billing and
            support on the customer's behalf?
            """,
            [
                "A Cloud Solution Provider agreement.",
                "An Enterprise Agreement.",
                "A pay-as-you-go subscription purchased on the Azure website.",
                "A free trial subscription."
            ], "A",
            """
            Under a Cloud Solution Provider arrangement, a Microsoft partner owns the customer
            relationship: it manages the subscription, invoices the customer and provides the first
            line of support.

            An Enterprise Agreement is a direct volume agreement with Microsoft, and web direct
            purchases are managed by the customer.
            """);

        yield return Mc("cm-030", D3, "Describe cost management in Azure", R7,
            """
            Which two statements about the Azure free account are correct? Each correct answer
            presents a complete solution.
            """,
            [
                "It includes a credit that can be used during the first 30 days.",
                "It includes a set of services that remain free for 12 months.",
                "It never requires a payment method to be registered.",
                "It automatically converts to a pay-as-you-go subscription after 30 days.",
                "It provides unlimited use of every Azure service."
            ], "A,B",
            """
            The free account combines a credit that must be used within the first thirty days with
            a set of popular services that remain free for twelve months, plus some services that
            are always free.

            A payment method is required at sign-up even though it is not charged, the account does
            not convert automatically, and free usage is capped rather than unlimited.
            """);
    }
}
