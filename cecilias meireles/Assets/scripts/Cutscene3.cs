
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene3 : MonoBehaviour
{
    public int clicou;
    public Transform cameraPos;
    public void Clicou()
    {
        clicou++;
        switch (clicou)
        {
            case 1:
                cameraPos.position = new Vector2(2, 0);
                break;
            case 2:
                cameraPos.position = new Vector2(4, 0);
                break;
            case 3:
                cameraPos.position = new Vector2(6, 0);
                break;
            case 4:
                cameraPos.position = new Vector2(8, 0);
                break;
            case 5:
                cameraPos.position = new Vector2(10, 0);
                break;
            case 6:
                cameraPos.position = new Vector2(12, 0);
                break;
            case 7:
                cameraPos.position = new Vector2(14, 0);
                break;
            case 8:
                cameraPos.position = new Vector2(16, 0);
                break;
            case 9:
                SceneManager.LoadScene("menu");
                break;


        }
    }
}
