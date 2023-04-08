using System;
using StrongInject;

namespace ClassLibrary1
{
    [Register(typeof(B), typeof(IB))]
    [Register(typeof(A), typeof(IA))]
    public partial class Container : IContainer<IB> { }

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

        public void f() => Console.WriteLine(_a);

    }
}
