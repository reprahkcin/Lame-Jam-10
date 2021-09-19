using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GroundSpawner.instance.SpawnTile();

            Destroy(gameObject, 2f);
        }
    }
}
