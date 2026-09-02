using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Domain 3 of the AZ-900 skills outline: "Describe Azure management and governance" (30-35%).
public static partial class QuestionBank
{
    private static readonly ExamDomain D3 = AzureDomains.ManagementAndGovernance;

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
            An architect places a web tier in West Europe and its database in North Europe, then is
            surprised by a network line on the bill.

            Which statement explains the charge?
            """,
            [
                "Egress, data leaving an Azure data centre, is charged, while ingress is free, so the constant cross-region replies from the database are billed.",
                "Ingress, data entering an Azure data centre, is charged, so the queries sent to the database are billed.",
                "Both directions are charged at the same rate, so the total is simply the sum of the traffic.",
                "Neither direction is charged within the same geography, so the line must be an error."
            ], "A",
            """
            Data entering an Azure data centre is free; data leaving is charged. That asymmetry is
            the single most useful fact about Azure network pricing, and it is why a chatty
            application split across regions costs more than the same application in one region.

            Here the queries into North Europe cost nothing and every response leaving it is
            billed. Keeping tightly coupled resources in the same region avoids generating the
            chargeable direction at all.
            """,
            """
            Only one direction of traffic is charged. Work out which, then which half of this
            conversation travels in it.
            """);

        yield return Mc("cm-002", D3, "Describe cost management in Azure", R7,
            """
            Which two factors directly change the amount charged for an Azure resource? Each correct
            answer presents a complete solution.
            """,
            [
                "The region the resource is deployed to.",
                "The service or performance tier selected for the resource.",
                "The tags applied to the resource.",
                "The resource group the resource is placed in.",
                "The name given to the resource."
            ], "A,B",
            """
            Prices for the same service vary between regions, and the tier chosen, whether a
            performance tier, a service tier or a storage access tier, changes the rate charged.
            Both are real design levers.

            Tags are the distractor worth being precise about. They are central to cost management
            because they let you attribute and report spending, but attributing a cost is not the
            same as changing it: a tagged and an untagged virtual machine cost exactly the same.
            Names and resource group membership are metadata too.
            """,
            """
            One distractor is genuinely important to cost management without affecting the amount
            charged. Note the word "directly" in the question.
            """);

        yield return Mc("cm-003", D3, "Describe cost management in Azure", R7,
            """
            A virtual machine is not needed for a month. An administrator shuts it down from inside
            the guest operating system and expects the compute charges to stop.

            What actually happens, and what should have been done?
            """,
            [
                "Compute charges continue, because shutting down in the guest does not release the allocation; the machine must be deallocated, after which disk charges still apply.",
                "Compute charges stop, because any shutdown releases the compute allocation, and disk charges also stop.",
                "Compute charges stop, and disk charges continue, because a guest shutdown and a deallocation are equivalent.",
                "All charges stop immediately, because Azure bills only for running processes."
            ], "A",
            """
            Shutting down inside the guest leaves the virtual machine in a stopped state with its
            compute capacity still allocated, and Azure keeps billing for it. Deallocating, from
            the portal, CLI or PowerShell, releases the capacity and ends the compute charge.

            Even then the managed disks holding the operating system and data still exist and are
            still billed, so a deallocated machine is cheap rather than free. Removing every charge
            means deleting the machine and its disks, which destroys the data.
            """,
            """
            Two words for stopping a machine mean different things to the billing system. Which one
            did the administrator actually do?
            """);

        yield return YesNo("cm-004", D3, "Describe cost management in Azure", R7,
            """
            For each of the following statements about Azure costs, select Yes if the statement is
            true. Otherwise, select No.
            """,
            [
                ("Deploying the same virtual machine size in a different region can change its price.", true),
                ("Data transferred into an Azure region is charged at the same rate as data out of it.", false),
                ("Deleting a virtual machine automatically stops the charges for its managed disks.", false),
                ("A deallocated virtual machine still incurs charges for its public IP address if one is reserved.", true)
            ],
            """
            Regional price differences are real and often significant, so region choice is a
            legitimate cost lever. Inbound traffic is free while outbound is charged, so the second
            statement is false.

