using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public bool isScored = false;


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GroundSpawner.instance.SpawnTile(true);

            if (isScored)
            {


                GameManager.instance.AddScore(GameManager.instance.numberOfObstacles * GameManager.instance.scorePerObstacle + (int)GameManager.instance.playerSpeed);

                CanvasManager.instance.UpdateScore();

            }
            Destroy(gameObject, 2f);
        }
    }


}
