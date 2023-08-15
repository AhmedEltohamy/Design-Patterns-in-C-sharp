using Observer.Observers;

namespace Observer.Subjects;

internal class Shop : ISubject
{
    private List<IProductObserver> _observers = new List<IProductObserver>();
    
    private List<string> _products = new List<string>();

    public void AddNewProduct(string productName)
    {
        if (string.IsNullOrWhiteSpace(productName))
            throw new ArgumentNullException(nameof(productName));

        if (_products.Any(p => p == productName))
            throw new InvalidOperationException($"Product with name: {productName} is already exists");

        _products.Add(productName);
        NotifyObservers(productName);
    }

    public void RegisterObserver(IProductObserver observer)
    {
        if (observer is null)
            throw new ArgumentNullException(nameof(observer));

        _observers.Add(observer);
    }

    public void RemoveObserver(IProductObserver observer)
    {
        if (observer is null)
            throw new ArgumentNullException(nameof(observer));

        _observers.Remove(observer);
    }

    public void NotifyObservers(string newProduct) => _observers.ForEach(o => o.OnNewProductAvailable(newProduct));
}
