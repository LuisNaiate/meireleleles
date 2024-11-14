using UnityEngine.SceneManagement;
using UnityEngine;

public class Cutscene1 : MonoBehaviour
{
    public int clicou;
    public Transform cameraPos;
    public void Clicou()
    {
        clicou++;
      switch (clicou)
        {
            case 1:
                cameraPos.position = new Vector2(0, 0);
                break;
            case 2:
                cameraPos.position = new Vector2(15, 0);
                break;
            case 3:
                cameraPos.position = new Vector2(30, 0);
                break;
            case 4:
                cameraPos.position = new Vector2(45, 0);
                break;
            case 5:
                cameraPos.position = new Vector2(60, 0);
                break;
            case 6:
                SceneManager.LoadScene("fase1");
                break;
            
        }
    }
}
