using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var config = new System.IO.FileInfo("MyConfigFolder/mylog4netconfig.xml");
            XmlConfigurator.Configure(config);

            var logAaa = LogManager.GetLogger("aaa.ccc");
            logAaa.Info("log string - aaa ");  //should be written to aaa-logger

            var logBbb= LogManager.GetLogger("log string - bbb");
            logBbb.Info("bbb"); //should be written to the root-logger

            Console.WriteLine("DONE");
            Console.ReadKey();
        }
    }
}
