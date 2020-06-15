using System;
using System.IO;
using System.Xml;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText("XMLFile1.xml"));

            //если не присвоить падлючий префикс дефолтовому XML - из XPath к нему ниака не обратишься
            //(ну, точнее, обратишься, но через три жопы)
            //типа, безопасность, типизированность 
            var nsMgr = new XmlNamespaceManager(doc.NameTable);
            nsMgr.AddNamespace("m", "http://www.gribuser.ru/xml/fictionbook/2.0");

            var author = doc.SelectSingleNode("/m:FictionBook/m:description/m:title-info/m:author",
                nsMgr);

            Console.WriteLine(author.InnerText);

            Console.WriteLine("DONE");
        }
    }
}
