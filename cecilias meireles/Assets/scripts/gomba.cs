using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gomba : MonoBehaviour
{
   
    public int damage = 2;
    public Rigidbody2D body;
    public float speed = 2;
    int direction = -1;



    void Update()
    {
        body.velocity = new Vector2(speed * direction, body.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            
                Destroy(gameObject);
            
        }

        if(collision.gameObject.CompareTag("precipicio"))
        {
            direction *= -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("ground"))
        {
            direction *= -1;
        }
    }
}
