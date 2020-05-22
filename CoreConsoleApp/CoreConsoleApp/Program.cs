using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string dbName = "ConsoleApp1.MyContext2";   //когда нужна новая БД - просто имя сменить
            var options = new DbContextOptionsBuilder<MyContext>()
                .UseSqlServer($"Data Source=(localdb)\\mssqllocaldb;Initial Catalog={dbName};Integrated Security=True;MultipleActiveResultSets=True");

            Console.WriteLine("DONE");
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
        public MyContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Persons { get; set; } = null!;
    }
}
