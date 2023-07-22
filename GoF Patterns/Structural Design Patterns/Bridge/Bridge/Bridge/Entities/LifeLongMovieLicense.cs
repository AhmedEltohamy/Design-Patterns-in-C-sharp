namespace Bridge.Entities;

internal class LifeLongMovieLicense : MovieLicense
{
    public LifeLongMovieLicense(string movie, DateTime purchaseDate, Discount discount) : base(movie, purchaseDate, discount)
    {
    }

    public override DateTime? ExpirationDate => null;

    protected override double OriginalPrice => 8;
}
