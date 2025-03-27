
var a = new B<Item>();
var b = new B<BItem>();

var resA = await a.GetCollection();
var resB = await b.GetCollection();


Console.WriteLine("Hi!");


class Item
{
}

interface IA
{


    Task<IEnumerable<Item>> GetCollection();
}


class BItem : Item
{
}

class B<TItem> : IA where TItem: new()
{
    public Task<IEnumerable<Item>> GetCollection()
    {
        var res = new List<TItem>{new TItem()};

        return Task.FromResult((IEnumerable<Item>)res);
    }
}