using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadro1 : MonoBehaviour
{
    //esse não é o quadro certo, é o livro 1, coloquei o nome errado kk lol @_@
    public static bool pegou1 = false;
    public GameObject a1;
    public Animator animationb;
    public GameObject aa1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("player"))
        {
            pegou1 = true;
            a1.SetActive(true);
            //Time.timeScale = 0.0f;
            
           animationb.SetBool("pegou1", true);
            
        }


    }

    private void Update()
    {
        
    }
    public void TimeRun()
    {
        //Time.timeScale = 1.0f;
        aa1.SetActive(false);
        a1.SetActive(false);
        Destroy(gameObject);
        
    }
    
}
