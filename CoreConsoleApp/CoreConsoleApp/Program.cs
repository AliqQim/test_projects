using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;

//made by chat-gpt :)

string xml = File.ReadAllText("XMLFile1.xml");

XDocument document = XDocument.Parse(xml);

XNamespace mNamespace = "http://www.gribuser.ru/xml/fictionbook/2.0";

// Создание пространства имен
XmlNamespaceManager nsMgr = new XmlNamespaceManager(new NameTable());
nsMgr.AddNamespace("m", mNamespace.NamespaceName);

// Чтение XPath
XElement? authorElement = document.XPathSelectElement("/m:FictionBook/m:description/m:title-info/m:author", nsMgr);
if (authorElement != null)
{
    string author = authorElement.Value;
    Console.WriteLine(author);
}

Console.WriteLine("DONE");
Console.ReadKey();