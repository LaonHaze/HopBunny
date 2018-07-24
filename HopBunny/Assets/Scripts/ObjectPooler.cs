using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {
    public GameObject pooledObject;

    public int pooledNum;

    public List<GameObject> pooledObjectList;

	// Use this for initialization
	void Start () {
        pooledObjectList = new List<GameObject>();

        for(int i = 0; i < pooledNum; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjectList.Add(obj);
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

    public void SetAllInactive()
    {
        for (int i = 0; i < pooledNum; i++)
        {
            pooledObjectList[i].SetActive(false);
        }
    }
}
