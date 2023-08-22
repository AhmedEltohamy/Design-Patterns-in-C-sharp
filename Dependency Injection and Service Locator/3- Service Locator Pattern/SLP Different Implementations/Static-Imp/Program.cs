using SLP_Different_Implementations;
using Static_Imp;

var client = new Client();

client.ServiceA = ServiceLocator.Instance.GetIServiceA();
client.ServiceB = ServiceLocator.Instance.GetIServiceB();

client.DoWork();

Console.ReadKey();