using SLP_Different_Implementations.IServices;

namespace SLP_Different_Implementations.Services;

public class ServiceB : IServiceB
{
    public void ExecuteOperationB() =>
        Console.WriteLine("Executing operation from service B.......");
}
