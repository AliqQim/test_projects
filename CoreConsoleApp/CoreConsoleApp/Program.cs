using CoreConsoleApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

using (MyContext context = MyContextFactory.CreateContext())
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


    var businessLogic = new BusinessLogic(context);
    var joinedRes = await businessLogic.GetJoinedDataAsync();

    joinedRes.ForEach(x=>Console.WriteLine(x));
    

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