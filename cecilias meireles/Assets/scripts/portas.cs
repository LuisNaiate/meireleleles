using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portas : MonoBehaviour
{
    public static GameObject porta2;
    public static GameObject porta3;
    public static GameObject porta4;
    public static GameObject portaFinal;
    public bool completo1;
    public bool completo2;
    public bool completo3;
    public bool completo4;
    public bool completoFinal;
    public TagAttribute bloqueada;
    void Start()
    {
       

    }

   
    void Update()
    {
        if (completo1 == true)
        {
            
         
        }
        if (completo2 == true)
        {
            porta3.tag = "porta3";
            
        }
        if (completo3 == true)
        {
            porta4.tag = "porta4";
            
        }
        if (completo4== true)
        {
            portaFinal.tag = "portaFinal";
            
        }
     
        if(Input.GetKeyDown(KeyCode.V))
        {
            completo1 = true;
        }
    }
   

}

