using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Chapter 7 of the study guide: Azure Pricing, Service Levels, and Lifecycle (pages 262-288).
// Original wording written against the factual content of that chapter.
public static partial class TrainingCatalog
{
    private const string M6 = "Study guide, ch. 7: Azure Pricing, Service Levels, and Lifecycle";

    private static TrainingModule PricingModule() => new()
    {
        Id = "m6",
        Title = "Pricing, SLAs and lifecycle",
        Domain = AzureDomains.ManagementAndGovernance,
        Reference = M6,
        Pages = "ch. 7, p262-288",
        Blurb = "What drives the bill, what reduces it, what Microsoft promises about "
              + "availability, and how long a service lasts.",
        Lessons =
        [
            new Lesson
            {
                Id = "m6-l1",
                Title = "What affects the cost of a resource",
                Objective = "Describe cost management in Azure",
                Pages = "p262-268",
                Intro = Para("""
                    Several independent factors set the price of a resource. The exam expects you
                    to separate the ones that genuinely change the amount charged from the ones
                    that only help you report on it.
                    """),
                Points =
                [
                    "Each resource or service has its own cost, varying by size, tier and other characteristics.",
                    "Location affects cost: the same resource can be priced differently in different regions.",
                    "Network traffic between regions can incur additional charges, which has to be factored into a deployment design.",
                    "Data moving into an Azure data centre (ingress) is not charged; data leaving (egress) is.",
                    "Compute charges stop when a virtual machine is deallocated, but its disks still exist and are still billed.",
                    "Deleting a virtual machine does not delete its associated resources; the network interface, public IP address and disks survive and keep incurring charges."
                ],
                Essentials =
                [
                    "Only one direction of network traffic is charged. A chatty application split across regions pays for every response leaving the far region.",
                    "Shutting a machine down inside the guest is not the same as deallocating it. The allocation, and the charge, remain.",
                    "Tags are central to cost management and change no price at all."
                ]
            },

            new Lesson
            {
                Id = "m6-l2",
                Title = "Reducing cost",
                Objective = "Describe cost management in Azure",
                Pages = "p268-274",
                Intro = Para("""
                    Azure offers several discount mechanisms, and they discount different parts
                    of the bill, so more than one can apply to the same workload.
                    """),
                Points =
                [
                    "Azure Reservations let you prepay for a service and receive a discount matching the length of the commitment, with one-year and three-year terms.",
                    "Payment flexibility allows the commitment to be spread across the agreement rather than paid as a single lump sum.",
                    "Azure Hybrid Benefit lets you apply Windows Server and SQL Server licences covered by Software Assurance to Azure workloads, lowering licensing cost.",
                    "Spot pricing uses spare capacity at a deep discount, in exchange for instances that can be evicted at short notice.",
                    "Right-sizing removes waste by matching instance size to actual consumption, and Azure Advisor surfaces the opportunities.",
                    "Spending limits and promotional offers provide further control over cost."
                ],
                Essentials =
                [
                    "A reservation discounts compute; Hybrid Benefit removes the licence component. They apply to different parts of the bill and can be combined.",
                    "Spot capacity suits work that can be interrupted and resumed. Anything that must stay reachable is a poor fit.",
                    "A reservation is still operational expenditure. Paying up front does not make it a purchased asset."
                ]
            },

            new Lesson
            {
                Id = "m6-l3",
                Title = "Estimating and managing cost",
                Objective = "Describe cost management in Azure",
                Pages = "p274-278",
                Intro = Para("""
                    Different tools serve different moments: before you deploy, and after. Two
                    of them are calculators used in advance, and one reports on money already
                    spent.
                    """),
                Points =
                [
                    "The Pricing Calculator estimates the cost of a specific proposed set of Azure resources, before anything is deployed and without needing a subscription.",
                    "The Total Cost of Ownership Calculator compares the cost of running workloads on-premises with the cost of running them in Azure. It has been deprecated and its capabilities delivered through Azure Migrate.",
                    "Microsoft Cost Management analyses actual spending, and supports budgets, threshold alerts, forecasting, scheduled reports and exports.",
                    "A budget alert notifies when spending crosses a threshold; it does not stop resources running.",
                    "Tags allow spending to be grouped and filtered so cost can be attributed to the department that consumed it.",
                    "Azure Advisor identifies opportunities to reduce cost once resources are running."
                ],
                Essentials =
                [
                    "The Pricing Calculator prices a planned Azure configuration; only the TCO route models the on-premises side of a comparison.",
                    "A budget is a monitoring construct, not a control. Enforcing a limit needs automation triggered by the alert, or policy restricting what may be deployed.",
                    "Because the TCO Calculator is deprecated in favour of Azure Migrate, expect either name to appear depending on when the exam was last refreshed."
                ]
            },

            new Lesson
            {
                Id = "m6-l4",
                Title = "Service level agreements",
                Objective = "Describe Azure service level agreements",
                Pages = "p278-281",
                Intro = Para("""
                    An SLA is a commitment about availability. Two things matter for the exam:
                    what the percentage is actually promising, and what happens when you chain
                    several services together.
                    """),
                Points =
                [
                    "An SLA is an agreement between Microsoft and the customer regarding the availability of a service. Many, but not all, Azure services have one.",
                    "Availability measures whether a service can be reached and used. Reduced performance is not counted as unavailability.",
                    "When services are chained so that all must be available, their individual SLAs multiply to give the composite SLA.",
                    "Because multiplying values below one always gives a smaller result, a composite SLA is lower than any single component, and falls further with each added dependency.",
                    "Choosing a higher tier or service level can improve a service's SLA, and the disk type chosen for a virtual machine affects its SLA.",
                    "Deploying virtual machines across two or more availability zones raises the SLA for the workload."
                ],
                Essentials =
                [
                    "Multiply, never average and never take the best or worst. The correct composite is smaller than every input.",
                    "Adding a dependent service lowers the composite SLA; adding a redundant alternative raises availability. Do not confuse the two.",
                    "Service credits are not automatic. The customer submits a claim, and the remedy is a credit against service charges rather than compensation for lost business."
                ]
            },

            new Lesson
            {
                Id = "m6-l5",
                Title = "The Azure service lifecycle",
                Objective = "Describe Azure service level agreements",
                Pages = "p281-284",
                Intro = Para("""
                    Azure services move through preview to general availability. What separates
                    the phases is not who can access them but what Microsoft promises about them.
                    """),
                Points =
                [
                    "Preview features are effectively in beta and are not guaranteed to reach general availability.",
                    "Preview features are not subject to SLAs or the limited warranty in the Online Service Terms, may not be covered by support, and can carry different security, compliance and privacy commitments.",
                    "Most previews are public and available to every Azure customer. Some are private, offered to selected organisations by invitation.",
                    "General availability is the next phase, and services in it are subject to the published SLAs and the other terms and warranties in the Online Service Terms.",
                    "Reaching general availability does not guarantee a service will be offered forever. Microsoft does deprecate and retire services.",
                    "The modern lifecycle policy provides a minimum of 12 months' notice before a generally available feature is retired."
                ],
                Essentials =
                [
                    "Public preview means open to everyone, not ready for production. Openness and readiness are different properties, and this is the trap.",
                    "General availability is the first phase at which anything is promised, so it is the earliest point a production workload should take a dependency.",
                    "Track lifecycle announcements for services you already run: the 12-month notice is what gives you time to react."
                ]
            }
        ]
    };
}
