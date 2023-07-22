namespace Bridge.Entities;

internal class TwoDaysMovieLicense : MovieLicense
{
    public TwoDaysMovieLicense(string movie, DateTime purchaseDate, Discount discount) : base(movie, purchaseDate, discount)
    {
    }

    public override DateTime? ExpirationDate => PurchaseDate.AddDays(2);

    protected override double OriginalPrice => 4;
}
