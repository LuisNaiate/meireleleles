using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Final1 : MonoBehaviour
{

    public float time;

    public void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            SceneManager.LoadSceneAsync("Hub");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        time += Time.deltaTime;
        if (collision.gameObject.CompareTag("player"))
        {

            
            if (time >=1)
            {
                SceneManager.LoadScene("Hub");
                time = 0;

            }
        }
    }
}
