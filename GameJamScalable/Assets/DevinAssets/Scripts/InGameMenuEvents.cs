using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class InGameMenuEvents : MonoBehaviour
{
	private VisualElement _pauseMenu;
	private bool _isPaused = false;

	private void Awake()
	{
		VisualElement root = GetComponent<UIDocument>().rootVisualElement;

		_pauseMenu = root.Q<VisualElement>("InGameMenu");
		root.Q<Button>("ContinueButton").clicked += () => ResumeGame();
		root.Q<Button>("SaveGame").clicked += () => SaveGame();
		root.Q<Button>("LoadGame").clicked += () => LoadGame();
		root.Q<Button>("ExitToMainMenuButton").clicked += () => ExitToMainMenu();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (_isPaused)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
		}
	}

	private void PauseGame()
	{
        UnityEngine.Cursor.lockState = CursorLockMode.None;
		UnityEngine.Cursor.visible = true;

		_isPaused = true;
		_pauseMenu.style.display = DisplayStyle.Flex;
		Time.timeScale = 0;
	}

	private void ResumeGame()
	{
		UnityEngine.Cursor.lockState = CursorLockMode.Locked;
		UnityEngine.Cursor.visible = false;

		_isPaused = false;
		_pauseMenu.style.display = DisplayStyle.None;
		Time.timeScale = 1;
	}

	private void SaveGame()
	{
	}

	private void LoadGame()
	{
	}

	private void ExitToMainMenu()
	{
		_isPaused = false;
		Time.timeScale = 1;

		SceneManager.LoadSceneAsync("MainMenu");
	}
}
