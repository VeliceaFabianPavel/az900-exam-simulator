using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Chapter 5 of the study guide: Identity, Access, and Security (pages 186-232).
// The network security section is out of scope here, matching QuestionBank.
// Original wording written against the factual content of that chapter.
public static partial class TrainingCatalog
{
    private const string M4 = "Study guide, ch. 5: Identity, Access, and Security";

    private static TrainingModule IdentityModule() => new()
    {
        Id = "m4",
        Title = "Identity, access and security",
        Domain = ExamDomain.ArchitectureAndServices,
        Reference = M4,
        Pages = "ch. 5, p186-232",
        Blurb = "Who a user is, what they are allowed to do, and the models and tools Azure "
              + "uses to decide both.",
        Lessons =
        [
            new Lesson
            {
                Id = "m4-l1",
                Title = "Directory services in Azure",
                Objective = "Describe Azure identity, access, and security",
                Pages = "p186-194",
                Intro = Para("""
                    Two Microsoft directory products share part of a name and do different jobs.
                    Telling them apart is the single most useful distinction in this chapter.
                    """),
                Points =
                [
                    "Microsoft Entra ID provides identity management for Azure, signing users in to cloud services and to Azure resources.",
                    "The Free edition covers user and group management, synchronisation with an on-premises directory, basic reporting, self-service password change, and single sign-on for Azure, Microsoft 365 and Dynamics 365.",
                    "Premium editions add capabilities such as authenticating to on-premises resources, self-service password reset for on-premises users, and dynamic groups. Conditional Access requires a Premium licence.",
                    "Entra ID can run entirely in the cloud. Synchronising an existing on-premises directory is optional, and creates a hybrid identity model.",
                    "Microsoft Entra Domain Services provides managed domain capabilities such as domain join, Group Policy, Kerberos, NTLM and LDAP, with Microsoft running the domain controllers.",
                    "Microsoft Entra Connect is the full synchronisation application installed on a domain-joined server; Entra Cloud Sync is the lighter agent-based alternative supporting fewer scenarios."
                ],
                Essentials =
                [
                    "Entra ID is not Active Directory Domain Services in the cloud. It offers none of the legacy protocols; Entra Domain Services is what does.",
                    "A legacy application needing domain join, Group Policy or LDAP points at Entra Domain Services, not Entra ID."
                ]
            },

            new Lesson
            {
                Id = "m4-l2",
                Title = "Authentication and authorization",
                Objective = "Describe Azure identity, access, and security",
                Pages = "p194-202",
                Intro = Para("""
                    Two questions that sound like one. Authentication asks who you are;
                    authorization asks what you may do. They are evaluated separately, which is
                    why a perfect sign-in can still be refused at a resource.
                    """),
                Points =
                [
                    "Authentication identifies the user. Authorization determines whether that identified user may use a resource.",
                    "Single sign-on lets one set of credentials reach multiple resources, so users are not challenged repeatedly.",
                    "Multifactor authentication requires more than one kind of verification, such as a password combined with an approval or code sent to a registered device.",
                    "Passwordless methods replace the password entirely with something you have and something you are or know, such as an authenticator app or a security key.",
                    "Conditional Access evaluates signals such as user location, device, and the application being reached, then decides whether to allow, block, or require an additional control."
                ],
                Essentials =
                [
                    "Multifactor means factors of different kinds. Two things you know, such as a password and a security question, are not two factors.",
                    "Single sign-on and multifactor authentication are complementary, not alternatives. The standard design is one strong, well-protected sign-in followed by single sign-on for everything after it.",
                    "Conditional Access decides whether a sign-in is permitted. What an authenticated user may then do to a resource is role-based access control."
                ]
            },

            new Lesson
            {
                Id = "m4-l3",
                Title = "External identities: B2B and B2C",
                Objective = "Describe Azure identity, access, and security",
                Pages = "p202-208",
                Intro = Para("""
                    Microsoft Entra External ID lets people outside your organisation reach your
                    resources using an identity they already have. Which tenant holds them is
                    what separates the two scenarios.
                    """),
                Points =
                [
                    "External identities use a bring-your-own-identity approach, so external users authenticate with accounts they already hold, including social accounts.",
                    "In business-to-business collaboration, partner users appear as guests in your own internal tenant.",
                    "In business-to-consumer scenarios, a separate external tenant manages the external users, keeping them apart from corporate resources.",
                    "You can control branding and the sign-up experience, capture profile information, and collaborate or transact with these users."
                ],
                Essentials =
                [
                    "B2B uses your internal tenant; B2C uses a separate external tenant. That is the distinction questions turn on.",
                    "A guest identity is a reference to an account owned elsewhere. You never hold its password, and removing the guest revokes access to your resources without touching the account at their employer."
                ]
            },

            new Lesson
            {
                Id = "m4-l4",
                Title = "Role-based access control",
                Objective = "Describe Azure identity, access, and security",
                Pages = "p208-214",
                Intro = Para("""
                    Azure RBAC is the primary authorization mechanism. Every assignment answers
                    three questions, and the way overlapping assignments combine catches people
                    out.
                    """),
                Points =
                [
                    "A role assignment combines a security principal (who), a role definition (what they may do), and a scope (where it applies).",
                    "A security principal may be a user, a group, a service principal representing an application, or a managed identity.",
                    "The common built-in roles are Owner, Contributor, Reader and User Access Administrator.",
                    "Contributor can create and manage resources of every type but cannot grant access to others. User Access Administrator is its mirror: access but not resources. Owner combines both.",
                    "Assignments can be made at management group, subscription, resource group or resource scope, and are inherited by everything beneath.",
                    "Permissions granted through RBAC are additive, so the effective result of overlapping assignments is the union.",
                    "Role assignments made to a group are transitive through nested group memberships."
                ],
                Essentials =
                [
                    "Because RBAC only ever adds, a narrower assignment cannot restrict a broader one. Removing access means removing the broader assignment.",
                    "Entra ID roles and Azure RBAC roles are separate systems assigned separately. A Global Administrator has no inherent power over a virtual machine.",
                    "A managed identity as the principal is what lets an application authenticate with no credential stored anywhere."
                ]
            },

            new Lesson
            {
                Id = "m4-l5",
                Title = "Zero Trust and defence in depth",
                Objective = "Describe Azure identity, access, and security",
                Pages = "p214-220",
                Intro = Para("""
                    Two security models that are often confused. One is about whether trust is
                    ever granted implicitly; the other is about how many independent barriers
                    stand between an attacker and the data.
                    """),
                Points =
                [
                    "Zero Trust grants no implicit trust to any user or device, whether inside your environment or outside it.",
                    "Every access request is verified against criteria including identity, location, device health and other conditional access signals.",
                    "Its three principles are verify explicitly, use least privilege access, and assume breach.",
                    "Least privilege is delivered through just-in-time access, which limits how long elevated rights are held, and just-enough-access, which limits how far they reach.",
                    "Defence in depth layers independent controls so that defeating any one of them still leaves the attacker short.",
                    "The layers run from physical security on the outside through identity and access, perimeter, network, compute and application, to data at the centre.",
                    "Azure Dedicated Host maps a physical server to your subscription so virtual machines run on hardware not shared with other organisations."
                ],
                Essentials =
                [
                    "Network location never establishes trust under Zero Trust. Being on the corporate LAN is not evidence of anything.",
                    "Data is the innermost layer of defence in depth and physical security the outermost. Every other layer exists to keep unauthorised parties away from the data.",
                    "The two models are complementary. Defence in depth counts the barriers; Zero Trust decides whether trust is ever assumed."
                ]
            },

            new Lesson
            {
                Id = "m4-l6",
                Title = "Security tools in Azure",
                Objective = "Describe Azure identity, access, and security",
                Pages = "p220-232",
                Intro = Para("""
                    Several security services with adjacent names. Sort them by the question each
                    one answers: where are my secrets, how healthy is my posture, and what is
                    happening across the estate.
                    """),
                Points =
                [
                    "Azure Key Vault is a secure repository for certificates, keys and other secrets, which applications call at run time rather than embedding the secret in code.",
                    "Microsoft Defender for Cloud assesses the security posture of resources, produces prioritised hardening recommendations, and expresses posture as a Secure Score.",
                    "Microsoft Sentinel is a security information and event management system. It collects data from users, devices, applications and infrastructure across on-premises and multiple clouds, and detects threats using built-in analytics, known-threat intelligence and machine learning.",
                    "Custom rules can be added to Sentinel to search for specific threat criteria.",
                    "Microsoft Entra Privileged Identity Management provides oversight of privileged roles, including approval workflows, time-bound activation and auditing."
                ],
                Essentials =
                [
                    "Defender for Cloud secures and assesses workloads. Sentinel sits above it, collecting from Defender and everything else to reason across the whole estate.",
                    "An application should reach Key Vault using a managed identity. Storing a secret in order to fetch secrets simply moves the problem."
                ]
            }
        ]
    };
}
