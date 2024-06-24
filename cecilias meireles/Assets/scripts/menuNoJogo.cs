using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menuNoJogo : MonoBehaviour
{
    public GameObject painel;
    public GameObject bot�o1;
    public GameObject bot�o2;
    public GameObject bot�o3;
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
        bot�o1.SetActive(false);
        bot�o2.SetActive(false);
        bot�o3.SetActive(false);

        voltar.SetActive(true);
        slider.SetActive(true);

    }
    public void OptionsBack()
    {
        bot�o1.SetActive(true);
        bot�o2.SetActive(true);
        bot�o3.SetActive(true);

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
