using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadro3 : MonoBehaviour
{
    public GameObject b3;
    public Animator animator;
    
    void Animar()
    {
        animator.SetBool("pegou", true);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            
            b3.SetActive(true);
            //Time.timeScale = 0.0f;
           
            animator.SetBool("pegou6", true);
        }
    }

    
    public void TimeRun()
    {
       // Time.timeScale = 1.0f;
        b3.SetActive(false);
        Destroy(gameObject);
    }
}
