using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance = null;

    protected virtual bool DontDestroy => false;

    public static T Instance
    {
        get
        {
            if (!_instance)
                _instance = FindAnyObjectByType<T>();

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        var instance = this as T;
        
        if (_instance == null)
        {
            _instance = instance;

            if (DontDestroy)
                DontDestroyOnLoad(gameObject);
        }
        else if (_instance != instance)
        {
             Destroy(gameObject);
        }

        if (transform.parent)
        {
            transform.SetParent(null);
        }

        OnAwake();
    }

    protected virtual void OnAwake() { }
}
