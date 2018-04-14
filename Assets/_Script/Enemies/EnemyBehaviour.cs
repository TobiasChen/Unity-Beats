using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	protected int Hp;
	public float Movementspeed;
	private GameObject player;
	private Rigidbody2D rb2d;

	public virtual void Start()
	{

		player = GameObject.FindGameObjectWithTag("Player");
		rb2d = GetComponent<Rigidbody2D>();
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
		if (other.tag == "bullet")
		{
			Hp -= 25;
			if (Hp <= 0)
			{
				Death();
			}
			other.gameObject.GetComponent<BulletComponent>().Destroy();
		}
	}

	protected void Death()
	{
			Destroy(gameObject);
	}
	protected virtual void KIBehaviour()
	{
		var dir = player.transform.position - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);		
		
	}

}
