using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallPossession {None, Player1, Player2}

public class BallController : MonoBehaviour
{
    public BallPossession ballPossession;

    public float speed = 8f; // Speed at which the ball moves
    public float maxSpeed = 100;
    public float speedBoost = 1;
    public float originalSpeed;

    private float xDirection; // Horizontal direction of the ball (left or right)
    private float yDirection; // Vertical direction of the ball (up or down)
    private Transform ballTrans;

   // public float BallHeightLimit = 5;

    public GameObject Player1;
    public GameObject Player2;

    public GameObject Goal1;
    public GameObject Goal2;

    public GameManager GM;

    private void Awake()
    {
        originalSpeed = speed;
        ballTrans = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the ball in the chosen direction every frame
        transform.Translate(new Vector2(xDirection, yDirection) * speed * Time.deltaTime);

        /*
        // If the ball collides with the top or bottom of the game board, reverse its vertical direction
        if (Mathf.Abs(transform.position.y) > BallHeightLimit)
        {
            yDirection *= -1;
        }
        */
      
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }

    // Method to reset the ball's position and choose a new random starting direction
    public void ResetBall()
    {
        speed = originalSpeed;
        transform.position = Vector2.zero;
        xDirection = Random.Range(0.25f, 1f);
        yDirection = Random.Range(-1f, 1f);
        ballPossession = BallPossession.None;
        transform.localScale = new Vector3 (1,1,1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject == Player1)
        {
       
        }
      else if (collision.gameObject == Player2)
        {
            xDirection *= -1;
            SpeedBoost(speedBoost);
            ballPossession = BallPossession.Player2;
        }


      // PLAYER GOALS
      if (collision.gameObject == Goal1)
        {
            // Send Score Event 1 (add score + reset level)
            GM.IncrementComputerScore();
            ResetBall();
        }
      else if (collision.gameObject == Goal2)
        {
            // Send Score Event 2 (Add Score + Reset Level)
            GM.IncrementPlayerScore();
            ResetBall();
        }

      // NEUTRAL OBJECTS
      if (collision.gameObject.CompareTag("Wall"))
        {
            yDirection *= -1;
            SpeedBoost(speedBoost / 2);
        }

        if (collision.gameObject.CompareTag("Out of Bounds"))
        {
            Debug.Log("out of Bounds");
            ResetBall();
        }
    }

    public void BallHit(float speedMod, bool player1)
    {
        // Player 1 Hit
        if (player1)
        {
            xDirection *= -1;
            SpeedBoost(speedBoost * speedMod);
            ballPossession = BallPossession.Player1;

            if (xDirection < 0)
            {
                xDirection *= xDirection;
            }
        }

        

        if (yDirection == 0)
        {
            WildBall();
        }
        // Player 2 Hit
    }

    public void SpeedBoost(float speedBooster)
    {
        speed = speed + speedBooster;
    }

    public void StrikeBall()
    {
        yDirection = 0;

        if (xDirection > 0)
        {
            xDirection = 1;
        }
        else if (xDirection < 0)
        {
            xDirection = -1;
        }
    }

    public void WildBall()
    {
        yDirection = Random.Range(-1f, 1f);
        xDirection = Random.Range(0.25f, 1f);
    }
}
