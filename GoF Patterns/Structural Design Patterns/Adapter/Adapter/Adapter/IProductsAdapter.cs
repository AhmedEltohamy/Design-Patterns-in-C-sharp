namespace Adapter;
internal interface IProductsAdapter
{
    IReadOnlyList<Product> GetAllProducts();
}
