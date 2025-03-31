using System.Collections.Generic;
using UnityEngine;

public class CustomObjectPool<T> : MonoBehaviour where T : Component
{
    private Queue<T> _pool = new();
    private Transform _parent = null;

    private void EnlargePool()
    {
        T newObject = Instantiate(this as T, Vector3.zero, Quaternion.identity);
        newObject.gameObject.SetActive(false);


        newObject.transform.SetParent(_parent);


        _pool.Enqueue(newObject);
    }

    public void InstantiatePool(int poolSize, Transform parent)
    {
        _parent = parent;

        for (int i = 0; i < poolSize; i++)
        {
            EnlargePool();
        }
    }

    public T Get()
    {
        if (_pool.Count == 0)
        {
            EnlargePool();
        }

        T poolObject = _pool.Dequeue();
        poolObject.gameObject.SetActive(true);

        return poolObject;
    }

    public void Release(T poolObject)
    {
        poolObject.gameObject.SetActive(false);
        _pool.Enqueue(poolObject);
    }
}