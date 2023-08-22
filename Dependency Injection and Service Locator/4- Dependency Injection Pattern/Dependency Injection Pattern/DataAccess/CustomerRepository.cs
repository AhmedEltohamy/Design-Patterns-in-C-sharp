namespace DataAccess;

public class CustomerRepository : ICustomerRepository
{
    private readonly static IReadOnlyList<Customer> _customers = new List<Customer>()
    {
        new Customer(1, "Ahmed"),
        new Customer(2, "Mohamed")
    };

    public string GetCustomerName(int id) => _customers.First(c => c.Id == id).Name;
}