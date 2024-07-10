using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class canão2 : MonoBehaviour
{
    public float time;
    public GameObject cannonBall;
    private int bulletSpeed = -15;
    public GameObject area;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 3 )
        {
            GameObject temp = Instantiate(cannonBall, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
            time = 0;
        }
    }
    
}
