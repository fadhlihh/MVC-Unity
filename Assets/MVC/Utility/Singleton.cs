namespace MVC.Utility
{
    public class Singleton<T> where T : Singleton<T>, new()
    {
        private static readonly object _lock = new object();
        private static T _instance;
        public static T Instance
        {
            get
            {
                lock (_lock)
                {

                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                    return _instance;
                }
            }
        }
    }
}
