using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PooledObject
{
	public abstract string GetName();
	public abstract GameObject GetObject();
	public abstract int GetAmount();
	public abstract bool GetCanGrow();
	public abstract bool GetCreateOnAwake();
}
