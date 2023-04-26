using Abstract_Factory.Abstract_Products;

namespace Abstract_Factory.Concrete_Products
{
    internal class ModernChair : IChair
    {
        public string Model => "Modern Chair";

        public void Debug() => Console.WriteLine(Model);
    }
}
