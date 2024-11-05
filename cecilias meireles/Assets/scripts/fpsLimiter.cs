using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsLimiter : MonoBehaviour
{
  
    public float updateRate = 1f; // Tempo entre as atualizações
    int frameCount = 0;
    float deltaTime = 0.0f;


    private void Awake()
    {
        Application.targetFrameRate = 60;
    }


    void Update()
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
