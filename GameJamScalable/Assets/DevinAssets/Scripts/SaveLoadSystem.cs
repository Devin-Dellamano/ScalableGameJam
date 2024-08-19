using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SaveLoadSystem : MonoBehaviour
{
	public static SaveLoadSystem instance { get; private set; }
	public bool UnparentOnAwake = true;

	[Header("File Storage Config")]
	[SerializeField] private string fileName = "game-data.json";


	public GameData gameData;

	private List<IDataPersistence> dataPersistenceObjects;
	private FileDataHandler dataHandler;

	public void Start()
	{
		this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
		this.dataPersistenceObjects = FindAllDataPersistenceObjects();
		LoadGame();
	}
	public void NewGame()
	{
		this.gameData = new GameData();
	}

	//save game
	public void SaveGame()
	{
		foreach (IDataPersistence dataPersistence in dataPersistenceObjects)
		{
			dataPersistence.SaveData(ref gameData);
		}
		dataHandler.Save(gameData);
	}

	public void SaveGame(Checkpoints caller)
	{
		foreach (IDataPersistence dataPersistence in dataPersistenceObjects)
		{
			dataPersistence.SaveData(ref gameData);
		}
		dataHandler.Save(gameData);
	}

	public void LoadGame()
	{
		this.gameData = dataHandler.Load();

		if (this.gameData == null)
		{
			Debug.Log("No data was found. Initializing data to defaults.");
			NewGame();
		}

		foreach (IDataPersistence dataPersistence in dataPersistenceObjects)
		{
			dataPersistence.LoadData(gameData);
		}
	}

	private void OnApplicationQuit()
	{
		SaveGame();
	}

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("Found more than one Data Persistence Manager in the scene.");
		}
		InitializeSingleton();
	}

	protected virtual void InitializeSingleton()
	{
		if (!Application.isPlaying)
		{
			return;
		}

		if (UnparentOnAwake)
		{
			transform.SetParent(null);
		}

		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(transform.gameObject);
			enabled = true;
		}
		else
		{
			if (this != instance)
			{
				Destroy(this.gameObject);
			}
		}
	}

	private List<IDataPersistence> FindAllDataPersistenceObjects()
	{
		IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

		return new List<IDataPersistence>(dataPersistenceObjects);
	}
}
