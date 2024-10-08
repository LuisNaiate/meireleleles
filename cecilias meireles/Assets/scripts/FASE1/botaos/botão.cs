
using UnityEngine;

public class botão : MonoBehaviour
{
    //botão1
    public GameObject barragem;
    public Sprite sprite;
    public SpriteRenderer spriteRenderer;

    //vai destruir o botão 1 que ta barrando a passagem

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            Destroy(barragem);
            spriteRenderer.sprite = sprite;
        }
    }
}




