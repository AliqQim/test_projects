using Newtonsoft.Json;

//.Net Framework [ same behaviour

string json = @"{ ""Name"": ""John Doe"", ""Age"": 30 }";
Class1 obj = JsonConvert.DeserializeObject<Class1>(json);
Class2 obj2 = JsonConvert.DeserializeObject<Class2>(json);

Console.WriteLine($"Name: {obj.Name}, Age: {obj.Age}");

Console.WriteLine("DONE");
Console.ReadKey();


class Class1
{
    [JsonProperty("Name")]
    public virtual string? Name { get; set; }

    [JsonProperty("Age")]
    public int Age { get; set; }


}

class Class2 : Class1
{
    [JsonIgnore]
    public override string? Name
    {
        get => $"Hoi: {NameRaw}";
        set => throw new NotImplementedException();
    }

    [JsonProperty("Name")]
    public virtual string? NameRaw { get; set; }
}

