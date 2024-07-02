using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Canvas previousCanvas;
    public GameObject newCanvas;

    private Canvas newCanvasComponent;

    void Start()
    {
        if (newCanvas != null)
        {
            newCanvasComponent = newCanvas.GetComponent<Canvas>();
        }
    }

    public void ShowNewCanvas()
    {
        previousCanvas.enabled = false;
        previousCanvas.GetComponent<GraphicRaycaster>().enabled = false;

        newCanvas.SetActive(true);
        newCanvasComponent.enabled = true;
    }

    public void ShowPreviousCanvas()
    {
        newCanvas.SetActive(false);
        newCanvasComponent.enabled = false;

        previousCanvas.enabled = true;
        previousCanvas.GetComponent<GraphicRaycaster>().enabled = true;
    }
}
