using System;

namespace DocumentPrintingExample
{
    public interface IPrinter
    {
        void Print(FormattedDocument formattedDocument);
    }

    class Printer : IPrinter
    {
        public void Print(FormattedDocument formattedDocument)
        {
            Console.WriteLine("Printing document: {0}", formattedDocument.Name);
        }
    }
}