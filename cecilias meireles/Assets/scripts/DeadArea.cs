using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadArea : MonoBehaviour
{
    #region variaveis 
    [SerializeField] GameObject boss;
    [SerializeField] float timer;
    machista machista;
    #endregion

    #region encontrar o boss 
    private void Awake()
    {
        boss = GameObject.FindGameObjectWithTag("boss");
    }
    #endregion

    #region quando o ataque ativar 
    void Start()
    {
        StartCoroutine(TempoDeEspera());
    }
    #endregion

    #region quando colidir com o player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            TransicaoDeMorte.morreuBoss = true;
            Destroy(collision.gameObject);
           StartCoroutine(TempoParaCarregarCena());
        }
    }
    #endregion

    #region Coroutinas (nomes autoexplicativo)
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
    #endregion
}
