
using System.Collections;
using UnityEngine;

public class botao4 : MonoBehaviour
{
    public GameObject plataformas;
    [SerializeField] Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            plataformas.SetActive(true);
            animator.SetBool("botaoPlataforma", true);
            StartCoroutine(AnimacaoDaCamera());
        }
    }
    IEnumerator AnimacaoDaCamera()
    {
        yield return new WaitForSeconds(5);
        animator.SetBool("botaoPlataforma", false);
    }
}
