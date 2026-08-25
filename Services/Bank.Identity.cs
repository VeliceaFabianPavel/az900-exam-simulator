using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Domain 2, identity and security portion. Sourced from chapter 5, excluding the
// network security section (firewalls, NSGs, WAF, DDoS) per the requested scope.
public static partial class QuestionBank
{
    private const string R5 = "Study guide, ch. 5: Identity, Access, and Security";

    private static IEnumerable<Item> IdentityAndSecurity()
    {
        // ---------------------------------------------------------- core identity

        yield return Mc("id-001", D2, "Describe Azure identity, access, and security", R5,
            """
            What is the difference between authentication and authorization?
            """,
            [
                "Authentication establishes who a user is, and authorization determines what that user is allowed to do.",
                "Authentication determines what a user is allowed to do, and authorization establishes who the user is.",
                "Authentication applies to users, and authorization applies only to applications.",
                "Authentication and authorization are two names for the same process."
            ], "A",
            """
            Authentication answers the question "who are you?" by verifying an identity, for
            example with a user name and password. Authorization answers "what are you allowed to
            do?" once that identity has been established.

            Both are required: proving who you are grants no access to a resource until an
            authorization decision has also been made.
            """);

        yield return Mc("id-002", D2, "Describe Azure identity, access, and security", R5,
            """
            Which service provides cloud-based identity and access management for Azure, Microsoft
            365 and custom applications?
            """,
            [
                "Microsoft Entra ID.",
                "Azure Key Vault.",
                "Microsoft Sentinel.",
                "Azure Policy."
            ], "A",
            """
            Microsoft Entra ID, previously called Azure Active Directory, is the cloud identity and
            access management service. It is included automatically with Azure, Microsoft 365 and
            Dynamics 365 subscriptions and can also authenticate custom applications.

            Key Vault stores secrets, Sentinel is a security information and event management
            solution, and Azure Policy enforces resource configuration rules.
            """);

        yield return Mc("id-003", D2, "Describe Azure identity, access, and security", R5,
            """
            Which statement about Microsoft Entra ID is correct?
            """,
            [
                "It can be used without any on-premises Active Directory deployment.",
                "It requires an on-premises Active Directory domain to function.",
                "It is a direct cloud-hosted copy of Active Directory Domain Services.",
                "It can only authenticate users of Microsoft 365."
            ], "A",
            """
            Microsoft Entra ID can operate entirely in the cloud with no on-premises directory at
            all. Organisations that already run Active Directory can synchronise it to Entra ID to
            create a hybrid identity model, but that is optional.

            Entra ID is not the same product as Active Directory Domain Services; the service that
            provides managed domain services in Azure is Microsoft Entra Domain Services.
            """);

        yield return Mc("id-004", D2, "Describe Azure identity, access, and security", R5,
            """
            You must run a legacy application in Azure that requires domain join, Group Policy and
            LDAP, but you do not want to deploy or maintain domain controllers.

            Which service should you use?
            """,
            [
                "Microsoft Entra Domain Services.",
                "Microsoft Entra ID Free.",
                "Azure Key Vault.",
                "Microsoft Entra External ID."
            ], "A",
            """
            Microsoft Entra Domain Services provides managed domain capabilities such as domain
            join, Group Policy, Kerberos, NTLM and LDAP, with Microsoft operating the domain
            controllers.

            That combination is exactly what legacy applications with traditional Active Directory
            dependencies need when they are moved to Azure.
            """);

        yield return Mc("id-005", D2, "Describe Azure identity, access, and security", R5,
            """
            Users sign in once and then access several different applications without being
            prompted for their credentials again.

            Which capability does this describe?
            """,
            [
                "Single sign-on.",
                "Multifactor authentication.",
                "Conditional Access.",
                "Role-based access control."
            ], "A",
            """
            Single sign-on lets one set of credentials grant access to multiple resources, so users
            are not challenged repeatedly as they move between applications.

            Multifactor authentication strengthens a single sign-in event, Conditional Access
            decides whether a sign-in is permitted, and role-based access control governs what an
            authenticated user may do.
            """);

        yield return Mc("id-006", D2, "Describe Azure identity, access, and security", R5,
            """
            After entering a password, users must also approve a prompt in an authenticator
            application before they are signed in.

            Which capability does this describe?
            """,
            [
                "Multifactor authentication.",
                "Single sign-on.",
                "Role-based access control.",
                "Federation."
            ], "A",
            """
            Multifactor authentication requires two or more distinct verifications before access is
            granted, such as a password combined with an approval prompt, a phone call or a text
            message.

            Requiring an additional factor substantially reduces the risk that a stolen password
            alone is enough to compromise an account.
            """);

        yield return Mc("id-007", D2, "Describe Azure identity, access, and security", R5,
            """
            You need to allow sign-in without a prompt when users are in the corporate office, but
            require multifactor authentication when they sign in from any other location.

            Which feature should you use?
            """,
            [
                "Conditional Access.",
                "Role-based access control.",
                "Azure Policy.",
                "A resource lock."
            ], "A",
            """
            Conditional Access evaluates signals such as location, device state, application and
            user risk, and then decides whether to allow access, block it or require an additional
            control such as multifactor authentication.

            Role-based access control governs permissions on resources, and Azure Policy and
            resource locks govern resource configuration rather than sign-in.
            """);

        yield return YesNo("id-008", D2, "Describe Azure identity, access, and security", R5,
            """
            For each of the following statements, select Yes if the statement is true. Otherwise,
            select No.
            """,
            [
                ("Single sign-on reduces the number of times a user must enter credentials.", true),
                ("Multifactor authentication and single sign-on are mutually exclusive.", false),
                ("Conditional Access can require multifactor authentication based on the user's location.", true)
            ],
            """
            Single sign-on reduces repeated credential prompts, and Conditional Access can use
            location as one of the signals that triggers a multifactor authentication requirement.

            The two are complementary rather than mutually exclusive: a strong initial sign-in
            protected by multifactor authentication is normally combined with single sign-on for
            everything that follows.
            """);

        // ---------------------------------------------------------- RBAC

        yield return Mc("id-009", D2, "Describe Azure identity, access, and security", R5,
            """
            Which three elements make up an Azure role assignment?
            """,
            [
                "A security principal, a role definition and a scope.",
                "A user, a password and a policy.",
                "A subscription, a resource group and a tag.",
                "A tenant, a directory and a licence."
            ], "A",
            """
            Every role assignment combines who is being granted access (the security principal),
            what they may do (the role definition), and where the permissions apply (the scope).

            A security principal may be a user, a group, a service principal representing an
            application, or a managed identity.
            """);

        yield return Mc("id-010", D2, "Describe Azure identity, access, and security", R5,
            """
            A user must be able to create and manage all resource types in a subscription, but must
            not be able to grant access to other users.

            Which built-in role should you assign?
            """,
            ["Contributor.", "Owner.", "Reader.", "User Access Administrator."], "A",
            """
            The Contributor role can create and manage resources of every type but cannot grant
            access to others, which is precisely the separation described.

            Owner adds the ability to delegate access, Reader allows viewing only, and User Access
            Administrator manages access without the ability to manage resources.
            """);

        yield return Mc("id-011", D2, "Describe Azure identity, access, and security", R5,
            """
            Which built-in role provides full access to all resources, including the ability to
            assign roles to other users?
            """,
            ["Owner.", "Contributor.", "Reader.", "Security Admin."], "A",
            """
            Owner combines full management of resources with the ability to delegate access by
            assigning roles, which makes it the most privileged of the fundamental built-in roles.

            Because of that combination it should be granted sparingly and, where possible, only
            for the time it is genuinely needed.
            """);

        yield return Drag("id-012", D2, "Describe Azure identity, access, and security", R5,
            """
            Match each requirement to the least privileged built-in role that satisfies it. Each
            role may be used once, more than once, or not at all.
            """,
            "Built-in roles",
            [
                "Reader",
                "Contributor",
                "Owner",
                "User Access Administrator"
            ],
            [
                ("View resources without making any changes", 1),
                ("Create and manage resources but not grant access to others", 2),
                ("Manage user access to resources without managing the resources", 4),
                ("Manage all resources and delegate access to others", 3)
            ],
            """
            Reader is view-only, and Contributor adds full resource management while withholding
            the ability to delegate access.

            User Access Administrator is the mirror image of Contributor: it manages access but
            not resources. Owner combines both capabilities and is therefore the most privileged.
            """);

        yield return Mc("id-013", D2, "Describe Azure identity, access, and security", R5,
            """
            A user is assigned the Reader role at a resource group and the Contributor role at the
            subscription that contains that resource group.

            What is the user's effective permission on resources in that resource group?
            """,
            [
                "Contributor, because Azure role assignments are additive and the most permissive assignment applies.",
                "Reader, because the assignment closest to the resource takes precedence.",
                "No access, because the two assignments conflict.",
                "Owner, because two role assignments are combined into a higher role."
            ], "A",
            """
            Azure role-based access control uses an additive model. Permissions from all applicable
            assignments are combined, and the effective result is the most permissive set, so the
            Contributor assignment inherited from the subscription wins.

            Azure RBAC has no concept of a narrower assignment overriding a broader one; explicit
            deny assignments are a separate mechanism.
            """);

        yield return Mc("id-014", D2, "Describe Azure identity, access, and security", R5,
            """
            Group Alpha is assigned the Contributor role. Group Beta is a member of Group Alpha,
            and a user is a member of Group Beta.

            What access does the user have?
            """,
            [
                "Contributor, because group role assignments are transitive.",
                "No access, because role assignments do not flow through nested groups.",
                "Reader, because nested groups receive a reduced role.",
                "Contributor, but only after the assignment is repeated on Group Beta."
            ], "A",
            """
            Role assignments made to a group are transitive: a user inherits the role through the
            full chain of nested group memberships without needing a direct assignment.

            This makes group-based assignment the practical way to manage access at scale, but it
            also means nested memberships must be reviewed carefully.
            """);

        yield return Mc("id-015", D2, "Describe Azure identity, access, and security", R5,
            """
            At which four scopes can an Azure role assignment be applied?
            """,
            [
                "Management group, subscription, resource group and resource.",
                "Tenant, geography, region and availability zone.",
                "Billing account, billing profile, invoice section and subscription.",
                "Directory, domain, organisational unit and object."
            ], "A",
            """
            Azure role assignments can be made at a management group, a subscription, a resource
            group or an individual resource, and they are inherited by everything below the chosen
            scope.

            The other lists describe the geographic hierarchy, the billing hierarchy and
            traditional Active Directory structure rather than RBAC scopes.
            """);

        yield return Mc("id-016", D2, "Describe Azure identity, access, and security", R5,
            """
            What is the difference between Microsoft Entra ID roles and Azure RBAC roles?
            """,
            [
                "Entra ID roles manage identity objects and directory features, whereas Azure RBAC roles manage access to Azure resources.",
                "Entra ID roles manage Azure resources, whereas Azure RBAC roles manage identity objects.",
                "They are two names for the same set of roles.",
                "Entra ID roles apply only to guest users, whereas Azure RBAC roles apply only to employees."
            ], "A",
            """
            Microsoft Entra ID roles, such as Global Administrator and User Administrator, control
            directory objects and tenant-level features like users, groups and application
            registrations.

            Azure RBAC roles, such as Owner, Contributor and Reader, control what can be done with
            Azure resources including virtual machines, storage accounts and databases. The two
            systems are separate and are assigned independently.
            """);

        yield return Mc("id-017", D2, "Describe Azure identity, access, and security", R5,
            """
            An application running on an Azure virtual machine must authenticate to Azure Key Vault
            without any credential being stored in the application's configuration.

            What should you use?
            """,
            [
                "A managed identity.",
                "A shared access signature with a long expiry.",
                "A service principal secret stored in an environment variable.",
                "The subscription owner's credentials."
            ], "A",
            """
            A managed identity lets an Azure service authenticate to other Azure services that
            support Microsoft Entra authentication without any credential being created, stored or
            rotated by the developer.

            The alternatives all involve a secret that has to live somewhere, which is the precise
            risk that managed identities were designed to remove.
            """);

        // ---------------------------------------------------------- zero trust and defence in depth

        yield return Mc("id-018", D2, "Describe Azure identity, access, and security", R5,
            """
            Which three principles guide the Zero Trust model?
            """,
            [
                "Verify explicitly, use least privilege access, and assume breach.",
                "Trust but verify, encrypt everything, and centralise logging.",
                "Defend the perimeter, segment the network, and patch quickly.",
                "Authenticate, authorise, and audit."
            ], "A",
            """
            Zero Trust rests on three principles: verify explicitly using all available signals,
            grant least privilege access through just-in-time and just-enough-access techniques,
            and assume breach by compartmentalising access and instrumenting the environment.

            The model replaces implicit trust based on network location with trust granted by
            exception and continuously re-evaluated.
            """);

        yield return Mc("id-019", D2, "Describe Azure identity, access, and security", R5,
            """
            Which statement best describes the Zero Trust model?
            """,
            [
                "No user or device is trusted by default, whether inside or outside the corporate network.",
                "Devices connected to the internal network are trusted automatically.",
                "Trust is granted permanently once a user completes multifactor authentication.",
                "Only external users must be verified before they are granted access."
            ], "A",
            """
            Zero Trust removes the assumption that anything inside a network boundary is safe.
            Every user and device must be verified, and access is granted narrowly and continually
            re-evaluated rather than being conferred once and left in place.

            That is why location alone never establishes trust under this model.
            """);

        yield return Mc("id-020", D2, "Describe Azure identity, access, and security", R5,
            """
            Which concept describes applying multiple independent layers of security control so
            that the failure of any single layer does not expose the data?
            """,
            [
                "Defence in depth.",
                "Zero Trust.",
                "Shared responsibility.",
                "Least privilege."
            ], "A",
            """
            Defence in depth layers controls from physical security through identity and access,
            perimeter, network, compute, application and finally data, so that an attacker must
            defeat several independent measures.

            Zero Trust is the trust model, shared responsibility divides duties with the provider,
            and least privilege is one specific control among many.
            """);

        yield return Mc("id-021", D2, "Describe Azure identity, access, and security", R5,
            """
            In a defence in depth model, which layer is considered the innermost layer that all
            other layers exist to protect?
            """,
            ["Data.", "Physical security.", "Perimeter.", "Identity and access."], "A",
            """
            Data sits at the centre of the defence in depth model. Every other layer, from the
            physical facility outward through identity, perimeter, network, compute and
            application, exists to keep unauthorised parties away from it.

            Physical security is the outermost layer in the model rather than the innermost.
            """);

        yield return Mc("id-022", D2, "Describe Azure identity, access, and security", R5,
            """
            Which practice grants an administrator elevated permissions only for the limited period
            during which the task must be performed?
            """,
            [
                "Just-in-time access.",
                "Just-enough-access.",
                "Single sign-on.",
                "Federation."
            ], "A",
            """
            Just-in-time access limits the time window in which elevated permissions are held, so
            standing administrative access is avoided.

            Just-enough-access is the complementary idea of limiting the breadth of permissions to
            the minimum required. Both together express the least privilege principle of Zero
            Trust.
            """);

        // ---------------------------------------------------------- external identities

        yield return Mc("id-023", D2, "Describe Azure identity, access, and security", R5,
            """
            Your organisation needs to let engineers from a supplier sign in to a shared project
            application using their own corporate credentials.

            Which capability should you use?
            """,
            [
                "Microsoft Entra business-to-business collaboration.",
                "Microsoft Entra business-to-consumer collaboration.",
                "Microsoft Entra Domain Services.",
                "Azure Key Vault."
            ], "A",
            """
            Business-to-business collaboration invites partner users into your workforce tenant as
            guest users. Their identities remain managed by their own organisation, and you control
            only what they may access.

            Business-to-consumer scenarios use an external tenant and are aimed at consumers
            signing up with personal or social accounts.
            """);

        yield return Mc("id-024", D2, "Describe Azure identity, access, and security", R5,
            """
            What is the difference between a workforce tenant and an external tenant?
            """,
            [
                "A workforce tenant holds employee identities and internal resources, whereas an external tenant hosts consumer-facing applications and keeps external users separate from corporate resources.",
                "A workforce tenant hosts consumer applications, whereas an external tenant holds employee identities.",
                "A workforce tenant supports only cloud-only accounts, whereas an external tenant supports only synchronised accounts.",
                "There is no functional difference; the names are interchangeable."
            ], "A",
            """
            A workforce tenant is the standard tenant containing employee identities, internal
            applications and corporate resources, and it is where partner guests appear in
            business-to-business collaboration.

            An external tenant is used for customer-facing scenarios, keeping consumer identities
            and applications separated from corporate resources while allowing the sign-in
            experience to be customised.
            """);

        yield return YesNo("id-025", D2, "Describe Azure identity, access, and security", R5,
            """
            For each of the following statements about external identities, select Yes if the
            statement is true. Otherwise, select No.
            """,
            [
                ("In business-to-business collaboration, partner users appear as guest users in your tenant.", true),
                ("In business-to-consumer scenarios, consumers can sign in with a social account.", true),
                ("Your organisation becomes responsible for managing the passwords of business-to-business guest users.", false)
            ],
            """
            Partner users appear as guests in the workforce tenant, and consumer scenarios commonly
            allow sign-in with existing social or personal accounts.

            The defining benefit of external identities is that the external provider continues to
            manage the credential. Your organisation manages only what that identity is authorised
            to reach.
            """);

        yield return Mc("id-026", D2, "Describe Azure identity, access, and security", R5,
            """
            Which tool synchronises identities from an on-premises Active Directory to Microsoft
            Entra ID using a full application installed on a domain-joined server?
            """,
            [
                "Microsoft Entra Connect.",
                "Microsoft Entra Cloud Sync.",
                "Microsoft Entra Domain Services.",
                "Microsoft Sentinel."
            ], "A",
            """
            Microsoft Entra Connect is the full synchronisation application installed on a
            domain-joined server, with synchronisation, health monitoring and configuration wizard
            components.

            Microsoft Entra Cloud Sync is the lighter alternative, using small agents and a
            cloud-based provisioning service. It is simpler to run but supports fewer scenarios.
            """);

        // ---------------------------------------------------------- security tools

        yield return Mc("id-027", D2, "Describe Azure identity, access, and security", R5,
            """
            Which service continuously assesses the security posture of your Azure resources,
            provides hardening recommendations and reports a Secure Score?
            """,
            [
                "Microsoft Defender for Cloud.",
                "Microsoft Sentinel.",
                "Azure Monitor.",
                "Azure Advisor."
            ], "A",
            """
            Microsoft Defender for Cloud assesses resources against security benchmarks, produces
            prioritised hardening recommendations and expresses overall posture as a Secure Score.
            It also provides threat protection and works across Azure, AWS and GCP.

            Sentinel is the security information and event management solution, while Monitor and
            Advisor address telemetry and general optimisation.
            """);

        yield return Mc("id-028", D2, "Describe Azure identity, access, and security", R5,
            """
            Which service is a cloud-native security information and event management solution that
            collects data across your estate, correlates alerts into incidents and automates
            response?
            """,
            [
                "Microsoft Sentinel.",
                "Microsoft Defender for Cloud.",
                "Azure Key Vault.",
                "Microsoft Purview."
            ], "A",
            """
            Microsoft Sentinel is the security information and event management solution. It
            ingests signals from users, devices, applications and infrastructure across on-premises
            and multiple clouds, correlates related alerts into incidents, and can trigger
            automated responses through playbooks.

            Defender for Cloud focuses on the security posture and protection of cloud workloads
            rather than enterprise-wide event correlation.
            """);

        yield return Mc("id-029", D2, "Describe Azure identity, access, and security", R5,
            """
            Which service should you use to store application passwords, API keys, certificates and
            cryptographic keys centrally, so that they are not hard-coded in application code?
            """,
            [
                "Azure Key Vault.",
                "Azure Storage account.",
                "Microsoft Entra ID.",
                "Azure Policy."
            ], "A",
            """
            Azure Key Vault centralises secrets, certificates and cryptographic keys, so
            applications retrieve them at run time after authenticating, and no credential needs to
            be embedded in code or configuration.

            Centralising secrets also makes access straightforward to monitor, audit and revoke.
            """);

        yield return Mc("id-030", D2, "Describe Azure identity, access, and security", R5,
            """
            What does the Secure Score in Microsoft Defender for Cloud represent?
            """,
            [
                "A measure of the current security posture of your environment that helps prioritise remediation.",
                "The percentage of your monthly budget that has been consumed.",
                "The availability commitment for the services in your subscription.",
                "The number of users who have completed multifactor authentication registration."
            ], "A",
            """
            Secure Score summarises how closely the environment matches recommended security
            controls, grouped by control area, so that teams can see their posture at a glance and
            prioritise the changes that will improve it most.

            It is a security measure, not a cost, availability or registration metric.
            """);

        yield return Mc("id-031", D2, "Describe Azure identity, access, and security", R5,
            """
            A regulatory requirement states that your virtual machines must not run on hardware
            shared with other Microsoft customers.

            Which option addresses this requirement?
            """,
            [
                "Azure Dedicated Host.",
                "An availability set.",
                "A virtual machine scale set.",
                "A proximity placement group."
            ], "A",
            """
            Azure Dedicated Host provisions physical servers dedicated to a single customer, so
            virtual machines do not share hardware with other organisations. This directly
            satisfies regulatory requirements that prohibit shared hardware.

            Availability sets, scale sets and placement groups affect resilience, scaling and
            latency, not hardware isolation.
            """);

        yield return Drag("id-032", D2, "Describe Azure identity, access, and security", R5,
            """
            Match each requirement to the appropriate Azure service. Each service may be used once,
            more than once, or not at all.
            """,
            "Services",
            [
                "Azure Key Vault",
                "Microsoft Defender for Cloud",
                "Microsoft Sentinel",
                "Microsoft Entra ID"
            ],
            [
                ("Store certificates and application secrets centrally", 1),
                ("Assess resource security posture and report a Secure Score", 2),
                ("Correlate security alerts from across the estate into incidents", 3),
                ("Authenticate users signing in to cloud applications", 4)
            ],
            """
            Key Vault is the secret and certificate store, and Defender for Cloud provides posture
            assessment with Secure Score.

            Sentinel is the security information and event management solution that correlates
            alerts into incidents, and Entra ID is the identity provider that authenticates users.
            """);

        yield return Mc("id-033", D2, "Describe Azure identity, access, and security", R5,
            """
            Which Microsoft Entra ID capability lets you discover, monitor and restrict standing
            administrative access, including time-bound role activation?
            """,
            [
                "Privileged Identity Management.",
                "Conditional Access.",
                "Self-service password reset.",
                "Dynamic groups."
            ], "A",
            """
            Privileged Identity Management provides oversight of privileged roles, including
            discovery, approval workflows, time-bound activation and auditing, so administrators
            hold elevated rights only when they need them.

            It is available with the Premium P2 edition, alongside identity protection
            capabilities.
            """);

        yield return YesNo("id-034", D2, "Describe Azure identity, access, and security", R5,
            """
            For each of the following statements about Azure role-based access control, select Yes
            if the statement is true. Otherwise, select No.
            """,
            [
                ("A role assignment made at a subscription is inherited by all resource groups in that subscription.", true),
                ("A managed identity can be used as the security principal in a role assignment.", true),
                ("Assigning two roles to the same user results in the more restrictive role taking effect.", false)
            ],
            """
            Role assignments are inherited downward through the scope hierarchy, and a security
            principal can be a user, group, service principal or managed identity.

            Because the model is additive, overlapping assignments combine and the most permissive
            result applies, so the third statement is false.
            """);

        yield return Mc("id-035", D2, "Describe Azure identity, access, and security", R5,
            """
            Which Microsoft Entra ID edition is required to use Conditional Access policies?
            """,
            [
                "Premium P1 or Premium P2.",
                "Free.",
                "Any edition, including Free.",
                "Premium P2 only."
            ], "A",
            """
            Conditional Access requires a Microsoft Entra ID Premium P1 or Premium P2 licence, and
            it is also included with Microsoft 365 Business Premium.

            The Free edition covers user and group management, directory synchronisation and basic
            single sign-on, but not Conditional Access.
            """);
    }
}
