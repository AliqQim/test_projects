
using AutoMapper;

var a = new A { Fld1 = 222, LinkToCObj = new C1 { SomeFld = "Uraa!" } };


var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
var mapper = config.CreateMapper();


var b = mapper.Map<B>(a); //exception here because there is no C1 -> C2 mapping


Console.WriteLine("Hi!");


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<A, B>();
    }
}

public class A
{
    public int Fld1 { get; set; }
    public C1? LinkToCObj { get; set; }

}

public class B
{
    public int Fld1 { get; set; }
    public C2? LinkToCObj { get; set; }

}

public class C1
{
    public string? SomeFld { get; set; }
}

public class C2
{
    public string? SomeFld { get; set; }
}