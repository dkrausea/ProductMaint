namespace DocumentPrintingExample
{
    public class DocumentPrinter
    {
        private readonly IDocumentRepository _repository;
        private readonly IDocumentFormatter _formatter;
        private readonly IPrinter _printer;

        public DocumentPrinter(
            IDocumentRepository repository,
            IDocumentFormatter formatter,
            IPrinter printer)
        {
            _repository = repository;
            _formatter = formatter;
            _printer = printer;
		}

        public void PrintDocument(string documentName)
        {
            var document = _repository.GetDocumentByName(documentName);
            var formattedDocument = _formatter.Format(document);

            _printer.Print(formattedDocument);
        }
    }
}