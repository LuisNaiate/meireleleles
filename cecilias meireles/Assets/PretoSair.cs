using UnityEngine;

public class PretoSair : MonoBehaviour
{
    //Esse Script serve para quando sair ou entrar da dungeon, o lado de fora ou de dentro ficar preto
     
    #region variaveis
    [Header("Variaveis")]
    Transform player;
    public GameObject entrou, saiu;
    public GameObject light1, light2;
    #endregion

    #region atribuitions
    void Start()
    {
      player = GameObject.FindWithTag("player").transform;
    }
    #endregion

    #region A mecanica 
    void Update()
    {
        if(player.position.x > transform.position.x)
        {
            entrou.SetActive(true);
            saiu.SetActive(false);
            light1.SetActive(false); 
            light2.SetActive(true);
        }
        else
        {

            entrou.SetActive(false);
            saiu.SetActive(true);
            light1.SetActive(true);
            light2.SetActive(false);
        }
    }
    }
    #endregion


