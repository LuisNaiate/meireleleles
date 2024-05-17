using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed = 5, jumpstrengh = 5;
    float horizontal;
    public bool groundCheck;
    public Transform foot;
    public int escalarr = 5, descer = -5;
    public float vertical;
    public Transform hand;
    public bool naEscada;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // movimentação
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        body.velocity = new Vector2 (horizontal * speed, body.velocity.y);

        //pulo
        groundCheck = Physics2D.OverlapCircle(foot.position, 0.05f);
        if (Input.GetButtonDown("Jump") && groundCheck)
        {
            body.AddForce  (new Vector2(0, jumpstrengh * 100));
        }



        //escada
        naEscada = Physics2D.OverlapCircle(hand.position, 0.05f);

        if (Input.GetButton("Vertical") && naEscada)
        {

            body.velocity = new Vector2(0, escalarr);

           
        }
        
       if (naEscada == true)
        {
            body.gravityScale = 0;
            if (Input.GetButtonDown("Vertical"))
            {

                body.velocity = new Vector2(0, escalarr);


            }
        }
       else
        {
            body.gravityScale = 1;
        }
    }
   
}
