using Abstract_Factory.Abstract_Products;

namespace Abstract_Factory.Concrete_Products
{
    internal class ModernTable : ITable
    {
        public string model => "Modern Table";

        public byte NumberOfLegs => 4;

        public void Debug() => Console.WriteLine($"{model} with {NumberOfLegs} Legs");
    }
}
