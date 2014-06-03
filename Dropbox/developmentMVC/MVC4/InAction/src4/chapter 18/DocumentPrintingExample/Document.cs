namespace DocumentPrintingExample
{
    public class Document
    {
        public string Name { get; set; }
        public string DocumentContents { get; set; }
    }

    public class FormattedDocument : Document {
        //...format-related properties would go here.
    }

}