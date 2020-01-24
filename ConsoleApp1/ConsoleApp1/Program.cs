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

            var user = new User
            {
                Age = 21,
                Name = "����",
                Branch = new Branch
                {
                    Name = "������������� 1"
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
