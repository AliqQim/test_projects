using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            JObject o = JObject.Parse(File.ReadAllText("data.json"));


            Console.WriteLine("DONE");
            Console.ReadKey();
        }
    }
}
