using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp1.Tests
{


    class A
    {
        public int i;
    }

    public class MyComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return ((A)x).i - ((A)y).i;
        }
    }

    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void fTest()
        {
            //Assert.AreEqual(
            //    new A { i = 1 },
            //    new A { i = 1 }
            //    );    //падает

            CollectionAssert.AreEqual(
                new[] { new A { i = 1 } },
                new[] { new A { i = 1 } },
                new MyComparer()
                );


        }
    }
}