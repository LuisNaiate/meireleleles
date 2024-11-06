
using UnityEngine;

public class botão : MonoBehaviour
{
    //botão1
    #region variaveis 
    [SerializeField] GameObject barragem;
    [SerializeField] Sprite sprite;
    [SerializeField] SpriteRenderer spriteRenderer;
    #endregion
    //vai destruir o botão 1 que ta barrando a passagem

    #region spriteRenderer
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    #endregion

    #region quando for atingido pelo bullet
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            Destroy(barragem);
            spriteRenderer.sprite = sprite;
        }
    }
    #endregion
}




