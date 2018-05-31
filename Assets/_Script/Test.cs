using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Test : NetworkBehaviour {

	// Use this for initialization
	void Start ()
	{
	}

	private void OnEnable()
	{
		//CmdServerDestroy();
		StartCoroutine(Destroy());
		//print("Gameobject: " + gameObject.name + " was enabled");
	}

	private void OnDisable()
	{
		//print("Gameobject: " + gameObject.name + " was disabled");
		
		StopAllCoroutines();
	}
	IEnumerator Destroy()
	{
		while (true)
		{
			yield return new WaitForSeconds(2f);
			//SimplePool.DespawnGameObject(gameObject);
		}
	}
	
}
