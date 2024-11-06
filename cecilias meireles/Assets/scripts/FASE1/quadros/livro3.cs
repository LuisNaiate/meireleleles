using UnityEngine;

public class livro3 : MonoBehaviour
{
    #region variaveis 
    public static bool pegou3 = false;
    public GameObject a3;
    public Animator animator;
    #endregion

    #region quando o player pegar
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            pegou3 = true;
            a3.SetActive(true);
         
           
            animator.SetBool("pegou3", true);

        }
    }
    #endregion

}
