using Mapster;

var person = new Person { Name = "Alice", Age = 30 };

var dto = person.Adapt<PersonDto>();

Console.WriteLine($"Hello, {dto}!");


public record Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
}

// Целевой класс
public record PersonDto
{
    public string? Name { get; set; }
}
