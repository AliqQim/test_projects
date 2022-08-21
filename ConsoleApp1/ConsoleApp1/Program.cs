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

            builder.RegisterModule<TestModule>();
            builder.RegisterModule<TestModule>();

            var container = builder.Build();

            container.Resolve<I>().Greet();

            Console.WriteLine("DONE");
            Console.ReadKey();
        }
    }
    public interface I
    {
        void Greet();
    }
    public class A: I
    {
        public void Greet() => Console.WriteLine("Hi!");
    }

}
