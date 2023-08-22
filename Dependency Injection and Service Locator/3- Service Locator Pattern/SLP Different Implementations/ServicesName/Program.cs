using ServicesName;
using SLP_Different_Implementations;
using SLP_Different_Implementations.IServices;
using SLP_Different_Implementations.Services;

// register services with ServiceLocator
ServiceLocator.Instance.Register("ServiceA", new ServiceA());
ServiceLocator.Instance.Register("ServiceB", new ServiceB());

var client = new Client();

client.ServiceA = (IServiceA)ServiceLocator.Instance.GetService("ServiceA");
client.ServiceB = (IServiceB)ServiceLocator.Instance.GetService("ServiceB");

client.DoWork();

Console.ReadKey();