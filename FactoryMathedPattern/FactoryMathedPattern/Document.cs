using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public interface IDocument
    {
        void Open();
    }

    public class WordDocument : IDocument
    {
        public void Open() {
            Console.WriteLine("Word is opened");
        }
    }
    public class PdfDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("PDF is opened");
        }
    }
    public class ExcelDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Excel is opened");
        }
    }

}
