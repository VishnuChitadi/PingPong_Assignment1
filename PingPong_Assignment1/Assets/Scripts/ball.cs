using UnityEngine;

public class ball : MonoBehaviour
{
    // Reference to the Rigidbody2D component
    Rigidbody2D rb;

    // Speed of the ball
    public float speed = 5f;

    // Current direction of the ball
    public Vector2 direction;

    // Reference to the scoreManager script
    public scoreManager scoreManager;

    void Start()
    {
        // Get Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Find scoreManager in scene if not assigned in Inspector
        if (scoreManager == null)
              scoreManager = FindFirstObjectByType<scoreManager>();

        // Initialize ball movement with mostly horizontal direction
        direction = new Vector2(1, Random.Range(-0.2f, 0.2f)).normalized;
    }

    void Update()
    {
        // Move the ball each frame
        rb.linearVelocity = direction * speed;
    }

    // Reset ball to center and set random direction
    void ResetBall()
    {
        transform.position = Vector2.zero;
        direction = new Vector2(Random.Range(0, 2) == 0 ? 1 : -1,
                                Random.Range(-0.2f, 0.2f)).normalized;
    }

    void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("Ball collided with: " + collision.gameObject.name + " | Tag: " + collision.gameObject.tag);

    if (collision.CompareTag("leftWall"))
    {
        Debug.Log("Left wall hit → Player 2 should score");
        scoreManager.AddScore(2);
        ResetBall();
    }
    else if (collision.CompareTag("rightWall"))
    {
        Debug.Log("Right wall hit → Player 1 should score");
        scoreManager.AddScore(1);
        ResetBall();
    }
    else if (collision.CompareTag("leftPaddle") || collision.CompareTag("rightPaddle"))
    {
        direction.x = -direction.x;
        direction.y = Random.Range(-0.5f, 0.5f);
        direction = direction.normalized;
    }
    else if (collision.CompareTag("topWall") || collision.CompareTag("bottomWall"))
    {
        direction.y = -direction.y;
    }
}

}



