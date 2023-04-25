namespace Singleton.Implementations._4__Thread_Safe_Without_Using_Locks_Not_Quite_Lazy
{
    internal sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static Singleton()
        {
        }

        private Singleton()
        {
        }

        public static Singleton Instance => _instance;
    }
}
