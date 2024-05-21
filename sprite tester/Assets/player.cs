using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D body;
    public float horizontal;
    public float speed = 5;
    public Animator anim;
    public bool olhandoDireita;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
        if (horizontal != 0)
        {
            anim.SetInteger("pedro", 1);
        }
        if (horizontal == 0)
        {
            anim.SetInteger("pedro", 0);
        }

    }
    void Flip()
    {
        if (horizontal == -1 && olhandoDireita || horizontal == 1 && !olhandoDireita)
        {
            olhandoDireita = !olhandoDireita;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;
            Vector3 localposition = transform.position;
            if (olhandoDireita)
            {

                localposition.x += 1.33f;
                transform.position = localposition;

            }
            if (!olhandoDireita)
            {
                localposition.x += -1.33f;
                transform.position = localposition;


            }
        }
    }
}

