using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portas : MonoBehaviour
{
    public GameObject porta2;
    public GameObject porta3;
    public GameObject porta4;
    public GameObject portaFinal;
    public bool completo1;
    public bool completo2;
    public bool completo3;
    public bool completo4;
    public bool completoFinal;
    public TagAttribute bloqueada;
    void Start()
    {
        porta2.tag = "bloqueada";
        porta3.tag = "bloqueada";
        porta4.tag = "bloqueada";
        porta4.tag = "bloqueada";

    }

   
    void Update()
    {
        if (completo1 == true)
        {
            porta2.tag = "porta2";
            porta2.isStatic = true;
        }
        if (completo2 == true)
        {
            porta3.tag = "porta3";
            porta3.isStatic = true;
        }
        if (completo3 == true)
        {
            porta4.tag = "porta4";
            porta4.isStatic = true;
        }
        if (completo4== true)
        {
            portaFinal.tag = "portaFinal";
            portaFinal.isStatic = true;
        }
     
    }
   

}

