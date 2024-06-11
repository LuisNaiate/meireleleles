using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed = 5, jumpstrengh = 5, bulletSpeed = 50;
    float horizontal;
    public bool groundCheck;
    public Transform foot;
    public GameObject spawn;
    public string faseParaCarregar;
    public GameObject bullet;
    int direction = 1;
    public bool comLivro = false;


    void Start()
    { 

    }
    void Update()
    {
        // movimentação
        horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);

        //pulo
        groundCheck = Physics2D.OverlapCircle(foot.position, 0.05f);

        if (horizontal < 0)
        {
            direction = -1;
        }
        else if (horizontal > 0)
        {
            direction = 1;
        }


        
        if (Input.GetButtonDown("Jump") && groundCheck == true)
        {
            body.AddForce(new Vector2(0, jumpstrengh * 100));
        }

        if (Input.GetButtonDown("Fire1") && comLivro == true) 
        {
            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * direction, 0);
        }
    }
   
    //caiuvoltar
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("caiuvolta"))
        {
            body.MovePosition(spawn.transform.position);
        }

        //sistema de respawn
        if (collision.gameObject.CompareTag("fase1"))
        {
            faseParaCarregar = "fase1";
        }
        if (collision.gameObject.CompareTag("fase2"))
        {
            faseParaCarregar = "fase2";
        }
        if (collision.gameObject.CompareTag("fase3"))
        {
            faseParaCarregar = "fase3";
        }
        if (collision.gameObject.CompareTag("fase4"))
        {
            faseParaCarregar = "fase4";
        }
        if (collision.gameObject.CompareTag("faseFinal"))
        {
            faseParaCarregar = "faseFinal";
        }

        if(collision.gameObject.CompareTag("livroPowerUp"))
        {
            comLivro = true;
            Destroy(collision.gameObject);
        }

    }

    //entrar nas portas
    private  void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("porta"))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                SceneManager.LoadScene(faseParaCarregar);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            SceneManager.LoadScene(faseParaCarregar);
        }

    }

   
}