            The last two are the same lesson twice: the virtual machine is not the only billable
            thing you created. Deleting it does not remove its disks, network interface or public
            IP, and a reserved static IP is billed whether or not anything is attached to it. This
            is the classic source of a bill that will not go down.
            """,
            """
            Two statements are about what survives after you stop or delete a virtual machine. List
            what else was created alongside it.
            """);

        // ---------------------------------------------------------- calculators

        yield return Mc("cm-005", D3, "Describe cost management in Azure", R7,
            """
            A team must produce a monthly cost estimate for a proposed solution of specific virtual
            machines, a database and a storage account. Nothing has been deployed and the team has
            no Azure subscription yet.

            Which tool should it use?
            """,
            [
                "The Azure Pricing Calculator.",
                "Microsoft Cost Management.",
                "The Total Cost of Ownership Calculator.",
                "Azure Advisor."
            ], "A",
            """
            The Azure Pricing Calculator prices a specific proposed configuration: you pick the
            products, set region, tier and instance count, and the estimate updates as you go. It
            needs no subscription, which is the detail the last sentence of the stem is testing.

            Cost Management and Advisor both analyse resources that already exist, so neither can
            help before deployment, and the TCO Calculator compares an existing on-premises estate
            with Azure rather than pricing a new design.
            """,
            """
            Two of these tools require something to already be running. The final sentence rules
            them out.
            """);

        yield return Mc("cm-006", D3, "Describe cost management in Azure", R7,
            """
            A finance director asks for a comparison between continuing to run the existing
            on-premises data centre and migrating those workloads to Azure, including the costs of
            hardware, power and staff.

            Which tool is designed for that comparison?
            """,
            [
                "The Total Cost of Ownership Calculator.",
                "The Azure Pricing Calculator.",
                "Microsoft Cost Management.",
                "Azure Monitor."
            ], "A",
            """
            The Total Cost of Ownership Calculator models the full cost of ownership in both
            places, which is what makes it the right answer: it accounts for the on-premises side,
            including hardware, power, facilities and labour, not just the Azure side. Its
            capabilities are now delivered through Azure Migrate.

            The Pricing Calculator prices an Azure configuration and knows nothing about the
            existing data centre, so it can produce one half of the comparison but never the
            comparison itself.
            """,
            """
            Both calculators can price the Azure side. Only one of them can price what the company
            is running today.
            """);

        yield return Dropdowns("cm-007", D3, "Describe cost management in Azure", R7,
            """
            Select the answer choice that completes each statement based on the information
            presented.
            """,
            [
                ("To estimate the cost of a specific set of Azure resources before deployment, use",
                    ["the Pricing Calculator", "the TCO Calculator", "Microsoft Cost Management", "Azure Advisor"], 1),
                ("To compare on-premises costs against running the same workloads in Azure, use",
                    ["the Pricing Calculator", "the TCO Calculator", "Microsoft Cost Management", "Azure Monitor"], 2),
                ("To set a budget and be alerted when spending crosses a threshold, use",
                    ["the Pricing Calculator", "the TCO Calculator", "Microsoft Cost Management", "Azure Policy"], 3),
                ("To be told that an existing virtual machine is oversized and could be resized, use",
                    ["the Pricing Calculator", "the TCO Calculator", "Microsoft Cost Management", "Azure Advisor"], 4)
            ],
            """
            The two calculators work before anything is deployed: the Pricing Calculator prices a
            planned Azure configuration, and the TCO Calculator compares on-premises ownership with
            Azure.

            The last two rows work afterwards and are easy to blur. Cost Management reports what you
            spent and enforces budgets and alerts; Azure Advisor inspects how resources are actually
            used and recommends specific changes such as right-sizing an underused virtual machine.
            One tells you the number, the other tells you what to do about it.
            """,
            """
            Split the four rows into before deployment and after. Then, within each pair, ask which
            tool reports and which one recommends.
            """);

        yield return Mc("cm-008", D3, "Describe cost management in Azure", R7,
            """
            A team must analyse last quarter actual spending by department, forecast next month,
            and email a recurring report to finance.

