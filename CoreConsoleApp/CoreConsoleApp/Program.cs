using System;
using System.ComponentModel;
using System.Threading.Channels;
using StrongInject;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new Container().Run(x => x.f());
            Console.WriteLine("DONE");
        }

    }

    [Register(typeof(B), typeof(IB))]
    [Register(typeof(A), typeof(IA))]
    public partial class Container: IContainer<IB>{}

    public interface IA
    {

    }

    public class A : IA
    {

    }

    public interface IB
    {
        void f();
    }

    public class B : IB
    {
        private readonly IA _a;

        public B(IA a)
        {
            _a = a;
            
        }

        public void f()=> Console.WriteLine(_a);

    }

}
