using UnityEngine;

public class quadro2 : MonoBehaviour
{
    #region variaveis
    public GameObject b2;
    public Animator animator;
    public static bool pegouQuadro2 = false;
    #endregion

    private void Start()
    {
        if (pegouQuadro2 == true)
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
    #region para sair do painel, o botão funciona aqui
    public void TimeRun()
    {
        //Time.timeScale = 1.0f;
        b2.SetActive(false);
        Destroy(gameObject);
        pegouQuadro2 = true;
    }
    #endregion


}
