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

        // Find the player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        CanvasManager.instance.UpdateSpeedReadout(playerSpeed);
        CanvasManager.instance.UpdateHealthBar(playerHealth);

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



    // Player Material
    public Material playerMaterial;

    // Flashing Material
    public Material flashingMaterial;

    // Player GameObject
    public GameObject player;

    // Player Health
    public float playerHealth = 100;

    public void AdjustHealth(float amount)
    {
        playerHealth += amount;

        StartCoroutine(FlashColor(0.05f));
    }

    IEnumerator FlashColor(float duration)
    {
        player.GetComponent<Renderer>().material = flashingMaterial;
        yield return new WaitForSeconds(duration);
        player.GetComponent<Renderer>().material = playerMaterial;
        yield return new WaitForSeconds(duration);
        player.GetComponent<Renderer>().material = flashingMaterial;
        yield return new WaitForSeconds(duration);
        player.GetComponent<Renderer>().material = playerMaterial;


    }


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