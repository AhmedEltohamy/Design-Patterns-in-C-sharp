namespace Factory_Method
{
    // Abstarct Creator
    internal abstract class CreditCardFactory
    {
        protected abstract CreditCard MakeCard();

        public CreditCard CreateCard() => this.MakeCard();
    }
}
