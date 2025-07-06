using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreConsoleApp
{

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

    public class Order
    {
        public int Id { get; set; }
        public string Item { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }


    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", "dbo");    //seems like no version without explicit table name
            modelBuilder.Entity<Order>().ToTable("Orders", "other");
        }
    }
}
