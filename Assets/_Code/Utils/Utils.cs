using UnityEngine;

namespace _Code.Utils
{
    public class LazySingleton<T> where T : new()
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }
                return instance;
            }
        }
    }
    public class Utils : MonoBehaviour
    {
        
    }
}