using Abstract_Factory;
using Abstract_Factory.Concrete_Factories;

var modernShop = new FurnitureShop("Modern Furniture", new ModernFurnitureFactory());
var classicShop = new FurnitureShop("Classic Furniture", new ClassicFurnitureFactory());

modernShop.ShowProducts();

Console.WriteLine();

classicShop.ShowProducts();