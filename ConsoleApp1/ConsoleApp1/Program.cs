using ClassLibrary2;
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
            //new Container().Run(x => x.f());

            Class1.CoreF();

            Console.WriteLine("DONE");
            Console.ReadKey();
        }
    }

    //[Register(typeof(B), typeof(IB))]
    //[Register(typeof(A), typeof(IA))]
    //public partial class Container : IContainer<IB> { }

    //public interface IA
    //{

    //}

    //public class A : IA
    //{

    //}

    //public interface IB
    //{
    //    void f();
    //}

    //public class B : IB
    //{
    //    private readonly IA _a;

    //    public B(IA a)
    //    {
    //        _a = a;

    //    }

    //    public void f() => Console.WriteLine(_a);

    //}
}
