using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    
	private void OnEnable()
	{
		Invoke("RecyclePickup", 4);
	}

	public void RecyclePickup()
	{
		gameObject.SetActive(false);
	}
}
