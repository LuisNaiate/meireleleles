using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon1 : MonoBehaviour
{
    public float time;
    public GameObject cannonBall;
    private int bulletSpeed = -15;
    public static bool atirar;
    public int life = 2;
    public ParticleSystem dust1;

    public Transform dust;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 3)
        {
            GameObject temp = Instantiate(cannonBall, dust.position, dust.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
            time = 0;
            CreateDust();

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

    void CreateDust()
    {
        dust1.Play();
    }
}