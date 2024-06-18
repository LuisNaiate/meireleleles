using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public static int damage = 1;
    public  GameObject platTrigger;
    public  GameObject quadroDes;
    public  GameObject botao1;


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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("botão1"))
        {
            Destroy(botao1);
        }
        if (collision.gameObject.CompareTag("botão2"))
        {
            platTrigger.SetActive(true);
        }
        if (collision.gameObject.CompareTag("botão3"))
        {
            quadroDes.SetActive(false);
        }
    }
}
