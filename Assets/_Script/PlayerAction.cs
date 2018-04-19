using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
	public GameObject BulletProjectile;
	private float FireDelay;
	private PlayerController PC;

	// Use this for initialization
	void Start ()
	{
		SimplePool.Preload(BulletProjectile, 200);
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
		SimplePool.Spawn(BulletProjectile, transform.position, transform.rotation);
	}
}
