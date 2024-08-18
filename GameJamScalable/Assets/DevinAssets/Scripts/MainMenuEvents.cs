using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument _document;
    private Button _button;
    public string _sceneName;

    private void Awake()
    {
        _document = GetComponent<UIDocument>(); 
        _button = _document.rootVisualElement.Q("NewGame") as Button;
        _button.RegisterCallback<ClickEvent>(NewGameClick);
    }

    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(NewGameClick);
    }

    private void NewGameClick(ClickEvent evt)
    {
        SceneManager.LoadScene(_sceneName);
        Debug.Log("You pressed the New Game button");
    }
}
