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


            Console.WriteLine("Creating global");
            using var globalProvider = services.BuildServiceProvider();
            globalProvider.GetService<B>();

            Console.WriteLine("Creating scope");
            using (var scope1 = globalProvider.CreateScope())
            {
                scope1.ServiceProvider.GetService<B>();
                scope1.ServiceProvider.GetService<B>();


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

      
    }
}
