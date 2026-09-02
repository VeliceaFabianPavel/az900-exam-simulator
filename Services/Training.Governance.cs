using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Chapter 6 of the study guide: Azure Monitoring, Governance, and Compliance (pages 233-261).
// Original wording written against the factual content of that chapter.
public static partial class TrainingCatalog
{
    private const string M5 = "Study guide, ch. 6: Governance, Monitoring, and Compliance";

    private static TrainingModule GovernanceModule() => new()
    {
        Id = "m5",
        Title = "Governance, monitoring and compliance",
        Domain = AzureDomains.ManagementAndGovernance,
        Reference = M5,
        Pages = "ch. 6, p233-261",
        Blurb = "Enforcing standards on what gets deployed, watching what it does, and "
              + "demonstrating compliance afterwards.",
        Lessons =
        [
            new Lesson
            {
                Id = "m5-l1",
                Title = "Azure Policy and initiatives",
                Objective = "Describe features and tools for governance and compliance",
                Pages = "p233-240",
                Intro = Para("""
                    Policy governs what a resource may look like. It is the counterpart to
                    role-based access control, which governs who may act at all, and the two
                    answer genuinely different questions.
                    """),
                Points =
                [
                    "Azure Policy defines business rules controlling how resources are deployed and used, and provides the means to create, manage and apply them.",
                    "An initiative is a group of policies deployed together to meet a collective governance goal.",
                    "Policy assignments are made at management group, subscription or resource group scope, and apply to everything beneath unless excluded.",
                    "The audit effect records non-compliance while allowing the resource, which makes it the safe effect for introducing a new rule.",
                    "The deny effect blocks the operation outright. Other effects append properties to a request or deploy a missing related resource.",
                    "If a scope is assigned two or more initiatives containing conflicting policies, Azure marks the affected resources with a compliance state of conflicting."
                ],
                Essentials =
                [
                    "Policy applies to everyone equally, including subscription owners, and grants no permissions. RBAC grants permissions and constrains nobody's choice of region or size.",
                    "Assigning at a management group is what makes a rule reach subscriptions created later."
                ]
            },

            new Lesson
            {
                Id = "m5-l2",
                Title = "Resource locks and tags",
                Objective = "Describe features and tools for governance and compliance",
                Pages = "p240-244",
                Intro = Para("""
                    Two lightweight governance features. Locks restrict what can be done to a
                    resource; tags describe it. Neither does what people commonly assume.
                    """),
                Points =
                [
                    "A ReadOnly lock lets authorised administrators read a resource but not update or delete it.",
                    "A CanNotDelete lock lets them read and modify the resource but not delete it.",
                    "Locks are inherited from parent scopes, and where several apply, the most restrictive wins.",
                    "Locks apply to every user regardless of role, so even an Owner must remove the lock before deleting.",
                    "Tags are name and value pairs attached to resources, used to record owner, environment or cost centre and to group spending in cost reporting."
                ],
                Essentials =
                [
                    "Locks resolve to the most restrictive; RBAC resolves to the most permissive. Two overlapping-scope rules pointing in opposite directions.",
                    "Locks act on the resource, not on the data inside it. A ReadOnly lock on a database stops it being reconfigured, not rows being written.",
                    "Tags are not inherited by resources from their resource group, and they never change what a resource costs. They make cost attributable, not cheaper."
                ]
            },

            new Lesson
            {
                Id = "m5-l3",
                Title = "Azure Monitor, Log Analytics and Application Insights",
                Objective = "Describe monitoring tools in Azure",
                Pages = "p244-250",
                Intro = Para("""
                    Azure Monitor is the umbrella. Underneath it sit the store you query and the
                    component that instruments your own application, and questions usually turn
                    on which piece does which job.
                    """),
                Points =
                [
                    "Azure Monitor is a group of services providing reporting, analysis and alerting, and it captures data as both metrics and logs.",
                    "Metrics are numeric values describing how a resource is performing or what it is consuming at a point in time.",
                    "Logs capture data about events that happen in Azure, and can hold varied structured data.",
                    "Monitoring begins automatically when a resource is added to a subscription; logs and metrics do not have to be configured by hand.",
                    "Log Analytics is where log data is stored in tables and queried, with results visualised and pinned to dashboards.",
                    "Application Insights lets developers send telemetry from their own applications into Azure for monitoring and reporting.",
                    "An action group is a reusable collection of notifications and actions invoked when an alert fires."
                ],
                Essentials =
                [
                    "Application Insights produces application telemetry; Log Analytics stores and queries it. They are two halves of one relationship, not alternatives.",
                    "Monitoring starting automatically is a favourite exam point: you do not create metrics and logs before monitoring begins."
                ]
            },

            new Lesson
            {
                Id = "m5-l4",
                Title = "Service Health, Resource Health and Advisor",
                Objective = "Describe monitoring tools in Azure",
                Pages = "p250-254",
                Intro = Para("""
                    Three health views that differ only in how narrow they are, plus one service
                    that reads your usage and tells you what to change.
                    """),
                Points =
                [
                    "Azure Status shows the global health of Azure services by geography and region, publicly.",
                    "Azure Service Health narrows that to the services and regions your own subscriptions use, and covers planned maintenance, health advisories, security advisories and billing updates.",
                    "Resource Health is a component of Service Health and reports on your individual resources.",
                    "Azure Advisor analyses resource configuration and usage telemetry and produces personalised, actionable recommendations.",
                    "Advisor groups its recommendations into five categories: cost optimisation, security, reliability, operational excellence and performance efficiency."
                ],
                Essentials =
                [
                    "Sort the three health views from widest to narrowest: Status is global and public, Service Health is personalised, Resource Health is per resource.",
                    "Azure Monitor shows you the data; Advisor reads it and tells you what to do about it. That is the line between them.",
                    "Advisor's five categories mirror the pillars of the Azure Well-Architected Framework."
                ]
            },

            new Lesson
            {
                Id = "m5-l5",
                Title = "Purview, privacy and compliance resources",
                Objective = "Describe features and tools for governance and compliance",
                Pages = "p254-258",
                Intro = Para("""
                    Several Microsoft compliance destinations with similar names. Separate them
                    by what each one gives you: an explanation, a document, or a score.
                    """),
                Points =
                [
                    "Microsoft Purview provides unified data governance, discovering and classifying data across on-premises, Azure, other clouds and SaaS applications, and cataloguing it.",
                    "The Microsoft Privacy Statement describes what personal data Microsoft processes, and how and why.",
                    "The Trust Center is a Microsoft website covering security, privacy, compliance and transparency.",
                    "The Service Trust Portal is the public site for audit and compliance reports for Azure, and it hosts Compliance Manager.",
                    "Compliance Manager uses a workflow-based risk assessment to produce a compliance score, and lets improvement actions be assigned and tracked.",
                    "Non-regulatory bodies such as ISO, IEC and NIST publish standards but do not enforce them. HIPAA and GDPR are regulations enforced by governmental bodies."
                ],
                Essentials =
                [
                    "The Trust Center is informational only. It performs no risk assessment on your resources and applies no settings or policies; enforcement is Azure Policy.",
                    "Compliance Manager measures and recommends but cannot guarantee compliance, which remains the organisation's responsibility.",
                    "NIST is a government agency whose publications are still standards rather than law. The test is who can impose a penalty."
                ]
            },

            new Lesson
            {
                Id = "m5-l6",
                Title = "Azure Government and Azure China",
                Objective = "Describe features and tools for governance and compliance",
                Pages = "p258-261",
                Intro = Para("""
                    Two physically isolated instances of Azure built for particular regulatory
                    regimes. The exam asks who may use them and how separate they really are.
                    """),
                Points =
                [
                    "Azure Government is an isolated instance supporting US federal, state and local government and the solution providers serving them, supported and managed by screened US personnel.",
                    "Azure China is an isolated instance hosted and operated by 21Vianet under licence from Microsoft, because Chinese rules require a value-added telecom permit held by a company with less than 50 percent foreign investment.",
                    "Azure China is not restricted to Chinese government agencies. It is open to any organisation doing business in China that must meet Chinese regulations.",
                    "Connections between Azure China and sites within China use ExpressRoute; connections to sites outside China use a site-to-site VPN. In both cases the service must come from a telecom provider licensed by the Chinese Ministry of Industry and Information Technology.",
                    "Accounts cannot be moved between global Azure and Azure China; a separate account is required, and cross-border data transfer is subject to security assessment and government approval."
                ],
                Essentials =
                [
                    "Isolation reaches the tenant, not just the data centre. Separate accounts and subscriptions, no transfers.",
                    "An accredited platform does not make your workload compliant. Shared responsibility still applies to how you configure and operate what you deploy."
                ]
            }
        ]
    };
}
