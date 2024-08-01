using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;

using UnityEngine;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    public Rigidbody2D body;
    [SerializeField] private float speed = 5, jumpstrengh = 5, bulletSpeed = 15;
    float horizontal;
    [SerializeField]private  bool groundCheck;
    public Transform foot;
    public GameObject spawn;
    public string faseParaCarregar;
    public GameObject bullet;
    int direction = 1;
    public bool comLivro = false;
    bool olhandoDireita;
    public GameObject portal1;
    public GameObject portal2;
         Collider2D footCollision;
    public static bool fase1 = false;
    public bool noPortal = false;
    public bool hub;
    public float time;
    public bool podePular = true;
    public float doubleJump = 2;
    public LayerMask layerMask;
   
    


    void Start()
    { 
        olhandoDireita = true;
        
    }
    public void t1me()
    {
        time += Time.deltaTime;
    }

    void pulo()
    {
        body.AddForce(new Vector2(0, jumpstrengh * 100));
    }
    void Update()
    {
        

        // movimentação
        horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);


        Flip();
        //pulo

        // groundCheck = Physics2D.OverlapCircle(foot.position, 0.05f);
        footCollision = Physics2D.OverlapCircle(foot.position, 0.05f, layerMask);
        groundCheck = footCollision;

        if (footCollision != null)
        {
            if (footCollision.CompareTag("enemy"))
            {
                // Mathf.Pow(2, 5);
                //Mathf.PI;
                //Mathf.Infinity;
                body.AddForce(new Vector2(0, jumpstrengh * 120));
                Destroy(footCollision.gameObject);
            }
        }
        //direção
        if (horizontal < 0)
        {
            direction = -1;
        }
        else if (horizontal > 0)
        {
            direction = 1;
        }


        //pular
        if (Input.GetButtonDown("Jump") && groundCheck == true)
        {
           pulo();
            

        }

        //atirar
        if (Input.GetButtonDown("Fire1") && comLivro == true) 
        {
            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * direction, 0);
        }
    }
   
    //caiuvoltar
    private void OnTriggerEnter2D(Collider2D collision)
    {

      
        if (collision.gameObject.CompareTag("caiuvolta"))
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

        //pegar livro power up
        if(collision.gameObject.CompareTag("livroPowerUp"))
        {
            comLivro = true;
            Destroy(collision.gameObject);
        }

        //morrer pro canhão
        if (collision.gameObject.CompareTag("cannonBall"))
        {
            SceneManager.LoadScene(faseParaCarregar);
        }

        //caiu no void
        if (collision.gameObject.CompareTag("queda"))
        {
            SceneManager.LoadScene(faseParaCarregar);
        }

        if(collision.gameObject == portal1 && collision.gameObject == portal2)
        {
            podePular = false;
        }
       else
        {
            podePular = true;
        }
        

    }
   
    //entrar nas portas
    private  void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("hub"))
        {
            fase1 = false;
        }

        if (collider.gameObject.CompareTag("porta"))
        {
            t1me();

            if (time >= 0.5f)
            {
                SceneManager.LoadScene("fase1");
                fase1 = true;
                time = 0;
            }
        }
        //entrar nos portais da fase 1
        if (collider.gameObject.CompareTag("portal1"))
        {
            t1me();
            if (time >= 1)
            {
                transform.position = new Vector2(-415.5f, 4.5f);
                time = 0;
            }
        }
        
        if (collider.gameObject.CompareTag("portal2") )
        {
            t1me();
            if (time >= 1)
            {
                transform.position = new Vector2(-421.589996f, 4.53000021f);
                time = 0;
            }
        }

        // entrar no final 1
        if(collider.gameObject.CompareTag("FINAL1"))
        {
            body.velocity = new Vector2(0, 2);
        }
    }

    // morrer pros inimigos
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("enemy"))
        {
            SceneManager.LoadScene(faseParaCarregar);
        }
        if (collision.gameObject.tag == "plataform")
        {
            gameObject.transform.parent = collision.transform;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataform")
        {
            gameObject.transform.parent = null;
        }
    }
    // virar o sprite
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
        //arrumando portal
    }
}
