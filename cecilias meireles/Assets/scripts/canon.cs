using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class canon : MonoBehaviour
{
    public float time;
    public GameObject cannonBall;
   private int bulletSpeed = -15;
    public static bool atirar;
    public int life = 2;
    public ParticleSystem dust1;
    public AudioSource audioSource;
    public Transform dust;


    // private SpriteRenderer SpriteRenderer;
     private Animator animator_;
    // Start is called before the first frame update
    void Start()
    {
        // SpriteRenderer = GetComponent<SpriteRenderer>();
        animator_ = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if ( time  >= 3) 
        {
            // if(SpriteRenderer  != null) 
            //  {
            GameObject temp = Instantiate(cannonBall, dust.position, dust.rotation);
                temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
                time = 0; 
                CreateDust();
                audioSource.Play(); 
             animator_.SetBool("atirou", true);
            // }
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
                //  SpriteRenderer = null;
                //  animator_.SetBool("morreu", true);
                Destroy(gameObject);

            
            }
        }
    }

    void CreateDust()
    {
        dust1.Play();
    }

}
