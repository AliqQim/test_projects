using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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
            using (var connection = new SqliteConnection("Filename=:memory:"))
            {
                connection.Open();

                var options = new DbContextOptionsBuilder<MyContext>()
                    .UseSqlite(connection)
                    .Options;
                
                int petyaId;
                Person newPetya;

                using (var context = new MyContext(options))
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    newPetya = new Person
                    {
                        Name = "петя",
                        Age = 22,
                        Job = new Job { Name = "работа 1" },
                        Zamorochkas = new List<Zamorochka> {
                            new Zamorochka { Name = "тупо шутит" },
                            new Zamorochka { Name = "безалаберный" },
                        }

                    };

                    context.Persons.Add(newPetya);
                    context.Persons.Add(new Person
                    {
                        Name = "Вася",
                        Age = 23,
                        Job = new Job { Name = "работа 2" },
                        Zamorochkas = new List<Zamorochka> { new Zamorochka { Name = "далбич" } }
                    });

                    context.SaveChanges();

                    petyaId = newPetya.Id;
                }

                using (var context = new MyContext(options)) {

                    var selectedPetya = context.Persons.Find(petyaId);

                    if (!object.ReferenceEquals(selectedPetya, newPetya))
                        Console.WriteLine("они разные");


                    Console.WriteLine(context.Persons.Count());


                    foreach (var p in context.Persons)
                    {
                        Console.WriteLine($"{p.Name} {p.Age}");
                    }

                    var persons = context.Persons.Include(x=>x.Zamorochkas);

                    string? firstzamorochkaName = persons.First().Zamorochkas?.First()?.Name;
                    Console.WriteLine(firstzamorochkaName);


                    Console.WriteLine("Количество персон в первом контексте: " +
                            context.Persons.Count());

                    //убеждаемся, что контекст использует коннекшен, заложенный в опции
                    using (var connection2 = new SqliteConnection("Filename=:memory:"))
                    {
                        connection2.Open();

                        var options2 = new DbContextOptionsBuilder<MyContext>()
                        .UseSqlite(connection2)
                        .Options;

                        using (var context2 = new MyContext(options2))
                        {
                            context2.Database.EnsureCreated();
                            Console.WriteLine("Количество персон во втором контексте: " +
                                context2.Persons.Count());

                        }
                    }

                }

            }
            Console.WriteLine("Done!");
        }
    }

    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public int Age { get; set; }

        public List<Zamorochka> Zamorochkas { get; set; } = null!;

        public Job Job { get; set; } = null!;

    }

    public class Zamorochka
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }



    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Persons { get; set; } = null!;
    }
}
