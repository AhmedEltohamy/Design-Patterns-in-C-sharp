using DataAccess;

namespace BusinessLogic;

public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        ArgumentNullException.ThrowIfNull(customerRepository);
        _customerRepository = customerRepository;
    }

    public string GetCustomerName(int id) =>
        _customerRepository.GetCustomerName(id);
}