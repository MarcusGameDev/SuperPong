using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2D : MonoBehaviour
{
    public float speed = 5;
    public float dashSpeed = 20;
    public Vector2 direction;


    // Update is called once per frame
    void Update()
    {
        // BASIC MOVEMENT IN 2D
        float Xmove = Input.GetAxisRaw("Horizontal");
        float Ymove = Input.GetAxisRaw("Vertical");

        direction = new Vector2(Xmove, Ymove);
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);

        // Add a dash in game
        if (Input.GetKeyDown(KeyCode.E))
        {
           // Vector2 dashTarget = new Vector2((direction.x + transform.position.x) * dashSpeed, (direction.y + transform.position.y) * dashSpeed);
            transform.position = transform.position + new Vector3(direction.x * dashSpeed, direction.y * dashSpeed, 0);
        }

       

     
    }
}
