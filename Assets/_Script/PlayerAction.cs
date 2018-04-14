using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
	public GameObject BulletProjectile;

	private float FireDelay;
	private PlayerController PC;

	private ObjectPooler OP;
	// Use this for initialization
	void Start ()
	{
		OP = GetComponent<ObjectPooler>();
		OP.PooledObject = new Bullet();
		OP.enabled = true;
		PC = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButton("Fire1") && FireDelay == 0)
		{
			Fire();
		}

		if (FireDelay > 0)
			FireDelay -= Time.deltaTime;
		else
		{
			FireDelay = 0;
		}
	}

	void Fire()
	{
		GameObject obj = OP.GetPooledObject();
		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive(true);
	}
}
