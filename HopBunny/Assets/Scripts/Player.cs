using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody2D rb;
    SpriteRenderer rend;
    Vector3 screenMin;
    Vector3 screenMax;
    private float movement;
    public float speed;
    private float transpeed = 4f;
    private float ScreenWidth;
    Vector3 playerSize;


	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rend = gameObject.GetComponentInChildren<SpriteRenderer>();
        ScreenWidth = Screen.width;
        screenMin = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));
        screenMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        playerSize = rend.bounds.size;
    }
	
	// Update is called once per frame
	void Update () {
            
        if (Input.touchCount > 0)
        {
            Touch curinput = Input.GetTouch(0);
            if (curinput.position.x < ScreenWidth / 2)
            {
                movement = Mathf.Lerp(movement, -1f, Time.deltaTime * transpeed);
                rend.flipX = true;

            }
            else if (curinput.position.x > ScreenWidth / 2)
            {
                movement = Mathf.Lerp(movement, 1f, Time.deltaTime * transpeed);
                rend.flipX = false ;
            }
        } else
        {
            movement = Mathf.Lerp(movement, 0, Time.deltaTime * (transpeed + .5f));
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, screenMin.x + playerSize.x/2, screenMax.x - playerSize.x / 2), transform.position.y, transform.position.z);

    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement*speed;
        rb.velocity = velocity;
    }
}
