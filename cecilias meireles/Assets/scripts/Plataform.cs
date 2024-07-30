using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool plataform1, plataform2;
    public bool moveRight = true, moveUp = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plataform1)
        {
            if (transform.position.x > -10)
            {
                moveRight = false;
            }
            else if (transform.position.x < -20)
            {
                moveRight = true;
            }
            if (moveRight)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);
            }
        }
        if (plataform2)
        {
            if (transform.position.y > 3)
            {
                moveUp = false;
            }
            else if (transform.position.y < -1)
            {
                moveUp = true;
            }
            if (moveUp)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.up * -moveSpeed * Time.deltaTime);
            }
        }
    }
}
