using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
	private VisualElement _mainMenu;

    public string _sceneName;

    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitGameButton;

	private void Awake()
    {
		VisualElement root = GetComponent<UIDocument>().rootVisualElement;

		_mainMenu = root.Q<VisualElement>("MainMenu");
        newGameButton = root.Q<Button>("NewGame");
		newGameButton.clicked += () => NewGame();

        loadGameButton = root.Q<Button>("LoadGame");
        loadGameButton.clicked += () => LoadGame();

        settingsButton = root.Q<Button>("Settings");
        settingsButton.clicked += () => SettingsMenu();

        exitGameButton = root.Q<Button>("ExitGame");
        exitGameButton.clicked += () => ExitGame();
    }

    private void NewGame()
    {
		//SaveLoadSystem.instance.NewGame();
        SceneManager.LoadSceneAsync("DevinsScene");
    }

    private void LoadGame()
    {
		//SaveLoadSystem.instance.LoadGame();
	}

    private void SettingsMenu()
    {

    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
