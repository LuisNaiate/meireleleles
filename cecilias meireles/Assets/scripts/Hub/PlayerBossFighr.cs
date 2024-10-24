using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBossFight : MonoBehaviour
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
    [Space]
    [Range(0f, 10f)]
    [SerializeField] private float speed_ = 5;
    [Space]
    [SerializeField] float jumpstrengh_ = 5;
    [Space]
    [SerializeField] float bulletSpeed_ = 15;
    float horizontal_;

    [Header("pulo e pulo duplo")]
    [SerializeField] private bool groundCheck_;
    private Collider2D footCollision;
    [Space]
    private int maxJump_ = 2;
    private int jumpsLeft;
    //[SerializeField] private bool podePular = true;

    [Header("tiro")]
    public GameObject bullet;
    private bool podeAtirar = true;
    private float cooldownTiro = 0.5f;

    [Header("tempo")]
    [SerializeField] private float time_;

    [Header("animação")]
    private Animator animator_;

   
    [Header("audio")]
    private AudioSource audioSourceTiro_;

    public bool doublejum = true;
    public bool comLivro = true;


    #endregion
    //Anotações:

    #region Atribuições de variaveis--------
    private void Awake()
    {
        olhandoDireita_ = true;

        audioSourceTiro_ = GetComponent<AudioSource>();
        animator_ = GetComponent<Animator>();
        body_ = GetComponent<Rigidbody2D>();
        jumpsLeft = maxJump_;

       


    }
    #endregion


    #region CheckPointSystem ---------------------
    void Start()
    {

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
        animator_.SetBool("andando", horizontal_ != 0);

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

            if (doublejum && groundCheck_)
            {
                body_.AddForce(new Vector2(0, jumpstrengh_ * 75));
                CreateDust();

            }
            else if (doublejum && jumpsLeft > 0)
            {
                body_.AddForce(new Vector2(0, jumpstrengh_ * 60));
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





        if (body_.velocity.y < 0 && groundCheck_ == true)
        {
            jumpsLeft = maxJump_;
        }
        #endregion

        #region atirar----------
        //atirar
        if (Input.GetButtonDown("Fire1") && comLivro == true && podeAtirar)
        {
            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed_ * direction_, 0);
            podeAtirar = false;
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
    } // cirar fumaça quando pula
    #endregion

}

