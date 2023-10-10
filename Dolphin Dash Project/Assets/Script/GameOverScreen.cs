using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;

    private void Awake()
    {
        if(GameOverPanel.activeSelf)
            GameOverPanel.SetActive(false);
    }


    private void Update()
    {
        if (ObjectiveMeter.ObjectiveComplete)
        {
            GameOver();
        }

        if(DolphinHealth.instance.currHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReplayLevel()
    {
        string CurrentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(CurrentScene);
    }

    public void ToMainMenu()
    {
        GameManager.manager.Mainmenu();
    }
}
