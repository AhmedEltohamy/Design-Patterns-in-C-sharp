using DataAccess;

namespace BusinessLogic;

public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService() =>
        _customerRepository = ServiceLocator.ServiceLocator.Instance.GetService<ICustomerRepository>();

    public string GetCustomerName(int id) =>
        _customerRepository.GetCustomerName(id);
}