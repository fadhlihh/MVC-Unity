using UnityEngine;

namespace MVC.Utility
{
    public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (!_instance)
                {
                    T instance = GameObject.FindObjectOfType<T>();
                    if (instance)
                    {
                        _instance = instance;
                    }
                    else
                    {
                        GameObject instanceObject = new GameObject($"[Loader] {typeof(T).Name}");
                        _instance = instanceObject.AddComponent<T>();
                        GameObject.DontDestroyOnLoad(instanceObject);
                    }
                }
                return _instance;
            }
        }
    }
}
