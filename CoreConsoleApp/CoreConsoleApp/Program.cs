
var b = new B<BItem>();

var res = b.GetCollection();


Console.WriteLine("Hi!");


class Item
{
}

interface IA
{


    ICollection<Item> GetCollection();
}


class BItem : Item
{
}

class B<TItem> : IA where TItem: new()
{
    public ICollection<Item> GetCollection()
    {
        var res = new List<TItem>{new TItem()};

        return ((IEnumerable<Item>)res).ToList();

        
    }
}