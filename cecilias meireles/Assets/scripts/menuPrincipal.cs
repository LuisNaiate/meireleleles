 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class menuPrincipal : MonoBehaviour
{
    
    public GameObject painelMenuInicial;
    public GameObject painelOpcoes;
    public AudioMixer audiomixer;
    

   
    public void jogar()
    {
        SceneManager.LoadScene("Hub");
        
      
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
    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("Master", volume);
    }
    public void SetVolumeMusic(float volume)
    {
        audiomixer.SetFloat("Music", volume);
    }
    public void SetVolumeSFX(float volume)
    {
        audiomixer.SetFloat("SFX", volume);
    }
}
