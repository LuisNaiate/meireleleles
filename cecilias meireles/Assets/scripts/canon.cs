using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{
    public float time;
    public GameObject cannonBall;
   private int bulletSpeed = -15;
    public static bool atirar;
    public int life = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if ( time  >= 3) 
        {
            GameObject temp = Instantiate(cannonBall, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed , 0);
            time = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            life -= bullet.damage;

            if (life <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }

}
