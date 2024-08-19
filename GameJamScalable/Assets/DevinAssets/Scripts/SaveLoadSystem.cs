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

	[Header("Debugging")]
	[SerializeField] private bool initializeDataIfNull = false;

	[Header("File Storage Config")]
	[SerializeField] private string fileName = "game-data.json";


	public GameData gameData;
	private List<IDataPersistence> dataPersistenceObjects;
	private FileDataHandler dataHandler;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("Found more than one SaveLoadSystems in the scene.");
			Destroy(this.gameObject);
			return;
		}
		instance = this;
		DontDestroyOnLoad(this.gameObject);

		this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
	}

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
		SceneManager.sceneUnloaded += OnSceneUnloaded;
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
		SceneManager.sceneUnloaded -= OnSceneUnloaded;
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		this.dataPersistenceObjects = FindAllDataPersistenceObjects();
		LoadGame();
	}

	public void OnSceneUnloaded(Scene scene)
	{
		SaveGame();
	}

	public void NewGame()
	{
		this.gameData = new GameData();
		gameData.level = "DevinsScene";
	}

	//save game
	public void SaveGame()
	{
		if (this.gameData == null)
		{
			Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
			return;
		}

		foreach (IDataPersistence dataPersistence in dataPersistenceObjects)
		{
			dataPersistence.SaveData(ref gameData);
		}
		dataHandler.Save(gameData);
	}

	public void SaveGame(Checkpoints caller)
	{
		if (this.gameData == null)
		{
			Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
			return;
		}

		gameData.checkpointName = caller.name;

		foreach (IDataPersistence dataPersistence in dataPersistenceObjects)
		{
			dataPersistence.SaveData(ref gameData);
		}
		dataHandler.Save(gameData);
	}

	public void LoadGame()
	{
		this.gameData = dataHandler.Load();

		if (this.gameData == null && initializeDataIfNull)
		{
			NewGame();
		}

		if (this.gameData == null)
		{
			Debug.Log("No data was found. A New Game needs to be started before data can be saved.");
			return;
		}

		foreach (IDataPersistence dataPersistence in dataPersistenceObjects)
		{
			dataPersistence.LoadData(gameData);
		}

		SceneManager.LoadSceneAsync(gameData.level);
	}

	private List<IDataPersistence> FindAllDataPersistenceObjects()
	{
		IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

		return new List<IDataPersistence>(dataPersistenceObjects);
	}

	public bool HasGameData()
	{
		return this.gameData != null;
	}
}
