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
                var options = new DbContextOptionsBuilder<MyContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new MyContext(options))
                {
                    bool reset = true;

                    if (reset)
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

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

                    var persons = context.Persons.ToArray();

                    string? firstzamorochkaName = persons.First().Zamorochkas?.First()?.Name;
                    Console.WriteLine(firstzamorochkaName);


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
