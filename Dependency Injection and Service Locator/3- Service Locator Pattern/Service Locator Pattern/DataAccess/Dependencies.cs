namespace DataAccess;

public static class Dependencies
{
    public static void RegisterService()
    {
        var serviceLocator = ServiceLocator.ServiceLocator.Instance;
        serviceLocator.Register<ICustomerRepository>(new  CustomerRepository());
    }
}
