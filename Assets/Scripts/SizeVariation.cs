using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeVariation : MonoBehaviour
{

    public float minSize = 0.5f;
    public float maxSize = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Randomly change the size of the object
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, randomSize);
    }

}
