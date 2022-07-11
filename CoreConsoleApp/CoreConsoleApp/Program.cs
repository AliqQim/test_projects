using System;
using System.Collections.Generic;

namespace CoreConsoleApp
{
    //https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance#generic-interfaces-with-covariant-type-parameters
    class Program
    {
        static void Main(string[] args)
        {

            I<A> a = new IB();


            Console.WriteLine("DONE");
        }
    }

    class A { }
    class B : A { }
    interface I<out T>  //no "out here" - error
    {
        public T MyProperty { get; }    //if there is a setter here - compiler error. 
    }

    class IB : I<B>
    {
        public B MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
