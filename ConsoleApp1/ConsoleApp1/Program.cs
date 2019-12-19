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

            string dbName = "ConsoleApp1.MyContext1";
            using (var context = new MyContext($"Data Source=(localdb)\\mssqllocaldb;Initial Catalog={dbName};Integrated Security=True;MultipleActiveResultSets=True"))
            {

                var workers = new Class { Name = "Рабочий класс" };
                var bourjua = new Class { Name = "Буржуазия" };

                //context.Persons.Add(new Person { Name = "Владимир", Age = 22, Class = workers });
                //context.Persons.Add(new Person { Name = "Карл", Age = 23, Class = workers });
                //context.Persons.Add(new Person { Name = "Морозов", Age = 23, Class = bourjua});

                //context.SaveChanges();

                foreach (var item in context.Persons.ProjectTo<SocietyMemberDto>())
                {
                    Console.WriteLine($"{item.Name} - {item.Class.Name}");
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
        public Class Class { get; set; }
    }

    public class Class
    {
        public string Name { get; set; }
    }



    public class MyContext : DbContext
    {
        public MyContext(string connStr) : base(connStr) { }
        public virtual DbSet<Person> Persons { get; set; }
    }

    public class AdultDto
    {
        public string Name { get; set; }
    }


    public class SocietyIntermDto
    {

    }

    public class SocietyMemberDto
    {
        public string PersonName { get; set; }
        public string ClassName { get; set; }
    }

}
