
using UnityEngine;

public class bullet : MonoBehaviour
{

    public static int damage = 1;

    private void OnBecameInvisible()
    {

        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject, 0.001f);
        }
    }
}
