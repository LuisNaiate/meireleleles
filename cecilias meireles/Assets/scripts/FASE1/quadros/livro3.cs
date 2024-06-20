using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livro3 : MonoBehaviour
{
    public static bool pegou3 = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            pegou3 = true;
        }
    }
}
