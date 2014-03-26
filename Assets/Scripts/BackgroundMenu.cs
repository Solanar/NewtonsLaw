﻿using UnityEngine;
using System.Collections;

public class BackgroundMenu : MonoBehaviour {

	public Vector3 start;
	public Vector3 end;
	public float speed = 10.0f;

	private Transform group1;
	private float journeyLength;
	private float startTime;

	// Use this for initialization
	void Start () {
		group1 = GameObject.Find("Group1").transform;
		
		startTime = Time.time;
		journeyLength = Vector3.Distance(start, end);
	}
	
	// Update is called once per frame
	void Update () {
	   	float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;

		group1.position = Vector3.Lerp(start, end, fracJourney);

	}
}