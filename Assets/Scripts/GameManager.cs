using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;

    // --------------------------------------------------
    // Unity Life Cycle
    // --------------------------------------------------
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // --------------------------------------------------
    // Master Game Methods
    // TODO: Add methods for game logic
    // --------------------------------------------------

    // Start Game
    public void StartGame()
    {
        Debug.Log("Game Started");
    }

    // End Game
    public void EndGame()
    {
        Debug.Log("Game Ended");
    }

    // Restart Game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    // --------------------------------------------------
    // Game Variables
    // --------------------------------------------------

    // Score
    public int score;

    // score per obstacle
    [Range(0, 100)]
    public int scorePerObstacle = 10;

    public void AddScore(int amount)
    {
        score += amount;
    }


    // Player Variables
    [Range(0f, 20f)]
    public float playerSpeed = 10f;
    [Range(0f, 20f)]
    public float Jumpforce = 9.0f;
    [Range(0, 10)]
    public int numberOfObstacles = 5;
}
