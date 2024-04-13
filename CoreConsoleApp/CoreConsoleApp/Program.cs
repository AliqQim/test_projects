using CoreConsoleApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

using (var context = MyContextFactory.CreateContext())
{
    bool reset = true;

    if (reset)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.Persons.Add(new Person
        {
            Name = "петя",
            Age = 20,
            Job = new Job { Name = "работа 1" },
            

        });
        context.Persons.Add(new Person
        {
            Name = "Вася",
            Age = 23,
            Job = new Job { Name = "работа 2" },
            
        });

        context.SaveChanges();
    }

    Console.WriteLine("Deleting:");
    var count = context.Persons
                                .Where(p => p.Age < 21)
                                .DeleteFromQuery();

    Console.WriteLine($"{count} persons have been deleted.");


}

Console.WriteLine("DONE");
Console.ReadKey();



public class MyContextFactory : IDesignTimeDbContextFactory<MyContext>
{
    public MyContext CreateDbContext(string[] args) => CreateContext();

    public static MyContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<MyContext>()
                        .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                        .UseSqlServer($"Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MyContext;Integrated Security=True;MultipleActiveResultSets=True")
                        .Options;
        var context = new MyContext(options);
        return context;
    }
}