using System.Collections;

using UnityEngine;

public class canon : MonoBehaviour
{
    #region variaveis e componentes
    [Header("componetes")]
    [SerializeField] ParticleSystem dust1;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Transform dust;
    [Space]

    [Header("variaveis ")]
    float time;
    public GameObject cannonBall;
    int bulletSpeed = -15;
    public static bool atirar;
    int life = 2;
    [SerializeField] bool pegou = true;
    // private SpriteRenderer SpriteRenderer;
    private Animator animator_;
    // Start is called before the first frame update
    #endregion
    void Start()
    {
        // SpriteRenderer = GetComponent<SpriteRenderer>();
        animator_ = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        #region sistema de atirar
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

            pegou = true;
            StartCoroutine(Animacao());
            // }
        }
        #endregion

        #region sistema da animação quando atira
        if (pegou == true)
        {
            animator_.SetBool("atirou", true);
        }
        else if (pegou == false)
        {
            animator_.SetBool("atirou", false);
        }
    }


    IEnumerator Animacao()
    {
        yield return new WaitForSeconds(1);
        pegou = false;
    }
    #endregion

    #region sistema de morrer
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
    #endregion
    void CreateDust()
    {
        dust1.Play();
    }

}
