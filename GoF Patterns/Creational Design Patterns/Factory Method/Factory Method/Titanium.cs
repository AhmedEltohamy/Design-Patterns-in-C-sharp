namespace Factory_Method
{
    // Concrete Product
    internal class Titanium : CreditCard
    {
        public override string Type => "Titanium";

        public override int CreditLimit => 25000;

        public override int AnnualCharge => 1500;
    }
}
