using UnityEngine;

public class quadro2 : MonoBehaviour
{
    #region variaveis
    public GameObject b2;
    public Animator animator;
    #endregion


    #region quando o player pegar
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {

            b2.SetActive(true);
    
         
            animator.SetBool("pegou5", true);
        }
    }
    #endregion


}
