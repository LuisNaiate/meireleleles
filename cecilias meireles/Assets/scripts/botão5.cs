using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botão5 : MonoBehaviour
{
    public GameObject coisaPraDestruir;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);

        }
    }
}
