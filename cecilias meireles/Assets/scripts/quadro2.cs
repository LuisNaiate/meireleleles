using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadro2 : MonoBehaviour
{
    public GameObject b2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {

            b2.SetActive(true);
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
        b2.SetActive(false);
    }
}
