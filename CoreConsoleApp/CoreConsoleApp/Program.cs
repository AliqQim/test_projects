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
            services.AddSingleton<I, A>();  //instances will be disposed
            services.AddSingleton<I2>(new B()); //instance will not be disposed

            using var globalProvider = services.BuildServiceProvider();

            Console.WriteLine("If we want to replace one implementation to another:");
            Console.WriteLine(globalProvider.GetService<I>()!.GetType());
                        
        }


        public interface I { }
        public class A : I, IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("A:dispose");
            }
        }

        public interface I2 { }
        public class B : I2, IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("B:dispose");
            }
        }

      
    }
}
