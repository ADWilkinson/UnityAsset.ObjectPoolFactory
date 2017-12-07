using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameObject Projectile;

	public string PoolToUse;

	[SerializeField]
	private GameObject _pool; 
	
	// Use this for initialization
	void Start ()
	{
		_pool = GameObject.Find(PoolToUse);
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown(KeyCode.Space))
		{
			ShootProjectile();
		}
	}

	void ShootProjectile()
	{
		GameObject projectile = _pool.GetComponent<ObjectPool>().GetPooledObject();
		projectile.transform.position = transform.position;
		projectile.SetActive(true);
		Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
		projectileRb.velocity = Vector3.forward * 10;
	}
}
