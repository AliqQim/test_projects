using NUnit.Framework;
using CoreConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.EntityFrameworkCore;
using CoreConsoleAppTests.DbSetMockUtils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoreConsoleApp.Tests
{
    [TestFixture()]
    public class BusinessLogicTests
    {
        [Test()]
        public async Task GetJoinedDataAsyncTestAsync()
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
            }.AsQueryable();

            var contextMock = new Mock<IMyContext>();
            var mockDbSet = new Mock<DbSet<Person>>();
            mockDbSet.As<IAsyncEnumerable<Person>>()
               .Setup(d => d.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
               .Returns(new AsyncEnumerator<Person>(persons.GetEnumerator()));

            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(persons.Provider);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(persons.Expression);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(persons.ElementType);
            mockDbSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(persons.GetEnumerator());
            
            contextMock.Setup(x => x.Persons).Returns(mockDbSet.Object);

            var target = new BusinessLogic(contextMock.Object);
            var res = await target.GetJoinedDataAsync();

            Assert.NotNull(res);
        }
    }
}