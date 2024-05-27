using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carregarCenas : MonoBehaviour
{
    public string faseParaCarregar;
    public string fase1;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(faseParaCarregar);
        }
       

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("porta"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(fase1);
            }
        }
    }


}
