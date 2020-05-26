using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{


    //https://support.smartbear.com/alertsite/docs/monitors/api/endpoint/jsonpath.html

    class Program
    {
        static void Main(string[] args)
        {
            
            JObject o = JObject.Parse(File.ReadAllText("data.json"));
            var indices = (JObject) o.SelectToken("indices");
            foreach (var index in indices)
            {
                string title = index.Key;

                int size = (index.Value as JObject).SelectTokens("..size_in_bytes").First().Value<int>();

                Console.WriteLine($"{title}\t\t\t{ size }");
            }

            JObject o2 = JObject.Parse(File.ReadAllText("data2.json"));

            Console.WriteLine("*********пример №2");
            Console.WriteLine(o2.SelectToken("header.status"));
            Console.WriteLine(o2.SelectToken("response.signType.cert.body"));
            Console.WriteLine(o2.SelectToken("response.signType.cert.bodY"));
            Console.WriteLine(o2.SelectToken("response.signType.cert.bodY", true));

            Console.WriteLine("DONE");
            Console.ReadKey();
        }
    }
}
