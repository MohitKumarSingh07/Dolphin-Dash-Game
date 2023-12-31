using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public string levelName;
    public bool reset = false;
    public int startLives = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //coinText.text = PlayerPrefManager.GetScore().ToString();
        Time.timeScale = 1f;

    }
    public void loadLevel(string levelToLoad)
    {
        PlayerPrefManager.ResetPlayerState(startLives, false);

        SceneManager.LoadScene(levelToLoad);
    }

    public void LoadButton()
    {
        loadLevel(levelName);
    }
    public void MainMenu()
    {
        loadLevel(levelName);
    }
    public void ResetButton()
    {
        PlayerPrefManager.ResetPlayerState(startLives, true);
    }

    public void QuitGame()
    {
        //EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
