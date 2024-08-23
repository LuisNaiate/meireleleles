using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botao4 : MonoBehaviour
{
    public GameObject plataformas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            plataformas.SetActive(true);
        }
    }
}
