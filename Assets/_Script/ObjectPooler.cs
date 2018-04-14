using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
	public PooledObject PooledObject;
	public List<GameObject> PooledObjects = new List<GameObject>();
	public List<GameObject> NotActiveObjects = new List<GameObject>();

	private void Start()
	{
		if (PooledObject.GetCreateOnAwake())
		{
			Populate();
		}
	}

	void Populate()
	{
		PooledObjects.Clear();
		for (int i = 0; i < PooledObject.GetAmount(); i++)
		{
			AddObjectToList();
		}
	}

	void AddObjectToList()
	{	
			GameObject obj = Instantiate(PooledObject.GetObject());
			obj.SetActive(false);
			NotActiveObjects.Add(obj);
	}
	public GameObject GetPooledObject()
	{
		int i = NotActiveObjects.Count;
		if (i <= 0)
		{
			if (PooledObject.GetCanGrow())
			{	
				//No Objects left in Pool: Adding new
				AddObjectToList();
				//Could be replaced by i = i+1 or i++
				i = NotActiveObjects.Count;
			}
			else
			{
				//No Objects left in Pool and growth is not allowed, exiting.
				return null;
			}
		}
		//move Object from InActive to Active pool, return the active object.
		PooledObjects.Add(NotActiveObjects[i - 1]);
		NotActiveObjects.RemoveAt(i - 1);
		return PooledObjects[PooledObjects.Count - 1];

	}

	public void ReturnPooledObject()
	{
		NotActiveObjects.Add(PooledObjects[0]);
		PooledObjects.RemoveAt(0);
	}
}
