using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PooledObject {
	public override string GetName()
	{
		return "bullet";
	}
	public override GameObject GetObject()
	{
		return Resources.Load<GameObject>("Prefabs/Bullet");
	}
	public override int GetAmount()
	{
		return 50;
	}
	public override bool GetCanGrow()
	{
		return true;
	}
	public override bool GetCreateOnAwake()
	{
		return true;
	}
}
