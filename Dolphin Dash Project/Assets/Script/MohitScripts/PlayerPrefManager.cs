﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public static class PlayerPrefManager 
{
	public static int GetLives() 
	{
		if (PlayerPrefs.HasKey("Lives")) 
		{
			return PlayerPrefs.GetInt("Lives");
		} 
		else 
		{
			return 0;
		}
	}

	public static void SetLives(int lives) 
	{
		PlayerPrefs.SetInt("Lives",lives);
	}

	public static int GetScore() 
	{
		if (PlayerPrefs.HasKey("Score")) 
		{
			return PlayerPrefs.GetInt("Score");
		} 
		else 
		{
			return 0;
		}
	}

	public static void SetScore(int score) 
	{
		PlayerPrefs.SetInt("Score",score);
	}

	public static int GetHighscore() 
	{
		if (PlayerPrefs.HasKey("Highscore")) 
		{
			return PlayerPrefs.GetInt("Highscore");
		} 
		else 
		{
			return 0;
		}
	}

	public static void SetHighscore(int highscore) 
	{
		PlayerPrefs.SetInt("Highscore",highscore);
	}

    public static int GetPowerUps()
    {
        if (PlayerPrefs.HasKey("Power"))
        {
            return PlayerPrefs.GetInt("Power");
        }
        else
        {
            return 0;
        }
    }

    public static void SetPowerUps(int powerUps)
    {
        PlayerPrefs.SetInt("Power", powerUps);
    }


    public static void SavePlayerState(int score, int highScore, int lives, int powerUps) 
	{
		PlayerPrefs.SetInt("Score",score);
		PlayerPrefs.SetInt("Lives",lives);
		PlayerPrefs.SetInt("Highscore",highScore);
		PlayerPrefs.SetInt("Power",powerUps);
	}
	
	public static void ResetPlayerState(int startLives, bool resetHighscore) 
	{
		Debug.Log ("Player State reset.");
		PlayerPrefs.SetInt("Lives",startLives);
		PlayerPrefs.SetInt("Score", 0);

		if (resetHighscore)
			PlayerPrefs.SetInt("Highscore", 0);
	}

	// store a key for the name of the current level to indicate it is unlocked
	public static void UnlockLevel() 
	{	
		PlayerPrefs.SetInt(SceneManager.GetActiveScene().name,1);
	}

	// determine if a levelname is currently unlocked (i.e., it has a key set)
	public static bool LevelIsUnlocked(string levelName) 
	{
		return (PlayerPrefs.HasKey(levelName));
	}

	// output the defined Player Prefs to the console
	public static void ShowPlayerPrefs() 
	{
		string[] values = {"Score","Highscore","Lives","Power"};

		foreach(string value in values) 
		{
			if (PlayerPrefs.HasKey(value)) 
			{
				Debug.Log (value+" = "+PlayerPrefs.GetInt(value));
			} 
			else 
			{
				Debug.Log (value+" is not set.");
			}
		}
	}
}
