﻿using UnityEngine;
using System.Collections;

// Load the clicked Level
public class LoadLevel : MonoBehaviour 
{

	public void LevelSelected()
	{
		// Get the level number from the name
		string[] levelNumber = gameObject.name.Split(char.Parse(" "));

		Application.LoadLevel("Scene " + levelNumber[1]);

	}
}
