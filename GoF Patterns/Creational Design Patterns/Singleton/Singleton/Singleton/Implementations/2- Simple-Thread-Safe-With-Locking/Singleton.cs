namespace Singleton.Implementations._2__Simple_Thread_Safe_With_Locking
{
    internal sealed class Singleton
    {
        private static Singleton? _instance;
        private static readonly object singletonLock = new object();

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                lock (singletonLock)
                {
                    if (_instance is null)
                        _instance = new Singleton();
                    return _instance;
                }
            }
        }
    }
}
