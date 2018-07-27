using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {
    public GameObject pooledObject;
    public GameObject specItem;
    public GameObject enemy;

    public int pooledNum;
    public int specNum;
    public int enemyNum;

    public List<GameObject> pooledObjectList;
    public List<GameObject> specItemList;
    public List<GameObject> enemyList;

	// Use this for initialization
	void Start () {
        pooledObjectList = new List<GameObject>();

        for(int i = 0; i < pooledNum; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjectList.Add(obj);
        }

        for(int j = 0; j < specNum; j++)
        {
            GameObject obj = Instantiate(specItem);
            obj.SetActive(false);
            specItemList.Add(obj);
        }

        for (int k = 0; k < enemyNum; k++)
        {
            GameObject obj = Instantiate(enemy);
            obj.SetActive(false);
            enemyList.Add(obj);
        }
    }
	
	public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledNum; i++)
        {
            if(!pooledObjectList[i].activeInHierarchy)
            {
                return pooledObjectList[i];
            }
        }

        GameObject obj = Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjectList.Add(obj);
        pooledNum++;

        return pooledObjectList[pooledNum - 1];
    }

    public GameObject GetSpecObject()
    {
        for (int i = 0; i < specNum; i++)
        {
            if (!specItemList[i].activeInHierarchy)
            {
                return specItemList[i];
            }
        }

        return GetPooledObject();
    }

    public GameObject GetEnemy()
    {
        for (int i=0; i < enemyNum; i++)
        {
            if(!enemyList[i].activeInHierarchy)
            {
                return enemyList[i];
            }
        }

        return GetPooledObject();
    }

    public void SetAllInactive()
    {
        for (int i = 0; i < pooledNum; i++)
        {
            pooledObjectList[i].SetActive(false);
        }

        for(int i = 0; i < specNum; i++)
        {
            specItemList[i].SetActive(false);
        }
    }
}
