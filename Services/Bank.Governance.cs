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
            Virtual machines may be created only in two approved regions and only in approved sizes.
            The people who create them are trusted engineers who already hold Contributor.

            Which service enforces this?
            """,
            [
                "Azure Policy, because it constrains the properties of a resource regardless of who is creating it.",
                "Azure role-based access control, by removing Contributor from the engineers.",
                "A CanNotDelete lock on each subscription.",
                "Microsoft Cost Management, by setting a budget per region."
            ], "A",
            """
            Azure Policy expresses rules about what a resource may look like and can deny a request
            that breaks them, such as a virtual machine in an unapproved region or of an unapproved
            size.

            The stem is designed to rule out the access-control answer. The engineers are supposed
            to create virtual machines; the question is which ones. Role-based access control can
            only decide whether they may act at all, so removing Contributor would break the job
            rather than constrain it. Locks prevent change and budgets only notify.
            """,
            """
            The people involved are meant to have permission. Ask which tool constrains what they
            create rather than whether they may create anything.
            """);

        yield return Mc("gv-002", D3, "Describe features and tools for governance and compliance", R6,
            """
            Which statement correctly describes the relationship between Azure Policy and Azure
            role-based access control?
            """,
            [
                "Policy controls what resource configurations are permitted and applies to everyone; RBAC controls who may perform actions. They are used together and neither grants what the other denies.",
                "Policy controls who may perform actions, and RBAC controls what configurations are permitted.",
                "Policy supersedes RBAC, so a policy assignment removes the need for role assignments.",
                "They are two names for the same feature, applied at different scopes."
            ], "A",
            """
            Azure Policy governs the properties of resources: which types, regions, sizes and
            settings are acceptable. It grants no permissions and applies to every principal
            equally, including subscription owners.

            Role-based access control governs identity: which principals may perform which
            operations at which scopes. The two answer different questions, which is why an
            authorised user can still be denied by policy and a compliant request can still be
            refused for lack of permission.
            """,
            """
            One of these answers who and the other answers what. Check whether either can substitute
            for the other, because one option claims exactly that.
            """);

        yield return Mc("gv-003", D3, "Describe features and tools for governance and compliance", R6,
            """
            A team wants to introduce a new tagging rule but must not break existing deployment
            pipelines while the estate is brought into line.

            Which Azure Policy effect should it start with?
            """,
            ["Audit.", "Deny.", "Append.", "DeployIfNotExists."], "A",
            """
            The audit effect records non-compliance so it appears in compliance reporting while
            allowing the resource through. That is exactly the phased rollout the stem describes:
            measure first, discover what would have broken, then switch to deny.

            Deny would block deployments immediately, which is the outcome being avoided. Append
            adds properties to the incoming request and deployIfNotExists provisions a related
            resource, so both change behaviour rather than just observing it.
            """,
            """
            The requirement is to learn without breaking anything. Only one effect changes nothing
            about the outcome of a request.
            """);

        yield return Drag("gv-004", D3, "Describe features and tools for governance and compliance", R6,
            """
            Match each Azure Policy effect to its behaviour. Each effect may be used once, more than
            once, or not at all.
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
                ("Provision an additional resource when a condition is met", 4),
                ("The safest effect to use when a new rule is first rolled out", 2)
            ],
            """
            Deny is the enforcing effect and audit is the observing one. Append modifies the
            incoming request by adding required properties, and deployIfNotExists triggers a
            remediation deployment when a required resource is missing.

            The last row is why audit appears twice. Because it changes nothing about whether a
            request succeeds, it is the effect used to measure the impact of a rule before anyone
            turns enforcement on.
            """,
            """
            One effect answers two rows. Ask which one has no effect on whether a deployment
            succeeds.
            """);

        yield return Mc("gv-005", D3, "Describe features and tools for governance and compliance", R6,
            """
            Securing a service requires fourteen separate policy definitions, and a governance team
            wants to assign and report on them as one thing.

            What should it create?
            """,
            [
                "An initiative, also called a policy set, which groups related definitions so they are assigned and tracked together.",
                "A single policy definition containing all fourteen rules, since a definition may hold any number of rules.",
                "A management group, which groups policy definitions for assignment.",
                "A role definition containing the fourteen policies as permissions."
            ], "A",
            """
            An initiative groups multiple policy definitions so they can be assigned as one unit
            and reported on as one compliance figure, which is what a broader governance goal needs.

            The distractors confuse neighbouring constructs. A management group is a scope you
            assign to, not a container of definitions, and a role definition describes permissions
            rather than resource rules. Initiatives are assigned at the same scopes as individual
            policies and grant no permissions.
            """,
            """
            The requirement is to treat many definitions as one. Ask which Azure construct exists
            for exactly that, and which of the options are scopes rather than groupings.
            """);

        yield return Mc("gv-006", D3, "Describe features and tools for governance and compliance", R6,
            """
            A rule must apply consistently to every subscription in the organisation, including any
            created next year.

            At which scope should the policy be assigned, and what are the valid assignment scopes?
            """,
            [
                "The management group, and the valid scopes are management group, subscription and resource group, with assignments inherited by all child objects unless excluded.",
                "Each subscription individually, and the valid scopes are subscription and resource group only.",
                "The tenant, and the valid scopes are tenant and geography.",
                "The billing account, and the valid scopes are billing account and billing profile."
            ], "A",
            """
            Policy assignments are made at a management group, a subscription or a resource group,
            and they apply to every child object unless an exclusion is configured.

            Assigning at the management group is what satisfies the requirement about future
            subscriptions: a new subscription placed in that group inherits the rule automatically,
            with nobody repeating the assignment. Per-subscription assignment would work today and
            quietly fail the first time somebody creates a subscription and forgets.
            """,
            """
            Two options could enforce the rule on the subscriptions that exist right now. Only one
            of them survives someone creating another one.
            """);

        // ---------------------------------------------------------- locks and tags

        yield return Mc("gv-007", D3, "Describe features and tools for governance and compliance", R6,
            """
            A production storage account must not be deleted accidentally, but administrators must
            still be able to change its configuration, such as its firewall rules.

            Which lock type should you apply?
            """,
            ["CanNotDelete.", "ReadOnly.", "Deny.", "Audit."], "A",
            """
            A CanNotDelete lock allows authorised users to read and modify the resource while
            blocking deletion, which matches both halves of the requirement.

            ReadOnly is the trap because it sounds like the safer choice: it also blocks
            configuration changes, so the firewall rules could no longer be edited. Deny and audit
            are Azure Policy effects, not lock types, so they are not options at all.
            """,
            """
            Both real lock types prevent deletion. The second requirement in the stem decides which
            one you can actually use.
            """);

        yield return Mc("gv-008", D3, "Describe features and tools for governance and compliance", R6,
            """
            A resource group carries a CanNotDelete lock, and a resource inside it carries a
            ReadOnly lock.

            What is the effective protection on that resource?
            """,
            [
                "ReadOnly, because locks are inherited and the most restrictive one applies.",
                "CanNotDelete, because the lock nearest the subscription takes precedence.",
                "No lock, because the two conflict and cancel each other out.",
                "Both are suspended until an administrator resolves the conflict."
            ], "A",
            """
            Locks are inherited from parent scopes, and where more than one applies the most
            restrictive wins. ReadOnly is more restrictive than CanNotDelete, because it blocks
            updates as well as deletion.

            Note how differently this behaves from role assignments, which combine additively and
            resolve to the most permissive result. Locks resolve to the most restrictive, and they
            never cancel out.
            """,
            """
            Azure has two overlapping-scope rules that point in opposite directions, one for roles
            and one for locks. Make sure you are applying the right one.
            """);

        yield return Mc("gv-009", D3, "Describe features and tools for governance and compliance", R6,
            """
            A user holds the Owner role on a subscription. A resource in it carries a CanNotDelete
            lock.

            Can the user delete the resource?
            """,
            [
                "Not while the lock is in place; the user must remove the lock first, which Owner does permit.",
                "Yes, because the Owner role overrides resource locks.",
                "Yes, but only through Azure PowerShell or the CLI, not the portal.",
                "No, and the lock cannot be removed once it has been applied."
            ], "A",
            """
            Locks apply to every user regardless of role, so even an Owner is stopped by the delete
            operation. That uniformity is precisely what makes a lock an effective guard against an
            accidental click.

            It is a speed bump rather than a wall, and the correct answer says so: a user with
            sufficient permissions can remove the lock and then delete the resource. The protection
            comes from making deletion a deliberate two-step act, not from making it impossible.
            """,
            """
            Two options say no. What separates them is whether the situation is permanent.
            """);

        yield return YesNo("gv-010", D3, "Describe features and tools for governance and compliance", R6,
            """
            For each of the following statements about resource locks, select Yes if the statement
            is true. Otherwise, select No.
            """,
            [
                ("A lock applied to a resource group is inherited by the resources it contains.", true),
                ("A lock can be scoped to apply to specific users only.", false),
                ("A ReadOnly lock on a database resource prevents rows inside the database being updated.", false),
                ("A CanNotDelete lock on a storage account prevents blobs inside it being deleted.", false)
            ],
            """
            Locks are inherited downward through the scope hierarchy and apply uniformly to every
            user; they cannot be targeted at particular roles or individuals.

            The last two statements are the same boundary twice. Locks operate on the management
            plane, meaning the resource itself, and not on the data plane, meaning what is stored
            inside it. So a lock stops the database or storage account being reconfigured or
            deleted, and does nothing to the rows or blobs within.
            """,
            """
            Two statements ask about data inside a resource rather than the resource itself. Locks
            draw a line between those two things.
            """);

        yield return Mc("gv-011", D3, "Describe features and tools for governance and compliance", R6,
            """
            Which two purposes do resource tags serve? Each correct answer presents a complete
            solution.
            """,
            [
                "Grouping resources for cost reporting and chargeback.",
                "Recording facts such as owner, environment or cost centre for management purposes.",
                "Encrypting the contents of a resource.",
                "Preventing a resource from being deleted.",
                "Determining the region in which a resource runs."
            ], "A,B",
            """
            Tags are name and value pairs attached to resources. They support cost reporting, since
            Cost Management can group and filter by tag, and operational organisation, since they
            record who owns a resource and which environment it belongs to.

            The three distractors each name a real Azure capability that tags do not provide:
            encryption comes from the service, deletion protection from a lock, and placement from
            the region chosen at deployment. A tag describes a resource; it never changes it.
            """,
            """
            Each wrong option names something Azure genuinely does, using a different feature. Ask
            what a tag can actually change about a resource.
            """);

        // ---------------------------------------------------------- monitoring

        yield return Mc("gv-012", D3, "Describe monitoring tools in Azure", R6,
            """
            A team needs one service to collect metrics and logs from Azure resources and
            on-premises servers, query them, and raise an alert that triggers an automated action.

            Which service should it use?
            """,
            [
                "Azure Monitor.",
                "Azure Advisor.",
                "Azure Service Health.",
                "Microsoft Sentinel."
            ], "A",
            """
            Azure Monitor is the umbrella telemetry service. It gathers metrics, logs and traces
            from resources in Azure and outside it, supports querying and visualisation, and raises
            alerts that can invoke action groups.

            The distractors all consume or resemble telemetry without being it. Advisor gives
            optimisation recommendations, Service Health reports on the health of Azure itself
            rather than your workload, and Sentinel is the security-focused SIEM built above this
            layer rather than the general monitoring service.
            """,
            """
            Several of these services deal in signals. Only one of them is the general collection
            and alerting layer the others build on.
            """);

        yield return Mc("gv-013", D3, "Describe monitoring tools in Azure", R6,
            """
            What is the difference between metrics and logs in Azure Monitor?
            """,
            [
                "Metrics are numerical values describing a system at a point in time; logs are records of events holding varied structured data, stored in tables and queried.",
                "Metrics are records of events, whereas logs are numerical point-in-time values.",
                "Metrics are stored only on-premises, whereas logs are stored only in Azure.",
                "Metrics must be configured manually, whereas logs are collected automatically."
            ], "A",
            """
            Metrics are lightweight numerical samples describing some aspect of a system at a
            specific moment, such as bytes stored or requests processed, which is what makes them
            cheap to keep and easy to chart.

            Logs record events and can carry many different kinds of structured data. They live in
            tables in a Log Analytics workspace and are interrogated with queries rather than
            plotted directly. Both begin collecting automatically when a resource is added.
            """,
            """
            One of these is a number at a moment and the other is a record of something that
            happened. That difference explains why only one of them needs a query language.
            """);

        yield return Mc("gv-014", D3, "Describe monitoring tools in Azure", R6,
            """
            A development team must see request rates, failure rates and dependency timings for a
            live web application, and send its own custom telemetry from the application code.

            Which component of Azure Monitor should it use, and where does that data end up?
            """,
            [
                "Application Insights, and its telemetry is stored in a Log Analytics workspace where it can be queried alongside other logs.",
                "Application Insights, which stores its telemetry in a separate system that cannot be queried with other logs.",
                "Log Analytics, which instruments the application code directly.",
                "Azure Service Health, which reports application failure rates."
            ], "A",
            """
            Application Insights is the application performance monitoring component. The
            application is instrumented so it emits telemetry, which is then used to understand
            performance, failures and usage.

            The second half is the relationship worth knowing. Log Analytics is the workspace and
            query engine, and Application Insights data lands there, so application telemetry can be
            correlated with platform logs in a single query rather than sitting in a silo. Log
            Analytics does not instrument anything itself.
            """,
            """
            Two components of Azure Monitor are involved here, not one. Work out which produces the
            data and which stores and queries it.
            """);

        yield return Mc("gv-015", D3, "Describe monitoring tools in Azure", R6,
            """
            Which component of Azure Monitor provides the workspace where log data is stored and the
            query environment used to analyse it?
            """,
            [
                "Log Analytics.",
                "Application Insights.",
                "Azure Advisor.",
                "Azure Service Health."
            ], "A",
            """
            Log Analytics provides the workspace in which log data is stored in tables, and the
            query environment used to interrogate it so that results can be analysed, charted and
            pinned to dashboards.

            Application Insights is the closest distractor and sits on the other side of the same
            relationship: it produces application telemetry that flows into a Log Analytics
            workspace, rather than replacing it.
            """,
            """
            The two Azure Monitor components here work together. This question asks for the one that
            holds the data rather than the one that generates it.
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
                ("Prevent resources being created in unapproved regions", 4),
                ("Be told that an existing virtual machine is oversized for its actual load", 2)
            ],
            """
            Azure Monitor handles telemetry collection and alerting, Service Health communicates
            planned maintenance and incidents affecting the services you use, and Azure Policy
            enforces configuration rules such as permitted regions.

            The last row repeats Advisor rather than adding a service, and it is the row that
            separates the two recommendation-shaped answers. Monitor would show you the CPU graph;
            Advisor is what reads that usage and tells you the machine is too big.
            """,
            """
            The last row could plausibly be Monitor. Ask whether the requirement is to see the data
            or to be told what to do about it.
            """);

        // ---------------------------------------------------------- service health

        yield return Mc("gv-017", D3, "Describe monitoring tools in Azure", R6,
            """
            One of your virtual machines is unreachable. Other machines in the same region are fine
            and Azure Status shows no incident.

            Which tool tells you whether the platform caused this specific machine problem?
            """,
            [
                "Resource Health.",
                "Azure Status.",
                "Service Health.",
                "Azure Advisor."
            ], "A",
            """
            Resource Health reports on your individual resources, showing whether a specific
            resource is available and listing recent events such as an unplanned host reboot or a
            period of degradation. It is the only one of the three health views that goes down to a
            single machine.

            The stem has already eliminated the other two by narrowing the problem. Azure Status is
            the global view and shows nothing, and Service Health is personalised to your
            subscriptions but still reports on services and regions, not on one virtual machine.
            """,
            """
            The three health views differ only in how narrow they are. The scenario has already
            ruled out the two wider ones.
            """);

        yield return Mc("gv-018", D3, "Describe monitoring tools in Azure", R6,
            """
            Several services appear to be failing at once and you suspect a widespread problem
            outside your subscription.

            Which tool gives the global view of Azure service health by region, and how does it
            differ from Service Health?
            """,
            [
                "Azure Status, which shows every Azure service and region publicly, whereas Service Health is filtered to the services and regions your subscriptions actually use.",
                "Azure Status, which is filtered to your subscriptions, whereas Service Health shows every service publicly.",
                "Service Health, which is the only public view, since Azure Status requires a subscription.",
                "Resource Health, which aggregates the health of all Azure customers resources."
            ], "A",
            """
            Azure Status is the public, global view of which Azure services are affected in which
            regions, and it is the right starting point when you suspect something widespread.

            The three views narrow progressively, which is the relationship being tested. Status is
            global and public, Service Health is personalised to the services and regions in your
            subscriptions, and Resource Health narrows further to your individual resources.
            """,
            """
            Two options name the right tool and swap its description with another. Sort the three
            health views from widest to narrowest first.
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
                    ["Azure Status", "Service Health", "Resource Health", "Azure Policy"], 3),
                ("To be alerted when the CPU of that virtual machine exceeds a threshold, use",
                    ["Azure Status", "Service Health", "Resource Health", "Azure Monitor"], 4)
            ],
            """
            The three health views narrow progressively: Azure Status is global, Service Health is
            personalised to the services and regions in your subscriptions and is also the source of
            health advisories, security advisories and billing updates, and Resource Health reports
            on your individual resources.

            The fourth row deliberately steps outside that family. Health views report on whether
            the platform is delivering the service; a threshold on your own workload metric is
            Azure Monitor, which is a different question entirely.
            """,
            """
            Three of these rows sit on the same scale from global to specific. The fourth is asking
            about your workload rather than about the platform.
            """);

        yield return Mc("gv-020", D3, "Describe monitoring tools in Azure", R6,
            """
            Which categories of information does Azure Service Health provide?
            """,
            [
                "Planned maintenance, health advisories, security advisories and billing updates.",
                "Planned maintenance, cost forecasts, budgets and invoices.",
                "Role assignments, policy assignments, lock definitions and tags.",
                "Virtual machine sizes, storage tiers, regional pricing and quotas."
            ], "A",
            """
            Service Health delivers personalised information in four categories: upcoming planned
            maintenance, health advisories describing service changes and retirements, security
            advisories, and billing updates covering pricing and metering changes.

            Billing updates are the category people forget, and they are what make the closest
            distractor tempting. Service Health tells you that a price or meter is changing; it does
            not forecast your spend or issue invoices, which is Cost Management.
            """,
            """
            One category in the correct answer sounds like it belongs to a different service. Ask
            whether being told about a pricing change is the same as being shown your bill.
            """);

        yield return Mc("gv-021", D3, "Describe monitoring tools in Azure", R6,
            """
            Forty alert rules must all notify the same on-call rota and call the same webhook. The
            rota changes every quarter.

            What should you use, and why?
            """,
            [
                "An action group, because it is a reusable collection of notifications and actions that many alert rules can share, so a rota change is made once.",
                "Forty separate notification lists, one per alert rule, because action groups apply to a single alert.",
                "A resource group, because grouping the alert rules makes them notify together.",
                "A Microsoft Entra ID group, because alert rules notify Entra groups directly."
            ], "A",
            """
            An action group is a reusable set of notification preferences and actions, such as
            email, SMS, push or a webhook call, that is invoked when an alert fires.

            Reuse is the whole point and the reason the stem mentions a changing rota: because forty
            rules reference one action group, updating the rota is a single edit rather than forty.
            A resource group is a management container and has no role in alerting.
            """,
            """
            The detail that decides this is that the rota changes. Ask which option means changing
            it in one place.
            """);

        // ---------------------------------------------------------- advisor

        yield return Mc("gv-022", D3, "Describe monitoring tools in Azure", R6,
            """
            A manager wants a prioritised list of specific changes to improve the environment, based
            on how the resources are actually being used.

            Which service should you use, and how does it differ from Azure Monitor?
            """,
            [
                "Azure Advisor, which analyses configuration and usage telemetry and recommends actions, whereas Azure Monitor collects and presents the telemetry itself.",
                "Azure Advisor, which collects the raw telemetry that Azure Monitor then interprets.",
                "Azure Monitor, which produces the Advisor score from its collected metrics.",
                "Microsoft Purview, which recommends improvements based on data classification."
            ], "A",
            """
            Azure Advisor continuously analyses resource configuration and usage telemetry, then
            presents actionable recommendations and an Advisor score reflecting how closely the
            environment follows best practice. Recommendations can be filtered by subscription,
            resource group and category.

            The distinction from Monitor is the direction of the work. Monitor gathers and shows
            you the data; Advisor reads it and tells you what to change. Confusing which one sits on
            top of the other is the error the wrong options encode.
            """,
            """
            Both services see the same usage data. One shows it to you and the other draws a
            conclusion from it.
            """);

        yield return Mc("gv-023", D3, "Describe monitoring tools in Azure", R6,
            """
            Azure Advisor groups its recommendations into five categories that mirror another
            Microsoft framework.

            Which set correctly lists them, and which framework do they mirror?
            """,
            [
                "Cost optimisation, security, reliability, operational excellence and performance efficiency, mirroring the Azure Well-Architected Framework.",
                "Cost optimisation, security, reliability, operational excellence and performance efficiency, mirroring the Cloud Adoption Framework.",
                "Cost, compliance, capacity, connectivity and continuity, mirroring the Well-Architected Framework.",
                "Availability, durability, scalability, elasticity and agility, mirroring the Cloud Adoption Framework."
            ], "A",
            """
            Advisor five categories are cost optimisation, security, reliability, operational
            excellence and performance efficiency, and they are the five pillars of the Microsoft
            Azure Well-Architected Framework.

            The framework matters because it is the other half of the pairing. The Cloud Adoption
            Framework is about the journey of adopting Azure, in stages such as strategy, plan,
            ready, adopt and govern; the Well-Architected Framework is about the qualities of a
            workload, which is what a recommendation engine reports on.
            """,
            """
            Two options list the five categories correctly. What separates them is which of the two
            Microsoft frameworks describes workload quality rather than adoption stages.
            """);

        // ---------------------------------------------------------- purview and compliance

        yield return Mc("gv-024", D3, "Describe features and tools for governance and compliance", R6,
            """
            An organisation must find where personal data is held across on-premises file shares,
            Azure storage, a second cloud and several SaaS applications, classify it, and publish a
            searchable catalogue.

            Which solution should it use?
            """,
            [
                "Microsoft Purview.",
                "Azure Policy.",
                "Microsoft Defender for Cloud.",
                "Azure Monitor."
            ], "A",
            """
            Microsoft Purview is the unified data governance, security and compliance family. It
            discovers and classifies data across a hybrid, multicloud and SaaS estate, builds a data
            map, and provides a catalogue for curating and securing it.

            The distinction from Defender for Cloud is worth holding: Defender assesses the security
            posture of the resources, while Purview is concerned with the data inside them. Purview
            also hosts audit, data lifecycle management, eDiscovery and Compliance Manager.
            """,
            """
            Two of these services look across clouds. Ask which one is interested in the data rather
            than in the resources holding it.
            """);

        yield return Mc("gv-025", D3, "Describe features and tools for governance and compliance", R6,
            """
            A team wants to read how Microsoft approaches security, privacy, compliance and
            transparency before designing a regulated workload.

            Which resource should it use, and what should it not expect from it?
            """,
            [
                "The Microsoft Trust Center, which is informational and neither assesses your resources nor enforces anything.",
                "The Microsoft Trust Center, which also scans your subscriptions and reports non-compliant resources.",
                "Azure Policy, which publishes Microsoft privacy and transparency practices.",
                "Azure Advisor, which is the published source of Microsoft compliance principles."
            ], "A",
            """
            The Microsoft Trust Center publishes how Microsoft approaches security, privacy,
            compliance and transparency, which is the right reading for a team designing a regulated
            workload.

            Its limits are the second half of the answer and the common misconception. It is a
            website, not a service pointed at your tenant: it assesses nothing, recommends nothing
            and enforces nothing. Assessment is Defender for Cloud or Compliance Manager, and
            enforcement is Azure Policy.
            """,
            """
            Two options name the right resource. One of them credits it with a capability that
            belongs to a service rather than a website.
            """);

        yield return Mc("gv-026", D3, "Describe features and tools for governance and compliance", R6,
            """
            An external auditor asks for Microsoft own independent audit reports for Azure, such as
            its SOC and ISO certifications.

            Where should you obtain them?
            """,
            [
                "The Service Trust Portal.",
                "The Microsoft Trust Center.",
                "The Azure portal Activity log.",
                "Microsoft Defender for Cloud."
            ], "A",
            """
            The Service Trust Portal is where Microsoft publishes audit reports and compliance
            documentation for its cloud services, and where those reports are downloaded for
            internal or third-party auditors. It also hosts Compliance Manager.

            The Trust Center is the closest distractor and is the right place to read about
            Microsoft approach in general terms; the Service Trust Portal is where the evidence
            itself lives. The Activity log records operations in your own subscription and says
            nothing about Microsoft audits.
            """,
            """
            Two Microsoft sites cover trust and compliance. One explains the approach, the other
            hands you the documents.
            """);

        yield return Mc("gv-027", D3, "Describe features and tools for governance and compliance", R6,
            """
            A compliance officer wants a risk-based score for the organisation, with improvement
            actions assigned to named people and evidence attached.

            Which tool provides this, and what can it not do?
            """,
            [
                "Compliance Manager, which produces a compliance score and tracks assigned improvement actions, but cannot guarantee compliance, which remains the organisation responsibility.",
                "Compliance Manager, which guarantees compliance with any standard whose score reaches 100 percent.",
                "The Microsoft Trust Center, which assigns and tracks improvement actions.",
                "Azure Policy, which produces the organisation compliance score against regulations."
            ], "A",
            """
            Compliance Manager, part of Microsoft Purview and reached through the Service Trust
            Portal, performs workflow-based risk assessments, produces a compliance score, and lets
            improvement actions be assigned and tracked with supporting evidence.

            The limit is the important half. It recommends and measures; it cannot certify. Under
            shared responsibility, achieving and demonstrating compliance stays with the
            organisation, so a high score is evidence of effort rather than a guarantee.
            """,
            """
            Two options name the right tool. One of them promises something no assessment tool can
            deliver under the shared responsibility model.
            """);

        yield return Mc("gv-028", D3, "Describe features and tools for governance and compliance", R6,
            """
            A company stores data in an Azure region inside its own country in order to satisfy a
            national law about who may compel access to that data.

            Which two concepts are in play, and how do they differ?
            """,
            [
                "Data residency is where the data is physically stored; data sovereignty is the legal regime that applies to it because of where it is stored.",
                "Data residency is the legal regime that applies; data sovereignty is the physical storage location.",
                "They are two names for the same concept, applied to storage and to backups respectively.",
                "Data residency applies to live data and data sovereignty applies only to backups."
            ], "A",
            """
            Data residency describes the geographic location where data physically sits, which in
            Azure is governed largely by the choice of geography and region.

            Data sovereignty describes the legal and regulatory obligations that attach to the data
            because of the jurisdiction it sits in, including rules on access, disclosure and
            cross-border transfer. The scenario shows why the two are connected but not the same:
            the company controls residency in order to determine which sovereignty applies.
            """,
            """
            One of these terms is a fact about geography and the other is a consequence in law.
            Decide which is the cause and which is the effect.
            """);

        yield return Mc("gv-029", D3, "Describe features and tools for governance and compliance", R6,
            """
            Which of the following is a regulatory standard enforced by a governmental body, rather
            than a standard published by a standards organisation?
            """,
            ["GDPR.", "ISO 27001.", "NIST SP 800-53.", "IEC 62443."], "A",
            """
            The General Data Protection Regulation is European Union law defining data protection
            and privacy requirements, and it is enforced by governmental data protection
            authorities that can levy fines. HIPAA is a comparable example in the United States.

            ISO, IEC and NIST publish standards and frameworks that organisations may adopt, and
            certification is carried out by accredited bodies rather than governments. NIST is the
            distractor worth noting: it is a United States government agency, but its publications
            are standards rather than law, except where a contract or another regulation makes them
            binding.
            """,
            """
            One distractor comes from a government agency and still is not a regulation. Ask who can
            impose a penalty for non-compliance.
            """);

        yield return YesNo("gv-030", D3, "Describe features and tools for governance and compliance", R6,
            """
            For each of the following statements about compliance resources, select Yes if the
            statement is true. Otherwise, select No.
            """,
            [
                ("The Service Trust Portal can be used to download Microsoft audit reports.", true),
                ("The Microsoft Trust Center enforces compliance settings on your Azure resources.", false),
                ("Compliance Manager can assign compliance improvement actions to people in your organisation.", true),
                ("Using a compliant Azure region makes any workload deployed there compliant.", false)
            ],
            """
            The Service Trust Portal is the source of audit reports, and Compliance Manager supports
            assigning and tracking improvement actions. The Trust Center is informational, and
            enforcing configuration on resources is the job of Azure Policy.

            The last statement is the shared responsibility trap in its compliance form. Microsoft
            certifications cover the platform; how you configure, secure and operate what you deploy
            on it is yours, so a compliant region is a prerequisite rather than an outcome.
            """,
            """
            The last statement is the shared responsibility model wearing a compliance hat. Ask what
            a Microsoft certification actually certifies.
            """);

        yield return Mc("gv-031", D3, "Describe features and tools for governance and compliance", R6,
            """
            A United States federal agency asks whether deploying to Azure Government makes its
            workload compliant.

            Which statement is correct?
            """,
            [
                "Azure Government is a physically isolated instance in United States data centres operated by screened United States personnel, but the agency remains responsible for how it configures and operates its workload.",
                "Azure Government automatically makes any workload deployed there compliant with all applicable government regulations.",
                "Azure Government is simply a set of Azure regions open to any customer worldwide.",
                "Azure Government is operated by a third-party partner under licence from Microsoft."
            ], "A",
            """
            Azure Government is a separate, physically isolated instance of Azure hosted in United
            States data centres, supported by screened United States personnel and available to
            eligible government entities and their solution providers after validation. It meets
            broad compliance requirements, including Department of Defense Impact Level 5.

            None of that transfers the customer half of the work. Shared responsibility still
            applies, so the platform being accredited is not the same as the workload being
            compliant. The instance run by a partner under licence is Azure operated by 21Vianet in
            China.
            """,
            """
            The factual description is not what separates the options. Ask what an accredited
            platform does and does not do for the workload you put on it.
            """);

        yield return Mc("gv-032", D3, "Describe features and tools for governance and compliance", R6,
            """
            A multinational company with an existing global Azure tenant wants to expand into China
            using Azure operated by 21Vianet.

            Which statement is correct?
            """,
            [
                "It is a physically isolated instance operated by a Chinese partner, so the company needs separate accounts and subscriptions; they cannot be moved between it and global Azure.",
                "It shares accounts and subscriptions with global Azure, so the existing tenant simply extends into the new regions.",
                "It is available only to Chinese government agencies, so the company cannot use it.",
                "It is operated directly by Microsoft from data centres outside China."
            ], "A",
            """
            Azure in China is a separate, physically isolated instance operated by 21Vianet under
            licence from Microsoft, which is how Chinese regulatory requirements for
            telecommunications operators are satisfied.

            The consequence for this company is the practical point: the separation extends to
            identity and billing, so accounts and subscriptions are entirely distinct and cannot be
            transferred across. Any organisation doing business in China may use it, not only
            government agencies.
            """,
            """
            The word "isolated" is doing more work than it first appears. Ask whether the separation
            stops at the data centre or reaches the tenant as well.
            """);
    }
}
