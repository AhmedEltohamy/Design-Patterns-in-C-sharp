namespace DataAccess;

public static class CustomerRepositoryFactory
{
    public static CustomerRepository GetCustomerRepository() => new CustomerRepository();
}
