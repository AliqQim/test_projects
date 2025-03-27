
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


    Task<IReadOnlyCollection<Item>> GetCollection();
}


class BItem : Item
{
}

class B<TItem> : IA where TItem: new()
{
    public async Task<IReadOnlyCollection<Item>> GetCollection()
    {
        var res = new List<TItem>{new TItem()};
        await Task.Delay(1);

        return (IReadOnlyCollection<Item>)res;
    }
}