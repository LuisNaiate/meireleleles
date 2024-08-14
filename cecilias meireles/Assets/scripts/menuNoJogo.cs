using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Audio;


public class menuNoJogo : MonoBehaviour
{

    public UnityEvent Pause, UnPause, opcoes, sairOpcoes;
    public AudioMixer audiomixer;

    private void Update()
    {

        if (Input.GetButtonDown("Cancel"))
        {

            if (Time.timeScale == 1)
            {
                Pausar();

            }
            else
            {

                Despausar();

            }


        }



    }
    public void Pausar()
    {
        Pause.Invoke();
        Time.timeScale = 0;

    }
    public void Despausar()
    {
        UnPause.Invoke();
        Time.timeScale = 1;

    }
    public void Opcoes()
    {
        opcoes.Invoke();

    }
    public void SairOpcoes()
    {
        sairOpcoes.Invoke();



    }
    public void Sair()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;


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
