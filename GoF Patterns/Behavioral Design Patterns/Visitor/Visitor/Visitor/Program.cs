using Visitor.Entities;
using Visitor.Visitors;

var customeres = new List<Customer>()
{
    new Customer("Customer 1", 500),
    new Customer("Customer 2", 1000),
    new Customer("Customer 3", 800)
};

var employees = new List<Employee>()
{
    new Employee("Employee 1", 14),
    new Employee("Employee 2", 5)
};

var discountVisitor = new DiscountVisitor();

foreach (var customer in customeres)
    customer.Accept(discountVisitor);

foreach (var employee in employees)
    employee.Accept(discountVisitor);

Console.WriteLine($"Total Discount Given is: {discountVisitor.TotalDiscountGiven}");

Console.ReadKey();