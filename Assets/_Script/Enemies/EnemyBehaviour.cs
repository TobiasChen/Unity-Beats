using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	protected int HP;
	protected float Movementspeed;
	private GameObject player;
	private Rigidbody2D rb2d;

	public virtual void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		rb2d = GetComponent<Rigidbody2D>();
	}

	public virtual void OnEnable()
	{
		
	}

	// Update is called once per frame
	public virtual void Update ()
	{
		KIBehaviour();
	}

	private void FixedUpdate()
	{
		rb2d.AddForce(this.transform.right * Movementspeed);	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet")
		{
			HP -= 25;
			if (HP <= 0)
			{
				EnemyDeath();
			}
		}
	}

	protected void EnemyDeath()
	{
			SimplePool.Despawn(gameObject);
	}
	protected virtual void KIBehaviour()
	{
		var dir = player.transform.position - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);			
	}

}
