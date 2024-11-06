using UnityEngine;

public class quadro3 : MonoBehaviour
{
    #region variaveis
    public GameObject b3;
    public Animator animator;
    #endregion


    #region quando o player pegar
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            
            b3.SetActive(true);
   
           
            animator.SetBool("pegou6", true);
        }
    }
    #endregion
}
