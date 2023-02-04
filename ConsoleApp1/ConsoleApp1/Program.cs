using Autofac;
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

            var builder = new ContainerBuilder();
            builder.RegisterType<Logger>().AsSelf().SingleInstance();
            builder.RegisterType<A>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<B>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<C>().AsSelf().InstancePerLifetimeScope();

            A a1, a2;
            Logger logger;

            using (var container = builder.Build())
            {
                using (var outerScope = container.BeginLifetimeScope())
                {
                    logger = outerScope.Resolve<Logger>();

                    using (var innerScope1 = outerScope.BeginLifetimeScope())
                    {
                        a1 = innerScope1.Resolve<A>();
                    }
                    using (var innerScope2 = outerScope.BeginLifetimeScope())
                    {
                        a2 = innerScope2.Resolve<A>();
                    }
                }

            }
            //ensure by means of debugger that logger is same instance everywhere,
            //and each A instance have their own instance of b. and C has same B instance as A.

            Console.WriteLine("DONE");
            Console.ReadKey();
        }
    }

    public class Logger
    {
        
    }

    public class A {
        private readonly Logger logger;
        private readonly B b;
        private readonly C c;

        public A(Logger logger, B b, C c)
        {
            this.logger = logger;
            this.b = b;
            this.c = c;
        }
    } 
    public class B { } 
    public class C {
        private readonly B b;

        public C(B b)
        {
            this.b = b;
        }
    }


}
