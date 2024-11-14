
using UnityEngine;

public class gomba : MonoBehaviour
{
    [Header("corpo")]
    private Rigidbody2D body_;
    private CapsuleCollider2D capsuleCollider_;
    private SpriteRenderer spriteRenderer_;

    [Header("status")]
    public int damage = 2;
    public float speed = 2;
    int direction = -1;

    #region variaveis privadas
    void Start()
    {
        spriteRenderer_ = GetComponent<SpriteRenderer>();
        capsuleCollider_ = GetComponent<CapsuleCollider2D>();
        body_ = GetComponent<Rigidbody2D>();

    }
    #endregion

    #region movimentação
    void Update()
    {
        body_.velocity = new Vector2(speed * direction, body_.velocity.y);
    }
    #endregion
    #region quando morrer
    void morte()
    {
        speed = 0 ; direction = 0; damage = 0;
       
        spriteRenderer_.color = Color.red;
        gameObject.transform.Rotate(0, 0, -90);
        body_.gravityScale = 0;
        capsuleCollider_.isTrigger = true;
        Destroy(gameObject, 0.8f);
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
    #region morte
        if (collision.gameObject.CompareTag("bullet"))
        {
            morte();
            Destroy(collision.gameObject);

          
            

        }
        #endregion
        #region cuidado dos precipicios e trocar de lado

        if (collision.gameObject.CompareTag("precipicio"))
        {
            direction *= -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("ground"))
        {
            direction *= -1;
        }
    }
        #endregion
}
