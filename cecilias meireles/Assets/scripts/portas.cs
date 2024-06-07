using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portas : MonoBehaviour
{
    public  GameObject porta2;
    public  GameObject porta3;
    public  GameObject porta4;
    public  GameObject portaFinal;
    public bool completo1;
    public bool completo2;
    public bool completo3;
    public bool completo4;
    public bool completoFinal;
    public TagAttribute bloqueada;
    public string tagPorta2;
    public string tagPorta3;
    public string tagPorta4;
    public string tagPortaFinal;
    void Start()
    {
       

    }

   
    void Update()
    {
        if (completo1 == true)
        {
            porta2.tag = tagPorta2;
         
        }
        if (completo2 == true)
        {
            porta3.tag = tagPorta3;
            
        }
        if (completo3 == true)
        {
            porta4.tag = tagPorta4;
            
        }
        if (completo4== true)
        {
            portaFinal.tag = tagPortaFinal;
            
        }
     
        if(Input.GetKeyDown(KeyCode.V))
        {
            completo1 = true;
        }
    }
   

}

