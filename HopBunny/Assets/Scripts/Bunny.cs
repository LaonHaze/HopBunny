using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour {
    Animator bunnyanim;
    public GameManager gameManager;

    void Start()
    {
        bunnyanim = gameObject.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            bunnyanim.SetTrigger("touchDown");
        }
        
        
        
    }
}
