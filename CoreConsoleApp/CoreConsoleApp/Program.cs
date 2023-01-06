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

            //would be no whitespaces if it was "false" here
            //would be no effect if this were set after the Load method
            doc.PreserveWhitespace = true;

            doc.LoadXml(File.ReadAllText("XMLFile1.xml"));

            Console.WriteLine(doc.InnerXml);

            Console.WriteLine("DONE");
        }
    }
}
