using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GooglePlayServices : MonoBehaviour {
    public static string leaderboard = "CgkI6KT_86MdEAIQAA";
    public GameObject startButton;
	// Use this for initialization
	void Awake () {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        LogIn();
    }
    
    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) => {
            if (success)
            {
                startButton.SetActive(true);
                Debug.Log("Login Success");
            }
            else
            {
                Debug.Log("Login Failed");
            }
        });
    }

    public void OnShowLeaderBoard()
    {
        //Social.ShowLeaderboardUI();
        PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboard);
    }
	
    public static void OnAddScoreToLeaderBoard(long score)
    {
        if(Social.localUser.authenticated)
        {
            Social.ReportScore(score, leaderboard, (bool success) => { });
        }
    }


}