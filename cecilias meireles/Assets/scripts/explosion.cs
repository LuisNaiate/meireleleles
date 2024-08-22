using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class explosion : MonoBehaviour
{
    public AudioClip boom;
     AudioSource booom;
    public GameObject parede;
    public GameObject s;
    Animator animator;
    
    void Start()
    {
        booom = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == s)
        {
            booom.PlayOneShot(boom);
            parede.SetActive(false);
            Destroy(gameObject, 2);
            animator.SetBool("kjk", true);
        }
        else 
        {
            animator.SetBool("kjk", false);
        }
    }
}
