
using SLP_Different_Implementations.IServices;

namespace SLP_Different_Implementations;

public class Client
{
    public IServiceA? ServiceA { get; set; }
    public IServiceB? ServiceB { get; set; }

    public void DoWork()
    {
        if (ServiceA is null || ServiceB is null)
            throw new InvalidOperationException();

        ServiceA.ExecuteOperationA();
        ServiceB.ExecuteOperationB();
    }
}
