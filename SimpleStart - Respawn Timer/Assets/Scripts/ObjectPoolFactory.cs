using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        var script = objPooler.GetComponent<ObjectPool>();
        script.EnableGrowth = EnableGrowth;
        script.PoolQuantity = PoolQuantity;
        script.ObjectsToPool = ObjectsToPool;

        script.ContructPooler();
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