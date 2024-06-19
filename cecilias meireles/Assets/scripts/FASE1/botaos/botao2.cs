using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botao2 : MonoBehaviour
{
    //botão 2

    public GameObject platFalse;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            platFalse.SetActive(true);
        }
    }
    // pra a plataforma que n ta vir e pegar o livro
}
