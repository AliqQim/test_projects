
var a = new A { Fld1 = 222, LinkToCObj = new C1 { SomeFld = "Uraa!" } };


Console.WriteLine("Hi!");

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