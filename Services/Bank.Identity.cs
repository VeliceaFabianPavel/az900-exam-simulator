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
            A user signs in successfully with a valid password and a matching multifactor prompt,
            then receives an error when opening a storage account.

            Which statement explains what happened?
            """,
            [
                "Authentication succeeded but authorization failed: proving who you are grants no access until a separate decision about what you may do is made.",
                "Authentication failed, because a successful sign-in always implies access to every resource in the tenant.",
                "Authorization succeeded but authentication failed, because multifactor prompts are part of authorization.",
                "Neither applies, because authentication and authorization are two names for the same process."
            ], "A",
            """
            Authentication answers who are you, by verifying an identity with something like a
            password plus a second factor. Authorization answers what are you allowed to do, and it
            is evaluated separately, per resource, after the identity is established.

            This scenario is the everyday consequence: a perfect sign-in and no permission on the
            storage account produce exactly this error. The two are never interchangeable, and a
            multifactor prompt strengthens authentication rather than granting anything.
            """,
            """
            Nothing went wrong with the sign-in itself. Ask which of the two questions had actually
            been answered by the time the error appeared.
            """);

        yield return Mc("id-002", D2, "Describe Azure identity, access, and security", R5,
            """
            An organisation needs one identity and access management service to sign users in to
            Azure, Microsoft 365 and a custom line-of-business web application.

            Which service should it use?
            """,
            [
                "Microsoft Entra ID.",
                "Azure Key Vault.",
                "Microsoft Sentinel.",
                "Azure Policy."
            ], "A",
            """
            Microsoft Entra ID, previously called Azure Active Directory, is the cloud identity and
            access management service. It comes with Azure, Microsoft 365 and Dynamics 365
            subscriptions, and custom applications can be registered against it so they use the
            same identities.

            The other three services are all security-adjacent, which is what makes them plausible:
            Key Vault stores secrets and certificates, Sentinel is the security information and
            event management solution, and Azure Policy governs resource configuration. None of
            them signs a user in.
            """,
            """
            All four are security services. Only one of them answers the question of who a user is.
            """);

        yield return Mc("id-003", D2, "Describe Azure identity, access, and security", R5,
            """
            A startup with no servers of its own wants to use Microsoft Entra ID. An adviser tells
            it that an on-premises Active Directory domain must be deployed first.

            Which statement is correct?
            """,
            [
                "The adviser is wrong: Entra ID can run entirely in the cloud, and synchronising an existing on-premises directory is optional.",
                "The adviser is right: Entra ID is a cloud-hosted copy of Active Directory Domain Services and needs a source domain.",
                "The adviser is right, but only because the startup wants single sign-on, which requires an on-premises domain.",
                "The adviser is wrong, because Entra ID can authenticate only Microsoft 365 users and so is unsuitable anyway."
            ], "A",
            """
            Entra ID is cloud-native and needs nothing on-premises. Organisations that already run
            Active Directory can synchronise it to create a hybrid identity model, but that is a
            choice for organisations with an existing investment, not a prerequisite.

            The distinction the adviser has missed is that Entra ID is not Active Directory Domain
            Services in the cloud. It does not do domain join, Group Policy or LDAP; the service
            that provides those is Microsoft Entra Domain Services.
            """,
            """
            Ask whether these two directory products are the same thing in different places, or
            genuinely different services that share part of a name.
            """);

        yield return Mc("id-004", D2, "Describe Azure identity, access, and security", R5,
            """
            You must run a legacy application on Azure virtual machines. It requires domain join,
            Group Policy and LDAP, and you do not want to deploy or maintain domain controllers.

            Which service should you use?
            """,
            [
                "Microsoft Entra Domain Services.",
                "Microsoft Entra ID.",
                "Domain controllers on Azure virtual machines, joined to the existing forest.",
                "Microsoft Entra External ID."
            ], "A",
            """
            Microsoft Entra Domain Services provides managed domain capabilities, including domain
            join, Group Policy, Kerberos, NTLM and LDAP, with Microsoft running the domain
            controllers.

            Entra ID alone cannot do this: it is a modern identity service and offers none of those
            legacy protocols, which is the single most useful distinction in this area. Running
            your own domain controllers on virtual machines would work and reintroduces exactly the
            maintenance the stem rules out. External ID handles customer and partner identities.
            """,
            """
            Two Entra services have similar names and only one speaks the old protocols. The final
            clause then eliminates the do-it-yourself option.
            """);

        yield return Mc("id-005", D2, "Describe Azure identity, access, and security", R5,
            """
            Users sign in once in the morning and then move between several applications without
            being prompted again. A security lead argues this weakens security.

            Which response is correct?
            """,
            [
                "Single sign-on concentrates protection on one strong sign-in, which is why it is normally paired with multifactor authentication and Conditional Access rather than avoided.",
                "The security lead is right: single sign-on removes authentication from every application after the first.",
                "The security lead is right: single sign-on and multifactor authentication cannot be used together.",
                "Single sign-on is a form of authorization, so it has no bearing on how users authenticate."
            ], "A",
            """
            Single sign-on lets one authenticated session grant access to multiple applications, so
            users are not challenged repeatedly. The trade is real: that one sign-in matters more,
            which is precisely why it is protected with multifactor authentication and evaluated by
            Conditional Access rather than treated as a weakness to avoid.

            Authentication still happens for each application, using the established session rather
            than a fresh credential prompt, and single sign-on is an authentication behaviour, not
            an authorization one.
            """,
            """
            The security lead has a point about concentration of risk. Ask what is normally done
            about it rather than whether the concern is imaginary.
            """);

        yield return Mc("id-006", D2, "Describe Azure identity, access, and security", R5,
            """
            A policy requires two verifications before sign-in completes. Which combination
            satisfies multifactor authentication?
            """,
            [
                "A password and an approval prompt in an authenticator application, because they are different kinds of factor.",
                "A password and a security question, because the user must supply two separate answers.",
                "A password and the same password re-entered on a second screen, because it is verified twice.",
                "A fingerprint and a facial scan, because two biometric readings are always two factors."
            ], "A",
            """
            Multifactor authentication requires two or more distinct kinds of verification, usually
            described as something you know, something you have and something you are. A password
            is something you know; an approval in an authenticator app is something you have, so
            the pair qualifies.

            A security question is another thing you know, and re-entering a password is the same
            thing twice, so neither adds a factor. Two biometrics are both something you are, which
            is why they do not count as two factors either, even though each is strong on its own.
            """,
            """
            Count the categories rather than the prompts. Two challenges drawn from the same
            category do not make two factors.
            """);

        yield return Mc("id-007", D2, "Describe Azure identity, access, and security", R5,
            """
            You must allow sign-in without a prompt from the corporate office, require multifactor
            authentication from anywhere else, and block sign-in outright from countries the
            company does not operate in.

            Which feature should you use?
            """,
            [
                "Conditional Access.",
                "Role-based access control.",
                "Azure Policy.",
                "Microsoft Entra Privileged Identity Management."
            ], "A",
            """
            Conditional Access evaluates signals such as location, device state, application and
            sign-in risk, and then allows, blocks or requires an extra control such as multifactor
            authentication. All three behaviours in the stem come from one Conditional Access
            policy.

            Role-based access control decides what an authenticated user may do rather than whether
            they may sign in, Azure Policy governs resource configuration, and Privileged Identity
            Management handles just-in-time elevation of privileged roles.
            """,
            """
            Every requirement here is decided at the moment of sign-in and depends on where the
            user is. That narrows it to one feature.
            """);

        yield return YesNo("id-008", D2, "Describe Azure identity, access, and security", R5,
            """
            For each of the following statements, select Yes if the statement is true. Otherwise,
            select No.
            """,
            [
                ("Single sign-on reduces the number of times a user must enter credentials.", true),
                ("Multifactor authentication and single sign-on are mutually exclusive.", false),
                ("Conditional Access can require multifactor authentication based on the user location.", true),
                ("Conditional Access decides what an authenticated user may do to a resource.", false)
            ],
            """
            Single sign-on reduces repeated credential prompts, and Conditional Access can use
            location as one of the signals that triggers a multifactor requirement. The two are
            complementary, not exclusive: one strong sign-in protected by multifactor, then single
            sign-on for everything after it, is the standard design.

            The last statement swaps two mechanisms that both feel like access control. Conditional
            Access decides whether a sign-in is permitted and under what conditions; what an
            authenticated user may then do to a resource is role-based access control.
            """,
            """
            The last statement describes a real capability under the wrong name. Work out which
            feature actually owns that decision.
            """);

        // ---------------------------------------------------------- RBAC

        yield return Mc("id-009", D2, "Describe Azure identity, access, and security", R5,
            """
            An application running in Azure needs read access to one storage account, without any
            credential stored in its configuration.

            Which three elements make up the role assignment that grants this, and what is the
            security principal?
            """,
            [
                "A security principal, a role definition and a scope, and the principal is the application managed identity.",
                "A security principal, a role definition and a scope, and the principal must be a user account the application signs in as.",
                "A user, a password and a policy, and the principal is the application service account.",
                "A subscription, a resource group and a tag, and the principal is the resource group."
            ], "A",
            """
            Every role assignment combines who is granted access, what they may do, and where it
            applies: security principal, role definition and scope.

            A security principal is not only a user. It may be a group, a service principal
            representing an application, or a managed identity, and a managed identity is what
            satisfies the requirement that no credential be stored, because Azure handles the
            credential for you.
            """,
            """
            The three elements are the easy half. The other half asks what can occupy the first
            slot, and the answer is broader than a person.
            """);

        yield return Mc("id-010", D2, "Describe Azure identity, access, and security", R5,
            """
            A platform engineer must create and manage every resource type in a subscription but
            must not be able to grant access to anyone else. A separate identity team will handle
            access grants.

            Which two built-in roles should be assigned, one to each? Each correct answer presents
            part of the solution.
            """,
            [
                "Contributor, for the platform engineer.",
                "User Access Administrator, for the identity team.",
                "Owner, for the platform engineer.",
                "Reader, for the identity team.",
                "Security Admin, for the identity team."
            ], "A,B",
            """
            Contributor can create and manage resources of every type and cannot grant access to
            others, which is exactly the separation the stem describes. Its complement is User
            Access Administrator, which manages access without being able to manage resources.

            Owner is the wrong answer precisely because it combines both powers, which is what the
            organisation is trying to split. Reader can only view, and Security Admin governs
            security settings rather than access assignment.
            """,
            """
            The two roles you want are the two halves of a third role. Identify the role being
            deliberately avoided and the answer follows.
            """);

        yield return Mc("id-011", D2, "Describe Azure identity, access, and security", R5,
            """
            An audit finds several standing Owner assignments at subscription scope.

            Why is that a concern, and what is the recommended alternative?
            """,
            [
                "Owner combines full resource management with the ability to assign roles, so it should be granted sparingly and, where possible, activated just in time rather than held permanently.",
                "Owner is not a concern at subscription scope, because its powers apply only to the resource groups inside it.",
                "Owner is a concern because it cannot assign roles, so administrators work around it with shared credentials.",
                "Owner is a concern, and the recommended alternative is to assign Reader to everyone and grant access manually per request."
            ], "A",
            """
            Owner is the most privileged of the fundamental built-in roles because it does two
            things at once: full management of resources, and delegation of access to others. A
            standing assignment therefore means a permanent path to granting anyone else anything.

            The recommended answer is not to remove capability but to remove permanence, elevating
            into the role only when it is needed and for a limited time. Assigning Reader to
            everyone and handling each request by hand is not a workable control.
            """,
            """
            Two separate powers are bundled into this one role. Once you see both, the issue with
            holding it permanently follows.
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
                ("Manage all resources and delegate access to others", 3),
                ("Restart a virtual machine and resize its disk, nothing more", 2)
            ],
            """
            Reader is view-only and Contributor adds full resource management while withholding
            delegation. User Access Administrator is the mirror image of Contributor: access but
            not resources. Owner combines both and is the most privileged.

            The last row is a reminder that "least privileged" is judged among the roles offered.
            Restarting and resizing are write operations, so Reader is insufficient, and Contributor
            is the least privileged of the remaining choices even though a narrower role such as
            Virtual Machine Contributor would be better still in practice.
            """,
            """
            The word "least" governs every row. For the last one, decide first whether the action
            changes anything.
            """);

        yield return Mc("id-013", D2, "Describe Azure identity, access, and security", R5,
            """
            A user is assigned Reader at a resource group and Contributor at the subscription
            containing it. An administrator expected the narrower assignment to restrict the user.

            What is the effective permission on resources in that resource group, and why?
            """,
            [
                "Contributor, because Azure RBAC is additive and the union of all applicable assignments applies; a narrower assignment does not override a broader one.",
                "Reader, because the assignment closest to the resource takes precedence over inherited ones.",
                "No access, because the two assignments conflict and Azure resolves conflicts by denying.",
                "Owner, because two overlapping assignments are merged into the next role up."
            ], "A",
            """
            Azure role-based access control combines the permissions of every applicable
            assignment, so the effective result is the union rather than the narrowest. The
            Contributor role inherited from the subscription therefore wins.

            The administrator expectation is the misconception being tested: there is no
            precedence rule that lets a lower scope subtract permissions. Removing access means
            removing the broader assignment, or using deny assignments, which are a separate
            mechanism.
            """,
            """
            Ask whether Azure RBAC ever subtracts. If it only ever adds, the answer follows
            directly.
            """);

        yield return Mc("id-014", D2, "Describe Azure identity, access, and security", R5,
            """
            Group Alpha is assigned the Contributor role. Group Beta is a member of Group Alpha,
            and a user is a member of Group Beta only.

            What access does the user have, and what does that imply for access reviews?
            """,
            [
                "Contributor, because group role assignments are transitive through nested groups, so reviews must follow the whole membership chain.",
                "No access, because role assignments do not flow through nested groups, so only direct members need reviewing.",
                "Reader, because nested membership confers a reduced version of the role.",
                "Contributor, but only once the assignment is repeated directly on Group Beta."
            ], "A",
            """
            Role assignments made to a group are transitive: the user inherits Contributor through
            the full chain of nested memberships without any direct assignment.

            That is what makes group-based assignment workable at scale, and it is also the risk.
            Looking at who is directly in the group that holds the role tells you very little, so a
            meaningful access review has to expand nested groups.
            """,
            """
            Work out whether the role reaches the user first. The consequence for reviews follows
            from whichever answer you reach.
            """);

        yield return Mc("id-015", D2, "Describe Azure identity, access, and security", R5,
            """
            At which four scopes can an Azure role assignment be applied, and how does an assignment
            behave with respect to the scopes beneath it?
            """,
            [
                "Management group, subscription, resource group and resource, and an assignment is inherited by everything below the scope it is made at.",
                "Management group, subscription, resource group and resource, and an assignment applies only at the exact scope it is made at.",
                "Tenant, geography, region and availability zone, and an assignment is inherited downward.",
                "Billing account, billing profile, invoice section and subscription, and an assignment is inherited downward."
            ], "A",
            """
            Role assignments are made at a management group, a subscription, a resource group or an
            individual resource, and inheritance is the whole reason the hierarchy matters: an
            assignment flows down to every scope beneath it.

            The other two lists are real Azure hierarchies borrowed from elsewhere, the geographic
            one and the billing one, neither of which is an RBAC scope.
            """,
            """
            Two options list the same four scopes. What separates them is what an assignment does
            once it is made.
            """);

        yield return Mc("id-016", D2, "Describe Azure identity, access, and security", R5,
            """
            A user holds the Global Administrator role in Microsoft Entra ID and reports being
            unable to restart a virtual machine.

            Which statement explains this?
            """,
            [
                "Entra ID roles govern directory objects and tenant features, while Azure RBAC roles govern Azure resources; the two systems are assigned separately.",
                "Global Administrator includes every Azure resource permission, so the failure must be a service outage.",
                "Entra ID roles govern Azure resources and Azure RBAC roles govern directory objects, so the user needs an Entra ID role instead.",
                "The two role systems are the same, so the user simply needs to sign out and back in."
            ], "A",
            """
            Microsoft Entra ID roles such as Global Administrator and User Administrator control
            directory objects and tenant-level features: users, groups, application registrations
            and the like. Azure RBAC roles such as Owner, Contributor and Reader control what can be
            done with Azure resources.

            They are separate systems with separate assignments, which is exactly why the most
            privileged directory role in the tenant confers no ability to restart a virtual
            machine. A Global Administrator can elevate to gain Azure access, but that is a
            deliberate, auditable action rather than something the role includes.
            """,
            """
            The role name suggests it covers everything. Ask what the word "directory" is limiting
            it to.
            """);

        yield return Mc("id-017", D2, "Describe Azure identity, access, and security", R5,
            """
            An application on an Azure virtual machine must authenticate to Azure Key Vault. Nothing
            resembling a credential may be stored in its configuration, and nobody wants to rotate a
            secret on a schedule.

            What should you use?
            """,
            [
                "A managed identity.",
                "A service principal with a client secret stored in an environment variable.",
                "A shared access signature with a very long expiry.",
                "A certificate stored on the virtual machine local disk."
            ], "A",
            """
            A managed identity lets an Azure service authenticate to other services that support
            Microsoft Entra authentication with no credential created, stored or rotated by the
            developer. Azure manages the underlying credential and its lifecycle.

            Every alternative here puts a secret somewhere, whether in an environment variable, a
            long-lived signature or a file on disk, which is the exact risk managed identities were
            designed to remove. The second clause about rotation is what rules out even the
            better-managed of those options.
            """,
            """
            Three options differ only in where the secret is kept. The stem asks for one where
            there is no secret to keep.
            """);

        // ---------------------------------------------------------- zero trust and defence in depth

        yield return Mc("id-018", D2, "Describe Azure identity, access, and security", R5,
            """
            Which three principles guide the Zero Trust model?
            """,
            [
                "Verify explicitly, use least privilege access, and assume breach.",
                "Verify explicitly, defend the perimeter, and assume breach.",
                "Trust but verify, encrypt everything, and centralise logging.",
                "Authenticate, authorise, and audit."
            ], "A",
            """
            Zero Trust rests on verifying explicitly using every available signal, granting least
            privilege through just-in-time and just-enough-access techniques, and assuming breach by
            compartmentalising access and instrumenting the environment.

            The strongest distractor swaps one principle for perimeter defence, which is precisely
            the model Zero Trust replaces: trust is no longer conferred by network location, so
            defending a boundary cannot be one of its principles.
            """,
            """
            One option gets two of the three right. The wrong one belongs to the model Zero Trust
            was created to move away from.
            """);

        yield return Mc("id-019", D2, "Describe Azure identity, access, and security", R5,
            """
            A network team argues that traffic from the corporate LAN can skip additional
            verification because the LAN is internal.

            How does the Zero Trust model answer that?
            """,
            [
                "Network location never establishes trust: every user and device is verified regardless of where the request originates, and access is continually re-evaluated.",
                "The team is correct, because Zero Trust applies only to requests arriving from the internet.",
                "The team is correct once users have completed multifactor authentication, after which trust is permanent.",
                "Zero Trust has no view on network location, because it governs only what an authenticated user may do."
            ], "A",
            """
            Zero Trust removes exactly the assumption the team is making, that being inside a
            boundary is evidence of safety. Every user and device is verified, access is granted
            narrowly, and it is re-evaluated rather than conferred once.

            The other options each preserve some form of implicit trust, whether by network origin
            or by treating a single strong sign-in as permanent. Zero Trust also very much has a
            view on location: it uses it as one signal among many, never as a substitute for
            verification.
            """,
            """
            The team argument rests on one assumption. Identify it, and note that it is the exact
            assumption the model is named after rejecting.
            """);

        yield return Mc("id-020", D2, "Describe Azure identity, access, and security", R5,
            """
            A design uses disk encryption, a network firewall, role-based access control and
            physical data centre controls, so that defeating any one of them still leaves an
            attacker short of the data.

            Which concept does this describe, and how does it relate to Zero Trust?
            """,
            [
                "Defence in depth, and it is complementary to Zero Trust: one describes layering controls, the other describes how trust is granted.",
                "Defence in depth, and it replaces Zero Trust, since layered controls make continuous verification unnecessary.",
                "Zero Trust, and defence in depth is simply its outermost layer.",
                "Least privilege, and defence in depth is the mechanism that enforces it."
            ], "A",
            """
            Defence in depth layers independent controls from physical security through identity and
            access, perimeter, network, compute, application and finally data, so an attacker must
            defeat several measures rather than one.

            The relationship matters because the two ideas are often confused. Defence in depth is
            about how many independent barriers exist; Zero Trust is about whether trust is ever
            granted implicitly. A modern design uses both, and neither removes the need for the
            other.
            """,
            """
            Naming the concept is straightforward. The second half asks whether these two ideas
            compete or answer different questions.
            """);

        yield return Mc("id-021", D2, "Describe Azure identity, access, and security", R5,
            """
            In the defence in depth model, which layer is innermost, and which is outermost?
            """,
            [
                "Data is innermost and physical security is outermost.",
                "Physical security is innermost and data is outermost.",
                "Identity and access is innermost and data is outermost.",
                "Data is innermost and the network layer is outermost."
            ], "A",
            """
            Data sits at the centre of the model. Every other layer exists to keep unauthorised
            parties away from it, which is why it is drawn innermost.

            Physical security is the outermost layer, since an attacker standing in the data centre
            has bypassed everything else. Between them run identity and access, perimeter, network,
            compute and application.
            """,
            """
            Ask what the whole model exists to protect, and what an attacker would have to reach
            first before any digital control mattered.
            """);

        yield return Mc("id-022", D2, "Describe Azure identity, access, and security", R5,
            """
            An administrator holds no standing privileged role. To run a maintenance task she
            requests elevation, holds the role for two hours, and it then lapses. Her elevated role
            also covers only the one subscription she works on.

            Which two practices does this describe? Each correct answer presents part of the
            solution.
            """,
            [
                "Just-in-time access, for the two-hour window.",
                "Just-enough-access, for the single-subscription scope.",
                "Single sign-on, for the two-hour window.",
                "Federation, for the single-subscription scope.",
                "Defence in depth, for the combination of both."
            ], "A,B",
            """
            The scenario contains both halves of least privilege deliberately. Just-in-time access
            limits how long elevated permissions are held, so nothing is standing; just-enough-access
            limits how far they reach, so the role covers one subscription rather than the tenant.

            Together they express the least privilege principle of Zero Trust. Single sign-on and
            federation are authentication mechanisms, and defence in depth is about layering
            independent controls rather than scoping one.
            """,
            """
            Two different limits are applied here, one measured in time and one in scope. Each has
            its own name.
            """);

        // ---------------------------------------------------------- external identities

        yield return Mc("id-023", D2, "Describe Azure identity, access, and security", R5,
            """
            Engineers from a supplier must sign in to a shared project application using their own
            corporate credentials. Their employer should keep managing their accounts and passwords.

            Which capability should you use?
            """,
            [
                "Microsoft Entra business-to-business collaboration.",
                "Microsoft Entra business-to-consumer collaboration in an external tenant.",
                "Creating accounts for each engineer in your own tenant and issuing them passwords.",
                "Microsoft Entra Domain Services."
            ], "A",
            """
            Business-to-business collaboration invites partner users into your workforce tenant as
            guest users. Their identity stays with their own organisation, which keeps managing the
            account, the password and any offboarding; you control only what the guest may access.

            That division is the point of the final sentence in the stem. Creating local accounts
            would make you responsible for credentials belonging to someone else employees.
            Business-to-consumer is for consumers signing up with personal or social accounts.
            """,
            """
            The last sentence of the scenario decides this. Ask which option leaves the supplier
            still holding its own passwords.
            """);

        yield return Mc("id-024", D2, "Describe Azure identity, access, and security", R5,
            """
            What is the difference between a workforce tenant and an external tenant?
            """,
            [
                "A workforce tenant holds employee identities and internal resources; an external tenant hosts consumer-facing applications and keeps consumer identities apart from corporate resources.",
                "A workforce tenant hosts consumer applications; an external tenant holds employee identities.",
                "A workforce tenant supports only cloud-only accounts; an external tenant supports only synchronised accounts.",
                "There is no functional difference, and the names are interchangeable."
            ], "A",
            """
            A workforce tenant is the standard tenant containing employee identities, internal
            applications and corporate resources, and it is also where partner guests appear under
            business-to-business collaboration.

            An external tenant serves customer-facing scenarios, keeping consumer identities and
            their applications separate from corporate resources and allowing the sign-in
            experience to be branded and customised. The separation is the reason a distinct tenant
            type exists at all.
            """,
            """
            Both tenant types hold identities that are not employees in some sense. Ask which one
            keeps those identities away from corporate resources by design.
            """);

        yield return YesNo("id-025", D2, "Describe Azure identity, access, and security", R5,
            """
            For each of the following statements about external identities, select Yes if the
            statement is true. Otherwise, select No.
            """,
            [
                ("In business-to-business collaboration, partner users appear as guest users in your tenant.", true),
                ("In business-to-consumer scenarios, consumers can sign in with a social account.", true),
                ("Your organisation becomes responsible for managing the passwords of business-to-business guest users.", false),
                ("Removing a guest user from your tenant disables that person account at their own employer.", false)
            ],
            """
            Partner users appear as guests in the workforce tenant, and consumer scenarios commonly
            allow sign-in with existing social or personal accounts.

            The two false statements are the same idea from opposite ends. A guest identity is a
            reference to an account owned elsewhere, so you never hold its password, and removing
            the guest revokes access to your resources without touching the account at the partner
            organisation. Credential management stays entirely with the home tenant.
            """,
            """
            The last two statements both ask who owns a guest account. Settling that once answers
            both.
            """);

        yield return Mc("id-026", D2, "Describe Azure identity, access, and security", R5,
            """
            An organisation must synchronise on-premises Active Directory identities to Microsoft
            Entra ID. It needs a scenario that only the full synchronisation application supports,
            and it accepts running a domain-joined server for it.

            Which tool should it use, and what is the alternative it is ruling out?
            """,
            [
                "Microsoft Entra Connect, ruling out Entra Cloud Sync, which uses lightweight agents and a cloud provisioning service but supports fewer scenarios.",
                "Microsoft Entra Cloud Sync, ruling out Entra Connect, which is being retired in favour of agents.",
                "Microsoft Entra Domain Services, ruling out Entra Connect, which cannot write to Entra ID.",
                "Microsoft Sentinel, ruling out Entra Connect, which does not monitor synchronisation health."
            ], "A",
            """
            Microsoft Entra Connect is the full synchronisation application installed on a
            domain-joined server, bringing the synchronisation service, health monitoring and a
            configuration wizard.

            Entra Cloud Sync is the lighter alternative: small agents plus a cloud-based
            provisioning service, simpler to run and to make highly available, at the cost of
            supporting a narrower set of scenarios. That trade is exactly what the stem is
            describing. Domain Services provides managed domain controllers rather than
            synchronisation.
            """,
            """
            Two tools do this job and differ in weight. The stem tells you which side of that
            trade-off the organisation has chosen.
            """);

        // ---------------------------------------------------------- security tools

        yield return Mc("id-027", D2, "Describe Azure identity, access, and security", R5,
            """
            A team wants one service that continuously assesses the configuration of its resources
            against security benchmarks, ranks what to fix first, and covers workloads in Azure and
            in another public cloud.

            Which service should it use?
            """,
            [
                "Microsoft Defender for Cloud.",
                "Microsoft Sentinel.",
                "Azure Advisor.",
                "Azure Monitor."
            ], "A",
            """
            Microsoft Defender for Cloud assesses resources against security benchmarks, produces
            prioritised hardening recommendations, expresses posture as a Secure Score, and adds
            workload threat protection. It covers Azure, AWS and Google Cloud, which is what the
            multicloud requirement points at.

            Azure Advisor is the closest distractor because it also gives recommendations, but
            across cost, reliability, performance and operations for Azure resources rather than
            deep security posture across clouds. Sentinel correlates events, and Monitor collects
            telemetry.
            """,
            """
            Two of these services hand you a list of recommendations. The scenario names the
            subject matter and the scope that separate them.
            """);

        yield return Mc("id-028", D2, "Describe Azure identity, access, and security", R5,
            """
            A security operations centre must collect signals from on-premises servers, Azure, a
            second cloud provider and several SaaS applications, group related alerts into a single
            incident, and trigger an automated response.

            Which service should it use, and how does it differ from the closest alternative?
            """,
            [
                "Microsoft Sentinel, because it is the SIEM that correlates estate-wide signals into incidents, whereas Defender for Cloud focuses on the posture and protection of cloud workloads.",
                "Microsoft Defender for Cloud, because Secure Score is calculated from correlated incidents.",
                "Microsoft Sentinel, because Defender for Cloud cannot generate any alerts of its own.",
                "Azure Monitor, because incident correlation is a feature of log queries."
            ], "A",
            """
            Microsoft Sentinel is the cloud-native security information and event management
            solution. It ingests signals from users, devices, applications and infrastructure across
            on-premises and multiple clouds, correlates related alerts into incidents, and runs
            playbooks to automate response.

            The distinction from Defender for Cloud is worth being precise about. Defender for Cloud
            secures and assesses cloud workloads and does generate alerts, which is why option C is
            wrong; Sentinel is the layer above that collects from Defender and everything else and
            reasons across the whole estate.
            """,
            """
            Both leading options are real security services from the same family. One protects
            workloads, the other watches everything at once.
            """);

        yield return Mc("id-029", D2, "Describe Azure identity, access, and security", R5,
            """
            An application must retrieve a database password, an API key and a TLS certificate at
            run time, with access to each one auditable and revocable.

            Which service should you use, and what should the application use to authenticate to
            it?
            """,
            [
                "Azure Key Vault, and the application should authenticate with a managed identity.",
                "Azure Key Vault, and the application should authenticate with a client secret stored in its configuration file.",
                "An Azure storage account with restricted access, and the application should authenticate with a shared access signature.",
                "Microsoft Entra ID, which stores application secrets directly on the app registration."
            ], "A",
            """
            Azure Key Vault centralises secrets, certificates and cryptographic keys so applications
            fetch them at run time, and centralising them is what makes access auditable and
            revocable in one place.

            The second half closes the obvious loop. Storing a client secret in configuration to
            reach the vault simply moves the problem one step, so the application should
            authenticate with a managed identity and hold no credential at all.
            """,
            """
            Choosing the vault is the easy half. Ask how the application proves who it is without
            recreating the very problem the vault solves.
            """);

        yield return Mc("id-030", D2, "Describe Azure identity, access, and security", R5,
            """
            A manager sees the Secure Score in Microsoft Defender for Cloud fall after a month of
            new deployments and asks what it means.

            Which explanation is correct?
            """,
            [
                "It measures how closely the environment matches recommended security controls, so adding resources that do not follow them lowers the score and shows what to remediate first.",
                "It measures the percentage of the monthly budget consumed, so more resources always lower it.",
                "It measures the availability commitment for the services in the subscription.",
                "It measures how many users have registered for multifactor authentication."
            ], "A",
            """
            Secure Score summarises current posture against recommended controls, grouped by control
            area, so a team can see where it stands and prioritise the changes with the largest
            effect.

            The scenario is the normal behaviour rather than a fault: deploying resources that do
            not yet follow the recommendations adds unmet controls and pulls the score down, which
            is precisely the signal it exists to give. It is not a cost, availability or
            registration metric.
            """,
            """
            The score moving down after new deployments is expected. Work out what the score is
            comparing against, and the reason becomes obvious.
            """);

        yield return Mc("id-031", D2, "Describe Azure identity, access, and security", R5,
            """
            A regulation states that your virtual machines must not run on physical hardware shared
            with other Microsoft customers.

            Which option addresses this, and what does it cost you?
            """,
            [
                "Azure Dedicated Host, which provisions physical servers for your exclusive use and is billed for the host whether or not the VMs on it are running.",
                "Azure Dedicated Host, which provisions physical servers for your exclusive use at no additional cost over the virtual machines.",
                "An availability set, which places the virtual machines on hardware reserved for one customer.",
                "A proximity placement group, which guarantees the virtual machines are the only ones on the host."
            ], "A",
            """
            Azure Dedicated Host provisions physical servers dedicated to a single customer, which
            is the only option here that actually addresses hardware isolation. Availability sets
            and proximity placement groups affect resilience and latency and place nothing
            exclusively.

            The cost half is the practical consequence: you are billed for the host itself, so
            capacity you do not fill is capacity you still pay for. That is the trade that makes
            dedicated hosting a compliance decision rather than a default one.
            """,
            """
            Only one option isolates hardware. The rest of the answer is about what you start
            paying for once you stop sharing.
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
                ("Correlate alerts from across the whole estate into incidents", 3),
                ("Authenticate users signing in to cloud applications", 4),
                ("Let an application prove its identity without holding a secret", 4)
            ],
            """
            Key Vault is the secret and certificate store, Defender for Cloud provides posture
            assessment with Secure Score, Sentinel correlates alerts into incidents, and Entra ID
            authenticates users.

            The last row is the one that repeats a service rather than adding a fifth. A managed
            identity is a Microsoft Entra ID feature, so identity, not Key Vault, is what lets an
            application authenticate with no secret of its own; Key Vault is then what that identity
            is used to open.
            """,
            """
            The final row sounds like the first one but is asking about a different half of the
            problem. Ask which service issues the identity rather than which one holds the secret.
            """);

        yield return Mc("id-033", D2, "Describe Azure identity, access, and security", R5,
            """
            An organisation wants administrators to hold no standing privileged roles, requesting
            elevation with approval and having it lapse automatically, with a full audit trail.

            Which capability provides this, and what edition is required?
            """,
            [
                "Microsoft Entra Privileged Identity Management, which requires Microsoft Entra ID Premium P2.",
                "Microsoft Entra Privileged Identity Management, which is included in the Free edition.",
                "Conditional Access, which requires Microsoft Entra ID Premium P1.",
                "Self-service password reset, which requires Microsoft Entra ID Premium P1."
            ], "A",
            """
            Privileged Identity Management provides discovery, approval workflows, time-bound role
            activation and auditing, so elevated rights are held only while they are needed. It is
            the mechanism behind just-in-time administrative access.

            It is a Premium P2 feature, alongside identity protection. Conditional Access is a real
            capability at P1 and decides whether a sign-in is allowed rather than managing role
            elevation, so it does not meet the requirement even though the licence tier is lower.
            """,
            """
            Name the capability first, then recall which premium tier it belongs to. The two
            premium tiers each own different features.
            """);

        yield return YesNo("id-034", D2, "Describe Azure identity, access, and security", R5,
            """
            For each of the following statements about Azure role-based access control, select Yes
            if the statement is true. Otherwise, select No.
            """,
            [
                ("A role assignment made at a subscription is inherited by all resource groups in it.", true),
                ("A managed identity can be the security principal in a role assignment.", true),
                ("Assigning two roles to the same user means the more restrictive one takes effect.", false),
                ("Azure RBAC roles and Microsoft Entra ID roles are assigned through the same system.", false)
            ],
            """
            Assignments are inherited downward through the scope hierarchy, and a security principal
            may be a user, a group, a service principal or a managed identity.

            The model is additive, so overlapping assignments combine and the most permissive result
            applies. And the two role systems are genuinely separate: Entra ID roles govern
            directory objects while Azure RBAC roles govern resources, which is why a Global
            Administrator has no inherent power over a virtual machine.
            """,
            """
            The last two statements are both about how assignments combine or where they live. Neither
            works the way a single unified permissions system would.
            """);

        yield return Mc("id-035", D2, "Describe Azure identity, access, and security", R5,
            """
            A company on the Microsoft Entra ID Free edition wants to require multifactor
            authentication only when users sign in from outside the office.

            What must change?
            """,
            [
                "It must move to Microsoft Entra ID Premium P1 or P2, because Conditional Access policies are not available in the Free edition.",
                "Nothing, because Conditional Access is available in every edition including Free.",
                "It must move to Premium P2 specifically, because Conditional Access is a P2-only feature.",
                "Nothing, because location-based rules are configured in Azure Policy rather than in Entra ID."
            ], "A",
            """
            Conditional Access is what evaluates a signal such as location and then requires an
            extra control, and it requires a Premium P1 or P2 licence. It is also included with
            Microsoft 365 Business Premium.

            The Free edition covers user and group management, directory synchronisation and basic
            single sign-on, but not conditional policies. P2 adds Privileged Identity Management and
            identity protection on top of P1, so restricting this feature to P2 alone is wrong.
            Azure Policy governs resource configuration, not sign-in.
            """,
            """
            The requirement is conditional on a signal, which names the feature. The rest is
            recalling the lowest paid tier that includes it.
            """);
    }
}
