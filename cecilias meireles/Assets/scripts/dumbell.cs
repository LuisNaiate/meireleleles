using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class dumbell : MonoBehaviour
{
    public GameObject player;
    public float horizontal;
    public float speed;
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
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
}
