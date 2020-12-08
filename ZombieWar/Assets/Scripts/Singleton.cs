using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieWar
{
    public class Singleton<Type> : MonoBehaviour where Type: MonoBehaviour
    {
        private static Type _instance;

        public static Type Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<Type>();

                    if (_instance == null)
                    {
                        var singleton = new GameObject("[SINGLETON]" + typeof(Type));
                        _instance = singleton.AddComponent<Type>();
                        DontDestroyOnLoad(singleton);
                    }
                }
                return _instance;
            }
        }
    }
}
