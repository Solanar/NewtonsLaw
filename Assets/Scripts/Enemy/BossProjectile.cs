﻿using UnityEngine;
using System.Collections;


public class BossProjectile : MonoBehaviour 
{
	public GenericEnemy self;
	public Vector3 oldTarget { private get; set; }
	public GameObject parent;
	public float maxMagnitude;

	void Start ()
	{
		float p_velocity = parent.rigidbody2D.velocity.magnitude;
		self = new GenericEnemy (this.gameObject, 100, 50f, 2.0f);
		// 2 - Limited time to live to avoid any leak
		Destroy (gameObject, 6); // seconds 

		//Apply all force in beginning
		Vector3 dir = oldTarget - this.transform.position;
		Vector2 force = dir * (self.movementSpeed + p_velocity);
		force.Normalize ();
		force.Scale (new Vector2 (maxMagnitude, maxMagnitude));
		rigidbody2D.AddForce (force);
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			// hurt player
			self.decreasePlayerHealth(1);
			Destroy (gameObject);
		}
		else if (coll.gameObject.tag == "Enemy" && coll.gameObject != parent)
		{
			if (coll.gameObject.name.Contains ("Force Field"))
			{
				if (coll.gameObject.GetComponent<ForceFieldEnemy> ().shieldsDown)
				{ Destroy (gameObject); }
			}
			else
			{ 
				Destroy (gameObject); 
			}
		}
	}
}