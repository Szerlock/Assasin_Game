using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Canvas mainCanvas;
    public GameObject newCanvas;

    private GameObject newCanvasInstance;
    private Canvas newCanvasComponent;

    public void ShowNewCanvas()
    {
        mainCanvas.enabled = false;
        mainCanvas.GetComponent<GraphicRaycaster>().enabled = false;


        if (newCanvasInstance == null)
        {
            newCanvasInstance = Instantiate(newCanvas);
            newCanvasComponent = newCanvasInstance.GetComponent<Canvas>();
        }

        newCanvasInstance.SetActive(true);
        newCanvasComponent.enabled = true;
        newCanvasInstance.GetComponent<GraphicRaycaster>().enabled = true;

    }

    public void ShowMainCanvas()
    {
        if (newCanvasInstance != null)
        {
            newCanvasInstance.SetActive(false);
            newCanvasComponent.enabled = false;
            newCanvasInstance.GetComponent<GraphicRaycaster>().enabled = false;
        }

        mainCanvas.enabled = true;
        mainCanvas.GetComponent<GraphicRaycaster>().enabled = true;
    }
}
