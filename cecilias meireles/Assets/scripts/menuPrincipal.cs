
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class menuPrincipal : MonoBehaviour
{
    #region variaveis
    [Header("variaveis")]
    public GameObject painelMenuInicial;
    [Space] public GameObject painelMenuOuticial;
    [Space] public GameObject painelOpcoes;
    [Space] public AudioMixer audiomixer;
    [Space] public GameObject foraDoCredito;
    [Space] public GameObject dentroDoCredito;
    #endregion

    [SerializeField]
    #region jogar 
    public void jogar()
    {
        SceneManager.LoadScene("Fase1");
    }
    #endregion

    #region opções
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
    #endregion

    #region creditos
    public void Creditos()
    {
        foraDoCredito.SetActive(false);
        dentroDoCredito.SetActive(true);
    }
    public void FecharCreditos()
    {
        foraDoCredito.SetActive(true);
        dentroDoCredito.SetActive(false);
    }
    #endregion

    #region sair
    public void sairJogo()
    {
        Application.Quit();
    }
    #endregion

    #region sistema de volume 
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
