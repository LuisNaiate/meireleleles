using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class livro3 : MonoBehaviour
{
    public static bool pegou3 = false;
    public GameObject a3;
    public Animator animator;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            pegou3 = true;
            a3.SetActive(true);
           // Time.timeScale = 0.0f;
           
            animator.SetBool("pegou3", true);

        }
    }
    
    public void TimeRun()
    {
       // Time.timeScale = 1.0f;
        a3.SetActive(false);
        Destroy(gameObject);
    }
}
