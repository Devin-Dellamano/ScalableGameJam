using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
	public string playerName = "Player";
	public int playerHealth = 100;
	public int playerLives = 3;
	public string checkpointName = "";
	public string level = "";
	public Vector3 playerPosition = Vector3.zero;

	public void Awake()
	{
		
	}
}
