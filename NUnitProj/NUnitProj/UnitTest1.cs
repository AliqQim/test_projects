using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitProj
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        class A
        {
            public int MyProperty { get; set; }
            public string MyProperty2 { get; set; }
            public int MyDontCareProperty { get; set; }

            public IEnumerable<B> MyBees { get; set; }

        }

        class B
        {
            public int BProperty { get; set; }
            public int BPropertyDontCare { get; set; }
        }

        IEnumerable<A> GetDataGToCompare()
            => new List<A>
            {
                new A
                {
                    MyProperty = 1,
                    MyProperty2 = "2",
                    MyDontCareProperty = 3,
                    MyBees = new List<B>
                    {
                        new B
                        {
                            BProperty = 10,
                            BPropertyDontCare = 11
                        },
                        new B
                        {
                            BProperty = 13,
                            BPropertyDontCare = 14
                        },
                    }
                },
                new A
                {
                    MyProperty = 5,
                    MyProperty2 = "6",
                    MyDontCareProperty = 7,
                    MyBees = new List<B>
                    {
                        new B
                        {
                            BProperty = 20,
                            BPropertyDontCare = 21
                        }
                    }
                }
            };

        [Test]
        public void Test1()
        {

            var actualData = GetDataGToCompare();

            var expectedData = new[]
            {
                new
                {
                    MyProperty = 1,
                    MyProperty2 = "2",
                    MyBees = new []
                    {
                        new //reversed order
                        {
                            BProperty = 13,
                        },
                        new 
                        {
                            BProperty = 10,
                        },
                    }
                },
                new {
                    MyProperty = 5,
                    MyProperty2 = "6",
                    MyBees = new []
                    {
                        new 
                        {
                            BProperty = 20
                        }
                    }
                }
            };


            actualData.Should().BeEquivalentTo(expectedData, options=>
                options.ExcludingMissingMembers());
        }
    }
}