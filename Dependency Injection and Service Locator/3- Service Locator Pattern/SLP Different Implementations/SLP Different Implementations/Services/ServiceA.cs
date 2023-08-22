using SLP_Different_Implementations.IServices;

namespace SLP_Different_Implementations.Services;

public class ServiceA : IServiceA
{
    public void ExecuteOperationA() =>
        Console.WriteLine("Executing operation from service A.......");
}
