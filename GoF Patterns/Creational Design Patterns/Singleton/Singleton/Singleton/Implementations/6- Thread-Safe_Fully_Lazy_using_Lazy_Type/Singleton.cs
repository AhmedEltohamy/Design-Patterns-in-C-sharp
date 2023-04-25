namespace Singleton.Implementations._6__Thread_Safe_Fully_Lazy_using_Lazy_Type
{
    internal sealed class Singleton
    {
        private static readonly Lazy<Singleton> _lazy = new Lazy<Singleton>(() => new Singleton());

        private Singleton()
        {
        }

        public static Singleton Instance => _lazy.Value;
    }
}
