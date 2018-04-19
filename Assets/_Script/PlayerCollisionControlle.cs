using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionControlle : MonoBehaviour
{
	private BoxCollider2D BC2d;
	private PlayerController PC;
	private GameOver GO;
	// Use this for initialization
	void Start()
	{
		BC2d = GetComponent<BoxCollider2D>();
		PC = GetComponent<PlayerController>();
		GO = GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<GameOver>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		//print("Collision");
		if (other.gameObject.tag == "Enemy")
		{
			if (PC.PlayerHealthPoints >= 1)
			{
				PC.PlayerHealthPoints -= 1;
				print("The Player has lost a life and has now: " + PC.PlayerHealthPoints + " HP left");
			}
			else
			{
				GO.PlayerDeath();
			}
		}
	}
}
