using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    
    private void OnEnable()
    {
        Invoke("RecycleProjectile", 4);
    }

    public void RecycleProjectile()
    {
        gameObject.SetActive(false);
    }
}
