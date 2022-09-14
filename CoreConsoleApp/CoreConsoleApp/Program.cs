using ClassLibraryNoNullability;
using System;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 c = Class1.CreateInstanceReturnsNull();  //I expected a warning here, but there is no one
            c.SayHi();  //NullReferenceException

            Program? p = new Program();
            p.SayHiFromProgram();   //no warning althought p is of nullable type.
                                    //becasuse compiler sees that it definitey intialized with an object

            Console.WriteLine("DONE");
        }

        public static Program NullabilityCheck()
        {
            //return null;    //warning
            throw new NotSupportedException();
        }

        public void SayHiFromProgram() => Console.WriteLine("hi from program!");
    }
}
