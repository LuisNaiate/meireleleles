using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{
    public float time;
    public GameObject cannonBall;
   private int bulletSpeed = -50;
    public static bool atirar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if ( time  >= 2) 
        {
            GameObject temp = Instantiate(cannonBall, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed , 0);
            time = 0;
        }
    }
    
}