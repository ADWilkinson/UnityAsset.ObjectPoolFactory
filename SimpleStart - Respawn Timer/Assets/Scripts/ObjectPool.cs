using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool PoolingObject;

    public string Id;
    
    public List<GameObject> PooledObjects;
    public List<GameObject> ObjectsToPool { get; set; }
    public int PoolQuantity { get; set; }
    public bool EnableGrowth { get; set; }

    public void ContructPooler()
    {
        PoolingObject = this;
        Id = PoolingObject.ToString();
        
        PooledObjects = new List<GameObject>();

        for (int i = 0; i < PoolQuantity; i++)
        {
            foreach (var obj in ObjectsToPool)
            {
                GameObject objToAdd = Instantiate(obj, transform);
                objToAdd.SetActive(false);
                PooledObjects.Add(objToAdd);
            }
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < PooledObjects.Count; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }

        if (EnableGrowth)
        {
            foreach (var obj in ObjectsToPool)
            {
                GameObject objToAdd = Instantiate(obj, transform);
                objToAdd.SetActive(false);
                PooledObjects.Add(objToAdd);
            }
        }

        return null;
    }
}