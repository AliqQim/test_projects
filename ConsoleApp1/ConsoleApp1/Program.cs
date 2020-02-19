using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new UnityContainer())
            {
                container.RegisterType<I1, A>(new ContainerControlledLifetimeManager());
                container.RegisterFactory<I2>((cont) => cont.Resolve<I1>());


                container.Resolve<I1>();
                container.Resolve<I2>();





            }

            Console.WriteLine("DONE");
            Console.ReadKey();
        }


        interface I1 { };
        interface I2 { };

        static class Ctr
        {
            static int _ctr = 0;
            public static int Next() => _ctr++;
        }
        class A : IDisposable, I1, I2
        {
            public int _id;

            public A()
            {
                _id = Ctr.Next();
                Console.WriteLine($"A({_id})");
            }

            public void Dispose()
            {
                Console.WriteLine($"~A({_id})");
            }
        };
    }
}
