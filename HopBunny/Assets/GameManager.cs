using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject thePlayer;
    public GameObject lvlGen;
    public GameObject startPlatform;
    public ObjectPooler objPool;

    private Vector3 startPointPlayer;
    private Vector3 startPointGen;

	// Use this for initialization
	void Start () {
        startPointPlayer = thePlayer.transform.position;
        startPointGen = lvlGen.transform.position;
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
        StartCoroutine("RestartGame");
    }

    public IEnumerator RestartGame()
    {
        thePlayer.SetActive(false);
        objPool.SetAllInactive();
        lvlGen.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        thePlayer.transform.position = startPointPlayer;
        lvlGen.transform.position = startPointGen;
        ScoreManager.resetScore();
        startPlatform.SetActive(true);
        thePlayer.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        lvlGen.SetActive(true);
    }
}
