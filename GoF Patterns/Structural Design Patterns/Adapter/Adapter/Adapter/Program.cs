using Adapter;

IProductsAdapter objectAdapter = new ProductsObjectAdapter();
var products = objectAdapter.GetAllProducts();
foreach (var product in products)
    Console.WriteLine(product);

Console.WriteLine();

objectAdapter = new ProductsClassAdapter();
products = objectAdapter.GetAllProducts();
foreach (var product in products)
    Console.WriteLine(product);