            Which tool should it use?
            """,
            [
                "Microsoft Cost Management.",
                "The Azure Pricing Calculator.",
                "Azure Advisor.",
                "Azure Service Health."
            ], "A",
            """
            Microsoft Cost Management brings together cost analysis, budgets, threshold alerts,
            forecasting, scheduled reports and exports, all against actual consumption. Every
            requirement in the stem is one of its features.

            The Pricing Calculator produces estimates before deployment and has no view of what you
            actually spent. Advisor recommends changes rather than reporting spend, and Service
            Health reports on the health of Azure services.
            """,
            """
            The stem lists three requirements. Look for the one tool that covers all of them rather
            than the one that covers the first.
            """);

        yield return Mc("cm-009", D3, "Describe cost management in Azure", R7,
            """
            A team creates a budget in Microsoft Cost Management with an alert at 90 percent and
            assumes this will prevent overspending.

            What actually happens when spending crosses the threshold, and what would enforce a
            limit?
            """,
            [
                "A notification is sent and resources keep running; enforcement requires separate action, such as an automation triggered by the alert or policies that restrict what can be deployed.",
                "All resources in the subscription are shut down immediately, so no further action is needed.",
                "New resource creation is blocked automatically until the next billing period.",
                "The subscription is cancelled and must be reactivated by an administrator."
            ], "A",
            """
            A budget in Cost Management is a monitoring and notification construct. Crossing a
            threshold raises an alert and can trigger an action group; it never stops a resource, so
            the team assumption is exactly the misconception being tested.

            Actually constraining spend needs something else: automation invoked by the alert, or
            Azure Policy restricting which SKUs and regions may be deployed in the first place.
            """,
            """
            Ask whether a budget is a control or a warning. The second half of the answer follows
            from that.
            """);

        yield return Mc("cm-010", D3, "Describe cost management in Azure", R7,
            """
            A student subscription stops working part-way through the month and every resource
            becomes unavailable, although no budget alert was configured.

            What is the most likely cause?
            """,
            [
                "The spending limit that is applied automatically to credit-based subscriptions was reached, disabling the subscription until the next billing period.",
                "A budget in Microsoft Cost Management reached 100 percent and shut the resources down.",
                "A subscription quota was reached, which disables existing resources.",
                "The Azure Hybrid Benefit expired, which suspends the subscription."
            ], "A",
            """
            Spending limits are applied automatically to free trial and other credit-based
            subscriptions. When the credit is exhausted the subscription is disabled until the next
            billing period, which is what prevents an unexpected bill.

            The contrast with a budget is the point. A budget only notifies and never disables
            anything, so the absence of an alert is consistent with a spending limit rather than
            evidence against it. A quota limits how many resources you may create, not whether
            existing ones run. The limit can be removed, and converting to pay-as-you-go removes it.
            """,
            """
            Something stopped the resources, and budgets never do that. Ask which mechanism actually
            has the power to disable a subscription.
            """);

        // ---------------------------------------------------------- saving money

        yield return Mc("cm-011", D3, "Describe cost management in Azure", R7,
            """
            A company runs a fixed set of virtual machines continuously and expects to keep running
            them for at least three years. It also owns Windows Server licences with Software
            Assurance.

            Which two options should it combine? Each correct answer presents part of the solution.
            """,
            [
                "Azure Reservations for a three-year term.",
                "Azure Hybrid Benefit for the Windows Server licences.",
                "Spot virtual machines, to use spare capacity.",
                "Deallocating the virtual machines overnight.",
                "Moving the virtual machines to a different resource group."
            ], "A,B",
            """
            The two levers stack because they discount different things. A three-year reservation
            discounts the compute for a steady, predictable workload, and Azure Hybrid Benefit
            removes the Windows licence component by applying licences the company already owns.

