using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    static int score;
    public Text scoreText;
	// Use this for initialization
	void Start () {
        score = 0;
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

    void Update()
    {
        scoreText.text = score.ToString();
    }
}
