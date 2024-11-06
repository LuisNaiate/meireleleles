
using UnityEngine;

public class fpsLimiter : MonoBehaviour
{
    #region variaveis 
    public float updateRate = 1f; // Tempo entre as atualizações
    int frameCount = 0;
    float deltaTime = 0.0f;
    [SerializeField] bool ativarContagem;
    #endregion

    #region Qual fps dever ser
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    #endregion

    #region Mostrar o fps no console
    void Update()
    {
        if(ativarContagem)
        {

          deltaTime += Time.unscaledDeltaTime;
          frameCount++;

          if (deltaTime >= updateRate)
           {
            int fps = Mathf.RoundToInt(frameCount / deltaTime);
            Debug.Log("FPS: " + fps);

            frameCount = 0;
            deltaTime = 0.0f;
          }
        }
    }
    #endregion
}
