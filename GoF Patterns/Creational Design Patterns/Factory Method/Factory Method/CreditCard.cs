namespace Factory_Method
{
    // Abstract Product
    internal abstract class CreditCard
    {
        public abstract string Type { get; }
        public abstract int CreditLimit { get; }
        public abstract int AnnualCharge { get; }

        public virtual void Details() => Console.WriteLine($"Type: {Type}\nCredit Limit: {CreditLimit}\nAnnual Charge: {AnnualCharge}");
    }
}
