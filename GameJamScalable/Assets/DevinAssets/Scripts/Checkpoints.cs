using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour, IDataPersistence
{
	public bool isActive = false;

	public void SaveData(ref GameData data)
	{
		if (!data.checkpointName.Equals(this.gameObject.name))
		{
			GameObject.Find(data.checkpointName).GetComponent<Checkpoints>().isActive = false;
			this.isActive = true;
			data.checkpointName = this.gameObject.name;
		}
	}

	public void LoadData(GameData data)
	{
		if (data.checkpointName.Equals(this.gameObject.name))
		{
			isActive = true;
		}
		else
		{
			isActive = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
        {
			isActive = true;
			gameObject.GetComponentInChildren<Cloth>().enabled = true;
			gameObject.transform.Find("flagcl").gameObject.GetComponent<Renderer>().material.color = Color.white;
			SaveLoadSystem.instance.SaveGame(this);
		}    
	}
}
