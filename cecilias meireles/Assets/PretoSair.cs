using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PretoSair : MonoBehaviour
{
  
    
    public GameObject entrou, saiu;
    Transform player;
    void Start()
    {
      player = GameObject.FindWithTag("player").transform;
    }

    
    void Update()
    {
        if(player.position.x > transform.position.x)
        {
            entrou.SetActive(true);
            saiu.SetActive(false);
        }
        else
        {

            entrou.SetActive(false);
            saiu.SetActive(true);

        }
    }

    
}
