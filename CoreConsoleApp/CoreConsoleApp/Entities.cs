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

        public string Name { get; set; } = null!;
        public int Age { get; set; }

        public List<Zamorochka> OwnZamorochkas { get; set; } = null!;

        public Zamorochka UnforgivableZamorochkaOfOtherPerson{ get; set; } = null!;

        public Job Job { get; set; } = null!;

    }

    public class Zamorochka
    {
        public string Name { get; set; } = null!;
        public int ZodiacId { get; set; }
        public Zodiac Zodiac { get; set; } = null!;

        public override string? ToString() => $"{Name} ({Zodiac?.Name})";
    }

    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class Zodiac
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
        public virtual DbSet<Zodiac> Zodiacs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            
        }
    }
}
