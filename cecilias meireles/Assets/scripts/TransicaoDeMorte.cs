
using UnityEngine;

public class TransicaoDeMorte : MonoBehaviour
{
    public Animator anim;
     static TransicaoDeMorte instance;
    public static bool morreuBoss;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Preserva este GameObject entre as cenas.
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(morreuBoss == true)
        {
            anim.SetBool("MorreuBoss", true);

        }
    }
}
