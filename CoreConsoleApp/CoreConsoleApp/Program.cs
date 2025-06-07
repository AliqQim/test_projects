using Dtos;
using Mapster;
using System.Reflection;






var person = new Person { Name = "Alice", Age = 30 };

var dto = person.Adapt<PersonDto>();

Console.WriteLine($"Hello, {dto}!");


public class MyRegister : ICodeGenerationRegister
{
    public void Register(CodeGenerationConfig config)
    {
        config.AdaptTo("[name]Dto")
            .ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), "Dtos");

        config.GenerateMapper("[name]Mapper")
                .ForType<Person>();

    }
}

namespace Dtos{
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
}