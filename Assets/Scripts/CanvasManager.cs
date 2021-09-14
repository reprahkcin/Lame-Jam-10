using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    // Singleton
    public static CanvasManager instance;

    // --------------------------------------------------
    // GameObjects
    // --------------------------------------------------

    // Blackout Canvas
    public GameObject blackoutCanvas;

    // Canvases
    public GameObject[] canvases;

    // --------------------------------------------------
    // Variables
    // --------------------------------------------------

    // Current Canvas Index
    private int currentCanvasIndex = 0;

    // --------------------------------------------------
    // Methods
    // --------------------------------------------------

    public void FadeToBlack()
    {
        StartCoroutine(FadeToBlackCoroutine());
    }

    public void FadeFromBlack()
    {
        StartCoroutine(FadeFromBlackCoroutine());
    }

    IEnumerator FadeToBlackCoroutine()
    {
        blackoutCanvas.SetActive(true);
        Image image = blackoutCanvas.GetComponent<Image>();
        Color color = image.color;
        color.a = 0;
        image.color = color;
        while (color.a < 1)
        {
            color.a += 0.05f;
            image.color = color;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FadeFromBlackCoroutine()
    {
        Image image = blackoutCanvas.GetComponent<Image>();
        Color color = image.color;
        color.a = 1;
        image.color = color;
        while (color.a > 0)
        {
            color.a -= 0.05f;
            image.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        blackoutCanvas.SetActive(false);
    }

    // --------------------------------------------------
    // Transport controls
    // --------------------------------------------------

    // Next Canvas
    public void NextCanvas()
    {
        // Turn off all canvases
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].SetActive(false);
        }

        // Turn on current canvas + 1
        currentCanvasIndex++;
        if (currentCanvasIndex >= canvases.Length)
        {
            currentCanvasIndex = 0;
        }
        canvases[currentCanvasIndex].SetActive(true);
    }

    // Previous Canvas
    public void PreviousCanvas()
    {
        // Turn off all canvases
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].SetActive(false);
        }

        // Turn on current canvas - 1
        currentCanvasIndex--;
        if (currentCanvasIndex < 0)
        {
            currentCanvasIndex = canvases.Length - 1;
        }
        canvases[currentCanvasIndex].SetActive(true);
    }

    // Set Canvas
    public void SetCanvas(int index)
    {
        // Turn off all canvases
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].SetActive(false);
        }

        // Turn on current canvas
        currentCanvasIndex = index;
        canvases[currentCanvasIndex].SetActive(true);
    }

    // --------------------------------------------------
    // Unity Lifecycle
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

}
