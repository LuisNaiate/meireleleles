using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed = 5, jumpstrengh = 5;
    float horizontal;
    public bool groundCheck;
    public Transform foot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // movimentação
        horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2 (horizontal * speed, body.velocity.y);

        //pulo
        groundCheck = Physics2D.OverlapCircle(foot.position, 0.05f);
        if (Input.GetButtonDown("Jump") && groundCheck)
        {
            body.AddForce  (new Vector2(0, jumpstrengh * 100));
        }
    }
}
