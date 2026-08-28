using MockExam.Fluent.Models;

namespace MockExam.Fluent.Services;

// Chapter 1 of the study guide: Cloud Concepts (pages 56-89).
// Original wording written against the factual content of that chapter.
public static partial class TrainingCatalog
{
    private const string M1 = "Study guide, ch. 1: Cloud Concepts";

    private static TrainingModule CloudConceptsModule() => new()
    {
        Id = "m1",
        Title = "Cloud concepts",
        Domain = ExamDomain.CloudConcepts,
        Reference = M1,
        Pages = "ch. 1, p56-89",
        Blurb = "What the cloud is, what it costs, what it promises, and who is responsible "
              + "for which part of it.",
        Lessons =
        [
            new Lesson
            {
                Id = "m1-l1",
                Title = "What cloud computing actually is",
                Objective = "Describe cloud computing",
                Pages = "p57-60",
                Intro = Para("""
                    Cloud computing means consuming compute, storage and networking as a service
                    from a provider that owns the hardware, instead of buying and housing that
                    hardware yourself. The provider runs the data centres; you rent capacity in
                    them and manage progressively less of the stack the higher up you buy.

                    Microsoft sells three cloud offerings, and only one of them is on this exam.
                    Knowing which is which is worth a mark on its own.
                    """),
                Points =
                [
                    "Azure is the broad platform for infrastructure, data, application and AI services, and it is the offering AZ-900 covers.",
                    "Microsoft 365 is the end-user productivity bundle: Windows, Office, SharePoint, OneDrive.",
                    "Dynamics 365 covers enterprise resource planning and customer relationship management.",
                    "A data centre is a purpose-built facility for servers and supporting infrastructure. Organisations either own one, rent space in someone else's, or keep a small server room on site.",
                    "Moving to a provider removes the need to own that facility, and turns managing the workload into a responsibility split between you and the provider.",
                    "A provider also offers something almost no single organisation can build: data centres spread across the world, close enough to users to keep latency low."
                ],
                Essentials =
                [
                    "Microsoft 365 and Dynamics 365 are not examinable here. If a question offers them as answers to an Azure platform question, they are distractors.",
                    "The global distribution point matters because it is a genuine capability difference, not just a cost saving. Building it yourself is usually neither affordable nor practical."
                ]
            },

            new Lesson
            {
                Id = "m1-l2",
                Title = "Cloud economics: CapEx, OpEx and consumption",
                Objective = "Describe the benefits of cloud computing",
                Pages = "p60-61",
                Intro = Para("""
                    The financial argument for the cloud rests on two ideas: what kind of expense
                    the money is, and what triggers the charge. Both come up repeatedly on the
                    exam, and both are decided by something other than the size of the payment.
                    """),
                Points =
                [
                    "Capital expenditure (CapEx) buys a hard asset, such as servers or network hardware. The purchase is large, planned well ahead, and written down over the life of the equipment.",
                    "Operational expenditure (OpEx) is the cost of running the business, such as a monthly bill for consumed Azure services.",
                    "A consumption-based model charges for resources while they are actually in use, so cost tracks usage rather than capacity.",
                    "Because charges follow consumption, shutting a resource down stops the charges associated with it.",
                    "Economies of scale are the provider's advantage: buying hardware in enormous volume lowers its unit cost, and sharing that infrastructure across many customers lowers the cost per customer again. Part of that saving reaches the customer as lower prices."
                ],
                Essentials =
                [
                    "What separates CapEx from OpEx is whether the money bought an asset you own, not whether the payment was large or paid up front.",
                    "Economies of scale are a supply-side fact about the provider. Consumption-based pricing is a demand-side fact about your bill. Questions often offer both and expect you to pick the one being described."
                ],
                Table = new LessonTable(
                    "Which side of the line",
                    ["Spend", "Model"],
                    [
                        ["Buying servers for your own data centre", "CapEx"],
                        ["Perpetual software licences for owned hardware", "CapEx"],
                        ["Monthly metered charge for Azure compute", "OpEx"],
                        ["Per-user subscription to a hosted service", "OpEx"]
                    ])
            },

            new Lesson
            {
                Id = "m1-l3",
                Title = "Scalability, elasticity and agility",
                Objective = "Describe the benefits of high availability and scalability",
                Pages = "p61-65",
                Intro = Para("""
                    These three describe how quickly capacity and environments can change. They
                    are closely related and the exam expects you to keep them apart, so fix the
                    two axes of scaling first and the rest follows.
                    """),
                Points =
                [
                    "Scalability is the ability to adjust resources to meet demand. It may be done by hand or by rule.",
                    "Vertical scaling changes the capacity of an existing resource: scaling up adds CPU or memory to a machine, scaling down removes it.",
                    "Horizontal scaling changes the number of resources: scaling out adds instances, scaling in removes them.",
                    "Elasticity is the automatic case, where the platform adjusts capacity in response to measured demand with nobody in the loop at the time. Scalability is a function of elasticity.",
                    "Agility is the speed at which resources can be deployed and changed, which lets the business react quickly and cheaply."
                ],
                Essentials =
                [
                    "Up and down belong to the vertical axis; out and in belong to the horizontal one. Decide first whether the resource changed size or changed number.",
                    "Elasticity and agility both describe speed. Elasticity is a running workload resizing itself; agility is how fast you can stand up or tear down an environment.",
                    "Vertical scaling is capped by the largest available size and usually needs a restart. Horizontal scaling has no comparable ceiling, which is why it suits workloads that must stay up."
                ]
            },

            new Lesson
            {
                Id = "m1-l4",
                Title = "Availability, fault tolerance and disaster recovery",
                Objective = "Describe the benefits of high availability and scalability",
                Pages = "p65-70",
                Intro = Para("""
                    Three resilience terms that sound interchangeable and are not. They differ by
                    the scale of the failure they answer, and by whether anyone has to act.
                    """),
                Points =
                [
                    "High availability is the proportion of time a service is available, expressed as a percentage and backed by a service level agreement.",
                    "A 99.9 percent commitment permits roughly 43.2 minutes of unavailability across a 30-day period.",
                    "Reduced performance does not count as unavailability. A service that answers slowly is still available.",
                    "Fault tolerance is a system continuing to run when one or more of its components fail, with nobody activating anything.",
                    "Disaster recovery is the process of restoring systems and data after a major failure, and it involves a plan, backups and usually another location."
                ],
                Essentials =
                [
                    "Availability measures reachability, not speed. This is the single most repeated trap on the topic.",
                    "Fault tolerance absorbs a component failure automatically. Disaster recovery is what you do after a large-scale loss. They are different capabilities, not the same one at two sizes.",
                    "Each extra nine divides the permitted downtime by ten: about 43 minutes a month at 99.9 percent, about 4.3 at 99.99 percent."
                ]
            },

            new Lesson
            {
                Id = "m1-l5",
                Title = "IaaS, PaaS and SaaS",
                Objective = "Describe cloud service types",
                Pages = "p70-76",
                Intro = Para("""
                    The three service types differ by how much of the stack you still manage.
                    Every question on this topic is really asking where the boundary sits, and
                    the trade is always the same: more control costs more responsibility.
                    """),
                Points =
                [
                    "Infrastructure as a service supplies compute, storage and networking from the provider's pool. The provider runs the physical hardware and virtualisation; you run the operating system, the applications and their configuration.",
                    "Platform as a service supplies a managed application platform, so a team can build and deploy without obtaining or managing servers, operating systems or middleware.",
                    "Software as a service supplies a finished application that the provider hosts and updates. The customer manages user access rather than the software.",
                    "IaaS gives the most control and carries the most work; SaaS gives the least of both. PaaS sits between them.",
                    "The same product can appear under different service types. What decides the label is which layer you manage in that particular deployment, not the name of the software."
                ],
                Essentials =
                [
                    "Match the requirement to the layer it needs. A kernel driver or a chosen patching window forces IaaS, because both need ownership of the operating system.",
                    "SaaS needs the least effort overall, but it cannot host an application you wrote yourself. When a custom application must survive the move, PaaS is usually the answer.",
                    "Serverless computing is best understood as a category of PaaS: the infrastructure is still abstracted away, with the emphasis on event-driven and low-code work."
                ],
                Table = new LessonTable(
                    "Who manages what",
                    ["Layer", "IaaS", "PaaS", "SaaS"],
                    [
                        ["Application", "Customer", "Customer", "Provider"],
                        ["Runtime and middleware", "Customer", "Provider", "Provider"],
                        ["Operating system", "Customer", "Provider", "Provider"],
                        ["Virtualisation and hardware", "Provider", "Provider", "Provider"]
                    ])
            },

            new Lesson
            {
                Id = "m1-l6",
                Title = "The shared responsibility model",
                Objective = "Describe the shared responsibility model",
                Pages = "p74-79",
                Intro = Para("""
                    Moving a workload to a provider divides the work of running it. Where the
                    division falls depends on the service type, but a few duties never move at
                    all, and those are what most questions turn on.
                    """),
                Points =
                [
                    "Responsibility is split between customer and provider, and the boundary moves with the service type: most work stays with the customer under IaaS, least under SaaS.",
                    "The provider always owns the physical facility, the hardware and the virtualisation layer.",
                    "The customer always owns its own data, its user accounts and their access rights, whichever service type is in use.",
                    "Guest operating system patching belongs to the customer under IaaS, and to the provider under PaaS and SaaS.",
                    "The model does not stop at deployment. Monitoring the health of your own workload and tracking announced service changes remain yours for as long as it runs."
                ],
                Essentials =
                [
                    "Identity and data never transfer. Any answer claiming the provider takes over either one is wrong regardless of service type.",
                    "Enabling a provider security or backup service does not move a responsibility across the line. It helps you discharge one you still hold.",
                    "A managed service means the provider runs the software. It never means the provider decides who may read your data."
                ]
            },

            new Lesson
            {
                Id = "m1-l7",
                Title = "Public, private and hybrid clouds",
                Objective = "Describe cloud computing",
                Pages = "p79-82",
                Intro = Para("""
                    The deployment models describe who the infrastructure serves, not where it
                    physically sits or how exposed it is. One word decides whether a mixed estate
                    counts as hybrid, and the exam leans on it.
                    """),
                Points =
                [
                    "A public cloud serves many organisations over a publicly reachable network, sharing physical compute and networking between them, with physical and virtual boundaries keeping each tenant separate. Lower cost is its main advantage.",
                    "A private cloud serves a single organisation, whether it runs the platform itself or a third party runs it on dedicated hardware. Greater control is its main advantage.",
                    "A hybrid cloud is one where on-premises services and cloud services actually interact as part of a combined solution.",
                    "Any saving from a third-party private cloud comes from the host serving several customers on shared management, which recovers some economy of scale.",
                    "Owning both on-premises systems and cloud subscriptions is not enough to be hybrid. Without service interaction between the two, it is simply both."
                ],
                Essentials =
                [
                    "Interaction is the test for hybrid. Two environments running side by side with no data, identity or network path between them are not a hybrid cloud.",
                    "Public describes shared, provider-owned infrastructure. It says nothing about whether your resources are reachable from the internet.",
                    "A private cloud is often no cheaper than staying on-premises, because dedicating the hardware removes the sharing that makes public cloud cheap."
                ]
            }
        ]
    };
}
