using UnityEngine;

public class quadro1 : MonoBehaviour
{
    //esse não é o quadro certo, é o livro 1, coloquei o nome errado kk
    #region variaveis
    public static bool pegou1 = false;
    public GameObject Livro1;
    public Animator anim;
    #endregion

    #region Quando pegar o livro
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.CompareTag("player"))
        {
            pegou1 = true;
            Livro1.SetActive(true);
            //Time.timeScale = 0.0f;
            
           anim.SetBool("pegou1", true);
            
        }
    }
    #endregion
}
