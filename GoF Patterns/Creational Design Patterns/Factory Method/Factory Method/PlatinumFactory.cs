namespace Factory_Method
{
    // Concrete Creator
    internal class PlatinumFactory : CreditCardFactory
    {
        protected override CreditCard MakeCard() => new Platinum();
    }
}
