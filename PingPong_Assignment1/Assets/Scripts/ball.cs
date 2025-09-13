using UnityEngine;

public class ball : MonoBehaviour
{
    // Reference to the Rigidbody2D component of the ball
    Rigidbody2D rb;

    // Speed of the ball (set in the Inspector)
    public float speed = 5f;

    // Current direction of the ball's movement (normalized vector)
    public Vector2 direction;

    void Start()
    {
        // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();

        // Initialize ball movement:
        // Starts moving mostly horizontally (right) with a small random vertical component
        // Random vertical component prevents the ball from moving perfectly straight
        direction = new Vector2(1, Random.Range(-0.2f, 0.2f)).normalized;
    }

    void Update()
    {
        // Apply velocity to the Rigidbody2D each frame
        // Multiplying by speed sets how fast the ball moves
        rb.linearVelocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If the ball hits the right paddle
        if (collision.gameObject.CompareTag("rightPaddle"))
        {
            direction.x = -direction.x; // Flip horizontal direction (bounce back)
            
            // Add small random vertical component to make the bounce unpredictable
            direction.y = Random.Range(-0.5f, 0.5f);

            // Normalize the direction to maintain consistent speed
            direction = direction.normalized;
        }

        // If the ball hits the left paddle
        if (collision.gameObject.CompareTag("leftPaddle"))
        {
            direction.x = -direction.x; // Flip horizontal direction (bounce back)

            // Add small random vertical component to make the bounce unpredictable
            direction.y = Random.Range(-0.5f, 0.5f);

            // Normalize the direction to maintain consistent speed
            direction = direction.normalized;
        }
    }
}


