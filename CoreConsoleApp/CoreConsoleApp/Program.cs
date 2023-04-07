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

    
    [Register(typeof(A), typeof(IA))]
    public partial class Container : IContainer<IB>
    {
        [Factory]
        IB CreateB(Func<IA> a) => new B(a(), "alik");   //Func<IA> - we can order several instantiation delegates and choose one 
        //simpler version would be "IB CreateB(IA a) "
    }

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
        private readonly string _name;

        public B(IA a, string name)
        {
            _a = a;
            _name = name;
        }

        public void f()=> Console.WriteLine($"IA:{_a}, Hello, {_name}");

    }

}
