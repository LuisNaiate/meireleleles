using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