            Spot pricing is wrong for anything that must run continuously, since instances can be
            evicted. Deallocating overnight contradicts the stated requirement, and a resource group
            move changes nothing about cost.
            """,
            """
            The scenario gives two separate facts about the company. Each one unlocks a different
            discount, and they apply to different parts of the bill.
            """);

        yield return Mc("cm-012", D3, "Describe cost management in Azure", R7,
            """
            Which statement about Azure Reservation terms is correct?
            """,
            [
                "Terms are one year or three years, the three-year term carries the larger discount, and pricing reverts to pay-as-you-go at the end unless a new reservation is bought.",
                "Terms are one year or three years, and a reservation renews automatically at the end of the term.",
                "Terms are one month or twelve months, chosen when the resource is created.",
                "Terms are two years or five years, and the discount is identical for both."
            ], "A",
            """
            Reservations are purchased for one or three years, and the longer commitment carries
            the deeper discount, which can reach roughly 70 percent or more depending on the
            resource.

            The expiry behaviour is the part that catches organisations out. Nothing renews by
            itself, so a reservation that lapses quietly returns the workload to pay-as-you-go
            rates and the bill rises without anything having changed in the environment.
            """,
            """
            Two options give the right term lengths. What separates them is what happens on the day
            the term ends.
            """);

        yield return Mc("cm-013", D3, "Describe cost management in Azure", R7,
            """
            A company owns Windows Server and SQL Server licences covered by Software Assurance and
            plans to run those workloads on Azure virtual machines.

            Which option reuses those licences, and what does it leave the company paying for?
            """,
            [
                "Azure Hybrid Benefit, which leaves the company paying for the underlying compute and storage but not for the licence again.",
                "Azure Hybrid Benefit, which makes the virtual machines free while the licences remain valid.",
                "Azure Reservations, which include the Windows Server licence in the committed price.",
                "Azure dev/test pricing, which is the only way to reuse an owned licence."
            ], "A",
            """
            Azure Hybrid Benefit applies existing Windows Server and SQL Server licences covered by
            Software Assurance to Azure workloads, so the licence portion of the rate disappears.

            What remains is the infrastructure: the compute, storage and networking are still
            billed as usual, which is why the benefit reduces the bill rather than eliminating it.
            Reservations and dev/test pricing are separate discounts that do not draw on licences
            you already own, though a reservation can be combined with the benefit.
            """,
            """
            The mechanism is easy to name. The harder half is what is left on the invoice once the
            licence component is removed.
            """);

        yield return Mc("cm-014", D3, "Describe cost management in Azure", R7,
            """
            Which workload is the most appropriate candidate for Azure spot virtual machines?
            """,
            [
                "A nightly video encoding job that checkpoints its progress and can resume after an interruption.",
                "A customer-facing web application covered by an availability commitment.",
                "A production database that must be continuously available.",
                "A domain controller that authenticates users."
            ], "A",
            """
            Spot virtual machines run on spare capacity at a large discount and can be evicted with
            roughly thirty seconds of notice, carrying no availability commitment. The right
            workload is one where an interruption costs time rather than service.

            The encoding job qualifies precisely because it checkpoints: eviction means resuming
            rather than starting over. Anything that must stay reachable, whether a web application,
            a database or a domain controller, is a poor fit.
            """,
            """
            The deciding property is not that the job runs at night or in batches. It is what
            happens to its progress when the machine disappears mid-run.
            """);

        yield return Mc("cm-015", D3, "Describe cost management in Azure", R7,
            """
            A spot virtual machine is evicted.

            How much notice does Azure give, and what determines whether storage charges continue?
            """,
            [
                "About 30 seconds, and the eviction policy decides: deallocate keeps the disks and their charges, while delete removes the instance outright.",
                "About 30 seconds, and storage charges always stop, because eviction deletes the instance.",
                "About 5 minutes, and storage charges always continue, because the disks are always retained.",
                "About 24 hours, which is enough time to migrate the workload to standard pricing."
            ], "A",
            """
            Azure gives roughly thirty seconds of notice, which is why a spot workload has to be
            able to checkpoint or simply restart. Anything needing a longer graceful shutdown does
            not belong on spot capacity.

