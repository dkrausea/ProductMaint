using System;

namespace DocumentPrintingExample
{
    public interface IDocumentFormatter
    {
        FormattedDocument Format(Document document);
    }

    class DocumentFormatter : IDocumentFormatter
    {
        public FormattedDocument Format(Document document)
        {
            //Simple example that just constructs a FormattedDocument from a Document
            return new FormattedDocument 
            {
                Name = document.Name,
                DocumentContents = document.DocumentContents
            };
        }
    }
}