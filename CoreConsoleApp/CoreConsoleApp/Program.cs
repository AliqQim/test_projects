using Microsoft.Extensions.DependencyInjection;
using System;
using Unity;
using Unity.Microsoft.DependencyInjection;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UnityContainer unityContainer = new UnityContainer();

            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IA, A>();

            serviceCollection.BuildServiceProvider(unityContainer);

            var a = unityContainer.Resolve<IA>();


            Console.WriteLine("DONE");
        }


        public interface IA { }
        public class A : IA { }
    }
}
