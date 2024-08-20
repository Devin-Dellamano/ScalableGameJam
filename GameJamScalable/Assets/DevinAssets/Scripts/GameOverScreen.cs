using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverScreen : MonoBehaviour
{
	public VisualElement menu;

	private void Awake()
	{
		UnityEngine.Cursor.lockState = CursorLockMode.None;
		UnityEngine.Cursor.visible = true;
		VisualElement root = GameObject.Find("GameOverScreen").GetComponent<UIDocument>().rootVisualElement;

		menu = root.Q<VisualElement>("GameOverPanel");

		menu.Q<Button>("MainMenuButton").clicked += () => MainMenu();
		menu.Q<Button>("ExitGameButton").clicked += () => ExitGame();
	}

	private void MainMenu()
	{
		SceneManager.LoadSceneAsync("MainMenu");
	}

	private void ExitGame()
	{
		Application.Quit();
	}
}
