using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int playerScore = 0; // Player's score
    public int computerScore = 0; // Computer's score
    public int winScore = 5;
    public TMP_Text playerScoreText; // Reference to UI text element that displays player's score
    public TMP_Text computerScoreText; // Reference to UI text element that displays computer's score

    public TMP_Text WinText;
    public bool gameOver = false;

    private void Start()
    {
        ResetGame();
      
    }

    // Update is called once per frame
    void Update()
    {
        // Check for input to quit the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (gameOver == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          //  ResetGame();
        }
    }

    // Method to increment player's score and update UI text
    public void IncrementPlayerScore()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
    }

    // Method to increment computer's score and update UI text
    public void IncrementComputerScore()
    {
        computerScore++;
        computerScoreText.text = computerScore.ToString();
    }

    // Method to reset the game and scores
    public void ResetGame()
    {
        // Reset player and computer scores to 0
        playerScore = 0;
        computerScore = 0;

        // Update UI text to show new scores
        playerScoreText.text = "0";
        computerScoreText.text = "0";

        // Reset the ball's position and choose a new random starting direction
        BallController ball = FindObjectOfType<BallController>();
        ball.ResetBall();

        gameOver = false;
        WinText.gameObject.SetActive(false); // Sets wintext off by default
    }

    // Method to end the game and display winner
    public void EndGame(string winner)
    {
        WinText.gameObject.SetActive(true);

        // Display the winner in the console
        WinText.text = winner + " Wins!";

        gameOver = true;  
    }

    private void FixedUpdate()
    {
        if (playerScore >= winScore)
        {
            EndGame("Player 1");
        }
        else if (computerScore >= winScore)
        {
            EndGame("The Computer");
        }
    }
}
