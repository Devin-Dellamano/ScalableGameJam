using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
	public VisualElement _mainMenu;
	public VisualElement _controlMenu;

    private void Awake()
    {
		UnityEngine.Cursor.lockState = CursorLockMode.None;
		UnityEngine.Cursor.visible = true;

		VisualElement rootMainMenu = GameObject.Find("MainMenu").GetComponent<UIDocument>().rootVisualElement;
		VisualElement rootControlMenu = GameObject.Find("HowToPlay").GetComponent<UIDocument>().rootVisualElement;

		_mainMenu = rootMainMenu.Q<VisualElement>("MainMenu");
		_controlMenu = rootControlMenu.Q<VisualElement>("HowToPlay");

		_mainMenu.Q<Button>("NewGame").clicked += () => NewGame();
		_mainMenu.Q<Button>("LoadGame").clicked += () => LoadGame();
		_mainMenu.Q<Button>("Settings").clicked += () => SettingsMenu();
		_mainMenu.Q<Button>("ExitGame").clicked += () => ExitGame();
    }

    private void NewGame()
    {
		_mainMenu.style.display = DisplayStyle.None;
		_controlMenu.style.display = DisplayStyle.Flex;
	}

    private void LoadGame()
    {
	}

    private void SettingsMenu()
    {

    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
