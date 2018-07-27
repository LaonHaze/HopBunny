using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {

    public float jumpForce;
    public int score = 10;
    Rigidbody2D rb;
    Animator bunnyanim;

    void Update()
    {
        if(transform.position.y < (Camera.main.gameObject.transform.position.y - 10f))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb = collision.GetComponent<Rigidbody2D>();
        bunnyanim = collision.GetComponentInChildren<Animator>();
        float relativevel = rb.velocity.y;

        if (rb != null)
        {
            StartCoroutine(JumpAnim(relativevel));
        }
    }

    IEnumerator JumpAnim(float relativevel)
    {
        if (relativevel < 0f)
        {
            bunnyanim.SetTrigger("touchDown");
        }
        ScoreManager.setScore(score);
        yield return new WaitForSeconds(seconds: 0.1125f);
        Vector2 velocity = rb.velocity;
        velocity.y = jumpForce;
        rb.velocity = velocity;
        gameObject.SetActive(false);
    }
}
