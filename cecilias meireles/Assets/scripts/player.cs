using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;

using UnityEngine;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    [Header("coisas da beta")]
    public GameObject fimDaBeta;
    public GameObject Texto;

    [Header("player")]
    public Transform foot;
     Rigidbody2D body_;
    public ParticleSystem dust;

    [Header("movimentação")]    
    bool olhandoDireita_;
    int direction_ = 1;
    [SerializeField] private float speed_ = 5, jumpstrengh_ = 5, bulletSpeed_ = 15;
    float horizontal_;

    [Header("pulo e pulo duplo")]
    [SerializeField]private  bool groundCheck_;
    Collider2D footCollision;
    private int maxJump_ = 2;
    private int jumpsLeft;
    public float doubleJump = 2;
    public bool doublejum;
    public bool podePular = true;


    [Header("tiro")]
    public GameObject bullet;
    public bool comLivro = false;

    [Header("tempo")]
    public float time;

    [Header("animação")]
    private Animator animator_;


    public string fasePraCarregar;
    


    private void Awake()
    {
        olhandoDireita_ = true;
        animator_ = GetComponent<Animator>();
        body_ = GetComponent<Rigidbody2D>();
        jumpsLeft = maxJump_;
        
        fasePraCarregar = SceneManager.GetActiveScene().name;
    }

    void Start()
    { 
        //if(SceneManager == fasePraCarregar && CheckPoint.chegouCheckpoint == true)
        //{
        //    gameObject.transform.position = CheckPoint.checkpoint.position;
       // }
    }

    public void t1me()
    {
        time += Time.deltaTime;
    }

    void pulo()
    {
    }

    void PuloDuplo()
    {
    }
    void Update()
    {
        

        // movimentação
        horizontal_ = Input.GetAxis("Horizontal");
        body_.velocity = new Vector2(horizontal_ * speed_, body_.velocity.y);
       
        //animação de andar
        if(horizontal_ != 0) 
        {
            animator_.SetBool("andando", true);
        }
        else
        {
            animator_.SetBool("andando", false);

        }

        Flip();


        //pulo

        
        footCollision = Physics2D.OverlapCircle(foot.position, 0.05f);
        groundCheck_ = footCollision;

        if (footCollision != null)
        {
            if (footCollision.CompareTag("enemy"))
            {
                // Mathf.Pow(2, 5);
                //Mathf.PI;
                //Mathf.Infinity;
               
              
                body_.AddForce(new Vector2(0, jumpstrengh_ * 120));
                Destroy(footCollision.gameObject);
            }
            
        }
        //direção
        if (horizontal_ < 0)
        {
            direction_ = -1;
        }
        else if (horizontal_ > 0)
        {
            direction_ = 1;
        }


        //pular
        if (Input.GetButtonDown("Jump"))
        {

            if (!doublejum && groundCheck_)
            {
                body_.AddForce(new Vector2(0, jumpstrengh_ * 100));
                CreateDust();

            }
            else if(doublejum && jumpsLeft >0)
            {
                body_.AddForce(new Vector2(0, jumpstrengh_ * 100));
                CreateDust();
                jumpsLeft -= 1;

            }
       
        }
        

        if (body_.velocity.y < 0 && groundCheck_ == true)
        {
            jumpsLeft = maxJump_;
        }

        //atirar
        if (Input.GetButtonDown("Fire1") && comLivro == true) 
        {
            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed_ * direction_, 0);
        }
    }
   
    //caiuvoltar
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            CheckPoint.checkpoint.position = gameObject.transform.position;
            CheckPoint.chegouCheckpoint = true;
        }
        if (collision.gameObject.CompareTag("Pulo"))
        {
            doublejum = true;
            Destroy(collision.gameObject);
        }

        /*if (collision.gameObject.CompareTag("caiuvolta"))
        {
            body_.MovePosition(spawn.transform.position);
        } talvez eu use para checkpont, criar uma variavel public gameObject spawn;
        */
        if(collision.gameObject == fimDaBeta)
        {
            Texto.SetActive(true);
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
            SceneManager.LoadScene("fase1");
        }

        //caiu no void
        if (collision.gameObject.CompareTag("queda"))
        {
            SceneManager.LoadScene("fase1");
        }

        

    }
   
    

    // morrer pros inimigos
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("enemy"))
        {
            SceneManager.LoadScene("fase1");
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
        if (horizontal_ > 0 && !olhandoDireita_ || horizontal_ < 0 && olhandoDireita_)
        {
            olhandoDireita_ = !olhandoDireita_;
            Vector2 localscale = transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;
        }
    }
    void CreateDust()
    {
       dust.Play();
    }


}

public static class CheckPoint 
{
    public static Transform checkpoint;
    public static bool chegouCheckpoint; 
}