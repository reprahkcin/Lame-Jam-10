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
}
