
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicaoDeMorteJogo : MonoBehaviour
{
    public Animator anim;
     static TransicaoDeMorteJogo instance;
    public static bool morreuJogo;
    string fase;
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
        fase = SceneManager.GetActiveScene().name;
        if(fase == "Boss")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(morreuJogo == true)
        {
            anim.SetBool("MorreuJogo", true);

        }
    }
}
