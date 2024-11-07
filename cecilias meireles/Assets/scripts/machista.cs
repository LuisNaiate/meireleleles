using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class machista : MonoBehaviour
{
    #region variaveis 
    [Header("status")]
    public int life = 50;
    [Header("Ataques")]
    [SerializeField] GameObject[] speechBox;
    [Space]
    [Space][SerializeField] GameObject dumbell;
    [Space][SerializeField] GameObject deathZone;
    public int[] attacks;
    [Space]

    [Header("Timer")]
    float timer = 0f;
    
    [Space]

    [Header("GameObjects")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject DangerArea;
    [Space]

    [Header("RigidBody")]
    Rigidbody2D rb;

    [Header("animação")]
    public  Animator animator;
    [SerializeField] Animator animatorDanger;

    public static bool Voltou;


    
    #endregion

    
    void Start()
    {
        #region atribuições de variaveis 
        timer = 3;
       rb = GetComponent<Rigidbody2D>();
       player = GameObject.FindWithTag("player");
        animator = GetComponent<Animator>();
        #endregion

        #region ataque e animação
        DangerArea.SetActive(false);

        if (Voltou == true)
        {
            
            animator.SetBool("Voltou", true);
        }
        else return;
        #endregion
    }
    

    void Update()
    {
        #region tempo para atacar
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            Attack();
            timer = 0;
        }
        #endregion

        #region quando voltar 
        if (animator.GetBool("Voltou") == true)
        {
            StartCoroutine(VoltouTempo());
        }
        #endregion
    }
    #region se for acertado pelo tiro
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            life -= bullet.damage;
            if(life <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
    #endregion

    #region se colidir com o player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            TransicaoDeMorte.morreuBoss = true;
            Destroy(collision.gameObject);
            StartCoroutine(TempoParaCarregarCena());
        }
    }
    #endregion
    #region qual ataque vai executar
    void Attack()
    {
        
       int qualAtaque = Random.Range(0, attacks.Length);

        switch(qualAtaque)
        {
            case 0:
                Instantiate(dumbell);
                print("PESO");

                break;
            case 1:
                Instantiate(speechBox[Random.Range(0, speechBox.Length)]);
                print("FALA");
                break;

            case 2:
               animator.SetBool("Começou", true);
                StartCoroutine(Ataque3());
                break;
        }

       
    }
    #endregion
    #region coroutinas
    IEnumerator TempoParaCarregarCena()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Boss");
    }
    IEnumerator VoltouTempo()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("Voltou", false);
    }
    IEnumerator Ataque3()
    {
        yield return new WaitForSeconds(2.5f);

        DangerArea.SetActive(true);
        animatorDanger.SetBool("Contar", true);
        StartCoroutine(Contar());
       
    }
    IEnumerator Contar()
    {
        yield return new WaitForSeconds(3);
        DangerArea.SetActive(false);
        Instantiate(deathZone);
        gameObject.SetActive(false);
    }
    #endregion
}
