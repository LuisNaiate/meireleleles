
using UnityEngine;

public class cannonBall : MonoBehaviour
{
    #region se destruir 
    private void OnBecameInvisible()
    {

        Destroy(gameObject, 1);
    }
    #endregion

    #region quando colidir
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("plataform"))
        {
            Destroy(gameObject);
        }
    }
    #endregion  
}
