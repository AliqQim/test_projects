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

        context.Persons.Add(new Person
        {
            Name = "петя",
            Age = 22,
            Job = new Job { Name = "работа 1" },
            Zamorochkas = new List<Zamorochka> {
                            new Zamorochka { Name = "тупо шутит" },
                            new Zamorochka { Name = "безалаберный" },
                        }

        });
        context.Persons.Add(new Person
        {
            Name = "Вася",
            Age = 23,
            Job = new Job { Name = "работа 2" },
            Zamorochkas = new List<Zamorochka> { new Zamorochka { Name = "далбич" } }
        });

        context.SaveChanges();
    }


    Console.WriteLine(context.Persons.Count());


    var u1 = await context.Persons.SingleAsync(x=>x.Name == "петя");

    u1.Age = 666;

    Console.WriteLine(JsonConvert.SerializeObject(await context.Persons.ToListAsync()));
    //in this case петя has age of 666, i.e. the existing object being tracked is used

    Console.WriteLine(JsonConvert.SerializeObject(await context.Persons
        .AsNoTracking()
        .ToListAsync()));
    //here петя's age is 22, it's just read from DB


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