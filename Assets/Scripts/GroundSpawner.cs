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

    public GameObject[] obstacles;

    Vector3 nextTilePosition;

    public void SpawnTile(bool hasObstacles)
    {
        GameObject temp = Instantiate(groundTile, nextTilePosition, Quaternion.identity);
        nextTilePosition = temp.transform.GetChild(1).transform.position;

        if (hasObstacles)
        {
            // Set isScored to true on temp
            temp.GetComponent<GroundTile>().isScored = true;

            // // Set children of temp 2 through 12 inactive
            // for (int i = 2; i < 13; i++)
            // {
            //     temp.transform.GetChild(i).gameObject.SetActive(false);
            // }

            List<GameObject> tempObstacles = new List<GameObject>();


            while (tempObstacles.Count < GameManager.instance.numberOfObstacles)
            {
                // Generate random int between 2 and 12
                int randomObstacle = Random.Range(2, 12);
                // get child of temp at randomObstacle index
                GameObject obstacle = temp.transform.GetChild(randomObstacle).gameObject;
                // If obstacle does not exist in tempObstacles
                if (!tempObstacles.Contains(obstacle))
                {
                    // Add obstacle to tempObstacles
                    tempObstacles.Add(obstacle);
                    // Set obstacle to active
                    obstacle.SetActive(true);

                    // Generate int between 1 and 3
                    int randomObstacleSize = Random.Range(1, 4);

                    switch (randomObstacleSize)
                    {
                        case 1: // Small
                            obstacle.transform.localPosition = new Vector3(obstacle.transform.localPosition.x, -0.5f, obstacle.transform.localPosition.z);
                            break;

                        case 2: // Medium
                            obstacle.transform.localPosition = new Vector3(obstacle.transform.localPosition.x, 0, obstacle.transform.localPosition.z);
                            break;

                        case 3: // Large
                            obstacle.transform.localPosition = new Vector3(obstacle.transform.localPosition.x, 0.5f, obstacle.transform.localPosition.z);
                            break;

                    }

                    // Set the local y position to random float between -0.5 and 1
                    // obstacle.transform.localPosition = new Vector3(obstacle.transform.localPosition.x, Random.Range(-0.5f, 1.5f), 0);
                }
            }

        }


    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {

            SpawnTile(false);
        }


    }
}