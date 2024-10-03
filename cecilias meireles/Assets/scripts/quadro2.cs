using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadro2 : MonoBehaviour
{
    public GameObject b2;
    public Animator animator;

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {

            b2.SetActive(true);
          //  Time.timeScale = 0.0f;
         
            animator.SetBool("pegou5", true);
        }
    }

   
    public void TimeRun()
    {
        //Time.timeScale = 1.0f;
        b2.SetActive(false);
        Destroy(gameObject);
    }
}
