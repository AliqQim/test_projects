using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;

//made by chat-gpt :)

string xml = File.ReadAllText("XMLFile1.xml");

XDocument document = XDocument.Parse(xml);

Console.WriteLine("nodes by inner tag's attribute value:");

var nodes = document.XPathSelectElements("/persons/person[sourcedid/id = '2345']");

foreach (var node in nodes)
{
    Console.WriteLine("---");
    Console.WriteLine(node.ToString());
}

Console.WriteLine("DONE");
Console.ReadKey();