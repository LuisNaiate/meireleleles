using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadArea : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] float timer;
    machista machista;
    private void Awake()
    {
        boss = GameObject.FindGameObjectWithTag("boss");
    }
    void Start()
    {
        StartCoroutine(TempoDeEspera());
    }

    
    void Update()
    {
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            TransicaoDeMorte.morreuBoss = true;
            Destroy(collision.gameObject);
           StartCoroutine(TempoParaCarregarCena());
        }
    }
   IEnumerator TempoParaCarregarCena()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Boss");
    }

    IEnumerator TempoDeEspera()
    {
        yield return new WaitForSeconds(timer);
        boss.SetActive(true);
        machista.Voltou = true;
        Destroy(gameObject);
        
    }
}
