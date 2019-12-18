using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var context = new MyContext())
            {

                var workers = new Class { Name = "Рабочий класс" };
                var bourjua = new Class { Name = "Буржуазия" };

                context.Persons.Add(new Person { Name = "Владимир", Age = 22, Class = workers });
                context.Persons.Add(new Person { Name = "Карл", Age = 23, Class = workers });
                context.Persons.Add(new Person { Name = "Морозов", Age = 23, Class = bourjua});

                context.SaveChanges();


            }



            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }

    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public Class Class { get; set; }
    }

    public class Class
    {
        public string Name { get; set; }
    }



    public class MyContext : DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }
    }

    public class AdultDto
    {
        public string Name { get; set; }
    }
}
