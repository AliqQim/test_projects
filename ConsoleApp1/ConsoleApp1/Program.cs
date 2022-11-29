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

            Console.WriteLine("Reading int:");
            JObject jobj = JObject.Parse(File.ReadAllText("data.json"));

            var val = jobj.SelectToken("_all.total.store.size_in_bytes");
            long n = val.Value<long>();
            Console.WriteLine(n);

            Console.WriteLine("Reading bool:");
            bool boolVal = jobj.SelectToken("_shards.is_collection").Value<bool>();
            Console.WriteLine(boolVal);

            Console.WriteLine("Detecting non-existant field:");
            Console.WriteLine(jobj.SelectToken("_shards.null_field") == null);
            Console.WriteLine(jobj.SelectToken("_shards.null_fieldOOO") == null);
            
            
            Console.WriteLine("reading collection...");
            var jCollection = jobj.SelectToken("testCollection") as JArray;

            foreach (var item in jCollection)
            {
                Console.WriteLine(item.SelectToken("_shards.total").Value<int>());
            }

            Console.WriteLine("DONE");
            Console.ReadKey();
        }
    }
}
