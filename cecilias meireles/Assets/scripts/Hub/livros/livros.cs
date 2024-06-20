using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livros : MonoBehaviour
{
    public GameObject livro1;
    public GameObject quadro2;
    public GameObject quadro3;


    private void Update()
    {
        if (quadro1.pegou1 == true)
        {
            livro1.SetActive(true);
        }
        if (livro2.pegou2 == true)
        { 
            quadro2.SetActive(true);
        }
        if (livro3.pegou3 == true)
        {
            quadro3.SetActive(true);
        }
    }
}
