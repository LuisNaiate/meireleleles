using System.Collections;
using System.Collections.Generic;
using UnityEditor;

using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed = 5, jumpstrengh = 5;
    float horizontal;
    public bool groundCheck;
    public Transform foot;
    public GameObject spawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // movimentação
        horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);

        //pulo
        groundCheck = Physics2D.OverlapCircle(foot.position, 0.05f);

        if (Input.GetButtonDown("Jump") && groundCheck == true)
        {
            body.AddForce(new Vector2(0, jumpstrengh * 100));
        }
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("caiuvolta"))
        {
            body.MovePosition(spawn.transform.position);
        }

       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("porta"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("menu");
            }
        }
    }

}
