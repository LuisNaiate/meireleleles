using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menuNoJogo : MonoBehaviour
{
    public GameObject painel;
    public GameObject painelOpcoes;



    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(true);
        }
    }
    public void Back()
    {
        gameObject.SetActive(false);
    }

    public void Options()
    {
        painel.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
