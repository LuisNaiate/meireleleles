using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saiuEntrou : MonoBehaviour
{
  
    bool jaSaiu;
    public GameObject luz;
    public GameObject luzDungeon;
    public GameObject luzPlayer;
    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            luz.SetActive(false);
            luzDungeon.SetActive(true);
            luzPlayer.SetActive(true);
            jaSaiu = true;
        }

        if (collision.gameObject == player && jaSaiu == true)
        {
            luz.SetActive(true);
            luzDungeon.SetActive(false);
            luzPlayer.SetActive(false);
            jaSaiu = false;
        }
    }
}
