namespace DataAccess;

public static class CustomerRepositoryFactory
{
    public static ICustomerRepository GetCustomerRepository() => new CustomerRepository();
}
