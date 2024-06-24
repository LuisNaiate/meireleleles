using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menuNoJogo : MonoBehaviour
{
    public GameObject painel;
    public GameObject botão1;
    public GameObject botão2;
    public GameObject botão3;
    public GameObject voltar;
    public GameObject slider;


   



    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            painel.SetActive(true);
        }

        
    }
    public void Back()
    {
        painel.SetActive(false);
    }

    public void Options()
    {
        botão1.SetActive(false);
        botão2.SetActive(false);
        botão3.SetActive(false);

        voltar.SetActive(true);
        slider.SetActive(true);

    }
    public void OptionsBack()
    {
        botão1.SetActive(true);
        botão2.SetActive(true);
        botão3.SetActive(true);

        voltar.SetActive(false);
        slider.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("menu");

        if (player.fase1 == true)
        {
            SceneManager.LoadScene("Hub");
        }
    }
}
