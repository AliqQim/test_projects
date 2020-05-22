using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var options = new new DbContextOptionsBuilder<MyContext>()
            //    .UseSql

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
