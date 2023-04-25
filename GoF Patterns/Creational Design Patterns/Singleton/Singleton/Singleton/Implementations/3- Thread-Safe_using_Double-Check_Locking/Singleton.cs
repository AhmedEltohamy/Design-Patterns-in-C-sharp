namespace Singleton.Implementations._3__Thread_Safe_using_Double_Check_Locking
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
                if (_instance is null)
                {
                    lock (singletonLock)
                    {
                        if (_instance is null)
                            _instance = new Singleton();
                    }
                }
                return _instance;
            }
        }
    }
}
