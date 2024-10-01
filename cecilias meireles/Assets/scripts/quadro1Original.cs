using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadro1Original : MonoBehaviour
{
    public GameObject b1;
    public Animator animator;

    void Animar()
    {
        animator.SetBool("pegou", true);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {

            b1.SetActive(true);
            Time.timeScale = 0.0f;
            Destroy(gameObject, 0.5f);
            Animar();   
        }
    }

    
    public void TimeRun()
    {
        Time.timeScale = 1.0f;
        b1.SetActive(false);
    }
}
