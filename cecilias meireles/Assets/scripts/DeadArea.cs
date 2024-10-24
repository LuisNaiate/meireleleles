using UnityEngine;

public class DeadArea : MonoBehaviour
{
    [SerializeField] GameObject boss;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0.5f)
        {
            boss.SetActive(true);
            Destroy(gameObject);
            timer = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
