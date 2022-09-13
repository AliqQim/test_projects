using ClassLibraryNoNullability;
using System;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 c = Class1.CreateInstanceReturnsNull();  //I expected a warning here, but there is no 
            c.SayHi();

            Console.WriteLine("DONE");
        }

        public static Program NullabilityCheck()
        {
            //return null;    //warning
            throw new NotSupportedException();
        }
    }
}
