using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livro2 : MonoBehaviour
{
    public static bool pegou2 = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            pegou2 = true;
        }
    }
}
