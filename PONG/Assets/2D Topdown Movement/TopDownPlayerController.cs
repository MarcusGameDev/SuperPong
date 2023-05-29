using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{

    public float speed = 5f; // Player movement speed

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Read player input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement vector
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Move the player
        MovePlayer(movement);
    }

    private void MovePlayer(Vector2 movement)
    {
        // Apply movement to the rigidbody
        rb.velocity = movement * speed;
    }


}
