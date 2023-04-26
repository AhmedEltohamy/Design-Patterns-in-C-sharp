using Abstract_Factory.Abstract_Factory;

namespace Abstract_Factory
{
    internal class FurnitureShop
    {
        private readonly string _name;
        private readonly IFurnitureFactory _furnitureFactory;

        public FurnitureShop(string name, IFurnitureFactory furnitureFactory)
        {
            _name = name;
            _furnitureFactory = furnitureFactory;
        }

        public void ShowProducts()
        {
            Console.WriteLine($"/********************************** {_name} Shop **********************************/");
            _furnitureFactory.CreateChair().Debug();
            _furnitureFactory.CreateTable().Debug();
        }
    }
}
