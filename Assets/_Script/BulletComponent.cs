using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
	public float speed = 1200f;
	private Rigidbody2D rb2d;
	private ObjectPooler ObjectPooler;
	public float TimeoutDestructor = 2f;
	// Use this for initialization
	void Start ()
	{
		rb2d = transform.GetComponent<Rigidbody2D>();
		ObjectPooler = GameObject.FindGameObjectWithTag("Player").GetComponent<ObjectPooler>();
		rb2d.AddForce(transform.right * speed);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "enemy")
		{
			//other.GetComponent<>();
		}
	}

	private void OnEnable()
	{
		Invoke("Destroy", 2f);
		if (rb2d != null)
		{
			rb2d.AddForce(transform.right * speed);

		}
	}

	public void Destroy()
	{
		gameObject.SetActive(false);
		ObjectPooler.ReturnPooledObject();
	}

	private void OnDisable()
	{
		CancelInvoke();
	}

}
