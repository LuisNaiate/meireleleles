
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

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
    [Space] public GameObject assets;
    public GameObject colecionaveis;
    public GameObject volume;
    public GameObject controler;
    public GameObject colecionaveisBtn;
    public static bool terminouJogo = false;
    #endregion


    private void Update()
    {
        if (terminouJogo)
        {
            colecionaveisBtn.SetActive(true);

        }
    }
   

    #region jogar 
    public void jogar()
    {
        SceneManager.LoadScene("Cutscene1");
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

    public void AbrirVolume()
    {
        volume.SetActive(true);
        painelOpcoes.SetActive(false) ;

    }
    public void AbrirControler()
    {
        controler.SetActive(true);
        painelOpcoes.SetActive(false);

    }
    public void FecharVolume()
    {
        volume.SetActive(false);
        painelOpcoes.SetActive(true);
    }
    public void FecharControle()
    {
        controler.SetActive(false);
        painelOpcoes.SetActive(true);
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
    #region Assets
    public void Assets()
    {
        dentroDoCredito.SetActive(false);
        assets.SetActive(true);
    }

    public void AssetsFora()
    {
        dentroDoCredito.SetActive(true);
        assets.SetActive(false);
    }
    public void Colecionaveis()
    {
        painelMenuInicial.SetActive(false);
        colecionaveis.SetActive(true);
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
