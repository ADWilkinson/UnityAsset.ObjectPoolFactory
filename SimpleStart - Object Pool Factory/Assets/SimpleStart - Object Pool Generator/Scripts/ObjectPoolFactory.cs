using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Asset Title: SimpleStart - Object Pool Generator
    Version: Version: 1.0
    Author: Andrew Wilkinson
    
    Description: A simple solution for generating a custom object pooling object that will handle any amount of unique 
    objects you choose to pool. You can set how much of each object you want to have pooled in the scene and by using tags
    the pool allows runtime methods to retrieve specific objects needed from the pool and if there are none left, generate additional 
    objects if you choose to enable dynamic growth. These are the features in version 1.0, I would like to extend this to allow custom
    quantity of each individual unique object pooled rather then a blanket number for each object. Please leave feedback or suggestions 
    of what you would like me to add or imnprove on and i'll get straight back to you. 
*/ 

public class ObjectPoolFactory : MonoBehaviour
{
    public GameObject PoolSkeleton;
    public List<GameObject> ObjectsToPool = new List<GameObject>();
    public string PoolName { get; set; }
    public int PoolQuantity { get; set; }
    public bool EnableGrowth { get; set; }
    public GameObject ObjectToAdd { get; set; }

    public void AddObjectToBePooled(GameObject obj)
    {
        obj.SetActive(false);
        ObjectsToPool.Add(obj);
    }

    public void GeneratePoolingObject()
    {
        GameObject objPooler = Instantiate(PoolSkeleton);
        objPooler.name = PoolName;
        objPooler.GetComponent<IObjectPool>().Growth = EnableGrowth;
        objPooler.GetComponent<IObjectPool>().PoolName = PoolName;
        objPooler.GetComponent<IObjectPool>().Growth = EnableGrowth;
        objPooler.GetComponent<IObjectPool>().PoolQuantity = PoolQuantity;
        objPooler.GetComponent<IObjectPool>().ObjectsToPool = ObjectsToPool;
        objPooler.GetComponent<IObjectPool>().ConstructPooler();
    }

    public void ClearAllOptions()
    {
        ObjectsToPool.Clear();
        ObjectToAdd = null;
        PoolName = "";
        EnableGrowth = false;
        PoolQuantity = 0;
    }
}