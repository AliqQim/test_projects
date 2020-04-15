using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Resolution;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new UnityContainer())
            {
                container.EnableDebugDiagnostic();

                container.RegisterType<I, C1>();
                container.RegisterType<C2>(new PerResolveLifetimeManager());

                container.Resolve<A>().f();
                container.Resolve<A>(
                    new DependencyOverride<I>(
                        new ResolvedParameter(typeof(C2))))
                .f();
            }
            //https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ff660882%28v%3dpandp.20%29
            //https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ff660920(v=pandp.20)?redirectedfrom=MSDN

            Console.WriteLine("DONE");
            Console.ReadKey();
        }

        class A {
            private readonly B b;

            public A(B b, D d)
            {
                this.b = b;
            }

            public void f()
            {
                b.c.SayMyName();
            }
        };
        class B {
            public I c;

            public B(I c)
            {
                this.c = c;
            }
        };
        interface I
        {
            void SayMyName();
        };
        class C1 : I
        {
            public C1()
            {
                Console.WriteLine("конструктор C1");
            }
            public void SayMyName()
            {
                Console.WriteLine("C1");
            }
        }
        class C2 : I
        {
            public C2()
            {
                Console.WriteLine("конструктор C2");
            }
            public void SayMyName()
            {
                Console.WriteLine("C2");
            }
        }

        class D
        {
            public D(I i)
            {
                //убеждаемся, что инстанцирование I следует логике, зарегистрированной в контейнере
            }
        }
    }
}
