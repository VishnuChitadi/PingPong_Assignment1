using UnityEngine;
using TMPro; // Needed for TextMeshProUGUI

public class scoreManager : MonoBehaviour
{
    // UI text for Player 1 and Player 2 scores
    public TextMeshProUGUI playerOneScore;    
    public TextMeshProUGUI playerTwoScore;    

    // UI text for Player 1 and Player 2 winner messages
    public TextMeshProUGUI playerOneWinner;   
    public TextMeshProUGUI playerTwoWinner;   

    // Internal score counters for each player
    private int scoreP1 = 0;
    private int scoreP2 = 0;

    // Maximum score before declaring a winner
    private int maxScore = 5;

    // Called when the game starts
    void Start()
    {
        // Set default score text colors (optional)
        playerOneScore.color = Color.black;   // Player 1 score always black
        playerTwoScore.color = Color.black;   // Player 2 score always black
    }

    // Call this method to add a point to a player
    // input = 1 for Player 1, 2 for Player 2
    public void AddScore(int input)
    {
        if (input == 1)
        {
            scoreP1++; // Increase Player 1's score
            // Update Player 1 score UI text with label
            playerOneScore.text = "Player 1 score: " + scoreP1.ToString();
            CheckWinner(); // Check if Player 1 has won
        }
        else if (input == 2)
        {
            scoreP2++; // Increase Player 2's score
            // Update Player 2 score UI text with label
            playerTwoScore.text = "Player 2 score: " + scoreP2.ToString();
            CheckWinner(); // Check if Player 2 has won
        }
    }

    // Check if any player has reached the maximum score
    private void CheckWinner()
    {
        if (scoreP1 >= maxScore)
        {
            playerOneWinner.text = "Player 1 Wins!"; // Show winner message for Player 1
            playerTwoWinner.text = "";               // Clear Player 2 winner text
            EndGame();                               // Stop the game
        }
        else if (scoreP2 >= maxScore)
        {
            playerTwoWinner.text = "Player 2 Wins!"; // Show winner message for Player 2
            playerOneWinner.text = "";               // Clear Player 1 winner text
            EndGame();                               // Stop the game
        }
    }

    // Stop the game when a player wins
    private void EndGame()
    {
        Time.timeScale = 0f; // Freeze all game activity
        // Optional: You could also load a menu, restart, etc.
    }
}


