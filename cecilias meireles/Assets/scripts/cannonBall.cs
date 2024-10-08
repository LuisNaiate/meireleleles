
using UnityEngine;

public class cannonBall : MonoBehaviour
{

    private void OnBecameInvisible()
    {

        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("plataform"))
        {
            Destroy(gameObject);
        }
    }
}
