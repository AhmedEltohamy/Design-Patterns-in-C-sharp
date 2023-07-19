using System.Text.Json;
namespace Adapter;
internal class ProductsClassAdapter : ProductsExternalSource, IProductsAdapter
{
    public new IReadOnlyList<Product> GetAllProducts() =>
            JsonSerializer.Deserialize<List<Product>>(base.GetAllProducts()).AsReadOnly();

}
