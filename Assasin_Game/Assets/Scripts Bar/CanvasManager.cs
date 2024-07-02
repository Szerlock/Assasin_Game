using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Canvas previousCanvas;
    public GameObject newCanvas;

    public void ShowNewCanvas()
    {
        previousCanvas.enabled = false;
        previousCanvas.GetComponent<GraphicRaycaster>().enabled = false;

        newCanvas.SetActive(true);
    }

    public void ShowPreviousCanvas()
    {
        newCanvas.SetActive(false);
        previousCanvas.enabled = true;
        previousCanvas.GetComponent<GraphicRaycaster>().enabled = true;
    }
}
