using Mapster;


TypeAdapterConfig.GlobalSettings.RequireDestinationMemberSource = true;

var person = new Person { Name = "Alice", Age = 30 };

var dto = person.Adapt<PersonDto>();

Console.WriteLine($"Hello, {dto}!");


public record Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
}

public record PersonDto
{
    public string? Name { get; set; }

    public int MyProperty { get; init; }

}
