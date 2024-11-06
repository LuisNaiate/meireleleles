using UnityEngine;

public class quadro1Original : MonoBehaviour
{
    #region variaveis
    public GameObject b1;
    public Animator animator;
    #endregion

    #region quando o player pegar
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            b1.SetActive(true);
            animator.SetBool("pegou4", true);
        }
    }
    #endregion

}
