using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody2D rb;
    SpriteRenderer rend;
    private float movement;
    public float speed;


	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rend = gameObject.GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        movement = Input.GetAxis("Horizontal");
        if(movement > 0)
        {
            rend.flipX = false;
        } else if(movement < 0)
        {
            rend.flipX = true;
        }
	}

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement*speed;

        rb.velocity = velocity;
    }
}
