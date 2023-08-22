namespace ServicesName;

internal class ServiceLocator
{
    private static ServiceLocator locator;

    private ServiceLocator()
    {
    }

    public static ServiceLocator Instance
    {
        get
        {
            // ServiceLocator itself is a Singleton
            locator ??= new ServiceLocator();
            return locator;
        }
    }

    private Dictionary<string, object> _registry = new();

    public void Register(string serviceName, object serviceInstance) => 
        _registry[serviceName] = serviceInstance;

    public object GetService(string serviceName) => 
        _registry[serviceName];
}
