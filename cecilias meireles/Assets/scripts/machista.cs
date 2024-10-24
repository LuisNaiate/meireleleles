using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class machista : MonoBehaviour
{

    [Header("status")]
    public int life = 50;
    [Header("Ataques")]
    [SerializeField] GameObject[] speechBox;
    [SerializeField] GameObject dumbell;
    [SerializeField] GameObject deathZone;
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
    // Start is called before the first frame update
    void Start()
    {
       //transform.position = new Vector2(4.773764f, 4.313086f);
       timer = 3;
       rb = GetComponent<Rigidbody2D>();
       player = GameObject.FindWithTag("player");
        animator = GetComponent<Animator>();
        DangerArea.SetActive(false);
        if (Voltou == true)
        {
            animator.SetBool("Voltou", true);
        }
        else return;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            Attack();
            timer = 0;
        }

        
        if(animator.GetBool("Voltou") == true)
        {
            StartCoroutine(VoltouTempo());
        }
    }
    IEnumerator VoltouTempo()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("Voltou", false);
    }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            TransicaoDeMorte.morreuBoss = true;
            Destroy(collision.gameObject);
            StartCoroutine(TempoParaCarregarCena());
        }
    }

    IEnumerator TempoParaCarregarCena()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Boss");
    }
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

        /*
       if (ahido == 0)
        {
                Instantiate(dumbell);
                print("PESO");
        }
        if (ahido == 1)
        {
                Instantiate(speechBox[Random.Range(0, speechBox.Length)]);
                print("FALA");
        }
        if (ahido == 2)
        {
           Instantiate(deathZone);
            gameObject.SetActive(false);
        }
        */
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
}
