using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadro1 : MonoBehaviour
{
    public static bool pegou1 = false;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("player"))
        {
            pegou1 = true;
            Destroy(gameObject);
        }
    }
}
