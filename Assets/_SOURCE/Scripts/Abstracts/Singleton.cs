using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance = null;

    protected virtual bool DontDestroy => false;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<T>();

                if (_instance == null)
                {
                    GameObject gameObject = new GameObject();
                    gameObject.name = typeof(T).Name;
                    _instance = gameObject.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;

            if (DontDestroy)
                DontDestroyOnLoad(this.gameObject);
        }
        else
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
