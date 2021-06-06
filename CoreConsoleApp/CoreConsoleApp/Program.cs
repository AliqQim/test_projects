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
            services.AddScoped<B>();    //if remove this - an exception will be thrown

            using var globalProvider = services.BuildServiceProvider();

            Console.WriteLine(globalProvider.GetService<I>()!.GetType());
            
        }


        public interface I { }
        public class A : I
        {
           public A(IServiceProvider sp)
            {
                var b = sp.GetRequiredService<B>();
            }
        }

        public class B : I
        {
           
        }

      
    }
}
