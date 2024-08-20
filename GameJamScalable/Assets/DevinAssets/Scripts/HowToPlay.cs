using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class HowToPlay : MonoBehaviour
{
	public VisualElement _mainMenu;
	public VisualElement _controlMenu;

	private void Awake()
	{
		
		VisualElement rootMainMenu = GameObject.Find("MainMenu").GetComponent<UIDocument>().rootVisualElement;
		VisualElement rootControlMenu = GameObject.Find("HowToPlay").GetComponent<UIDocument>().rootVisualElement;

		_mainMenu = rootMainMenu.Q<VisualElement>("MainMenu");
		_controlMenu = rootControlMenu.Q<VisualElement>("HowToPlay");

		rootControlMenu.Q<Button>("ContinueButton").clicked += () => NewGame();
		rootControlMenu.Q<Button>("BackButton").clicked += () => MainMenu();
	}

	private void NewGame()
	{
		SceneManager.LoadSceneAsync("First_Level");
	}

	private void MainMenu()
	{
		_mainMenu.style.display = DisplayStyle.Flex;
		_controlMenu.style.display = DisplayStyle.None;
	}
}
