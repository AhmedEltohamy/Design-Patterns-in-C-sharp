namespace Observer.Observers;

internal class Customer : IProductObserver
{
    public string UserName { get; private set; }

    public Customer(string userName)
    {
        if (userName is null)
            throw new ArgumentNullException(nameof(userName));

        UserName = userName;
    }

    public void OnNewProductAvailable(string productName) => 
        Console.WriteLine($"Customer with username: {UserName} has been notified that product {productName} is now avaliable at the shop");
}
