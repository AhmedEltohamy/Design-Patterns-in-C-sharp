namespace Generics_Imp;

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

    private Dictionary<Type, object> _registry = new();

    public void Register<T>(T serviceInstance) =>
        _registry[typeof(T)] = serviceInstance;

    public T GetService<T>() => (T)_registry[typeof(T)];
}
