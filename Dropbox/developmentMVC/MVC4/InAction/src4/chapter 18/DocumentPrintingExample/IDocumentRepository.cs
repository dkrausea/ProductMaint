using System;

namespace DocumentPrintingExample
{
    public interface IDocumentRepository
    {
        Document GetDocumentByName(string documentName);
    }

    public class FilesystemDocumentRepository : IDocumentRepository
    {
        public Document GetDocumentByName(string documentName)
        {
            // In reality, this would load the document from the filesystem.
            // For simplicity, just return the document in memory.
            return new Document 
            {
                Name = documentName,
                DocumentContents = "Chapter 1: ...."
            };
        }
    }
}