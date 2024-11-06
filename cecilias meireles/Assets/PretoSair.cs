using UnityEngine;

public class PretoSair : MonoBehaviour
{
    //Esse Script serve para quando sair ou entrar da dungeon, o lado de fora ou de dentro ficar preto
     
    #region variaveis
    [Header("Variaveis")]
    Transform player;
    public GameObject entrou, saiu;
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
        }
        else
        {

            entrou.SetActive(false);
            saiu.SetActive(true);

        }
    }
    #endregion

}
