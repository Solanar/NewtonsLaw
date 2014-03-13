﻿using UnityEngine;
using System.Collections;

public class BasicBehaviourEnemy : MonoBehaviour 
{
	public float speed = 5;
	public int health = 100;
	public float damage = 2.0f;
	public GenericEnemy self;
	public Transform target;

	public float deathSpinMin = -100f; // A value to give the minimum amount of Torque when dying
	public float deathSpinMax = 100f;	// A value to give the maximum amount of Torque when dying
	public GameObject scorePointsUI; // A prefab of 100 that appears when the enemy dies.

	private EnemyDeath death;
	private EnemyMovement move;
	private SpriteRenderer ren;	// Reference to the sprite renderer.
	private PlayerScore scoreBoard;	// Reference to the Score Script

	// Use this for initialization
	void Start () 
	{
		self = new GenericEnemy(this.gameObject, health, speed, damage);
		// Setting up the references.
		ren = transform.Find("body").GetComponent<SpriteRenderer>();

		if(!target)
			target = GameObject.FindWithTag("Player").transform;

		death = this.GetComponent<EnemyDeath> ();
		death.die = this;
		move = this.GetComponent<EnemyMovement> ();
		move.location = this.transform;
		move.self = this.self;
		scoreBoard = GameObject.Find("Score").GetComponent<PlayerScore>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (self.health <= 0)
			death.Death (ren, deathSpinMin, deathSpinMax);


		// random target
		//var i = Random.insideUnitCircle;
		move.TryMove (target); 
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
		{
			if (coll.gameObject.name.Contains("Enemy 2") || coll.gameObject.name.Contains("Enemy Mito"))
			{
				Death ();
				createScore ();
			}
		}
		else if (coll.gameObject.tag == "Player")
		{
			// hurt self instead of player
			//Death ();
		}
		else if (coll.gameObject.tag == "Bullet")
		{
			//Debug.Log ("Hi");
			Death ();
			createScore();
		}
		//Debug.Log ("basic" + coll.gameObject.name);
	}

	void createScore() 
	{
		// Increase the score by so and so points
		scoreBoard.score += self.score;

		// Instantiate the score points prefab at this point.
		GameObject scorePoints = (GameObject) Instantiate(scorePointsUI, Vector3.zero, Quaternion.identity);
		scorePoints.transform.parent = gameObject.transform;
		scorePoints.transform.localPosition = new Vector3(0, 1.5f, 0);
	}

	private void Death ()
	{
		death.Death (ren, deathSpinMin, deathSpinMax);
	}
}