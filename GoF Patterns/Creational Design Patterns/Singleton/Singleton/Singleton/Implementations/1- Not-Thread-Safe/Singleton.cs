namespace Singleton.Implementations.Not_Thread_Safe
{
    internal sealed class Singleton
    {
        private static Singleton? _instance;

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                if (_instance is null)
                    _instance = new Singleton();
                return _instance;
            }
        }
    }
}
