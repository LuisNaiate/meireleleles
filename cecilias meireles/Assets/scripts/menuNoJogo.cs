
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Audio;


public class menuNoJogo : MonoBehaviour
{
    #region variaveis e eventos
    [Header("Events")]
    public UnityEvent Pause, UnPause, opcoes, sairOpcoes;

    [Header("audioMixer")]
    [Tooltip("aqui controla o audioMixer")]
    public AudioMixer audiomixer;
    #endregion

        #region Pausar o jogo
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
    #endregion

    #region controle de tempo
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
    #endregion

    #region opções
    public void Opcoes()
    {
        opcoes.Invoke();

    }
    public void SairOpcoes()
    {
        sairOpcoes.Invoke();



    }
    #endregion
    #region sair
    public void Sair()
    {
        SceneManager.LoadScene("Menu");
    
        Time.timeScale = 1;


    }
    #endregion

    #region controle de volume
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
    #endregion
}
