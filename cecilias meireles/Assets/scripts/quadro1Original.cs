using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadro1Original : MonoBehaviour
{
    public GameObject b1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {

            b1.SetActive(true);
            TimeStop();
            Destroy(gameObject, 0.5f);
        }
    }

    public void TimeStop()
    {
        Time.timeScale = 0.0f;

    }
    public void TimeRun()
    {
        Time.timeScale = 1.0f;
        b1.SetActive(false);
    }
}
