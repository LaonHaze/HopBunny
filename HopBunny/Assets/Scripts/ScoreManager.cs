using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    static int score;
    public Text scoreText;
    public Text highScoreText;
    public GooglePlayServices playServices;

    private static int highScore;
    private static bool doubleUp;
	// Use this for initialization
	void Start () {
        score = 0;
        doubleUp = false;
        loadHighScore();
	}
	
	public static void setScore(int thisScore)
    {
        if(doubleUp)
        {
            score += (thisScore*2);
        } else
        {
            score += thisScore;
        }
        
    }
    public static bool GetDouble()
    {
        return doubleUp;
    }

    public static void SetDouble()
    {
        doubleUp = true;
    }

    public static void NoDouble()
    {
        doubleUp = false;
    }

    public static void resetScore()
    {
        score = 0;
    }

    public static int getScore()
    {
        return score;
    }

    public void loadHighScore()
    {
        if (PlayerPrefs.HasKey("highestScore"))
        {
            highScore = PlayerPrefs.GetInt("highestScore");
        } else
        {
            highScore = 0;
        }
    }

    public void setHighScore()
    {
        if(score >= highScore)
        {
            highScore = score;
        }
    }

    public static void saveHighScore()
    {
        PlayerPrefs.SetInt("highestScore", highScore);
        GooglePlayServices.OnAddScoreToLeaderBoard(highScore);
    }

    void Update()
    {
        scoreText.text = score.ToString();
        setHighScore();
        highScoreText.text = highScore.ToString();
    }
}
