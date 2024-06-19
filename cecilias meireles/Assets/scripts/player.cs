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
    bool olhandoDireita;
    public GameObject portal1;
    public GameObject portal2;



    void Start()
    { 
        olhandoDireita = true;
    }
    void Update()
    {
        // movimentação
        horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);


        Flip();
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

        if(collider.gameObject.CompareTag("portal1") && Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector2(-415.5f, 4.5f); 
        }
        
        if (collider.gameObject.CompareTag("portal2") && Input.GetKeyDown(KeyCode.W))
        {
         transform.position = new Vector2(-421.589996f, 4.53000021f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            SceneManager.LoadScene(faseParaCarregar);
        }

    }


    void Flip()
    {
        if (horizontal > 0 && !olhandoDireita || horizontal < 0 && olhandoDireita)
        {
            olhandoDireita = !olhandoDireita;
            Vector2 localscale = transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;
        }
    }

   


    public void anotações()
    {
        //arrumar os botoes 
    }
}
