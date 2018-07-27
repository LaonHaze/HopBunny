using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject thePlayer;
    public GameObject lvlGen;
    public GameObject startPlatform;
    public ObjectPooler objPool;
    public GameObject pausePanel;
    public GameObject highScore;
    public GameObject highScoreLabel;
    public GameObject startPanel;

    private Vector3 startPointPlayer;
    private Vector3 startPointGen;
    private Vector3 startPointCam;

	// Use this for initialization
	void Start () {
        startPointPlayer = thePlayer.transform.position;
        startPointGen = lvlGen.transform.position;
        startPointCam = Camera.main.transform.position;
        Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if(thePlayer.transform.position.y < (lvlGen.transform.position.y - 35f))
        {
            Restart();
        }
	}

    public void Restart()
    {
        Collider2D cd = thePlayer.GetComponent<Collider2D>();
        Animator anim = thePlayer.GetComponentInChildren<Animator>();

        anim.SetBool("dead", false);
        cd.enabled = true;
        thePlayer.SetActive(false);
        objPool.SetAllInactive();
        lvlGen.SetActive(false);

        Camera.main.transform.position = startPointCam;
        thePlayer.transform.position = startPointPlayer;
        lvlGen.transform.position = startPointGen;
        ScoreManager.saveHighScore();
        ScoreManager.resetScore();

        startPlatform.SetActive(true);
        thePlayer.SetActive(true);
        lvlGen.SetActive(true);
        PauseGame();
    }
    
    public void StartGame()
    {
        startPanel.SetActive(false);
        highScore.SetActive(false);
        highScoreLabel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        highScore.SetActive(true);
        highScoreLabel.SetActive(true);
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        highScore.SetActive(false);
        highScoreLabel.SetActive(false);
        Time.timeScale = 1f;
    }
}
