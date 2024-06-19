using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botão : MonoBehaviour
{
    //botão1

    

    //vai destruir o botão 1 que ta barrando a passagem

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }
}




