
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicaoDeMorteJogo : MonoBehaviour
{
    public Animator anim;
     static TransicaoDeMorteJogo instance;
    public static bool morreuJogo;
    string fase;
    public Transform cameraSeguir;
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
        cameraSeguir = GameObject.FindGameObjectWithTag("camera").transform;
        fase = SceneManager.GetActiveScene().name;
        if(fase == "Boss" || fase == "menu")
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (cameraSeguir != null)
        {
            Vector3 desiredPosition = new Vector3(cameraSeguir.position.x, cameraSeguir.position.y, transform.position.z); // A posição que queremos alcançar, mantendo a coordenada Z da câmera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 1); // Interpolação linear para suavizar o movimento
            transform.position = smoothedPosition; // Atualiza a posição do objeto que está seguindo
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
