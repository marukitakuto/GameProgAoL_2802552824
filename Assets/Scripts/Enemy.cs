using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;

    private int direction = 1;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        // Flip sprite based on direction
        spriteRenderer.flipX = direction > 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Turn();
        }
    }

    void Turn()
    {
        direction *= -1;
    }
}