            What happens afterwards is a choice you make in advance. The eviction policy is either
            deallocate, which keeps the disks and therefore keeps billing for them but allows a
            restart later, or delete, which removes the instance and its charges entirely.
            """,
            """
            The notice period is one fact. The second half depends on a setting you configure when
            creating the machine, not on Azure.
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
                ("Reduce the size of virtual machines that are consistently underutilised", 4),
                ("Cut the bill without changing the workload, its size, or its running hours", 2)
            ],
            """
            Reservations reward a term commitment on predictable usage, spot pricing suits
            interruptible work on spare capacity, and right-sizing removes waste by matching
            instance size to actual consumption.

            The last row is the elimination exercise. Reservations require a commitment, spot
            requires accepting eviction and right-sizing changes the machine, so the only option
            that leaves the workload completely untouched is applying licences you already own.
            """,
            """
            The final row rules out three options by what they each require you to change. Whatever
            survives is the answer.
            """);

        yield return Mc("cm-017", D3, "Describe cost management in Azure", R7,
            """
            Finance wants Azure costs attributed to the department that consumed them. Resources
            already exist across many resource groups.

            Which approach works, and what should be added to keep it working?
            """,
            [
                "Tag resources with a cost centre and group by tag in Microsoft Cost Management, adding an Azure Policy to require or append the tag on new resources.",
                "Tag resources with a cost centre, which is sufficient on its own because Azure applies the tag to future resources automatically.",
                "Move every department resources into one resource group per department, which is the only supported attribution method.",
                "Assign the Reader role to each department, so that Cost Management reports by role assignment."
            ], "A",
            """
            Tags are name and value pairs on resources, and Microsoft Cost Management can group and
            filter spending by tag, which makes tagging the standard mechanism for chargeback and
            showback.

            The second half is what stops the scheme decaying. Tags are not inherited and nothing
            applies them automatically, so an untagged resource silently falls out of the report;
            Azure Policy can require a tag at creation or append one. Resource groups are a valid
            secondary grouping but not the only method, and role assignments have nothing to do with
            cost reporting.
            """,
            """
            The mechanism is easy to name. Ask what happens next month when somebody deploys a
            resource and forgets.
            """);

        yield return Mc("cm-018", D3, "Describe cost management in Azure", R7,
            """
            A company runs SQL Server on Azure virtual machines that are busy only during business
            hours, and wants to reduce both cost and administrative effort.

            Which change most directly achieves both?
            """,
            [
                "Migrate the databases to Azure SQL Database or Azure SQL Managed Instance.",
                "Increase the size of the virtual machines so that fewer are needed.",
                "Apply a ReadOnly lock to the virtual machines outside business hours.",
                "Move the virtual machines into a dedicated resource group for reporting."
            ], "A",
            """
            Moving from infrastructure as a service to a managed platform service addresses both
            halves at once: Microsoft takes over operating system patching and server maintenance,
            and billing shifts to the database service, which can scale with the workload instead of
            a virtual machine running flat out around the clock.

            Enlarging the machines increases cost, a lock prevents changes rather than stopping
            charges, and a resource group move changes nothing at all.
            """,
            """
            The question asks for one change that improves two things. Check each option against
            both cost and effort rather than either alone.
            """);

        // ---------------------------------------------------------- SLAs

        yield return Mc("cm-019", D3, "Describe Azure service level agreements", R7,
            """
            An architect proposes adding a fourth dependent service to a solution, arguing that
            more services means more redundancy and therefore a higher composite commitment.

            Which statement is correct?
            """,
            [
                "Composite availability is the product of the individual commitments, so each additional dependency lowers it rather than raising it.",
                "The architect is right, because chained commitments are averaged and a high fourth service raises the average.",
                "Composite availability equals the highest individual commitment, so a strong fourth service raises the total.",
                "Composite availability equals the lowest individual commitment and is unaffected by adding services."
            ], "A",
            """
            When services are chained so that the failure of any one makes the solution unavailable,
            their commitments multiply. Multiplying values below one always yields a smaller result,
            so the composite figure is lower than the weakest single component and falls further
            with every dependency added.

            The architect has confused dependency with redundancy. Redundant components are
            alternatives to each other and do improve availability; dependent components each add a
            way for the solution to fail.
            """,
            """
            Ask whether the fourth service is an alternative to the others or something the
            solution now needs. That distinction reverses the answer.
            """);

        yield return Mc("cm-020", D3, "Describe Azure service level agreements", R7,
            """
            A solution depends on two services, one committed at 99.9 percent and one at 99.99
            percent. Both must be available for the solution to work.

            What is the approximate composite availability?
            """,
            ["99.89 percent.", "99.99 percent.", "99.945 percent.", "99.9 percent."], "A",
            """
            Multiply the two: 0.999 times 0.9999 is approximately 0.9989, or about 99.89 percent.

            Every distractor here is a plausible wrong method, which is why they are worth
            recognising. Taking the higher commitment gives 99.99, averaging gives 99.945, and
            taking the weakest link gives 99.9. All three are above the true answer, because
            multiplication is the only method that produces a result worse than every input.
            """,
            """
            The correct answer must be smaller than both inputs. That alone eliminates most of the
            options before any arithmetic.
            """);

        yield return Mc("cm-021", D3, "Describe Azure service level agreements", R7,
            """
            A single virtual machine with Premium SSD disks runs a workload that must qualify for a
            higher availability commitment.

            Which change achieves that?
            """,
            [
                "Deploy two or more instances across two or more availability zones.",
                "Add a second virtual machine in the same availability zone as the first.",
                "Upgrade the disks from Premium SSD to a larger Premium SSD size.",
                "Apply a CanNotDelete lock to the virtual machine."
            ], "A",
            """
            Two or more instances spread across two or more availability zones reaches 99.99
            percent, because the instances no longer share power, cooling or networking. A single
            instance on Premium SSD sits at 99.9 percent.

            Adding a second instance in the same zone gains nothing from the zone perspective, disk
            size does not change the commitment once the disk type is already Premium, and a lock
            protects against accidental deletion rather than outage.
            """,
            """
            The current deployment is already at the top of the single-instance ladder. Look for
            the change that moves it onto a different ladder entirely.
            """);

        yield return YesNo("cm-022", D3, "Describe Azure service level agreements", R7,
            """
            For each of the following statements about Azure service level agreements, select Yes
            if the statement is true. Otherwise, select No.
            """,
            [
                ("Services in preview are generally not covered by a service level agreement.", true),
                ("Free Azure products generally have no service level agreement.", true),
                ("Microsoft automatically issues a service credit when a commitment is missed.", false),
                ("A service credit refunds the business losses caused by the outage.", false)
            ],
            """
            Preview services and free products are generally excluded from availability
            commitments, which is the main reason not to run production workloads on them.

            The last two statements are about what a credit actually is. Nothing is issued
            automatically: the customer submits a claim, or works through their partner. And the
            remedy is a percentage credit against the service charges, not compensation for lost
            business, which is the difference between an SLA and an insurance policy.
            """,
            """
            The last two statements both concern the remedy. Ask who initiates it and what it is
            calculated from.
            """);

        yield return Mc("cm-023", D3, "Describe Azure service level agreements", R7,
            """
            A team is told a workload needs no more than one hour of downtime per year.

            Which commitment level is the minimum that satisfies this?
            """,
            [
                "99.99 percent, which permits about 52.56 minutes per year.",
                "99.9 percent, which permits about 52.56 minutes per year.",
                "99.9 percent, which permits about 8.76 hours per year.",
                "99 percent, which permits about 3.65 days per year."
            ], "A",
            """
            A 99.9 percent commitment permits roughly 8.76 hours of downtime per year, which is far
            more than one hour, so it does not qualify. Adding a nine divides the allowance by ten:
            99.99 percent permits about 52.56 minutes, which fits inside the requirement.

            Option C states the 99.9 percent figure correctly but does not meet the requirement, and
            option B attaches the wrong figure to it, so reading the number and the percentage
            together is the whole task.
            """,
            """
            Two options quote 99.9 percent with different downtime figures. Fix the correct figure
            first, then check it against the requirement.
            """);

        yield return Mc("cm-024", D3, "Describe Azure service level agreements", R7,
            """
            An Azure service is reachable throughout an incident but responds far more slowly than
            normal. A manager wants to file a service credit claim.

            Which statement is correct?
            """,
            [
                "An availability commitment measures whether the service can be reached and used, so slow but successful responses are not downtime and would not support a claim.",
                "Any measurable degradation counts as downtime, so the claim is straightforward.",
                "The claim succeeds only if the slowdown lasted more than one hour, which is the threshold in Azure agreements.",
                "No claim is ever possible, because Azure services do not breach their commitments."
            ], "A",
            """
            Availability commitments are about reachability. A service answering every request,
            however slowly, is available, and performance targets are published separately as
            service-specific latency measures.

            The manager is not wrong to be unhappy, but the remedy is not a claim under an
            availability commitment. There is no general one-hour degradation threshold, and Azure
            services certainly can breach their commitments, which is why the credit process exists
            at all.
            """,
            """
            Decide what word the percentage is attached to. Then ask whether a slow answer breaks
            that word.
            """);

        // ---------------------------------------------------------- lifecycle

        yield return Mc("cm-025", D3, "Describe Azure service level agreements", R7,
            """
            A team wants to build a production workload on a feature currently in public preview,
            arguing that public availability implies readiness.

            Which statement is correct?
            """,
            [
                "Public preview is open to all customers but carries no availability commitment, may fall outside standard support, and is not guaranteed to reach general availability.",
                "Public preview features are fully supported and guaranteed to reach general availability, so the plan is sound.",
                "Public preview is available only to invited customers, so the team cannot use it anyway.",
                "Public preview features are covered by the same service level agreements as generally available ones."
            ], "A",
            """
            A public preview is open to any Azure customer so new functionality can be evaluated,
            which is exactly what makes it feel ready. Openness is not readiness: preview services
            carry no availability commitment, may sit outside standard support, and can change
            substantially or be withdrawn without reaching general availability.

            A private preview is the stage limited to invited organisations.
            """,
            """
            The team has inferred one property from another. Ask whether being available to
            everyone says anything about what is promised.
            """);

        yield return Mc("cm-026", D3, "Describe Azure service level agreements", R7,
            """
            What is the difference between a private preview and a public preview, and what do they
            have in common?
            """,
            [
                "A private preview is limited to invited customers and a public preview is open to all; neither carries an availability commitment.",
                "A private preview is limited to invited customers and a public preview is open to all; only the public preview carries an availability commitment.",
                "A private preview runs in a dedicated region and a public preview runs everywhere; both carry availability commitments.",
                "A private preview is free and a public preview is charged; neither carries an availability commitment."
            ], "A",
            """
            The difference is purely who can get in: private previews go to a selected set of
            organisations by invitation, public previews to any customer who chooses to try the
            feature.

            What they share matters more for a design decision. Neither stage carries an
            availability commitment, so moving from private to public preview changes the audience
            without changing what is promised.
            """,
            """
            Two options state the access difference correctly. The tie is broken by what the two
            stages have in common.
            """);

        yield return Dropdowns("cm-027", D3, "Describe Azure service level agreements", R7,
            """
            Select the answer choice that completes each statement based on the information
            presented.
            """,
            [
                ("A feature available only to invited organisations is in",
                    ["private preview", "public preview", "general availability", "retirement"], 1),
                ("A feature open to all customers but with no availability commitment is in",
                    ["private preview", "public preview", "general availability", "retirement"], 2),
                ("A feature covered by published service level agreements and support terms is in",
                    ["private preview", "public preview", "general availability", "retirement"], 3),
                ("The earliest stage at which a production workload should normally depend on a feature is",
                    ["private preview", "public preview", "general availability", "retirement"], 3)
            ],
            """
            Azure services progress from private preview, restricted to invited organisations, to
            public preview, open to everyone but without availability commitments, to general
            availability, where published service level agreements, online service terms and
            standard support all apply.

            The last row draws the practical conclusion. Because neither preview stage promises
            anything, general availability is the first point at which a production workload should
            take a dependency.
            """,
            """
            The first three rows are definitions and the fourth asks you to act on them. Which stage
            is the first to promise anything?
            """);

        yield return Mc("cm-028", D3, "Describe cost management in Azure", R7,
            """
            A deployment fails because the subscription has reached its limit for virtual machine
            cores in a region.

            Which statement about this limit is correct, and how does it differ from a spending
            limit?
            """,
            [
                "It is a quota: a default limit that can often be raised by support request up to a hard maximum, and it caps how many resources you may create rather than how much you may spend.",
                "It is a quota, and quotas are fixed values that can never be changed.",
                "It is a spending limit, and it will lift automatically at the start of the next billing period.",
                "It is a quota, and it increases automatically as the subscription spend increases."
            ], "A",
            """
            Quotas, also called subscription limits, start at a default value and can often be
            raised through a support request, up to a hard maximum that cannot be exceeded. Nothing
            about them adjusts automatically with spend.

            The contrast with a spending limit is the useful part. A quota caps how many resources
            you may create; a spending limit caps consumption cost and disables a credit-based
            subscription when the credit runs out. They fail in different ways and are fixed
            differently.
            """,
            """
            Two similar-sounding limits exist. One counts resources and one counts money; only one
            of them is raised by asking.
            """);

        yield return Mc("cm-029", D3, "Describe cost management in Azure", R7,
            """
            A small company wants a single organisation to manage its Azure subscription, invoice it
            directly and provide its first line of support.

            Which purchasing option fits?
            """,
            [
                "A Cloud Solution Provider agreement.",
                "An Enterprise Agreement.",
                "A pay-as-you-go subscription purchased on the Azure website.",
                "A free trial subscription."
            ], "A",
            """
            Under a Cloud Solution Provider arrangement a Microsoft partner owns the customer
            relationship: it manages the subscription, issues the invoice and provides first-line
            support, which matches all three requirements in the stem.

            An Enterprise Agreement is a direct volume agreement with Microsoft and is aimed at
            large organisations with committed spend, and a web direct purchase leaves the customer
            managing everything itself.
            """,
            """
            The stem lists three responsibilities. Ask which option moves all three to a third
            party rather than just one.
            """);

        yield return Mc("cm-030", D3, "Describe cost management in Azure", R7,
            """
            Which two statements about the Azure free account are correct? Each correct answer
            presents a complete solution.
            """,
            [
                "It includes a credit that must be used during the first 30 days.",
                "It includes a set of popular services that remain free for 12 months.",
                "It never requires a payment method to be registered.",
                "It converts to a pay-as-you-go subscription automatically after 30 days.",
                "It provides unlimited use of every Azure service for 12 months."
            ], "A,B",
            """
            The free account combines a credit usable within the first thirty days, a set of popular
            services free for twelve months, and a further set that is always free within monthly
            limits.

            The three distractors are the practical details people get wrong. A payment method is
            required at sign-up even though it is not charged, the account does not convert by
            itself, and the free usage is capped per service rather than unlimited.
            """,
            """
            Two of these are about the offer itself and three are about how it behaves at sign-up
            and expiry. The second group contains no correct answers.
            """);
    }
}
