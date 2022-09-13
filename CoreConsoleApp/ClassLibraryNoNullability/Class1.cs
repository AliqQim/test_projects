using System;

namespace ClassLibraryNoNullability
{
    public class Class1
    {
        public static Class1 CreateInstanceReturnsNull()
            => null;    //no warning

        public void SayHi() => Console.WriteLine("hi!");
    }
}
