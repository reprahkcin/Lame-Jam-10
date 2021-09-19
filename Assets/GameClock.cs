using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClock : MonoBehaviour
{
    // Singleton
    public static GameClock instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public float timer = 60f;
    private bool canCount = true;
    private bool doOnce = false;

    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;

        }
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            Debug.Log("Time's up!");
        }

        CanvasManager.instance.UpdateGameClock(timer);
    }


}
