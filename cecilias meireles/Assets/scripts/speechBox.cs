using UnityEngine;
using UnityEngine.UIElements;

public class speechBox : MonoBehaviour
{
    [Header("Timer")]
    float timer;
    [Space]

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
        timer = 0;
        transform.position = new Vector2(6, 1);
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
        player = GameObject.FindWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 3)
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
