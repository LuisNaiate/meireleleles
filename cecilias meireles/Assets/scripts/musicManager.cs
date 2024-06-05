using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicManager : MonoBehaviour
{

    public AudioSource musicMenu;
    public AudioSource musicHub;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void VolumeMusical(float value)
    {
        musicMenu.volume = value;
        musicHub.volume = value;


    }
    
}
