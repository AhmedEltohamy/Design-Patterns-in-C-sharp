using DataAccess;

namespace BusinessLogic;

public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService() =>
        _customerRepository = CustomerRepositoryFactory.GetCustomerRepository();

    public string GetCustomerName(int id) =>
        _customerRepository.GetCustomerName(id);
}