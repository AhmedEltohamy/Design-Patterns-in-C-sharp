
using BusinessLogic;

DataAccess.Dependencies.RegisterService();

var customerService = new CustomerService();

Console.WriteLine("Please enter customer id: ");
int customerId;
while (!int.TryParse(Console.ReadLine(), out customerId))
    Console.WriteLine("Please enter valid customer id: ");

var customerName = customerService.GetCustomerName(customerId);

Console.WriteLine($"Customer Name: {customerName}");

Console.ReadKey();