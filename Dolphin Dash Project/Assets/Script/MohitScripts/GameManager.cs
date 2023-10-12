using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public static GameManager manager;

	public string levelAfterVictory;
	public string levelAfterGameOver;

	public int coin = 0;

	public int score = 0;
	public int distance = 0;
	public int powerUp = 0;

	public int startLives = 3;
	public int lives = 3;

    public TMP_Text scoreText;
	public TMP_Text distanceText;
	public TMP_Text powerUpsText;

	public GameObject[] UIExtraLives;
	public GameObject UIGamePaused;
	private GameObject player;

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
		distance = (int)player.transform.position.x;
		distanceText.text = distance.ToString ();
    }
    private void setupDefaults()
	{ 
		player = GameObject.FindGameObjectWithTag("Dolphin");

		
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
		distance = PlayerPrefManager.GetHighscore();

		PlayerPrefManager.UnlockLevel();
	}

	private void refreshGUI() 
	{
		scoreText.text = score.ToString();

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
		coin += amount;

		scoreText.text = score.ToString();

		//if (score > highscore)
		//{
		//	highscore = score;
		//	HighScoreText.text = score.ToString();
		//}
	}
    public void AddPowerUps(int amount)
    {
        powerUp += amount;

        powerUpsText.text = powerUp.ToString();
    }

    public void UsePowerUps()
    {
        powerUp--;
        powerUpsText.text = powerUp.ToString();
    }


    public void ResetGame() 
	{
		lives--;

		refreshGUI();

		if (lives <= 0) 
		{
			PlayerPrefManager.SavePlayerState(score,distance,lives,powerUp);
			SceneManager.LoadScene(levelAfterGameOver);
		} 
		else 
		{
			//player.GetComponent<PlayerControler>().Respawn(_spawnLocation);
		}
	}

	public void LevelCompete() 
	{
		PlayerPrefManager.SavePlayerState(score, distance, lives, powerUp);
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
	public void Mainmenu()
	{
		SceneManager.LoadScene(levelAfterGameOver);
	}
}
