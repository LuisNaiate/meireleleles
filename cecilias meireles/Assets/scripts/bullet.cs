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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
}
