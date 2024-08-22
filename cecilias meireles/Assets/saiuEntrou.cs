using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saiuEntrou : MonoBehaviour
{
    public Animator animator;
    bool jaSaiu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            animator.SetBool("saiu", true);
            jaSaiu = true;
        }

        if (collision.gameObject.CompareTag("player") && jaSaiu == true)
        {
            animator.SetBool("saiu", false);
            jaSaiu = false;
        }
    }
}
