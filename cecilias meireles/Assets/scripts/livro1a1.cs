using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livro1a1 : MonoBehaviour
{
    public Animation anim;
    public GameObject teste;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.activeSelf)
        {
            anim.Play();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
