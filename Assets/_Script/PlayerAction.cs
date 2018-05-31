using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerAction : NetworkBehaviour
{
	public ServerPooling SV;
	public GameObject BulletProjectile;
	private float FireDelay;
	private PlayerController PC;
	private ClientPooling ClientPooling;

	void Start ()
	{
		ClientPooling = GameObject.Find("ServerPooling").GetComponent<ClientPooling> ();
		PC = GetComponent<PlayerController>();
		
	}
	

	void Update ()
	{
		if (!isLocalPlayer)
		{
			return;
		}
		if (Input.GetButtonDown("Fire1") && FireDelay == 0)
		{
			CmdFire();
		}

		if (FireDelay > 0)
			FireDelay -= Time.deltaTime;
		else
		{
			FireDelay = 0;
		}
	}
	[Command]
	void CmdFire()
	{
		print("CommandFire was called");
		GameObject temp = SimplePool.SpawnGameObject(BulletProjectile, transform.position,transform.rotation);
		temp.GetComponent<Rigidbody2D>().velocity = transform.right * 40;
		NetworkServer.Spawn(temp, ClientPooling._networkHash128);
		Debug.Log("Spawned Gameobject: " + temp);

	}

	void Fire()
	{
	}
}
