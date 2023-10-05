using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public static GameManager manager;

	public string levelAfterVictory;
	public string levelAfterGameOver;

	public int score = 0;
	public int highscore = 0;
	public int powerUp = 0;
	public int startLives = 3;
	public int lives = 3;

	public TMP_Text ScoreText;
	public TMP_Text HighScoreText;
	public TMP_Text powerUpsText;

	public GameObject[] UIExtraLives;
	public GameObject UIGamePaused;
	private GameObject player;

	private Vector3 spawnLocation;

	private void Awake()
	{
		if (manager == null)
		{
            manager = this.GetComponent<GameManager>();
		}

		setupDefaults();
	}

	private void Update()
	{

	}
   

	private void setupDefaults()
	{ 
		player = GameObject.FindGameObjectWithTag("Dolphin");

        spawnLocation = player.transform.position;
		
		refreshPlayerState();

		refreshGUI();
	}
	private void refreshPlayerState() 
	{
		lives = PlayerPrefManager.GetLives();

		if (lives <= 0) 
		{
			PlayerPrefManager.ResetPlayerState(startLives,false);

			lives = PlayerPrefManager.GetLives();
		}
		powerUp = PlayerPrefManager.GetPowerUps();
		score = PlayerPrefManager.GetScore();
		highscore = PlayerPrefManager.GetHighscore();

		PlayerPrefManager.UnlockLevel();
	}

	private void refreshGUI() 
	{
		ScoreText.text = score.ToString();
		HighScoreText.text = highscore.ToString ();

        for (int i = 0; i < UIExtraLives.Length; i++) 
		{
			if (i < (lives)) 
			{
				UIExtraLives[i].SetActive(true);
			} 
			else 
			{
				UIExtraLives[i].SetActive(false);
			}
		}
	}

	public void AddPoints(int amount)
	{
		score += amount;

		ScoreText.text = score.ToString();

		if (score > highscore)
		{
			highscore = score;
			HighScoreText.text = score.ToString();
		}
	}
    public void AddPowerUps(int amount)
    {
        powerUp += amount;

        powerUpsText.text = powerUp.ToString();
    }
    public void ResetGame() 
	{
		lives--;

		refreshGUI();

		if (lives <= 0) 
		{
			PlayerPrefManager.SavePlayerState(score,highscore,lives,powerUp);

			SceneManager.LoadScene(levelAfterGameOver);
		} 
		else 
		{
			//player.GetComponent<PlayerControler>().Respawn(_spawnLocation);
		}
	}

	public void LevelCompete() 
	{
		PlayerPrefManager.SavePlayerState(score,highscore,lives, powerUp);
		StartCoroutine(LoadNextLevel());
	}

	IEnumerator LoadNextLevel() 
	{
		yield return new WaitForSeconds(3.5f);
		SceneManager.LoadScene(levelAfterVictory);
	}

	public void GamePause()
	{
		Time.timeScale = 0;
		UIGamePaused.SetActive(true);
	}
    public void GameResume()
    {
        Time.timeScale = 1;
        UIGamePaused.SetActive(false);
    }
}
