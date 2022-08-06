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
                    //context.Database.EnsureDeleted();
                    //context.Database.EnsureCreated();

                    context.Persons.Add(new Person
                    {
                        Name = "петя",
                        Age = 22,
                        Job = new Job { Name = "работа 1" },
                        Zamorochkas = new List<Zamorochka> {
                            new Zamorochka { Name = "тупо шутит" },
                            new Zamorochka { Name = "безалаберный" },
                        }

                    });
                    context.Persons.Add(new Person
                    {
                        Name = "Вася",
                        Age = 23,
                        Job = new Job { Name = "работа 2" },
                        Zamorochkas = new List<Zamorochka> { new Zamorochka { Name = "далбич" } }
                    });

                    context.SaveChanges();
                }


                Console.WriteLine(context.Persons.Count());




                foreach (var p in context.Persons)
                {
                    Console.WriteLine($"{p.Name} {p.Age}");
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
