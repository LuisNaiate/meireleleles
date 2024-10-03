using UnityEngine;

public class livro2 : MonoBehaviour
{
    public static bool pegou2 = false;
    public GameObject a2;
    public Animator animator;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            pegou2 = true;
         
            a2.SetActive(true);
            //Time.timeScale = 0.0f;
            
            animator.SetBool("pegou2", true);
        }
    }
   
    public void TimeRun()
    {
        //Time.timeScale = 1.0f;
        a2.SetActive(false);
        Destroy(gameObject);
    }
}
