using Visitor.Visitors;

namespace Visitor.Entities;

internal class Customer : IElement
{
    public int AmountOrdered { get; private set; }
    
    public decimal Discount { get; set; }

    public string Name { get; private set; }

    public Customer(string name, int amountOrederd) 
    {
        Name = name;
        AmountOrdered = amountOrederd;
    }

    public void Accept(IVisitor visitor) => visitor.Visit(this);
}
