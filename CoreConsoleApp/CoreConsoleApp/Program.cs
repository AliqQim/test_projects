
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

        if (typeof(TItem) == typeof(Item))
        {
            return (ICollection<Item>)res;  //to avoid unnecessary list copying
        }

        return ((IEnumerable<Item>)res).ToList();

        
    }
}