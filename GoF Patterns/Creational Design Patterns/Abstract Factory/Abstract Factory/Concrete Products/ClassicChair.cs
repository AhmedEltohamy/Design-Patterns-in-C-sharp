using Abstract_Factory.Abstract_Products;

namespace Abstract_Factory.Concrete_Products
{
    internal class ClassicChair : IChair
    {
        public string Model => "Classic Chair";

        public void Debug() => Console.WriteLine(Model);
    }
}
