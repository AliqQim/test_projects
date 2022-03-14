using NUnit.Framework;
using System.Diagnostics;

namespace NUnitProj
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Debug.WriteLine("***************Setup");
        }
        
        [TearDown]
        public void TearDown()
        {
            Debug.WriteLine("***************TearDown");
        }

        [Test]
        public void Test1()
        {
            Debug.WriteLine("***************Test1");
        }

        [Test]
        public void Test2()
        {
            Debug.WriteLine("***************Test2");
        }
    }
}