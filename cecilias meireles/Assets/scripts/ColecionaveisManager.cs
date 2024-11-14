
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class ColecionaveisManager : MonoBehaviour
{
    #region variaveis
    [SerializeField] GameObject menuPrincipal;
 
  
    [Space]
    [SerializeField] int qual; 
    

    [Header("arrays")]
    public GameObject[] colecionaveis;

    [Header("buttons")]
    public Button proximo;
    public Button anterior;
    public Button voltar;
    #endregion

    private void Start()
    {
        proximo.onClick.AddListener(Proximo);
        anterior.onClick.AddListener(Anterior);
        voltar.onClick.AddListener(Voltar);
    }
   
    public void Proximo()
    {
        qual++;
    }
    private void Update()
    {
        if (qual < 0)
        {
            qual = 0;
        }
        if (qual > 5)
        {
            qual = 5;
        }

        switch (qual)
        {
                case 0:
                colecionaveis[0].SetActive(true);
                colecionaveis[1].SetActive(false);
                break;


                case 1:
                colecionaveis[1].SetActive(true);
                colecionaveis[0].SetActive(false);
                colecionaveis[2].SetActive(false);
                break;

                case 2:
                colecionaveis[2].SetActive(true);
                colecionaveis[1].SetActive(false);
                colecionaveis[3].SetActive(false);
                break;

                case 3:
                colecionaveis[3].SetActive(true);
                colecionaveis[2].SetActive(false);
                colecionaveis[4].SetActive(false);
                break;

                case 4:
                colecionaveis[4].SetActive(true);
                colecionaveis[3].SetActive(false);
                colecionaveis[5].SetActive(false);
                break;

                case 5:
                colecionaveis[5].SetActive(true);
                colecionaveis[4].SetActive(false);
                break;
        }
    }
    public void Anterior()
    {
        qual--;
    }
    public void Voltar()
    {
        menuPrincipal.SetActive(true);
        gameObject.SetActive(false);
    }
}
