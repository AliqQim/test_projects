using CoreConsoleApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

using (var context = MyContextFactory.CreateContext())
{
    bool reset = false;

    if (reset)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.Users.Add(new User
        {
            Name = "User 1",
            Orders = new List<Order>
            {
                new Order { Item = "Item 1" },
                new Order { Item = "Item 2" }
            }
        });


        context.SaveChanges();
    }


    Console.WriteLine(JsonConvert.SerializeObject(await context.Users.ToListAsync()));
}

Console.WriteLine("DONE");
Console.ReadKey();



public class MyContextFactory : IDesignTimeDbContextFactory<MyContext>
{
    public MyContext CreateDbContext(string[] args) => CreateContext();

    public static MyContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<MyContext>()
                        .UseSqlServer($"Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MyContext;Integrated Security=True;MultipleActiveResultSets=True")
                        .Options;
        var context = new MyContext(options);
        return context;
    }
}