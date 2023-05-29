using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f; // Speed at which the paddle moves
    public float topBound = 4.5f; // Top bound of the game board
    public float bottomBound = -4.5f; // Bottom bound of the game board

    public GameObject TopSidePanel;
    public GameObject BottomSidePanel;
    public GameObject CritPoint;

    // Update is called once per frame
    void Update()
    {
        // Get vertical input from player (up or down arrow keys)
        float input = Input.GetAxis("Vertical");

        // Move the paddle based on input and speed
        transform.Translate(Vector2.up * input * speed * Time.deltaTime);

        // Clamp the paddle position to ensure it doesn't move off the top or bottom of the game board
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, bottomBound, topBound));
    }


}
// work pls

