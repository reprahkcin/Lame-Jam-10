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

    void Update()
    {
        CanvasManager.instance.UpdateSpeedReadout(playerSpeed);
        if (playerSpeed > 20)
        {
            // Change obstacle material albedo to red
            obstacleMaterial.SetColor("_Color", Color.red);
        }
        if (playerSpeed < 20 && playerSpeed > 15)
        {

            // Change obstacle material albedo to orange
            obstacleMaterial.SetColor("_Color", new Color(1, 0.5f, 0));

        }
        if (playerSpeed < 15 && playerSpeed > 10)
        {

            // Change obstacle material albedo to yellow
            obstacleMaterial.SetColor("_Color", Color.yellow);
        }
        if (playerSpeed < 10)
        {

            // Change obstacle material albedo to green
            obstacleMaterial.SetColor("_Color", Color.green);

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

    public Material obstacleMaterial;


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