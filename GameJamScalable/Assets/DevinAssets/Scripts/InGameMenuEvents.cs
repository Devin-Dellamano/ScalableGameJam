using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class InGameMenuEvents : MonoBehaviour
{
	private UIDocument _document;
	private Button _button;

	private void Awake()
	{
		_document = GetComponent<UIDocument>();
		_button = _document.rootVisualElement.Q("ExitToMainMenuButton") as Button;
		_button.RegisterCallback<ClickEvent>(ExitToMainMenu);
	}

	private void OnDisable()
	{
		_button.UnregisterCallback<ClickEvent>(ExitToMainMenu);
	}

	private void ExitToMainMenu(ClickEvent evt)
	{
		SceneManager.LoadScene("MainMenu");
	}
}
