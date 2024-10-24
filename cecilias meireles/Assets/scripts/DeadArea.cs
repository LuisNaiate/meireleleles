using System.Collections;
using UnityEngine;

public class DeadArea : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] float timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TempoDeESpera());
    }

    
    void Update()
    {
     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("player"))
        {
            Destroy(collision.gameObject);
        }
    }

    IEnumerator TempoDeESpera()
    {
        yield return new WaitForSeconds(timer);
        boss.SetActive(true);
        Destroy(gameObject);
        
    }
}
