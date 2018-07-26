using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public GameObject carrotPrefab;
    public ObjectPooler objectPool;
    public Transform genPoint;
    
    public float lvlWidth = 2f;
    public float minY = 1.5f;
    public float maxY = 3f;
    
	void Update () {
        if(transform.position.y < genPoint.position.y)
        {
            SpawnItem();
        }
        
	}

    private void SpawnItem()
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.y += Random.Range(minY, maxY);
        spawnPosition.x = Random.Range(-lvlWidth, lvlWidth);
        
        GameObject newObject = objectPool.GetPooledObject();
        newObject.transform.position = spawnPosition;
        newObject.SetActive(true);

        transform.position = spawnPosition;
    }
    
}
