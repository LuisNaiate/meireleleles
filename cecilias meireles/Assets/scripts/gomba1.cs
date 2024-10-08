using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gomba1 : MonoBehaviour
{
    [Header("corpo")]
    private SpriteRenderer spriteRenderer_;
    private BoxCollider2D boxCollider_;
    private Rigidbody2D body_;

    [Header("status")]
    public int damage = 2;
    public float speed = 2;
    int direction = -1;
    public int life = 2;


    private void Start()
    {
        spriteRenderer_ = GetComponent<SpriteRenderer>();
        boxCollider_ = GetComponent<BoxCollider2D>();
        body_ = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
       body_.velocity = new Vector2(speed * direction, body_.velocity.y); 
    }

    void morte()
    {
        speed = 0;
        direction = 0;
        damage = 0;
        spriteRenderer_.color = Color.red;
        gameObject.transform.Rotate(0, 0, -90);
        body_.gravityScale = 0;
        boxCollider_.isTrigger = true;
        Destroy(gameObject, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("bullet"))
        {
          life -= bullet.damage;

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
