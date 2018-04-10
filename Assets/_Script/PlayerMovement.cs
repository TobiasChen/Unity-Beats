using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D rbPlayer;
	public Vector3 ScreenPosition;
	
	private PlayerController PC;
	void Start ()
	{
		rbPlayer = GetComponent<Rigidbody2D>();
		PC = GetComponent<PlayerController>();

	}
	
	// Update is called once per ;
	void Update ()
	{
		//Rotation
		ScreenPosition = Camera.main.WorldToScreenPoint(transform.position);	//Gets current Mouse Position
		Vector3 direction = Input.mousePosition- ScreenPosition;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void FixedUpdate()
	{
		//Horizontal and vertical Movement
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(horizontal, vertical);
		rbPlayer.AddForce(movement * PC.MovmentSpeed);
	}
}
