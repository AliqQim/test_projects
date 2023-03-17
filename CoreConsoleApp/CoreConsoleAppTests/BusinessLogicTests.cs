using NUnit.Framework;
using CoreConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace CoreConsoleApp.Tests
{
    [TestFixture()]
    public class BusinessLogicTests
    {
        [Test()]
        public void GetJoinedDataAsyncTest()
        {
            var persons = new List<Person>
            {
                new()
                {
                    Name = "Sidor", Zamorochkas = new List<Zamorochka>
                    {
                        new() { Name = "totally normal guy" }
                    }
                }
            };

            var contextMock = new Mock<IMyContext>();
            //contextMock.Setup(x => x.Persons).Returns(persons.AsQueryable());
        }
    }
}