namespace Prototype
{
    internal class PrototypeRegistery
    {
        private readonly Dictionary<string, Prototype> _registery = new Dictionary<string, Prototype>();

        public Prototype this[string dept]
        {
            get { return _registery[dept]; }
            set { _registery.Add(dept, value); }
        }
    }
}
