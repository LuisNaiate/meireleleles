using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public static int damage = 1;
    public GameObject platTrigger;
    public GameObject quadroDes;


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("botão1"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("botão2"))
        {
           platTrigger.SetActive(true);
        }
    }
}
