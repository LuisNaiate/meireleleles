using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gomba1 : MonoBehaviour
{
    [Header("corpo")]
    private SpriteRenderer spriteRenderer_;
    private CapsuleCollider2D capsuleCollider_;
    private Rigidbody2D body_;

    [Header("status")]
    public int damage = 2;
    public float speed = 2;
    int direction = -1;
    public int life = 2;

    #region atribui��es de variaveis 
    private void Start()
    {
        spriteRenderer_ = GetComponent<SpriteRenderer>();
        capsuleCollider_ = GetComponent<CapsuleCollider2D>();
        body_ = GetComponent<Rigidbody2D>();

    }
    #endregion

    #region movimenta��o
    void Update()
    {
       body_.linearVelocity = new Vector2(speed * direction, body_.linearVelocity.y); 
    }
    #endregion

    #region quando morrer
    void morte()
    {
        speed = 0;
        direction = 0;
        damage = 0;
        spriteRenderer_.color = Color.red;
        gameObject.transform.Rotate(0, 0, -90);
        body_.gravityScale = 0;
        capsuleCollider_.isTrigger = true;
        Destroy(gameObject, 1);
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {

        #region quando for atigido pelo tiro
        if (collision.gameObject.CompareTag("bullet"))
        {
          life -= bullet.damage;

            if (life <= 0)
            {
                morte();
                Destroy(collision.gameObject);
            }
            spriteRenderer_.color = Color.HSVToRGB(0f, 59f, 100);

            StartCoroutine(TempinhoDeVermelho());   
            Destroy(collision.gameObject);
        }
        #endregion

        #region trocar de dire��o
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
    #region corroutina
    IEnumerator TempinhoDeVermelho()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer_.color = Color.white;
    }
    #endregion
}
