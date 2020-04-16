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
            try
            {
                a();

            }
            catch (Exception e)
            {
                Console.WriteLine($"***catch in Main():\n{e.StackTrace}\n==============");
            }
    

            Console.WriteLine("DONE");
            Console.ReadKey();
        }


        static void a() { b(); }

        private static void b()
        {
            c();
        }

        private static void c()
        {
            try
            {
                d();
            }
            catch (Exception e)
            {
                Console.WriteLine($"***catch in c():\n{e.StackTrace}\n==============");
                throw;
            }
            
        }

        private static void d()
        {
            throw new NotImplementedException();
        }
    }
}
