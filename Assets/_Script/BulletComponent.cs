using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
	public float speed = 1200f;
	private Rigidbody2D rb2d;
	public float TimeoutDestructor = 2f;
	// Use this for initialization
	void Start ()
	{
		rb2d = transform.GetComponent<Rigidbody2D>();
		rb2d.AddForce(transform.right * speed);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			Destroy();
		}
	}
	
	private void OnEnable()
	{
		if (rb2d != null)
		{
			rb2d.AddForce(transform.right * speed);
		}

		StartCoroutine(ActiveTimer());
	}

	public void Destroy()
	{
		//print("Gameobject '" + gameObject.name + "' was disabled and returned to Pool");
		SimplePool.Despawn(gameObject);
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	IEnumerator ActiveTimer()
	{
		while (true)
		{	
		yield return new WaitForSeconds(TimeoutDestructor);
		Destroy();
		}
	}
}
