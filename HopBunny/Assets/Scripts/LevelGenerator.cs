using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public GameObject carrotPrefab;

    public int numCarrot;
    public float lvlWidth = 2.5f;
    public float minY = .5f;
    public float maxY = 1.5f;

	// Use this for initialization
	void Start () {
        Vector3 spawnPosition = new Vector3();
        for(int i = 0; i < numCarrot; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-lvlWidth, lvlWidth);
            Instantiate(carrotPrefab, spawnPosition, Quaternion.identity);
        }
		
	}
}
