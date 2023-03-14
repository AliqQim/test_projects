

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

var options = new DbContextOptionsBuilder<MyContext>()
                .UseSqlServer($"Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MyContext;Integrated Security=True;MultipleActiveResultSets=True")
                .Options;

using (var context = new MyContext(options))
{
    bool reset = true;

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




    foreach (var p in context.Persons)
    {
        Console.WriteLine($"{p.Name} {p.Age}");
    }

    var persons = context.Persons.Include(x => x.Zamorochkas);

    string? firstzamorochkaName = persons.First().Zamorochkas?.First()?.Name;
    Console.WriteLine(firstzamorochkaName);


}

Console.WriteLine("DONE");
Console.ReadKey();


public class Person
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;
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
}