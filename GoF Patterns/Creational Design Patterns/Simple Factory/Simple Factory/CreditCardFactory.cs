namespace Simple_Factory
{
    // Factory
    internal static class CreditCardFactory
    {
        public static CreditCard GetCreditCard(string cardType) => cardType switch 
        {
            "Titanium" => new Titanium(),
            "Platinum" => new Platinum(),
            "MoneyBack" => new MoneyBack(),
            _ => throw new NotImplementedException()
        };
    }
}
