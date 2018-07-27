using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public ObjectPooler objectPool;
    public Transform genPoint;
    
    public float lvlWidth = 3.5f;
    public float minY = 1.5f;
    public float maxY = 2f;
    
	void Update () {
        if(transform.position.y < genPoint.position.y)
        {
            float rand = Random.Range(0f, 100f);

            if (rand > 85)
            {
                SpawnSpec();
            }
            else if (rand < 20)
            {
                SpawnEnemy();
            } else
            {
                SpawnItem();
            }
        }
        
	}

    private void SpawnSpec()
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.y += Random.Range(1.5f, 2f);
        spawnPosition.x = Random.Range(-lvlWidth, lvlWidth);

        GameObject specObject = objectPool.GetSpecObject();
        specObject.transform.position = spawnPosition;
        specObject.SetActive(true);

        transform.position = spawnPosition;
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.y += Random.Range(2f, 2.5f);
        spawnPosition.x = Random.Range(-lvlWidth, lvlWidth);

        GameObject enemy = objectPool.GetEnemy();
        enemy.transform.position = spawnPosition;
        enemy.SetActive(true);

        transform.position = spawnPosition;
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
