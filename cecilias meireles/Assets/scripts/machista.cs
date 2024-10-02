using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class machista : MonoBehaviour
{
    public int[] attacks;
    public GameObject dumbell;
    public GameObject player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       Attack();
        player = GameObject.FindWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
       
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
        for (int i = 0; i < attacks.Length; i++)
        {
            Random.Range(i, 2);
            if (attacks[i] == 0)
            {
                Instantiate(dumbell);
                print("PESO");
            }
            if (attacks[i] == 1)
            {

            }
            if (attacks[i] == 2)
            {

            }
        }
    }
}
