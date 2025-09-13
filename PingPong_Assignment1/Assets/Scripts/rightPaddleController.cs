using UnityEngine; // Import Unity engine functionality

public class PaddleController : MonoBehaviour
{
    Rigidbody2D pad;          // Reference to the Rigidbody2D component of the paddle
    Vector2 position;         // Stores the current position of the paddle
    public float displacement; // How much the paddle moves per frame (speed)

    // Start is called before the first frame update
    void Start()
    {
        pad = GetComponent<Rigidbody2D>();    // Get the Rigidbody2D attached to this GameObject
        position = pad.transform.localPosition; // Store the starting position of the paddle
    }

    // Update is called once per frame
    void Update()
    {
        // If the Up Arrow key is held down
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Move upward until y position <= 4.5f (example upper bound)
            if (position.y <= 4.5f)
                position.y += displacement; // Add displacement to y to go up
        }
        // If the Down Arrow key is held down
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // Move downward until y position >= -4.5f (example lower bound)
            if (position.y >= -4.5f)
                position.y -= displacement; // Subtract displacement from y to go down
        }

        // Actually move the paddle to the new position
        pad.MovePosition(position);
    }
}

