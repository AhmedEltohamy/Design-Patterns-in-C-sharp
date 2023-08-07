using Visitor.Entities;

namespace Visitor.Visitors;

internal class DiscountVisitor : IVisitor
{
    public decimal TotalDiscountGiven { get; private set; }

    public void Visit(Customer customer)
    {
        var discount = customer.AmountOrdered / 10;
        customer.Discount = discount;
        TotalDiscountGiven += discount;
    }

    public void Visit(Employee employee)
    {
        var discount = employee.YearsEmployed < 10 ? 100 : 200;
        employee.Discount = discount;   
        TotalDiscountGiven += discount;
    }
}
