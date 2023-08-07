using Visitor.Visitors;

namespace Visitor.Entities;

internal class Employee : IElement
{
    public decimal YearsEmployed { get; private set; }

    public decimal Discount { get; set; }

    public string Name { get; private set; }

    public Employee(string name, decimal yearsEmployed)
    {
        Name = name;
        YearsEmployed = yearsEmployed;
    }

    public void Accept(IVisitor visitor) => visitor.Visit(this);
}