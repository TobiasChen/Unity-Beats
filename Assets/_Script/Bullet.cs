using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 1200f;
	private Rigidbody2D rb2d;

	public float TimeoutDestructor = 2f;
	// Use this for initialization
	void Start ()
	{
		rb2d = transform.GetComponent<Rigidbody2D>();
		rb2d.AddForce(transform.right * speed);
		//rb2d.AddForce(transform.forward);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (TimeoutDestructor >= 0)
		{
			TimeoutDestructor -= Time.deltaTime;
		}
		else
		{
			Destroy(gameObject);
		}
		//rb2d.AddForce(transform.forward);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "enemy")
		{
			//other.GetComponent<>();
		}
	}
}
