
using UnityEngine;

public class botao2 : MonoBehaviour
{
    //botão 2
    #region variaveis
    [Header("variaveis")]
    public GameObject platFalse;
    public GameObject apertado, solto;
    #endregion


    #region atirou 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            platFalse.SetActive(true);
            apertado.SetActive(true);
            solto.SetActive(false);
        }
    }
    #endregion
    // pra a plataforma que n ta vir e pegar o livro
}
