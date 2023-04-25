namespace Factory_Method
{
    // Concrete Creator
    internal class MoneyBackFactory : CreditCardFactory
    {
        protected override CreditCard MakeCard() => new MoneyBack();
    }
}
