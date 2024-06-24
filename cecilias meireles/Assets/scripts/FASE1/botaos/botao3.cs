using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botao3 : MonoBehaviour
{
    //botão3

    public GameObject livro;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            livro.SetActive(false);
        }
    }
}