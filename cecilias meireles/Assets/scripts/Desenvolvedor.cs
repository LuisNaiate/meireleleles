
using UnityEngine;

public class Desenvolvedor : MonoBehaviour
{
   
    void Start()
    {
        
    }

  
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.T))
        {
            CheckPoint.comLivro = true;
            
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            CheckPoint.doublejum = true;
        }
    }
}
