using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
	public Rigidbody2D BulletProjectile;

	private float FireDelay;
	private PlayerController PC;
	// Use this for initialization
	void Start () 
	{
		PC = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButton("Fire1") && FireDelay == 0)
		{
			Instantiate(BulletProjectile, transform.position, transform.rotation);
			FireDelay =PC.TimeBetweenShots;
		}

		if (FireDelay > 0)
			FireDelay -= Time.deltaTime;
		else
		{
			FireDelay = 0;
		}
	}
}
