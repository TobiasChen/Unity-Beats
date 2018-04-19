using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetBehaviour : EnemyBehaviour
{
	public float JetMovementSpeed;
	public int JetHP;

	public override void Start()
	{
		base.Start();	
		Movementspeed = JetMovementSpeed;
		HP = JetHP;
	}

	public override void OnEnable()
	{
		HP = JetHP;
	}
}