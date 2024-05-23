 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPrincipal : MonoBehaviour
{
    
    public GameObject painelMenuInicial;
    public GameObject painelOpcoes;
    public void jogar()
    {
        SceneManager.LoadScene("Luis_Scene");
        
    }

    public void Opcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void fecharOpcoes ()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void sairJogo()
    {
        Application.Quit();
    }
}
