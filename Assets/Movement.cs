using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	public float force;
	private Rigidbody2D rbPlayer;
	public Vector3 worldSpaceMouse;
	private Transform tfPlayer;
	public float rotationSpeed;
	
	void Start ()
	{
		rotationSpeed = 100f;
		tfPlayer = GetComponent<Transform>();
		rbPlayer = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per ;
	void Update ()
	{
		
		worldSpaceMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);	//Gets current Mouse Position
		Vector3 dis3 = new Vector3((worldSpaceMouse.x - transform.position.x), (worldSpaceMouse.y - transform.position.y), 0f); //Finds the relative diffrence between 
		transform.rotation = Quaternion.LookRotation(new Vector3(dis3.x,dis3.y,0f));
		if (transform.eulerAngles.y == 270)
			transform.rotation = Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,90f);
		else
		{
			transform.rotation = Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,270f);
		}
	}

	void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(horizontal, vertical);
		rbPlayer.AddForce(movement * force);
	}
}
