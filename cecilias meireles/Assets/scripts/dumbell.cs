using UnityEngine;

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
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
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
            Destroy(player);
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
}
