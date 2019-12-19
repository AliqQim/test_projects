using AutoMapper;
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

            string dbName = "ConsoleApp1.MyContext2";   //когда нужна новая БД - просто имя сменить
            using (var context = new MyContext($"Data Source=(localdb)\\mssqllocaldb;Initial Catalog={dbName};Integrated Security=True;MultipleActiveResultSets=True"))
            {
                Age = 21,
                Name = "Алик",
                Branch = new Branch
                {
                    Name = "Подразделение 1"
                }
            };

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>());

            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();
            var dto = mapper.Map<UserDto>(user);

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
}
