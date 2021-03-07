using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<A>();
            services.AddScoped<B>();
            services.AddScoped<C>();

            Console.WriteLine("Creating global");
            using var globalProvider = services.BuildServiceProvider();
            globalProvider.GetService<A>();

            Console.WriteLine("Creating outer scope");
            using (var scope1 = globalProvider.CreateScope())
            {
                scope1.ServiceProvider.GetService<B>();

                Console.WriteLine("Creating outer scope");
                using (var scope2 = globalProvider.CreateScope())
                {
                    scope2.ServiceProvider.GetService<C>();
                }
                Console.WriteLine("out of inner scope");
            }
            Console.WriteLine("out of outer scope");
             Console.WriteLine("DONE");
        }

        public class A : IDisposable
        {
            public A()
            {
                Console.WriteLine("Create A");
            }

            public void Dispose()
            {
                Console.WriteLine("Dispose A");
            }
        }

        public class B : IDisposable
        {
            public B()
            {
                Console.WriteLine("Create B");
            }

            public void Dispose()
            {
                Console.WriteLine("Dispose B");
            }
        }

        public class C : IDisposable
        {
            public C()
            {
                Console.WriteLine("Create C");
            }

            public void Dispose()
            {
                Console.WriteLine("Dispose C");
            }
        }
    }
}
