using Abstract_Factory.Abstract_Factory;
using Abstract_Factory.Abstract_Products;
using Abstract_Factory.Concrete_Products;

namespace Abstract_Factory.Concrete_Factories
{
    internal class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair() => new ModernChair();

        public ITable CreateTable() => new ModernTable();
    }
}
