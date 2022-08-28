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

            Console.WriteLine("nodes by inner tag's attribute value:");

            var nodes = doc.SelectNodes("/persons/person[./sourcedid[./id[text() = 2345]]]");

            
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine("---");
                Console.WriteLine(node.InnerXml);
                Console.WriteLine(node.InnerText);

            }


            Console.WriteLine("DONE");
        }
    }
}
