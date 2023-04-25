namespace Factory_Method
{
    // Concrete Creator
    internal class TitaniumFactory : CreditCardFactory
    {
        protected override CreditCard MakeCard() => new Titanium();
    }
}
