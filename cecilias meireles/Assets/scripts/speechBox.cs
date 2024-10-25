using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class speechBox : MonoBehaviour
{
   

    [Header("GameObjects")]
    [SerializeField] GameObject player;
    [Space]

    [Header("Speed")]
    [SerializeField] float horizontal;
    [SerializeField] float vertical;
    [SerializeField] float speed;

    [Header("RigidBody")]
    [SerializeField] Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = new Vector2(6, 1);
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
        player = GameObject.FindWithTag("player");
    }
    IEnumerator Estourar()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
       StartCoroutine(Estourar());
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
   
}
