namespace Observer.Observers;

internal interface IProductObserver
{
    void OnNewProductAvailable(string productName);
}
