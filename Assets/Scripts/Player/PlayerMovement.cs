﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.

	public float stunCooldown = 0f;

	void FixedUpdate () 
	{
		TryMove ();
	}

	private void TryMove ()
	{
		if (stunCooldown > 0)
			stunCooldown -= Time.deltaTime;
		else
			Move ();
	}

	private void Move ()
	{
		if (!Input.anyKey)
			return;

		// Cache the horizontal input.
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		// Set a maximum velocity, don't stop add force when you're over the max velocity!
		rigidbody2D.AddForce (new Vector2 (h * moveForce, v * moveForce));
		if (rigidbody2D.velocity.x > maxSpeed)
		{
			rigidbody2D.velocity = new Vector2 (maxSpeed, rigidbody2D.velocity.y);
		}
		else if (rigidbody2D.velocity.x < -maxSpeed)
		{
			rigidbody2D.velocity = new Vector2 (-maxSpeed, rigidbody2D.velocity.y);
		}
		if (rigidbody2D.velocity.y > maxSpeed)
		{
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, maxSpeed);
		}
		else if (rigidbody2D.velocity.y < -maxSpeed)
		{
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, -maxSpeed);
		}
	}
}
