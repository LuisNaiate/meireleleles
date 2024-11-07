using UnityEngine;

public class quadro1Original : MonoBehaviour
{
    #region variaveis
    public GameObject b1;
    public static bool pegouQuadro1 = false;
    public Animator animator;
    #endregion
    private void Start()
    {
        if (pegouQuadro1 == true)
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
            b1.SetActive(true);
            animator.SetBool("pegou4", true);
        }
    }
    #endregion

    #region para sair do painel, o botão funciona aqui
    public void TimeRun()
    {
        //Time.timeScale = 1.0f;
        b1.SetActive(false);
        Destroy(gameObject);
        pegouQuadro1 = true;
    }
    #endregion
}
