using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

/// <summary>
/// The AZ-900 skills outline as Microsoft publishes it (skills measured as of July 20, 2026):
/// three domains and the eleven objectives beneath them, each mapped onto the question bank.
///
/// Questions find their objective through the <see cref="Item.Objective"/> they already carry.
/// That field follows the study guide's grouping, which the outline does not always share, so
/// the few questions the two disagree on are claimed by id.
/// </summary>
public static class SkillsOutline
{
    private static readonly ExamDomain D1 = AzureDomains.CloudConcepts;
    private static readonly ExamDomain D2 = AzureDomains.ArchitectureAndServices;
    private static readonly ExamDomain D3 = AzureDomains.ManagementAndGovernance;

    public static IReadOnlyList<SkillsSection> Az900 { get; } =
    [
        // ------------------------------------------------------- Describe cloud concepts

        new()
        {
            Key = "1.1",
            Title = "Describe cloud computing",
            Domain = D1,
            Summary = "Cloud models, the shared responsibility model, the consumption-based model and pricing.",
            Objectives =
            [
                "Describe cloud computing",
                "Describe the shared responsibility model",
                "Describe the benefits of cloud computing"
            ]
        },
        new()
        {
            Key = "1.2",
            Title = "Describe the benefits of using cloud services",
            Domain = D1,
            Summary = "High availability, scalability and elasticity, reliability and predictability.",
            Objectives = ["Describe the benefits of high availability and scalability"],

            // Elasticity and agility, which the bank files with the financial benefits.
            Claims = ["cc-049", "cc-059"]
        },
        new()
        {
            Key = "1.3",
            Title = "Describe cloud service types",
            Domain = D1,
            Summary = "Infrastructure, platform and software as a service, and when each one fits.",
            Objectives = ["Describe cloud service types"]
        },

        // --------------------------------------- Describe Azure architecture and services

        new()
        {
            Key = "2.1",
            Title = "Describe the core architectural components of Azure",
            Domain = D2,
            Summary = "Regions, availability zones, resource groups, subscriptions, management groups and billing scopes.",
            Objectives =
            [
                "Describe the core architectural components of Azure",
                "Describe Azure billing concepts"
            ]
        },
        new()
        {
            Key = "2.2",
            Title = "Describe Azure compute and networking services",
            Domain = D2,
            Summary = "Virtual machines, containers, functions, application hosting and Azure data services. Networking is not in this bank.",
            Objectives =
            [
                "Describe Azure compute services",
                "Describe Azure compute and data services"
            ]
        },
        new()
        {
            Key = "2.3",
            Title = "Describe Azure storage services",
            Domain = D2,
            Summary = "Storage services, access tiers, redundancy, storage accounts, moving files and migration.",
            Objectives = ["Describe Azure storage services"]
        },
        new()
        {
            Key = "2.4",
            Title = "Describe Azure identity, access, and security",
            Domain = D2,
            Summary = "Microsoft Entra ID, authentication, Conditional Access, RBAC, Zero Trust, defence in depth and Defender for Cloud.",
            Objectives = ["Describe Azure identity, access, and security"]
        },

        // -------------------------------------- Describe Azure management and governance

        new()
        {
            Key = "3.1",
            Title = "Describe cost management in Azure",
            Domain = D3,
            Summary = "Cost factors, the pricing and TCO calculators, Cost Management, tags, purchasing options and SLAs.",

            // Service level agreements left the outline in 2022. The study guide still teaches
            // them alongside pricing, so they stay with cost management rather than vanish.
            Objectives =
            [
                "Describe cost management in Azure",
                "Describe Azure service level agreements"
            ],

            // The outline lists the purpose of tags here, not under governance.
            Claims = ["gv-011"]
        },
        new()
        {
            Key = "3.2",
            Title = "Describe features and tools in Azure for governance and compliance",
            Domain = D3,
            Summary = "Microsoft Purview, Azure Policy, resource locks and Microsoft's compliance resources.",
            Objectives = ["Describe features and tools for governance and compliance"]
        },
        new()
        {
            Key = "3.3",
            Title = "Describe features and tools for managing and deploying Azure resources",
            Domain = D3,
            Summary = "The Azure portal, Cloud Shell, Azure CLI and PowerShell, Azure Arc, infrastructure as code and ARM.",
            Objectives = ["Describe features and tools for managing Azure resources"]
        },
        new()
        {
            Key = "3.4",
            Title = "Describe monitoring tools in Azure",
            Domain = D3,
            Summary = "Azure Advisor, Azure Service Health and Azure Monitor.",
            Objectives = ["Describe monitoring tools in Azure"]
        }
    ];
}
