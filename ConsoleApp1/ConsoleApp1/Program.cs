using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new UnityContainer())
            {
                var a = container.Resolve<A>();

                Console.WriteLine("DONE");
                Console.ReadKey();
            }
        }

        class A { };
    }
}
