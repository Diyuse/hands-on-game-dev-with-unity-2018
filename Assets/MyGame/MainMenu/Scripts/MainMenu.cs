using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startGameButton;

    private void OnEnable()
    {
        startGameButton.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        startGameButton.onClick.RemoveAllListeners();
    }

    private void StartGame()
    {
        GoToLevel("BossSandbox");
    }

    public void GoToLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
