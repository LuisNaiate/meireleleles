using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class livro3 : MonoBehaviour
{
    public static bool pegou3 = false;
    public GameObject a3;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            pegou3 = true;
            a3.SetActive(true);
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
        a3.SetActive(false);
    }
}
