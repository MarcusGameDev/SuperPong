using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class turningPlayer2D : MonoBehaviour
{
    public float speed = 5;
    public Vector2 direction;
    public GameObject pointPosition;


    // Update is called once per frame
    void Update()
    {
        float Xmove = Input.GetAxisRaw("Horizontal");
        float Ymove = Input.GetAxisRaw("Vertical");

        direction = new Vector2(Xmove, Ymove);
        direction.Normalize();

        // Point position moves around the player depending on the current direction input
        pointPosition.transform.position = new Vector2 (this.gameObject.transform.position.x + direction.x, this.gameObject.transform.position.y + direction.y);

        // Player Looks at point position
        transform.up = pointPosition.transform.position - transform.position ;

        if(Xmove != 0 || Ymove !=0)
        {
    //        transform.Translate(transform.up * speed * Time.deltaTime);
        }


        //  transform.rotation = Quaternion.Euler(direction);
        // transform.Quaternion(direction * speed * Time.deltaTime);
    }
}
