using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<I, A>();
            services.AddScoped<I, B>();

            using var globalProvider = services.BuildServiceProvider();

            Console.WriteLine("If we want to replace one implementation to another:");
            Console.WriteLine(globalProvider.GetService<I>()!.GetType());
            
            Console.WriteLine("If we want to register set of implementations:");
            globalProvider.GetServices<I>().ToList().ForEach(x =>
                Console.WriteLine(x.GetType()));
            
        }


        public interface I { }
        public class A : I
        {
           
        }

        public class B : I
        {
           
        }

      
    }
}
