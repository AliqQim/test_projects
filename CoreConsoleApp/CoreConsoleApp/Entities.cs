using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreConsoleApp
{
    public class Person
    {
        public int Id { get; set; }


        internal const string NameOfNameField = nameof(_name);
        private string _name = null!;

        public string GetPivateNameVal() => _name;
        public void SetPivateNameVal(string newVal) => _name = newVal;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
