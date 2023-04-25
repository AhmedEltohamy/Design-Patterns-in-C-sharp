namespace Factory_Method
{
    // Concrete Product
    internal class MoneyBack : CreditCard
    {
        public override string Type => "MoneyBack";

        public override int CreditLimit => 15000;

        public override int AnnualCharge => 500;
    }
}
