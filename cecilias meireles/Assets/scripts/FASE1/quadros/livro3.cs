using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class livro3 : MonoBehaviour
{
    public static bool pegou3 = false;
    public GameObject a3;
    public Animator animator;

    void Animar()
    {
        animator.SetBool("pegou", true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            pegou3 = true;
            a3.SetActive(true);
            Time.timeScale = 0.0f;
            Destroy(gameObject, 2);
            Animar();

        }
    }
    
    public void TimeRun()
    {
        Time.timeScale = 1.0f;
        a3.SetActive(false);
    }
}
