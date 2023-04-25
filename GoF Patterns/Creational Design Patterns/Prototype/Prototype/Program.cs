using Prototype;

var emp1 = new Employee("Ahmed", "CS", new Address("street 123"));

var emp2 = emp1.Clone();
emp2.Department = "IT";
emp2.Address.Street = "Street 500";


Console.WriteLine("/************************************* Employee 1 *************************************/");
emp1.ShowDetails();

Console.WriteLine();

Console.WriteLine("/************************************* Employee 2 *************************************/");
emp2.ShowDetails();

Console.WriteLine();

Console.WriteLine("/************************************* Employee 1 *************************************/");
emp1.ShowDetails();


var registery = new PrototypeRegistery();
registery[emp1.Department] = emp1;

var emp3  = registery["CS"].Clone();
emp3.Name = "Mohamed";

Console.WriteLine();

Console.WriteLine("/************************************* Employee 3 *************************************/");
emp3.ShowDetails();

Console.WriteLine();

Console.WriteLine("/************************************* Employee 1 *************************************/");
emp1.ShowDetails();