using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Chapter 8 of the study guide: Creating and Managing Azure Resources (pages 289-345).
// The step-by-step lab exercises are out of scope here, matching QuestionBank.
// Original wording written against the factual content of that chapter.
public static partial class TrainingCatalog
{
    private const string M7 = "Study guide, ch. 8: Creating and Managing Azure Resources";

    private static TrainingModule ToolsModule() => new()
    {
        Id = "m7",
        Title = "Managing Azure resources",
        Domain = ExamDomain.ManagementAndGovernance,
        Reference = M7,
        Pages = "ch. 8, p289-345",
        Blurb = "The tools for deploying and managing resources, and how to pick the right one "
              + "for the job in front of you.",
        Lessons =
        [
            new Lesson
            {
                Id = "m7-l1",
                Title = "The Azure portal and the mobile app",
                Objective = "Describe features and tools for managing Azure resources",
                Pages = "p289-296",
                Intro = Para("""
                    The two graphical tools. Both are good at the same thing, one-off work, and
                    both are the wrong answer when a task has to be repeated.
                    """),
                Points =
                [
                    "The Azure portal is the browser-based graphical interface and the primary tool for managing resources. It needs no installation and works from any modern operating system.",
                    "A blade is a panel in the portal presenting the settings, controls and information for a specific resource, service or task.",
                    "The portal is usually the simplest choice for relatively simple, one-off management tasks.",
                    "The Azure Mobile App provides management capabilities on Android and iOS, and naturally offers less than the portal, PowerShell or the CLI.",
                    "The mobile app is the right choice when you need that capability from a phone, such as checking health and restarting a resource while away from a computer."
                ],
                Essentials =
                [
                    "The portal is not scriptable. Fifty identical deployments means fifty passes through a wizard, which is where the command-line tools take over.",
                    "The mobile app is deliberately narrower than the portal, not a replacement for it."
                ]
            },

            new Lesson
            {
                Id = "m7-l2",
                Title = "Azure PowerShell, the CLI and Cloud Shell",
                Objective = "Describe features and tools for managing Azure resources",
                Pages = "p296-304",
                Intro = Para("""
                    Two command-line tools that do essentially the same job, and one browser-based
                    environment for running either. Questions here are usually decided by the
                    operator's existing skills, not by capability.
                    """),
                Points =
                [
                    "Azure PowerShell and the Azure CLI provide essentially the same management capabilities, offering command-line and scripted management of Azure resources and functions.",
                    "The main difference between them is syntax: PowerShell uses cmdlets, the CLI uses a Bash-like command style.",
                    "Both can be installed natively on a device, and both run on Windows, Linux and macOS.",
                    "The Azure Cloud Shell is a web-based environment specifically for running either Azure PowerShell or Azure CLI sessions.",
                    "Cloud Shell requires no local installation, which makes it the answer when installing tools is not possible.",
                    "For anything requiring complex actions, PowerShell or the CLI are more appropriate than the portal."
                ],
                Essentials =
                [
                    "Neither tool can do something the other cannot. Any option claiming a hard capability difference between them is wrong.",
                    "Both are cross-platform. Claims that PowerShell is Windows-only or the CLI is Linux-only are distractors.",
                    "The Azure CLI can be run from within PowerShell, so those are not mutually exclusive environments."
                ]
            },

            new Lesson
            {
                Id = "m7-l3",
                Title = "ARM templates and infrastructure as code",
                Objective = "Describe features and tools for managing Azure resources",
                Pages = "p304-310",
                Intro = Para("""
                    When a deployment has to be repeatable, neither the portal nor a script is
                    the right answer. A template declares the result you want and lets Azure
                    work out how to get there.
                    """),
                Points =
                [
                    "Azure Resource Manager templates are JSON documents declaring the resources to deploy and their properties.",
                    "A declarative approach states the desired end state and lets the platform determine the steps. An imperative approach, such as a shell script, lists the operations to perform in order.",
                    "Re-deploying a template converges the environment on the declared state rather than duplicating resources.",
                    "Bicep is a more concise authoring language that is transpiled into a standard ARM template before deployment, so the deployment behaviour is unchanged.",
                    "Templates are the appropriate choice for building repeatable processes that deploy many resources together with their related resources and policies."
                ],
                Essentials =
                [
                    "The difference between declarative and imperative shows up when you run the same thing twice. A template confirms the state; a script may perform the actions again.",
                    "Both approaches can be automated. Declarative does not mean automated and imperative does not mean manual."
                ]
            },

            new Lesson
            {
                Id = "m7-l4",
                Title = "Azure Arc and managing resources outside Azure",
                Objective = "Describe features and tools for managing Azure resources",
                Pages = "p310-314",
                Intro = Para("""
                    Azure's management tools normally govern Azure resources. Arc extends them
                    to servers and clusters that are staying exactly where they are.
                    """),
                Points =
                [
                    "Azure Arc extends Azure management, monitoring and compliance to resources located outside Azure, including on-premises and in other clouds such as AWS and GCP.",
                    "Arc projects those resources into Azure Resource Manager so they can be tagged, governed by Azure Policy, secured with role-based access control and watched by Azure Monitor.",
                    "An on-premises server is onboarded by installing the Azure Connected Machine agent, after which it has an Azure Resource Manager identifier and appears in the portal.",
                    "Kubernetes clusters running outside Azure can also be attached to Arc.",
                    "Arc-enabled data services can run in a disconnected mode, keeping management local and exporting metadata and billing information periodically, which supports data residency requirements."
                ],
                Essentials =
                [
                    "Nothing is relocated. Arc adds a management projection over a machine that never leaves its own rack, which is what separates it from a migration service.",
                    "Azure Migrate moves workloads into Azure; Arc governs them where they are."
                ]
            },

            new Lesson
            {
                Id = "m7-l5",
                Title = "Choosing the right tool",
                Objective = "Describe features and tools for managing Azure resources",
                Pages = "p314-316",
                Intro = Para("""
                    Most tooling questions describe a task and expect you to pick the
                    proportionate tool. The chapter gives a clear decision order, and it is
                    worth memorising as a sequence.
                    """),
                Points =
                [
                    "For a relatively simple, one-off management task, the portal is usually the simplest choice.",
                    "For that same capability from a phone, the Azure Mobile App is the right answer.",
                    "For anything requiring complex actions, Azure PowerShell or the Azure CLI are most appropriate.",
                    "Between PowerShell and the CLI, pick the one matching the operator's existing skills, since capability is essentially equal.",
                    "For repeatable deployment of many resources with their related services and policies, ARM templates are the appropriate choice.",
                    "Leaving resources running costs money even on a free subscription, so unused resources, and especially virtual machines, should be turned off."
                ],
                Essentials =
                [
                    "Read the scenario for repeatability and for evidence. A one-off change points at the portal; a process that must be repeated and reviewed points at a template.",
                    "A Bash-fluent operator retrieving a property points at the CLI, not because PowerShell cannot do it, but because the question is about fit."
                ]
            }
        ]
    };
}
