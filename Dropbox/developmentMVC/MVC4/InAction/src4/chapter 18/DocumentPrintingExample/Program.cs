using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace DocumentPrintingExample {
    class Program {
        static void Main(string[] args) {
            
            // Example without using a container
            //NotUsingContainer();


            // Example using a container
            UsingContainer();

            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        private static void UsingContainer()
        {
            // configure the container
            ObjectFactory.Configure(cfg =>
            {
                cfg.For<IDocumentRepository>().Use<FilesystemDocumentRepository>();
                cfg.For<IDocumentFormatter>().Use<DocumentFormatter>();
                cfg.For<IPrinter>().Use<Printer>();
            });

            // create the root object
            var documentPrinter = ObjectFactory.GetInstance<DocumentPrinter>();
            documentPrinter.PrintDocument("C:/MVC3InAction/Manuscript.doc");
        }

        private static void NotUsingContainer()
        {
            var repository = new FilesystemDocumentRepository();
            var formatter = new DocumentFormatter();
            var printer = new Printer();

            var documentPrinter = new DocumentPrinter(repository, formatter, printer);
            documentPrinter.PrintDocument("C:/MVC3InAction/Manuscript.doc");
        }
    }
}
