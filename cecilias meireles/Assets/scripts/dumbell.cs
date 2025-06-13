using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dumbell : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] float horizontal;
    [SerializeField] float speed;
    [Space]
    float timer;
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body.linearVelocity = new Vector2(horizontal * speed, body.linearVelocity.y);
        player = GameObject.FindWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
          
            TransicaoDeMorte.morreuBoss = true;
            Destroy(collision.gameObject);
            StartCoroutine(TempoParaCarregarCena());
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }


    IEnumerator TempoParaCarregarCena()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Boss");
    }
   
}
