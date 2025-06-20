using FactoryMethodPattern;
using System;
public class Program
{
    public static void Main(string[] args)
    {
        DocumentFactory word = new WordDocumentFactory();
        IDocument wdoc = word.CreateDocument();
        wdoc.Open();

        DocumentFactory pdf = new PDFDocumentFactory();
        IDocument pdfdoc = pdf.CreateDocument();
        pdfdoc.Open();

        DocumentFactory excel = new ExcelDocumentFactory();
        IDocument exceldoc = excel.CreateDocument();
        exceldoc.Open();
    }
}
