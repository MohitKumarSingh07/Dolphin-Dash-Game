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

	public TMP_Text UIScore;
	public TMP_Text UIHighScore;
	public TMP_Text powerUps;
	//public TMP_Text UILevel;

	public GameObject[] UIExtraLives;
	public GameObject UIGamePaused;
	private GameObject _player;

	private Vector3 _spawnLocation;

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
		_player = GameObject.FindGameObjectWithTag("Dolphin");

        _spawnLocation = _player.transform.position;

		if (levelAfterVictory=="") 
		{
			Debug.LogWarning("levelAfterVictory not specified, defaulted to current level");
		    levelAfterVictory = SceneManager.GetActiveScene().name;
		}
		
		if (levelAfterGameOver=="") 
		{
			Debug.LogWarning("levelAfterGameOver not specified, defaulted to current level");
			levelAfterGameOver = SceneManager.GetActiveScene().name;
        }

		if (UIScore==null)
			Debug.LogError ("Need to set UIScore on Game Manager.");
		
		if (UIHighScore==null)
			Debug.LogError ("Need to set UIHighScore on Game Manager.");
		
		//if (UILevel==null)
		//	Debug.LogError ("Need to set UILevel on Game Manager.");
		
		if (UIGamePaused==null)
			Debug.LogError ("Need to set UIGamePaused on Game Manager.");
		
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

		score = PlayerPrefManager.GetScore();
		highscore = PlayerPrefManager.GetHighscore();

		PlayerPrefManager.UnlockLevel();
	}

	private void refreshGUI() 
	{
		UIScore.text = score.ToString();
		UIHighScore.text = highscore.ToString ();
		//UILevel.text = SceneManager.GetActiveScene().name;

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
		score = score + amount;

		UIScore.text = score.ToString();

		if (score > highscore)
		{
			highscore = score;
			UIHighScore.text = score.ToString();
		}
	}
	public void ResetGame() 
	{
		lives--;

		refreshGUI();

		if (lives <= 0) 
		{
			PlayerPrefManager.SavePlayerState(score,highscore,lives);

			SceneManager.LoadScene(levelAfterGameOver);
		} 
		else 
		{
			//player.GetComponent<PlayerControler>().Respawn(_spawnLocation);
		}
	}

	public void LevelCompete() 
	{
		PlayerPrefManager.SavePlayerState(score,highscore,lives);
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
