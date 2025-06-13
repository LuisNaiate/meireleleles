
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBossFight : MonoBehaviour
{

    #region variaveis
    public LayerMask filtro;

    [Header("player")]
    public Transform foot;
     Rigidbody2D body_;
    public ParticleSystem dust;

    [Header("movimenta��o")]
    bool olhandoDireita_;
    int direction_ = 1;
    [Space]
    [Range(0f, 10f)]
    [SerializeField]  float speed_ = 5;
    [Space]
    [SerializeField] float jumpstrengh_ = 5;
    [Space]
    [SerializeField] float bulletSpeed_ = 15;
    float horizontal_;

    [Header("pulo e pulo duplo")]
    [SerializeField]  bool groundCheck_;
     Collider2D footCollision;
    [Space]
     int maxJump_ = 2;
    [SerializeField]  private int jumpsLeft;
    //[SerializeField] private bool podePular = true;

    [Header("tiro")]
    public GameObject bullet;
     bool podeAtirar = true;
     float cooldownTiro = 0.5f;
    [SerializeField] Transform LivroSegurando;

    [Header("tempo")]
    [SerializeField] private float time_;

    [Header("anima��o")]
     Animator animator_;

   
    [Header("audio")]
     AudioSource audioSourceTiro_;

    public bool doublejum = true;
    public bool comLivro = true;

    [SerializeField] Transform parentePlayer;
    #endregion
    //Anota��es:

    #region Atribui��es de variaveis--------
    private void Awake()
    {
        olhandoDireita_ = true;

        audioSourceTiro_ = GetComponent<AudioSource>();
        animator_ = GetComponent<Animator>();
        body_ = GetComponent<Rigidbody2D>();
        jumpsLeft = maxJump_;

       


    }
    #endregion


  

    #region tempo-------
    public void T1me()
    {
        time_ += Time.deltaTime;
    }
    #endregion
    void Update()
    {




        #region movimenta��o e sprites ----------
        // movimenta��o
        horizontal_ = Input.GetAxis("Horizontal");
        body_.linearVelocity = new Vector2(horizontal_ * speed_, body_.linearVelocity.y);

        //anima��o de andar
        animator_.SetBool("andando", horizontal_ != 0);

        Flip();

        //dire��o
        if (horizontal_ < 0)
        {
            direction_ = -1;
        }
        else if (horizontal_ > 0)
        {
            direction_ = 1;
        }
        #endregion



        #region sistemaDePulo------------

        //pulo

        footCollision = Physics2D.OverlapCircle(foot.position, 0.05f, filtro);
        groundCheck_ = footCollision;

        if (Input.GetButtonDown("Jump"))
        {

            if (doublejum && groundCheck_)
            {
                body_.AddForce(new Vector2(0, jumpstrengh_ * 75));
                CreateDust();
                jumpsLeft--;
            }
            else if (doublejum && jumpsLeft > 0)
            {
                body_.AddForce(new Vector2(0, jumpstrengh_ * 50));
                CreateDust();
                jumpsLeft--;

            }

        }

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





        if (body_.linearVelocity.y < 0 && groundCheck_ == true)
        {
            jumpsLeft = maxJump_;
        }
        #endregion

        #region atirar----------
        //atirar
        if (Input.GetButtonDown("Fire1") && comLivro == true && podeAtirar)
        {
            GameObject temp = Instantiate(bullet, LivroSegurando.position, gameObject.transform.rotation);
            temp.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(bulletSpeed_ * direction_, 0);
            podeAtirar = false;
            if (direction_ < 0)
            {
                temp.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                temp.GetComponent<SpriteRenderer>().flipX = false;
            }
            StartCoroutine(CooldownTiro());
            audioSourceTiro_.Play();
        }
    }

    IEnumerator CooldownTiro()
    {
        yield return new WaitForSeconds(cooldownTiro);
        podeAtirar = true;
    }
    #endregion
    //caiuvoltar
    private void OnTriggerEnter2D(Collider2D collision)
    {
   

    }



    // morrer pros inimigos
    private void OnCollisionEnter2D(Collision2D collision)
    {

        #region morrer pra inimigo ------
        if (collision.gameObject.CompareTag("enemy"))
        {
            SceneManager.LoadScene("fase1");
        }
        #endregion
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
            gameObject.transform.parent = parentePlayer;
        }
    }

    #region flipar o sprite ------
    void Flip()
    {
        if (horizontal_ > 0 && !olhandoDireita_ || horizontal_ < 0 && olhandoDireita_)
        {
            olhandoDireita_ = !olhandoDireita_;
            Vector2 localscale = transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;
        }
    }  // virar o sprite
    #endregion
    #region particulas----
    void CreateDust()
    {
        dust.Play();
    } // cirar fuma�a quando pula
    #endregion

}





