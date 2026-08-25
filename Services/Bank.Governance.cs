using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Domain 3, governance / monitoring / compliance portion. Sourced from chapter 6.
public static partial class QuestionBank
{
    private const string R6 = "Study guide, ch. 6: Governance, Monitoring, and Compliance";

    private static IEnumerable<Item> GovernanceAndCompliance()
    {
        // ---------------------------------------------------------- policy and initiatives

        yield return Mc("gv-001", D3, "Describe features and tools for governance and compliance", R6,
            """
            Your organisation requires that virtual machines can only be created in two approved
            regions and only in approved sizes.

            Which service should you use to enforce this?
            """,
            [
                "Azure Policy.",
                "Azure role-based access control.",
                "A resource lock.",
                "Microsoft Cost Management."
            ], "A",
            """
            Azure Policy defines business rules that resources must satisfy, and it can deny the
            creation of resources that do not comply, such as a virtual machine in an unapproved
            region or of an unapproved size.

            Role-based access control determines who can act at all, but it cannot restrict which
            regions or sizes an authorised user may choose.
            """);

        yield return Mc("gv-002", D3, "Describe features and tools for governance and compliance", R6,
            """
            What is the difference between Azure Policy and Azure role-based access control?
            """,
            [
                "Azure Policy controls what resource configurations are permitted, whereas role-based access control controls who may perform actions.",
                "Azure Policy controls who may perform actions, whereas role-based access control controls what configurations are permitted.",
                "Azure Policy replaces role-based access control.",
                "They are two names for the same feature."
            ], "A",
            """
            Azure Policy governs the properties of resources: which types, regions, sizes and
            settings are acceptable. It applies to everyone equally and does not grant any
            permissions.

            Role-based access control governs identity: which security principals may perform which
            operations at which scopes. The two are used together.
            """);

        yield return Mc("gv-003", D3, "Describe features and tools for governance and compliance", R6,
            """
            Which Azure Policy effect records non-compliant resources without preventing them from
            being created?
            """,
            ["Audit.", "Deny.", "Append.", "DeployIfNotExists."], "A",
            """
            The audit effect logs a compliance violation so it appears in compliance reporting, but
            it allows the resource to be created. This makes it useful when introducing a new rule
            before enforcing it.

            Deny blocks the operation, append adds properties to the request, and deployIfNotExists
            provisions a related resource when the condition is met.
            """);

        yield return Drag("gv-004", D3, "Describe features and tools for governance and compliance", R6,
            """
            Match each Azure Policy effect to its behaviour. Each effect may be used once, more
            than once, or not at all.
            """,
            "Policy effects",
            [
                "Deny",
                "Audit",
                "Append",
                "DeployIfNotExists"
            ],
            [
                ("Block the creation of a non-compliant resource", 1),
                ("Record non-compliance but permit the resource", 2),
                ("Add a required property to the resource request", 3),
                ("Provision an additional resource when a condition is met", 4)
            ],
            """
            Deny is the enforcing effect and audit is the observing one, which is why audit is
            commonly used first when a new rule is rolled out.

            Append modifies the incoming request by adding required properties, and
            deployIfNotExists triggers a remediation deployment when the specified resource is
            missing.
            """);

        yield return Mc("gv-005", D3, "Describe features and tools for governance and compliance", R6,
            """
            What is an Azure Policy initiative?
            """,
            [
                "A group of related policy definitions that are assigned together to achieve a broader governance goal.",
                "A single policy definition written in JSON.",
                "A collection of role assignments applied to a management group.",
                "A schedule for applying Azure updates."
            ], "A",
            """
            An initiative, also called a policy set, groups multiple policy definitions so they can
            be assigned and tracked as one unit. Securing a service typically requires several
            policies working together, which is exactly what an initiative packages.

            Initiatives are assigned at the same scopes as individual policies and do not grant any
            permissions.
            """);

        yield return Mc("gv-006", D3, "Describe features and tools for governance and compliance", R6,
            """
            At which scopes can an Azure Policy assignment be applied?
            """,
            [
                "Management group, subscription and resource group.",
                "Tenant and geography only.",
                "Resource only.",
                "Billing account and billing profile."
            ], "A",
            """
            Policy assignments are made at a management group, a subscription or a resource group,
            and they apply to all child objects unless exclusions are configured.

            Assigning at a management group is the usual way to apply a rule consistently across
            many subscriptions at once.
            """);

        // ---------------------------------------------------------- locks and tags

        yield return Mc("gv-007", D3, "Describe features and tools for governance and compliance", R6,
            """
            You must prevent a production storage account from being deleted accidentally, while
            still allowing administrators to change its configuration.

            Which lock type should you apply?
            """,
            ["CanNotDelete.", "ReadOnly.", "Deny.", "Audit."], "A",
            """
            A CanNotDelete lock allows authorised users to read and modify the resource but blocks
            deletion, which is exactly the protection described.

            A ReadOnly lock would also block configuration changes, and deny and audit are Azure
            Policy effects rather than lock types.
            """);

        yield return Mc("gv-008", D3, "Describe features and tools for governance and compliance", R6,
            """
            A resource group has a CanNotDelete lock, and a resource inside it has a ReadOnly lock.

            What is the effective protection on that resource?
            """,
            [
                "ReadOnly, because the most restrictive lock applies.",
                "CanNotDelete, because the lock closest to the subscription wins.",
                "No lock, because the two conflict and cancel out.",
                "Both locks are ignored until one is removed."
            ], "A",
            """
            Locks are inherited from parent scopes, and when more than one applies, the most
            restrictive takes effect. ReadOnly is more restrictive than CanNotDelete because it
            also blocks updates.

            Locks are not additive in the way that role assignments are, and they never cancel each
            other out.
            """);

        yield return Mc("gv-009", D3, "Describe features and tools for governance and compliance", R6,
            """
            A user has the Owner role on a subscription. A resource in that subscription has a
            CanNotDelete lock.

            Can the user delete the resource?
            """,
            [
                "No, the lock must be removed first, even though the user is an Owner.",
                "Yes, because the Owner role overrides resource locks.",
                "Yes, but only through Azure PowerShell.",
                "No, and the lock can never be removed once applied."
            ], "A",
            """
            Resource locks apply to all users regardless of role. Even an Owner has to remove the
            lock before the delete operation will succeed, which is what makes locks an effective
            guard against accidental deletion.

            The lock can be removed by a user with the appropriate permissions; it is not
            permanent.
            """);

        yield return YesNo("gv-010", D3, "Describe features and tools for governance and compliance", R6,
            """
            For each of the following statements about resource locks, select Yes if the statement
            is true. Otherwise, select No.
            """,
            [
                ("A lock applied to a resource group is inherited by the resources it contains.", true),
                ("A lock can be scoped to apply to specific users only.", false),
                ("A ReadOnly lock on a database resource prevents updating rows inside the database.", false)
            ],
            """
            Locks are inherited downward through the scope hierarchy and apply uniformly to every
            user; they cannot be targeted at particular roles or individuals.

            Locks operate at the resource management level rather than inside the service, so a
            ReadOnly lock stops the database resource from being reconfigured but does not stop
            data being written to it.
            """);

        yield return Mc("gv-011", D3, "Describe features and tools for governance and compliance", R6,
            """
            Which two purposes do resource tags serve? Each correct answer presents a complete
            solution.
            """,
            [
                "Grouping resources for cost reporting and chargeback.",
                "Identifying the owner or environment of a resource for management purposes.",
                "Encrypting the contents of a resource.",
                "Preventing a resource from being deleted.",
                "Determining the region in which a resource runs."
            ], "A,B",
            """
            Tags are name and value pairs attached to resources, and they support both cost
            reporting, by allowing spending to be grouped and filtered, and operational
            organisation, by recording facts such as owner, environment or cost centre.

            Tags provide no encryption, no deletion protection and no influence over placement.
            """);

        // ---------------------------------------------------------- monitoring

        yield return Mc("gv-012", D3, "Describe monitoring tools in Azure", R6,
            """
            Which service collects and analyses telemetry from Azure and on-premises environments,
            and can raise alerts and trigger actions based on that data?
            """,
            [
                "Azure Monitor.",
                "Azure Advisor.",
                "Azure Service Health.",
                "Azure Policy."
            ], "A",
            """
            Azure Monitor is the umbrella service for telemetry. It gathers metrics, logs and
            traces from resources, supports querying and visualisation, and raises alerts that can
            trigger automated actions.

            Advisor gives optimisation recommendations, Service Health reports on Azure platform
            health, and Policy enforces configuration rules.
            """);

        yield return Mc("gv-013", D3, "Describe monitoring tools in Azure", R6,
            """
            What is the difference between metrics and logs in Azure Monitor?
            """,
            [
                "Metrics are numerical values describing a system at a point in time, whereas logs are records of events that can hold varied structured data.",
                "Metrics are records of events, whereas logs are numerical point-in-time values.",
                "Metrics are stored only on-premises, whereas logs are stored only in Azure.",
                "Metrics must be configured manually, whereas logs are collected automatically."
            ], "A",
            """
            Metrics are lightweight numerical samples that describe some aspect of a system at a
            specific moment, such as bytes stored or requests processed.

            Logs record events and can contain many different types of structured data. They are
            stored in tables in a Log Analytics workspace and are queried rather than charted
            directly. Both begin to be collected automatically when a resource is added.
            """);

        yield return Mc("gv-014", D3, "Describe monitoring tools in Azure", R6,
            """
            A development team must monitor the performance and usage of a live web application and
            send custom telemetry from the application code.

            Which component of Azure Monitor should they use?
            """,
            [
                "Application Insights.",
                "Log Analytics.",
                "Azure Advisor.",
                "Azure Service Health."
            ], "A",
            """
            Application Insights is the application performance monitoring component of Azure
            Monitor. Developers instrument their application so it sends telemetry, which is then
            used to understand performance, failures and usage patterns.

            Log Analytics is the workspace and query engine that stores and analyses log data,
            including the data Application Insights produces.
            """);

        yield return Mc("gv-015", D3, "Describe monitoring tools in Azure", R6,
            """
            Which component of Azure Monitor is used to write queries against collected log data
            and analyse the results?
            """,
            [
                "Log Analytics.",
                "Application Insights.",
                "Azure Advisor.",
                "Azure Policy."
            ], "A",
            """
            Log Analytics provides the workspace in which log data is stored in tables and the
            query environment used to interrogate it, so results can be analysed, charted and
            pinned to dashboards.

            Application Insights supplies application telemetry into that store rather than
            replacing it.
            """);

        yield return Drag("gv-016", D3, "Describe monitoring tools in Azure", R6,
            """
            Match each requirement to the appropriate Azure service. Each service may be used once,
            more than once, or not at all.
            """,
            "Services",
            [
                "Azure Monitor",
                "Azure Advisor",
                "Azure Service Health",
                "Azure Policy"
            ],
            [
                ("Collect metrics and logs from resources and raise alerts", 1),
                ("Receive recommendations to improve cost, security and reliability", 2),
                ("Learn about a planned maintenance event affecting your resources", 3),
                ("Prevent resources from being created in unapproved regions", 4)
            ],
            """
            Azure Monitor handles telemetry collection and alerting, and Azure Advisor produces
            prioritised optimisation recommendations.

            Azure Service Health communicates planned maintenance and incidents affecting the
            services you use, and Azure Policy enforces configuration rules such as permitted
            regions.
            """);

        // ---------------------------------------------------------- service health

        yield return Mc("gv-017", D3, "Describe monitoring tools in Azure", R6,
            """
            You need to determine whether a problem is caused by an issue affecting one specific
            virtual machine you own, rather than a broader Azure outage.

            Which tool should you use?
            """,
            [
                "Resource Health.",
                "Azure Status.",
                "Azure Advisor.",
                "The Azure Pricing Calculator."
            ], "A",
            """
            Resource Health reports on the health of your individual resources, showing whether a
            specific resource is available and listing recent events such as unplanned reboots or
            degradation.

            Azure Status shows the global health of Azure services by region and would not
            distinguish an issue confined to one of your resources.
            """);

        yield return Mc("gv-018", D3, "Describe monitoring tools in Azure", R6,
            """
            Which tool provides a global view of the health of Azure services by region, including
            active incidents and outages?
            """,
            [
                "Azure Status.",
                "Resource Health.",
                "Azure Monitor.",
                "Microsoft Cost Management."
            ], "A",
            """
            Azure Status is the global health view showing which Azure services are affected in
            which regions, and it is the right starting point when a widespread problem is
            suspected.

            Service Health narrows that view to the services and regions you actually use, and
            Resource Health narrows it further to your specific resources.
            """);

        yield return Dropdowns("gv-019", D3, "Describe monitoring tools in Azure", R6,
            """
            Select the answer choice that completes each statement based on the information
            presented.
            """,
            [
                ("To view the global health of Azure services by region, use",
                    ["Azure Status", "Service Health", "Resource Health", "Azure Advisor"], 1),
                ("To receive personalised notice of planned maintenance affecting your subscriptions, use",
                    ["Azure Status", "Service Health", "Resource Health", "Azure Monitor"], 2),
                ("To check whether one particular virtual machine you own is currently healthy, use",
                    ["Azure Status", "Service Health", "Resource Health", "Azure Policy"], 3)
            ],
            """
            The three views narrow progressively. Azure Status is global, Service Health is
            personalised to the services and regions in your subscriptions, and Resource Health
            reports on your individual resources.

            Service Health is also the source of health advisories, security advisories and billing
            updates.
            """);

        yield return Mc("gv-020", D3, "Describe monitoring tools in Azure", R6,
            """
            Which categories of information does Azure Service Health provide?
            """,
            [
                "Planned maintenance, health advisories, security advisories and billing updates.",
                "Cost forecasts, budgets, invoices and purchase orders.",
                "Role assignments, policy assignments and lock definitions.",
                "Virtual machine sizes, storage tiers and regional pricing."
            ], "A",
            """
            Service Health delivers personalised information in four categories: upcoming planned
            maintenance, health advisories describing service changes, security advisories, and
            billing updates covering pricing and metering changes.

            It also includes Resource Health, which reports on the health of your own resources.
            """);

        yield return Mc("gv-021", D3, "Describe monitoring tools in Azure", R6,
            """
            What is the purpose of an action group in Azure?
            """,
            [
                "It defines the set of notifications and automated actions to perform when an alert is triggered.",
                "It groups Azure resources for billing purposes.",
                "It groups users for the purpose of role assignment.",
                "It defines which Azure regions a subscription may use."
            ], "A",
            """
            An action group is a reusable collection of notification preferences and actions, such
            as sending email, sending a text message or calling a webhook, that is invoked when an
            alert fires.

            Reusing action groups across alerts is what makes alerting consistent across an
            organisation.
            """);

        // ---------------------------------------------------------- advisor

        yield return Mc("gv-022", D3, "Describe monitoring tools in Azure", R6,
            """
            Which service analyses your resource configuration and usage telemetry and then
            provides personalised recommendations to improve your environment?
            """,
            [
                "Azure Advisor.",
                "Azure Monitor.",
                "Azure Policy.",
                "Microsoft Purview."
            ], "A",
            """
            Azure Advisor continuously analyses resource configuration and usage telemetry, then
            presents actionable recommendations and an Advisor score reflecting how closely the
            environment follows best practice.

            Recommendations can be filtered by subscription, resource group and category.
            """);

        yield return Mc("gv-023", D3, "Describe monitoring tools in Azure", R6,
            """
            Azure Advisor groups its recommendations into five categories.

            Which set correctly lists them?
            """,
            [
                "Cost optimisation, security, reliability, operational excellence and performance efficiency.",
                "Cost, compliance, capacity, connectivity and continuity.",
                "Availability, durability, scalability, elasticity and agility.",
                "Identity, network, compute, storage and data."
            ], "A",
            """
            Advisor's five categories mirror the pillars of the Microsoft Azure Well-Architected
            Framework: cost optimisation, security, reliability, operational excellence and
            performance efficiency.

            The other lists mix together concepts from elsewhere in the syllabus and are not
            Advisor categories.
            """);

        // ---------------------------------------------------------- purview and compliance

        yield return Mc("gv-024", D3, "Describe features and tools for governance and compliance", R6,
            """
            Which solution provides unified data governance across on-premises, Azure, other clouds
            and software as a service applications, including data discovery, classification and
            cataloguing?
            """,
            [
                "Microsoft Purview.",
                "Azure Monitor.",
                "Azure Advisor.",
                "Azure Key Vault."
            ], "A",
            """
            Microsoft Purview is the unified data governance, security and compliance family. It
            discovers and classifies data across a hybrid estate, builds a data map, and provides a
            catalogue for curating and securing that data.

            It also hosts risk and compliance capabilities such as audit, data lifecycle
            management, eDiscovery and Compliance Manager.
            """);

        yield return Mc("gv-025", D3, "Describe features and tools for governance and compliance", R6,
            """
            Which website provides Microsoft's published information about security, privacy,
            compliance and transparency practices?
            """,
            [
                "The Microsoft Trust Center.",
                "The Azure Pricing Calculator.",
                "The Azure portal dashboard.",
                "Azure Advisor."
            ], "A",
            """
            The Microsoft Trust Center publishes how Microsoft approaches security, privacy,
            compliance and transparency, and it helps customers design compliant solutions.

            It is informational: it does not assess the risk of your resources, does not recommend
            configuration changes, and does not enforce policy.
            """);

        yield return Mc("gv-026", D3, "Describe features and tools for governance and compliance", R6,
            """
            An auditor asks for a copy of Microsoft's independent audit reports for Azure.

            Where should you obtain them?
            """,
            [
                "The Service Trust Portal.",
                "The Azure portal Activity log.",
                "Azure Advisor.",
                "The Azure Pricing Calculator."
            ], "A",
            """
            The Service Trust Portal is the public site where Microsoft publishes audit reports and
            compliance documentation for its cloud services, and it is where those reports can be
            downloaded for internal or third-party auditors.

            It also hosts Compliance Manager, which tracks an organisation's own compliance
            activities.
            """);

        yield return Mc("gv-027", D3, "Describe features and tools for governance and compliance", R6,
            """
            Which tool provides a risk-based compliance score and lets you assign and track
            compliance improvement actions across your organisation?
            """,
            [
                "Compliance Manager.",
                "The Microsoft Trust Center.",
                "Azure Monitor.",
                "Azure Policy."
            ], "A",
            """
            Compliance Manager, part of Microsoft Purview and reached through the Service Trust
            Portal, performs workflow-based risk assessments, produces a compliance score, and lets
            improvement actions be assigned and tracked with supporting evidence.

            It recommends actions but cannot guarantee compliance, which remains the organisation's
            responsibility.
            """);

        yield return Mc("gv-028", D3, "Describe features and tools for governance and compliance", R6,
            """
            What is the difference between data residency and data sovereignty?
            """,
            [
                "Data residency is where data is physically stored, whereas data sovereignty is the set of legal requirements that apply to data because of where it is stored.",
                "Data residency is the legal requirement, whereas data sovereignty is the physical storage location.",
                "They are two names for the same concept.",
                "Data residency applies only to backups, whereas data sovereignty applies only to live data."
            ], "A",
            """
            Data residency describes the geographic location in which data is physically stored,
            which in Azure is governed largely by the choice of geography and region.

            Data sovereignty describes the legal and regulatory obligations that attach to that
            data because of the jurisdiction it sits in, which can include rules on access,
            disclosure and cross-border transfer.
            """);

        yield return Mc("gv-029", D3, "Describe features and tools for governance and compliance", R6,
            """
            Which of the following is a regulatory standard enforced by a governmental body?
            """,
            ["GDPR.", "ISO.", "NIST.", "IEC."], "A",
            """
            The General Data Protection Regulation is European Union law defining data protection
            and privacy requirements, and it is enforced by governmental authorities. HIPAA is
            another regulatory example, in the United States.

            ISO, IEC and NIST are standards organisations. They publish standards but have no
            enforcement authority, which makes them non-regulatory.
            """);

        yield return YesNo("gv-030", D3, "Describe features and tools for governance and compliance", R6,
            """
            For each of the following statements about compliance resources, select Yes if the
            statement is true. Otherwise, select No.
            """,
            [
                ("The Service Trust Portal can be used to download Microsoft audit reports.", true),
                ("The Microsoft Trust Center enforces compliance settings on your Azure resources.", false),
                ("Compliance Manager can assign compliance improvement actions to people in your organisation.", true)
            ],
            """
            The Service Trust Portal is the source of audit reports, and Compliance Manager
            supports assigning and tracking improvement actions.

            The Trust Center is an informational website. Enforcing configuration settings on
            resources is the job of Azure Policy, not the Trust Center.
            """);

        yield return Mc("gv-031", D3, "Describe features and tools for governance and compliance", R6,
            """
            Which statement about Azure Government is correct?
            """,
            [
                "It is a physically isolated instance of Azure, hosted in United States data centres and operated by screened United States personnel.",
                "It is a set of Azure regions available to any customer worldwide.",
                "It is operated by a third-party partner under licence from Microsoft.",
                "It automatically makes any deployed workload compliant with all government regulations."
            ], "A",
            """
            Azure Government is a separate, physically isolated instance of Azure hosted in United
            States data centres, supported by screened United States personnel and available to
            eligible government entities and their solution providers after validation.

            It meets broad compliance requirements, including Department of Defense Impact Level 5,
            but it does not by itself make a workload compliant. Azure operated by 21Vianet in
            China is the instance run by a partner.
            """);

        yield return Mc("gv-032", D3, "Describe features and tools for governance and compliance", R6,
            """
            Which statement about Azure operated by 21Vianet in China is correct?
            """,
            [
                "It is a physically isolated instance of Azure operated by a Chinese partner, and accounts cannot be moved between it and global Azure.",
                "It is available only to Chinese government agencies.",
                "It shares the same accounts and subscriptions as global Azure.",
                "It is operated directly by Microsoft from data centres outside China."
            ], "A",
            """
            Azure in China is a separate, physically isolated instance operated by 21Vianet under
            licence from Microsoft, in order to satisfy Chinese regulatory requirements for
            telecommunications operators.

            Any organisation doing business in China may use it, but subscriptions and accounts are
            entirely separate, so an account cannot be transferred between it and global Azure.
            """);
    }
}
