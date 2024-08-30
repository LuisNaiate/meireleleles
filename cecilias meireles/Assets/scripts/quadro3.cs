using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadro3 : MonoBehaviour
{
    public GameObject b3;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            
            b3.SetActive(true);
            TimeStop();
            Destroy(gameObject, 1.5f);
        }
    }

    public void TimeStop()
    {
        Time.timeScale = 0.0f;

    }
    public void TimeRun()
    {
        Time.timeScale = 1.0f;
        b3.SetActive(false);
    }
}
