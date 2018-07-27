using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update () {
        if (transform.position.y < (Camera.main.gameObject.transform.position.y - 10f))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("eatUp");
    }

}
