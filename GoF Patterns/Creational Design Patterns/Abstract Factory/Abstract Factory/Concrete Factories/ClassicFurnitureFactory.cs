using Abstract_Factory.Abstract_Factory;
using Abstract_Factory.Abstract_Products;
using Abstract_Factory.Concrete_Products;

namespace Abstract_Factory.Concrete_Factories
{
    internal class ClassicFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair() => new ClassicChair();

        public ITable CreateTable() => new ClassicTable();
    }
}
