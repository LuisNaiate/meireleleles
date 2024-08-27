using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadro1 : MonoBehaviour
{
    public static bool pegou1 = false;
    public GameObject a1;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("player"))
        {
            pegou1 = true;
            a1.SetActive(true);
            TimeStop();
            Destroy(gameObject,2);
        }
    }

    public void TimeStop()
    {
        Time.timeScale = 0.0f;

    }
    public void TimeRun()
    {
        Time.timeScale = 1.0f;
        a1.SetActive (false);
    }
}
