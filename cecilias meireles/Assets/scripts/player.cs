using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    #region variaveis
    public LayerMask filtro;

    [Header("player")]
    public Transform foot;
    private Rigidbody2D body_;
    public ParticleSystem dust;

    [Header("movimentação")]
    bool olhandoDireita_;
    int direction_ = 1;
    [SerializeField] private float speed_ = 5, jumpstrengh_ = 5, bulletSpeed_ = 15;
    float horizontal_;

    [Header("pulo e pulo duplo")]
    [SerializeField] private bool groundCheck_;
    private Collider2D footCollision;
    [Space]
    private int maxJump_ = 2;
    private int jumpsLeft;
    [SerializeField] private bool podePular = true;

    [Header("tiro")]
    public GameObject bullet;
    private bool podeAtirar = true;
    private float cooldownTiro = 0.5f;

    [Header("tempo")]
    [SerializeField] private float time_;

    [Header("animação")]
    private Animator animator_;

    [Header("checkPointSystem")]
    public string fasePraCarregar;
    public Transform checkPoint;

    [Header("powerUpsObjects")]

    public GameObject tiroPowerUp, puloDuploPowerUp;

    [Header("textos")]
    public TMP_Text coletaveisQtdTxt;
    public int qtdOfColetaveis;
    

    [Header("gameObjects")]
    [SerializeField] private GameObject paredeFinal_;

    [Header("bossFight")]
    [SerializeField]private GameObject final_;
    [SerializeField] private string faseFinal_;

    [Header("audio")]
    private AudioSource audioSourceTiro_;
    #endregion
    //Anotações: Colocar as animações do cañhão quando atirar, falta colocar os sprites no projeto

    #region Atribuições de variaveis--------
    private void Awake()
    {
        olhandoDireita_ = true;
       
        audioSourceTiro_ = GetComponent<AudioSource>();
        animator_ = GetComponent<Animator>();
        body_ = GetComponent<Rigidbody2D>();
        jumpsLeft = maxJump_;
        
        fasePraCarregar = SceneManager.GetActiveScene().name;
        CheckPoint.checkpoint = checkPoint;
        coletaveisQtdTxt.text = qtdOfColetaveis + "/6"; //qtdOfColetaveis.ToString() ;
    }
        #endregion


    #region CheckPointSystem ---------------------
    void Start()
    {

        if (fasePraCarregar == "fase1" && CheckPoint.chegouCheckpoint == true)
        {
           gameObject.transform.position = CheckPoint.checkpoint.position;
        }

        if (CheckPoint.comLivro == true)
        {
            tiroPowerUp.SetActive(false);
        }
        if (CheckPoint.doublejum == true)
        {
            puloDuploPowerUp.SetActive(false);
        }

        checkPoint = CheckPoint.checkpoint;
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




        #region movimentação e sprites ----------
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

        //direção
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

            if (!CheckPoint.doublejum && groundCheck_)
            {
                body_.AddForce(new Vector2(0, jumpstrengh_ * 120));
                CreateDust();

            }
            else if(CheckPoint.doublejum && jumpsLeft >0)
            {
                body_.AddForce(new Vector2(0, jumpstrengh_ * 100));
                CreateDust();
                jumpsLeft --;

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
        


        

        if (body_.velocity.y < 0 && groundCheck_ == true)
        {
            jumpsLeft = maxJump_;
        }
        #endregion

        #region atirar----------
        //atirar
        if (Input.GetButtonDown("Fire1") && CheckPoint.comLivro == true && podeAtirar) 
        {
            audioSourceTiro_.Play();
            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed_ * direction_, 0);
            podeAtirar = false;
            StartCoroutine(CooldownTiro());
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
        #region Final da dungeon------
        if (collision.gameObject == final_)
        {
            SceneManager.LoadScene(faseFinal_);
        }
        if(collision.gameObject.CompareTag("cole"))
        {
            qtdOfColetaveis++;
            coletaveisQtdTxt.text = qtdOfColetaveis + "/6"; //qtdOfColetaveis.ToString() ;
            
        }
        if (qtdOfColetaveis >= 6 && collision.gameObject.CompareTag("finalArea"))
        {
            Destroy(paredeFinal_);
        }
        #endregion

        #region CheckPointSet---------
        if (collision.CompareTag("Checkpoint"))
        {
            CheckPoint.checkpoint.position = gameObject.transform.position;
            CheckPoint.chegouCheckpoint = true;
        }
        #endregion

        #region Get power ups

        if (collision.gameObject.CompareTag("Pulo"))
        {
            CheckPoint.doublejum = true;
            Destroy(collision.gameObject);
        }

      
        //pegar livro power up
        if(collision.gameObject.CompareTag("livroPowerUp"))
        {
            CheckPoint.comLivro = true;
            Destroy(collision.gameObject);
        }
        #endregion
        //morrer pro canhão
        #region morrer pra canão e cair ---
        if (collision.gameObject.CompareTag("cannonBall"))
        {
            SceneManager.LoadScene("fase1");
        }

        //caiu no void
        if (collision.gameObject.CompareTag("queda"))
        {
            SceneManager.LoadScene("fase1");
        }
        #endregion

        

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
        #region ficar nas plataformas---- 
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
    #endregion

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
    } // cirar fumaça quando pula
    #endregion

}
#region static
public static class CheckPoint 
{
    public static Transform checkpoint;
    public static bool chegouCheckpoint;
    public static bool doublejum;
    public static bool comLivro = false;
}
#endregion
