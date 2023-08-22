using Generics_Imp;
using SLP_Different_Implementations;
using SLP_Different_Implementations.IServices;
using SLP_Different_Implementations.Services;

// register services with ServiceLocator
ServiceLocator.Instance.Register<IServiceA>(new ServiceA());
ServiceLocator.Instance.Register<IServiceB>(new ServiceB());

var client = new Client();

client.ServiceA = ServiceLocator.Instance.GetService<IServiceA>();
client.ServiceB = ServiceLocator.Instance.GetService<IServiceB>();

client.DoWork();

Console.ReadLine();