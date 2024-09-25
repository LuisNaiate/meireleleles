using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gomba1 : MonoBehaviour
{
   
    public int damage = 2;
    public Rigidbody2D body;
    public float speed = 2;
    int direction = -1;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public int life = 2;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();


    }
    void Update()
    {
       
        body.velocity = new Vector2(speed * direction, body.velocity.y);
        
    }

    void morte()
    {
        speed = 0;
        direction = 0;
        damage = 0;
        spriteRenderer.color = Color.red;
        gameObject.transform.Rotate(0, 0, -90);
        body.gravityScale = 0;
        boxCollider.isTrigger = true;
        Destroy(gameObject, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        life -= bullet.damage;

        if (collision.gameObject.CompareTag("bullet"))
        {

            if (life <= 0)
            {
                morte();
                Destroy(collision.gameObject);
            }
          
            

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
