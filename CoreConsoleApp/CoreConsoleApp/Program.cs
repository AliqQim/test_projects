using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = CreateContext())
            {
                bool reset = true;

                if (reset)
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    var person1 = new Person
                    {
                        Age = 22,
                        Job = new Job {Name = "работа 1"},
                        Zamorochkas = new List<Zamorochka>
                        {
                            new Zamorochka {Name = "тупо шутит"},
                            new Zamorochka {Name = "безалаберный"},
                        }

                    };
                    person1.SetPivateNameVal("петя");

                    context.Persons.Add(person1);


                    var person2 = new Person
                    {
                        Age = 23,
                        Job = new Job {Name = "работа 2"},
                        Zamorochkas = new List<Zamorochka> {new Zamorochka {Name = "далбич"}}
                    };

                    person2.SetPivateNameVal("Вася");

                    context.Persons.Add(person2);

                    context.SaveChanges();
                }


                Console.WriteLine(context.Persons.Count());




                foreach (var p in context.Persons)
                {
                    Console.WriteLine($"{p.GetPivateNameVal()} {p.Age}");
                }

                var persons = context.Persons.Include(x => x.Zamorochkas);

                string? firstzamorochkaName = persons.First().Zamorochkas?.First()?.Name;
                Console.WriteLine(firstzamorochkaName);


            }

            Console.WriteLine("Done!");
        }

        private static MyContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<MyContext>()
                            .UseSqlServer($"Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MyContext;Integrated Security=True;MultipleActiveResultSets=True")
                            .Options;
            var context = new MyContext(options);
            return context;
        }

        public class MyContextFactory: IDesignTimeDbContextFactory<MyContext>
        {
            public MyContext CreateDbContext(string[] args) => CreateContext();
        }
    }



    
}
