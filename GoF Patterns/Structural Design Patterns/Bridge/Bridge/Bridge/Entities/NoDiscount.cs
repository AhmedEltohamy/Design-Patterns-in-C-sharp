namespace Bridge.Entities;

internal class NoDiscount : Discount
{
    public override decimal DiscountPercentage => 0;
}