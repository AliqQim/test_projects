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

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Person, AdultDto>());
            config.AssertConfigurationIsValid();

            string dbName = "ConsoleApp1.MyContext11";
            using (var context = new MyContext($"Data Source=(localdb)\\mssqllocaldb;Initial Catalog={dbName};Integrated Security=True;MultipleActiveResultSets=True"))
            {
                context.Database.Log = sql => Debug.WriteLine(sql);

                //context.Persons.Add(new Person { Name = "петя", Age = 22 });
                //context.Persons.Add(new Person { Name = "Вася", Age = 23 });

                //context.SaveChanges();

                var adults = context.Persons.Where(x=>x.Age >= 18);
                var adultsInfo = adults.ProjectTo<AdultDto>(config).Distinct();


                foreach (var a in adultsInfo)
                {
                    Console.WriteLine($"{a.Name}");
                }

            }


            var user = new User
            {
                Age = 21,
                Name = "����",
                Branch = new Branch
                {
                    Name = "������������� 1"
                }
            };

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
        public MyContext(string connStr) : base(connStr) { }
        public virtual DbSet<Person> Persons { get; set; }
    }

    public class AdultDto
    {
        public string Name { get; set; }
    }
}
