using Abstract_Factory.Abstract_Products;

namespace Abstract_Factory.Concrete_Products
{
    internal class ClassicTable : ITable
    {
        public string model => "Classic Table";

        public byte NumberOfLegs => 2;

        public void Debug() => Console.WriteLine($"{model} with {NumberOfLegs} Legs");
    }
}
