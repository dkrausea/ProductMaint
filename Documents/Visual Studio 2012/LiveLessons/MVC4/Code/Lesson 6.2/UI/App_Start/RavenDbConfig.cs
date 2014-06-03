using System.Web.Mvc;
using CodeCampServerLite.UI.Domain;
using Raven.Client;

namespace CodeCampServerLite.UI
{
    public static class RavenDbConfig
    {
        public static void FillData()
        {
            var store = DependencyResolver.Current.GetService<IDocumentStore>();

            using (var session = store.OpenSession())
            {
                var codeMash = new Conference("CodeMash");
                var mix10 = new Conference("MIX");
                var pdc = new Conference("PDC");

                codeMash.AddSession(new Session("0-60 with Fluent NHibernate", "Fluent NHibernate is a framework, that sits on top of NHibernate, which helps to cut down on some of the headaches you will indubitably encounter with picking up such a mature ORM. We'll be discussing how FNH can help cut down the learning curve of using NHibernate as an ORM and how it can benefit existing NHibernate production environments long term by utilizing a convention over configuration approach.", new Speaker("Hudson", "Akridge")));
                codeMash.AddSession(new Session("Azure: Lessons from the field", "Come learn about Microsoft's Azure platform (and cloud computing in general) as we look at an application built to assist in the processing and publishing of large-scale scientific data. We will discuss architecture choices, benchmarking results, issues faced as well as the work-arounds implemented. This session will give you insight into the process of developing for the cloud, as well as tips and tricks to help you avoid some common pitfalls.", new Speaker("Rob", "Gillen")));
                codeMash.AddSession(new Session("Going Dynamic with C#", "C# might be looking a little long in the tooth, but C# 4.0 adds dynamic support to compete with all the young punks. In this session, based on material from Effective C#, 2nd edition, you�ll learn how to mix dynamic features into the safety and performance of static typing. It�s yet another tool in the toolbox that you can use with C#. You�ll learn techniques that are easier to implement using dynamic features. You�ll learn how to bridge the gap between dynamic and static typing. Most of all you�ll learn when dynamic typing is an advantage, and when static typing provides the best solution.", new Speaker("Bill", "Wagner")));
                codeMash.AddSession(new Session("Maintainable ASP.NET MVC", "Introduce software developers to Microsoft�s ASP.NET MVC framework and provide �beyond the bits� guidance to help teams get up to speed on this exciting alternative to WebForms development.", new Speaker("Chris", "Patterson")));
                codeMash.AddSession(new Session("Techniques for Programming Parallel Solutions", "Building multi-threaded applications can be hard work. So come learn a number of techniques for developing software solutions that take advantage of today�s multi-core processors. In true CodeMash fashion, the session starts by laying a foundation of concurrency basics using C++. The bulk of the session then looks at all of the various techniques for parallelizing �work� in .NET 3.5 using C#, while avoiding a number of �gotchas�. Finally, the session concludes with how these techniques will make it easy to develop parallel solutions with the changes coming in Visual Studio 2010, .NET 4.0, and F#.", new Speaker("Michael", "Slade")));

                mix10.AddSession(new Session("Treat Your Content Right", "Most the time, designers don�t publish napkin sketches as final designs. But the same is not true of content. We regularly cram last-minute, sketchy content into our otherwise thoughtfully planned websites. Learn why content strategy and web writing matter, what they are, how to incorporate them into your design process, and how they make meaningful websites that connect with people. Also look at a few case studies that show how content strategy and happy collaborations produce better web experiences. For Everyone.", new Speaker("Tiffani", "Jones")));
                mix10.AddSession(new Session("The Mono Project", "Mono is a free and open source implementation of .NET that runs on Windows, Unix, and Macintosh. In more than 5 years since the first version of Mono was released, the Mono project has continued to add support for new functionality, such as C# 3.0, LINQ, and Silverlight; and has continued to see adoption. Come hear about the latest developments and future plans from the founder of the Mono project.", new Speaker("Miguel", "de Icaza")));

                pdc.AddSession(new Session("Building Line of Business Applications with Microsoft Silverlight 4", "Learn about enhancements to data binding and data validation as well as new support for rich text & printing in the platform that allow you to build compelling LOB user experiences. In addition, you will see how you can incorporate webcam & microphone support into your applications using Silverlight 4.", new Speaker("David", "Poll")));
                pdc.AddSession(new Session("Building Java Applications with Windows Azure", "Come learn how to build large-scale applications in the cloud using Java, taking advantage of new Windows Azure features. This session will cover using Apache Tomcat and Java in Windows Azure.", new Speaker("Steve", "Marx")));
                pdc.AddSession(new Session("ASP.NET MVC 2: Ninjas Still on Fire Black Belt Tips", "Having the customer on your back to deliver features on time and under budget with tight deadlines can make you feel like you�re being chased by ninjas on fire. Join Scott Hanselman and he�ll walk through lots of tips and tricks to get the most out of the ASP.NET MVC 2 framework and deliver work quickly and with style. Come see ASP.NET MVC 2�s better productivity features as we make the most of several key features.", new Speaker("Scott", "Hanselman")));
                pdc.AddSession(new Session("Developing REST Applications with the .NET Framework", "Come hear an overview of the REST principles and why REST is becoming popular beyond traditional Web applications. Learn how to write applications that produce and consume RESTful services using the .NET Framework 4 and the improvements we have planned for future versions of the .NET Framework.", new Speaker("Henrik", "Nielsen")));

                GenerateAttendees(codeMash);
                GenerateAttendees(mix10);
                GenerateAttendees(pdc);

                session.Store(codeMash);
                session.Store(mix10);
                session.Store(pdc);

                session.SaveChanges();
            }
        }


        private static void GenerateAttendees(Conference conference)
        {
            conference.Register("Nelson", "Tischler");
            conference.Register("Allie", "Lemelin");
            conference.Register("Guy", "Brumback");
            conference.Register("Karina", "Lerman");
            conference.Register("Darryl", "Schwager");
            conference.Register("Mathew", "Blay");
            conference.Register("Nita", "Swicegood");
            conference.Register("Clinton", "Westra");
            conference.Register("Tyrone", "Grieve");
            conference.Register("Hugh", "Nowland");
            conference.Register("Katy", "Greenstein");
            conference.Register("Maricela", "Kisinger");
            conference.Register("Hugh", "Banach");
            conference.Register("Mallory", "Rexford");
            conference.Register("Earnestine", "Belvin");
            conference.Register("Kathrine", "Hamamoto");
            conference.Register("Clinton", "Rinker");
            conference.Register("Neil", "Groman");
            conference.Register("Christian", "Pineiro");
            conference.Register("Lance", "Cullum");
            conference.Register("Allan", "Fahnestock");
            conference.Register("Kelly", "Mcgrail");
            conference.Register("Jamie", "Geiser");
            conference.Register("Tameka", "Bercier");
            conference.Register("Clayton", "Torpey");
            conference.Register("Tyrone", "Nassif");
            conference.Register("Tanisha", "Hendrixson");
            conference.Register("Lilia", "Paskett");
            conference.Register("Lorrie", "Simonsen");
            conference.Register("Pearlie", "Host");
        }
    }
}