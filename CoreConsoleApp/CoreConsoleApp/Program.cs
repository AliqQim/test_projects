using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string dbName = "MyContext";   //когда нужна новая БД - просто имя сменить
            var options = new DbContextOptionsBuilder<MyContext>()
                .UseSqlServer($"Data Source=(localdb)\\mssqllocaldb;Initial Catalog={dbName};Integrated Security=True;MultipleActiveResultSets=True")
                .Options;

            using (var context = new MyContext(options))
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Console.WriteLine(context.Persons.Count());

                //context.Persons.Add(new Person { Name = "петя", Age = 22 });
                //context.Persons.Add(new Person { Name = "Вася", Age = 23 });

                //context.SaveChanges();

                foreach (var p in context.Persons)
                {
                    Console.WriteLine($"{p.Name} {p.Age}");
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
