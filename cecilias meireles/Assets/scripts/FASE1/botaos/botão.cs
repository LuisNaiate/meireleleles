
using UnityEngine;

public class botão : MonoBehaviour
{
    //botão1
    public GameObject barragem;
    

    //vai destruir o botão 1 que ta barrando a passagem

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            Destroy(barragem);
            
        }
    }
}




