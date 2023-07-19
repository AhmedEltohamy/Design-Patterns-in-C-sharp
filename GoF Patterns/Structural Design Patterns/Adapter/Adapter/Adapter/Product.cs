namespace Adapter;
internal class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Product(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString() => $"product id: {Id}{Environment.NewLine}product name: {Name}";
}
