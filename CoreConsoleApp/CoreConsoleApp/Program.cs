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
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool reset = true;

            if (reset)
            {
                using (var context = CreateContext())
                {
                    context.Database.EnsureDeleted();
                    //context.Database.EnsureCreated();
                    context.Database.Migrate();

                    var taurus = new Zodiac { Name = "taurus" };
                    var gemini = new Zodiac { Name = "gemini" };

                    context.Zodiacs.Add(taurus);
                    context.Zodiacs.Add(gemini);

                    context.Persons.Add(new Person
                    {
                        Name = "петя",
                        Age = 22,
                        Job = new Job { Name = "работа 1" },
                        UnforgivableZamorochkaOfOtherPerson = new Zamorochka { Name = "Lameness", Zodiac = gemini },
                        OwnZamorochkas = new List<Zamorochka> {
                            new Zamorochka { Name = "тупо шутит", Zodiac = taurus },
                            new Zamorochka { Name = "безалаберный", Zodiac = gemini },
                        }

                    });
                    context.Persons.Add(new Person
                    {
                        Name = "Вася",
                        Age = 23,
                        Job = new Job { Name = "работа 2" },
                        UnforgivableZamorochkaOfOtherPerson = new Zamorochka { Name = "Being a smartass", Zodiac = gemini },
                        OwnZamorochkas = new List<Zamorochka> { new Zamorochka { Name = "далбич", Zodiac = taurus } }
                    });

                    context.SaveChanges();
                }
            }

            using (var context = CreateContext())
            {
                var genimi = context.Zodiacs.Single(x => x.Name == "gemini");
                var petya = context.Persons.Single(x => x.Name == "петя");

                petya.UnforgivableZamorochkaOfOtherPerson = new Zamorochka { Name = "Stupidness",  ZodiacId = genimi.Id };
                var toChange = petya.OwnZamorochkas.Single(x => x.Name == "тупо шутит");
                toChange.Name = "lame jokes";
                toChange.ZodiacId = genimi.Id;

                var toDelete = petya.OwnZamorochkas.Single(x => x.Name == "безалаберный");

                petya.OwnZamorochkas.Remove(toDelete);

                context.SaveChanges();
            }



            using (var context = CreateContext())
            {
                


                Console.WriteLine(context.Persons.Count());




                foreach (var p in context.Persons.Include(x=>x.OwnZamorochkas).ThenInclude(x=>x.Zodiac))
                {
                    Console.WriteLine($"{p.Name} {p.Age}");
                    Console.WriteLine(p.UnforgivableZamorochkaOfOtherPerson);
                    Console.WriteLine("Заморочки: " + string.Join(", ", p.OwnZamorochkas));
                }

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
