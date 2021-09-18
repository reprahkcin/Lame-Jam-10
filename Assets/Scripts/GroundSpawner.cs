using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    // Singleton
    public static GroundSpawner instance;

    void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public GameObject groundTile;

    Vector3 nextTilePosition;

    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextTilePosition, Quaternion.identity);
        nextTilePosition = temp.transform.GetChild(1).transform.position;
    }

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {

            SpawnTile();
        }


    }
}
