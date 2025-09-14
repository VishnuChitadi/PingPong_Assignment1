using UnityEngine;

public class ball : MonoBehaviour
{
    // Reference to the Rigidbody2D component of the ball
    Rigidbody2D rb;

    // Speed of the ball (set in the Inspector)
    public float speed = 5f;

    // Current direction of the ball's movement (normalized vector)
    public Vector2 direction;

    // Player 1 Score
    public int playerOneScore=0;

    // Player 2 Score
    public int playerTwoScore=0;

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
    void ResetBall()
{
    // Reset position to center
    transform.position = Vector2.zero;

    // Start moving in a random horizontal direction with small vertical variation
    direction = new Vector2(Random.Range(0, 2) == 0 ? 1 : -1, Random.Range(-0.2f, 0.2f)).normalized;
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
        else if (collision.gameObject.CompareTag("leftPaddle"))
        {
            direction.x = -direction.x; // Flip horizontal direction (bounce back)

            // Add small random vertical component to make the bounce unpredictable
            direction.y = Random.Range(-0.5f, 0.5f);

            // Normalize the direction to maintain consistent speed
            direction = direction.normalized;
        }

         else if (collision.gameObject.CompareTag("bottomWall"))
        {
            direction.y = -direction.y; // Flip vertical direction (bounce back)
        }

        else if (collision.gameObject.CompareTag("topWall"))
        {
            direction.y = -direction.y; // Flip vertical direction (bounce back)
        }

        else if (collision.gameObject.CompareTag("leftWall")){
            // Adds a point for player 2
            playerTwoScore++;

            Debug.Log("Player 2 Score: " + playerTwoScore); // Shows Player 2's score in console

            // Resets the ball after each point till 5.
            ResetBall();
        }

        else if (collision.gameObject.CompareTag("rightWall")){
            // Adds a point for player 2
            playerOneScore++;

            Debug.Log("Player 1 Score: " + playerOneScore); // Shows Player 2's score in console

            // Resets the ball after each point till 5.
            ResetBall();
        }

        

    }
}


