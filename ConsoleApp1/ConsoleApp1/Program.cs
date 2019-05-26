using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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
            Console.ReadKey();
        }
    }

    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }



    }



    public class MyContext : DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }
    }
}
