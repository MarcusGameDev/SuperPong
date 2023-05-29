using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float paddleSpeed = 10f; // Speed of the paddle
    public Transform ball; // Reference to the ball's transform
    private Rigidbody2D rb; // Reference to the paddle's Rigidbody2D component
    private float movement; // Movement direction of the paddle

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the direction from the paddle to the ball
        Vector2 direction = new Vector2(0, ball.position.y) - rb.position;

        // Normalize the direction
        direction.Normalize();

        // Set the movement direction based on the normalized direction
        movement = direction.y;

        // Move the paddle in the chosen direction at the chosen speed
        rb.velocity = new Vector2(rb.velocity.x, movement * paddleSpeed);
    }
}
