using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    static int score;
    public Text scoreText;
    public Text highScoreText;
    private static int highScore;
	// Use this for initialization
	void Start () {
        score = 0;
        loadHighScore();
	}
	
	public static void setScore(int thisScore)
    {
        score += thisScore;
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
    }

    void Update()
    {
        scoreText.text = score.ToString();
        setHighScore();
        highScoreText.text = highScore.ToString();
    }
}
