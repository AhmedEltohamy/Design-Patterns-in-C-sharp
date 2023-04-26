using Abstract_Factory.Abstract_Products;

namespace Abstract_Factory.Abstract_Factory
{
    internal interface IFurnitureFactory
    {
        IChair CreateChair();
        ITable CreateTable();
    }
}
