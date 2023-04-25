namespace Singleton.Implementations._5__Thread_Safe_Without_Using_Locks_Fully_Lazy
{
    internal sealed class Singleton
    {
        private Singleton()
        {
        }

        public static Singleton Instance => Nested.Instance;

        private class Nested
        {
            // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly Singleton Instance = new Singleton();
        }
    }
}
