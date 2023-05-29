using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PaddleType { Basic, Side, Crit}

public class PaddlePiece : MonoBehaviour
{
    [HideInInspector] public BallController ball;
    public float speedMod = 1f;
   // public float yMod = 0;

    public PaddleType pieceType;

    // Start is called before the first frame update
    public void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == ball.gameObject)
        {
            PaddleCheck();
        }
    }

    public void PaddleCheck()
    {
       

        if (pieceType == PaddleType.Crit)
        {
            ball.BallHit(1.5f, true);
            ball.StrikeBall();
            // Hit ball Fast and straight back at the enemy
        }
        else if (pieceType == PaddleType.Side)
        {
            // Hit the ball Fast but wild direction at the enemy
            ball.BallHit(1.5f, true);
            ball.WildBall();
        }
        else if (pieceType == PaddleType.Basic)
        {
            // Hit the Ball back at the enemy
            ball.BallHit(1f, true);
        }
        
    }
}
