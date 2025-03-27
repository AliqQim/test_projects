
var a = new B<Item>();
var b = new B<BItem>();

var resA = a.GetCollection();
var resB = b.GetCollection();


Console.WriteLine("Hi!");


class Item
{
}

interface IA
{


    IEnumerable<Item> GetCollection();
}


class BItem : Item
{
}

class B<TItem> : IA where TItem: new()
{
    public IEnumerable<Item> GetCollection()
    {
        var res = new List<TItem>{new TItem()};

        return (IEnumerable<Item>)res;
    }
}