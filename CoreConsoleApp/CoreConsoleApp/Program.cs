using CoreConsoleApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
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
 
}

using (var context = MyContextFactory.CreateContext())
{
    Console.WriteLine(JsonConvert.SerializeObject(await context.Persons.ToListAsync()));
}

using (var context = MyContextFactory.CreateContext())
{

    var p = new Person { Id = 1 };
    
    p.Name = "ZZZ"; //this won;t go to db

    context.Attach(p);
    
    p.Age = 777;    //this will go to DB

    context.SaveChanges();
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