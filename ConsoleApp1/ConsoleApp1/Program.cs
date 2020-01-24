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
            using (IUnityContainer container = new UnityContainer())
            {
                container.RegisterType<A>(new ContainerControlledLifetimeManager());
                container.RegisterType<B>();

                container.Resolve<B>();

                Console.WriteLine("child container is being created");
                using (var childContainer = container.CreateChildContainer())
                {
                    A a = new A();
                    childContainer.RegisterInstance<A>(a, new ContainerControlledLifetimeManager());
                    Console.WriteLine("creating using child container");
                    childContainer.Resolve<B>();
                    Console.WriteLine("creating using parent container");
                    container.Resolve<B>();
                }
                Console.WriteLine("child container is dead");
                container.Resolve<B>();
            }

            Console.WriteLine("DONE");
            Console.ReadKey();
        }


        static class Ctr
        {
            static int _ctr = 0;
            public static int Next() => _ctr++;
        }
        class A: IDisposable
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

        class B : IDisposable
        {
            private A _a;
            public int _id;

            public B(A a)
            {
                _a = a;
                _id = Ctr.Next();
                Console.WriteLine($"B({_id})(A{_a._id})");
            }

            public void Dispose()
            {
                Console.WriteLine($"~B({_id})(A{_a._id})");
            }
        };
    }
}
