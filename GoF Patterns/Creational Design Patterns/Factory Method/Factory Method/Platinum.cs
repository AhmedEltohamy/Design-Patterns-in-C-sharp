namespace Factory_Method
{
    // Concrete Product
    internal class Platinum : CreditCard
    {
        public override string Type => "Platinum";

        public override int CreditLimit => 35000;

        public override int AnnualCharge => 2000;
    }
}
