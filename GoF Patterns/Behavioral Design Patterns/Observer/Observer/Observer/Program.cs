using Observer.Observers;
using Observer.Subjects;

var shop = new Shop();

var customer1 = new Customer("Ahmed");
var customer2 = new Customer("Mohamed");

shop.RegisterObserver(customer1);
shop.RegisterObserver(customer2);

shop.AddNewProduct("IPhone 14");

shop.RemoveObserver(customer1);

shop.AddNewProduct("Oppo A3");

Console.ReadKey();