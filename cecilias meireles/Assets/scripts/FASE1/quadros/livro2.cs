using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livro2 : MonoBehaviour
{
    public static bool pegou2 = false;
    public GameObject a2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            pegou2 = true;
         
            a2.SetActive(true);
            TimeStop();
            Destroy(gameObject, 2);
        }
    }
    public void TimeStop()
    {
        Time.timeScale = 0.0f;

    }
    public void TimeRun()
    {
        Time.timeScale = 1.0f;
        a2.SetActive(false);
    }
}
