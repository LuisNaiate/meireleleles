using UnityEngine;

public class speechBox : MonoBehaviour
{
    public float timer;
    public GameObject player;
    public float horizontal;
    public float vertical;
    public float speed;
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
        body.velocity = new Vector2(vertical * speed, body.velocity.x);
        player = GameObject.FindWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 7)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Destroy(player);
        }
    }
}
