using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float velocity = 0, realVelocity = 10;
    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "LimiteIzquierdo")
        {
            sr.flipX = false;
            velocity = realVelocity;
        }
        else if (collision.tag == "LimiteDerecho")
        {
            sr.flipX = true;
            velocity = -realVelocity;
        }
        else if(collision.gameObject.tag == "Darkhole")
        {
            Destroy(this.gameObject);
        }

    }

}
