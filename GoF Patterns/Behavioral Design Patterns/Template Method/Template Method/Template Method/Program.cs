using Template_Method.Entities;

Console.WriteLine("Nescafe Coffee Preparation\n");
CoffeeTemplate coffee = new NescafeCoffee();
coffee.PrepareCoffee();

Console.WriteLine();

Console.WriteLine("Bru coffee preparation\n");
coffee = new BruCoffee();
coffee.PrepareCoffee();

Console.ReadKey();