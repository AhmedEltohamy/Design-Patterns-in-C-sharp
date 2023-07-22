using System.Text;

namespace Bridge.Entities;

internal abstract class MovieLicense
{
    private readonly Discount _discount;
    public string Movie { get; }
    public DateTime PurchaseDate { get; }

    protected MovieLicense(string movie, DateTime purchaseDate, Discount discount)
    {
        Movie = movie;
        PurchaseDate = purchaseDate;
        _discount = discount;   
    }

    public double GetPrice() => OriginalPrice * (1 - (double)(_discount.DiscountPercentage / 100m));

    protected abstract double OriginalPrice { get; }
    public abstract DateTime? ExpirationDate { get; }

    public override string ToString()
    {
        var str = new StringBuilder();
        str.AppendLine($"Movie: {Movie}");
        str.AppendLine($"Original Price: {OriginalPrice}");
        str.AppendLine($"Price after discount: {GetPrice()}");
        str.AppendLine($"Valid for: {ExpirationDate}");
        str.AppendLine();

        return str.ToString();
    }
}
