using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
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

public class ObjectPool : MonoBehaviour, IObjectPool
{
    /* properties used by the object pool factory */
    public string PoolName { get; set; }
    public int PoolQuantity { get; set; }
    public bool Growth { get; set; }
    public List<GameObject> ObjectsToPool { get; set; }

    /* local variables that are manipulated at run-time */
    public List<GameObject> ObjectsInScene;

    public List<GameObject> UniqueObjects;
    public bool GrowthEnabled;

    private void Start()
    {
        ObjectsInScene = new List<GameObject>();

        foreach (Transform child in transform)
        {
            ObjectsInScene.Add(child.gameObject);
        }
    }

    public void ConstructPooler()
    {
        // setting editor values to the local variables to carry over to run-time 
        GrowthEnabled = Growth;
        UniqueObjects = new List<GameObject>();


        // creating our pooled objects in the scene
        for (int i = 0; i < PoolQuantity; i++)
        {
            foreach (var obj in ObjectsToPool)
            {
                GameObject objToAdd = Instantiate(obj, transform);
                objToAdd.SetActive(false);
            }
        }

        // creating a seperate collection to track the number of unique objects pooled
        foreach (var obj in ObjectsToPool)
        {
            UniqueObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject(string objTag)
    {
        for (int i = 0; i < ObjectsInScene.Count; i++)
        {
            if (!ObjectsInScene[i].activeInHierarchy && ObjectsInScene[i].CompareTag(objTag))
            {
                return ObjectsInScene[i];
            }
        }

        if (GrowthEnabled)
        {
            foreach (var obj in UniqueObjects)
            {
                if (obj.CompareTag(objTag))
                {
                    GameObject objToAdd = Instantiate(obj, transform);
                    objToAdd.SetActive(false);
                    ObjectsInScene.Add(objToAdd);
                    return objToAdd;
                }
            }
        }

        return null;
    }
}