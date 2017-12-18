using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _pooledObjects;
    [SerializeField]
    private bool _growthEnabled;
    [SerializeField]
    private List<GameObject> _uniqueObjects;
    
    /* Properties for editor construction */
    public List<GameObject> ObjectsToPool { get; set; }
    public int PoolQuantity { get; set; }
    public bool EnableGrowth { get; set; }
    public string PoolName { get; set; }

    public void ConstructPooler()
    {
        _growthEnabled = EnableGrowth;
        _pooledObjects = ObjectsToPool;
        
        _pooledObjects = new List<GameObject>();

        for (int i = 0; i < PoolQuantity; i++)
        {
            foreach (var obj in _pooledObjects)
            {
                GameObject objToAdd = Instantiate(obj, transform);
                objToAdd.SetActive(false);
                _pooledObjects.Add(objToAdd);
            }
        }
    }

    public GameObject GetPooledObject()
    {
        
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        if (_growthEnabled)
        {
            foreach (var obj in _uniqueObjects)
            {
                GameObject objToAdd = Instantiate(obj, transform);
                objToAdd.SetActive(false);
                _pooledObjects.Add(objToAdd);
            }
        }

        return null;
    }
}