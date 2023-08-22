using SLP_Different_Implementations.IServices;
using SLP_Different_Implementations.Services;

namespace Static_Imp;

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

    private IServiceA? serviceA;
    private IServiceB? serviceB;

    public IServiceA GetIServiceA()
    {
        //we will make ServiceA a singleton for this example, but does not need to be in a general case
        serviceA ??= new ServiceA();
        return serviceA;
    }

    public IServiceB GetIServiceB()
    {
        //we will make ServiceA a singleton for this example, but does not need to be in a general case
        serviceB ??= new ServiceB();
        return serviceB;
    }
}
