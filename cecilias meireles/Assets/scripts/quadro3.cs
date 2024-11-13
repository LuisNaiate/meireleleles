using UnityEngine;

public class quadro3 : MonoBehaviour
{
    #region variaveis
    public GameObject b3;
    public Animator animator;
    public static bool pegouQuadro3 = false;
    #endregion

    private void Start()
    {
        if (pegouQuadro3 == true)
        {
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        while(b3 == true)
        {

         if (Input.GetButtonDown("Quit"))
         {
            TimeRun();
         }
        }
    }
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
    #region para sair do painel, o botão funciona aqui
    public void TimeRun()
    {
        //Time.timeScale = 1.0f;
        b3.SetActive(false);
        Destroy(gameObject);
        pegouQuadro3 = true;
    }
    #endregion
}
