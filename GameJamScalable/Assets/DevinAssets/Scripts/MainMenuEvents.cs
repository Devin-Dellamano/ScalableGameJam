using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
	private VisualElement _mainMenu;

    public string _sceneName;

    private void Awake()
    {
		VisualElement root = GetComponent<UIDocument>().rootVisualElement;

		_mainMenu = root.Q<VisualElement>("MainMenu");
		root.Q<Button>("NewGame").clicked += () => NewGame();
		root.Q<Button>("LoadGame").clicked += () => LoadGame();
		root.Q<Button>("Settings").clicked += () => SettingsMenu();
		root.Q<Button>("ExitGame").clicked += () => ExitGame();
    }

    private void NewGame()
    {
        SceneManager.LoadSceneAsync("JeffScene - Copy");
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
