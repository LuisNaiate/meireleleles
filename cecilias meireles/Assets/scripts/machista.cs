using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class machista : MonoBehaviour
{
    public float timer;
    public int[] attacks;
    public GameObject dumbell;
    public GameObject player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
       timer = 3;
       rb = GetComponent<Rigidbody2D>();
       player = GameObject.FindWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            Attack();
            timer = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Destroy(player);
        }
    }
    void Attack()
    {
           int ahido = Random.Range(0, attacks.Length);
         
            if (ahido == 0)
            {
                Instantiate(dumbell);
                print("PESO");
            }
            if (ahido == 1)
            {
                print("FALA");
            }
            if (ahido == 2)
            {
                print("DISSOLVER");
            }
    }
}
