using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorVariation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Get current color
        Color currentColor = GetComponent<Renderer>().material.color;

        // generate random number between 0.25 and 0.5
        float randomNumber = Random.Range(0f, 0.75f);

        currentColor = new Color(currentColor.r, currentColor.g - randomNumber, currentColor.b);

        // set new color
        GetComponent<Renderer>().material.color = currentColor;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
