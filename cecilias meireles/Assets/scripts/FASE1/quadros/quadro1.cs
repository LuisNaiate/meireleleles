using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class quadro1 : MonoBehaviour
{
    //esse não é o quadro certo, é o livro 1, coloquei o nome errado kk
    #region variaveis
    public static bool pegou1 = false;
    public GameObject livro1;
    public Animator anim;
    #endregion

    #region Quando pegar o livro
    private void Start()
    {
        if(pegou1 == true)
        {
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Quit"))
        {
            TimeRun();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.CompareTag("player"))
        {
            livro1.SetActive(true);
            //Time.timeScale = 0.0f;
            
           anim.SetBool("pegou1", true);
           
        }
    }
   
    #endregion
    #region para sair do painel, o botão funciona aqui
    public void TimeRun()
    {
        //Time.timeScale = 1.0f;
        livro1.SetActive(false);
        Destroy(gameObject);
        pegou1 = true;
    }
    #endregion
}
