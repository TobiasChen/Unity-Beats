using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class SimplePool
{

	private static GameObject DynamicFolder = GameObject.FindGameObjectWithTag("DynamicFolder");
	
	private const int DEFAULT_POOL_SIZE = 25;
	public class Pool
	{
		private int nextID = 0;
		//The Stack the Gameobjects are gpomg to be put on
		private Stack<GameObject> inactivePool;
		//The Gameobject, that is pooled in this Pool instance
		private GameObject prefab;
		
		
		public Pool(GameObject prefab, int initialQty)
		{
			this.prefab = prefab;
			inactivePool = new Stack<GameObject>(initialQty);
		}
		public GameObject Spawn(Vector3 position, Quaternion rotation)
		{
			GameObject obj;
			if (inactivePool.Count == 0)
			{
				
				//If the pool is empty a new Gameobject is spawned and then immediatly returned
				//It is also now attached to an empty GameObject, which in Turn is the child of the Dynamic Folder, to keep the working Directorie clean
				obj = GameObject.Instantiate(prefab, position, rotation, dictionaryOfFolders[prefab].transform);
				//The Name is changed by adding the current ID, to keep Track
				obj.name = prefab.name + " (" + (nextID++) + ")";
				//The new Object gets added to the PoolMember class, and the pool it is spawned in is saved
				obj.AddComponent<PoolMember>().myPool = this;
			}
			else
			{
				obj = inactivePool.Pop();
				if (obj == null)
				{
					return Spawn(position, rotation);
				}
			}

			obj.transform.position = position;
			obj.transform.rotation = rotation;
			obj.SetActive(true);
			//Debug.Log("ObjectPooler.Object.Spawn was called");
			return obj;
		}

		public void despawn(GameObject obj)
		{
			//Debug.Log("ObjectPooler.Object.despawn was called");
			obj.SetActive(false);
			//The Objects get added on the top of the unused Stack
			inactivePool.Push(obj);
		}
	}
	// A Class for all Pooled Objects
	class PoolMember : MonoBehaviour
	{
		public Pool myPool;
	}
	//A Dictionary of all current Pools, there can be only one Pool per Gameobject/Prefab
	public static Dictionary<GameObject,  Pool> dictionaryOfPools;
	//Dictionary for the Folders of the new GameObjects
	private static Dictionary<GameObject, GameObject> dictionaryOfFolders;
	
	
	public static void Init(GameObject prefab = null, int size = DEFAULT_POOL_SIZE)
	{
		//Creates the Dictionarys if they are not present
		if (dictionaryOfPools == null)
		{
			dictionaryOfPools = new Dictionary<GameObject, Pool>();
		}
		if (dictionaryOfFolders == null)
		{
			dictionaryOfFolders = new  Dictionary<GameObject, GameObject>();
		}

		//If the prefab that is supposed to be spawned is not NULL, the two new keys are added to the dictionary
		if (prefab != null)
		{
			if (dictionaryOfPools.ContainsKey(prefab) == false)
			{
				//Firstly a new Pool class is instaniated
				dictionaryOfPools[prefab] = new Pool(prefab, size);
			}

			if (dictionaryOfFolders.ContainsKey(prefab) == false)
			{
				//And a new empty GameObject is instantiated, the Dynamic Folder is set as its parent, its added to the Dictionary, and the Name is changed
				GameObject go = new GameObject();
				go.transform.SetParent(DynamicFolder.transform);
				dictionaryOfFolders[prefab] = go;
				dictionaryOfFolders[prefab].name = prefab.name + "s";
			}
		}
	}

	public static void Preload(GameObject prefab, int size = 1)
	{
		Init(prefab, size);
			GameObject[] obs = new GameObject[size];
		for (int i = 0; i < size; i++) 
		{
			obs[i] = SpawnGameObject (prefab, Vector3.zero, Quaternion.identity);
		}

		// Now despawn them all.
		for (int i = 0; i < size; i++) 
		{
			DespawnGameObject(obs[i]);
		}
	}

	public static GameObject SpawnGameObject(GameObject prefab, Vector3 pos, Quaternion rot)
	{
		//Debug.Log("ObjectPooler.SpawnGameObject was called");
		Init(prefab);
		return dictionaryOfPools[prefab].Spawn(pos, rot);
	}
	
	public static void DespawnGameObject(GameObject obj)
	{
		//Debug.Log(obj);
		//Debug.Log(obj.GetComponent<PoolMember>());
		PoolMember pm = obj.GetComponent<PoolMember>();
		if (pm == null)
		{
			//Debug.Log ("Object '" +obj.name+ "' wasn't spawned from a pool. Destroying it instead.");
			GameObject.Destroy(obj);		
		}
		else
		{
			//Debug.Log("ObjectPooler.DespawnGameObject was called and ObjectPooler.Object.despawn was called");
			pm.myPool.despawn(obj);
		}
	}
	
}
