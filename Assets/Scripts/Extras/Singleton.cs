using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<T>();
                if (_instance == null)
                {
                    GameObject nuevoGO = new GameObject();
                    _instance = nuevoGO.AddComponent<T>();
                    nuevoGO.name = typeof(T).ToString() + " (Singleton)";
                    DontDestroyOnLoad(nuevoGO);
                }
            }
            return _instance;
        }

    }

    protected virtual void Awake()
    {
        _instance = this as T;
    }
}
