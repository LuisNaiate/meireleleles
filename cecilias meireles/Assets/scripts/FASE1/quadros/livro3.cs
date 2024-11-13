using UnityEngine;

public class livro3 : MonoBehaviour
{
    #region variaveis 
    public static bool pegou3 = false;
    public GameObject a3;
    public Animator animator;
    bool pegouLivro = false;
    #endregion
    private void Start()
    {
        if (pegou3 == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (pegouLivro == true)
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
            a3.SetActive(true);

            pegouLivro = true;
                animator.SetBool("pegou3", true);

        }
    }
    #endregion
    #region para sair do painel, o botão funciona aqui
    public void TimeRun()
    {
        //Time.timeScale = 1.0f;
        a3.SetActive(false);
        Destroy(gameObject);
            pegou3 = true;
    }
    #endregion

}
