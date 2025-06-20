using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
    }

    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }
    public class PDFDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }
    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new ExcelDocument();
        }
    }
}
