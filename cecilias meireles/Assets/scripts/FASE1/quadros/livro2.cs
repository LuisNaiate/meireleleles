using UnityEngine;

public class livro2 : MonoBehaviour
{
    public static bool pegou2 = false;
    public GameObject a2;
    public Animator animator;
    bool pegouLivro = false;

    private void Start()
    {
        if (pegou2 == true)
        {
            gameObject.SetActive(false);
        }
    }
     void Update()
    {
        if(pegouLivro == true)
        {

         if (Input.GetButtonDown("Quit"))
         {
            TimeRun();
          }
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            pegou2 = true;
         
            a2.SetActive(true);
            //Time.timeScale = 0.0f;
            pegouLivro = true;
            animator.SetBool("pegou2", true);
        }
    }
   
    public void TimeRun()
    {
        //Time.timeScale = 1.0f;
        a2.SetActive(false);
        Destroy(gameObject);
        pegou2 = true;
    }
}
