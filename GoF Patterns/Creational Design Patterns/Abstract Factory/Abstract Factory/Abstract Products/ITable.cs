namespace Abstract_Factory.Abstract_Products
{
    internal interface ITable
    {
        string model { get; }
        byte NumberOfLegs { get; }
        void Debug();
    }
}
