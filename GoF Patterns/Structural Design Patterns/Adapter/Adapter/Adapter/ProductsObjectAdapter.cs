using System.Text.Json;
namespace Adapter;
internal class ProductsObjectAdapter : IProductsAdapter
{
    private readonly ProductsExternalSource _productsExternalSource = new();

    public IReadOnlyList<Product> GetAllProducts() => 
        JsonSerializer.Deserialize<List<Product>>(_productsExternalSource.GetAllProducts()).AsReadOnly();
}
