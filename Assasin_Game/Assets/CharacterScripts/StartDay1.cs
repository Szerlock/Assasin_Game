using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartDay1 : MonoBehaviour
{
    [SerializeField]
    private DialogeManager dialogeManager;
    public ScriptLuna luna;
    private GameObject drinkMakingCanvas;
    [SerializeField] 
    private int targetDialogueIndex = 1; 
    [SerializeField]
    private CanvasManager canvasManager;

    void Start()
    {
        luna.showLuna();
        if (canvasManager != null && canvasManager.newCanvas != null)
        {
            canvasManager.newCanvas.SetActive(false);
        }
    }

    void Update()
    {
        if(dialogeManager.getDialogueIndex() == targetDialogueIndex){
            ShowNewCanvas();
        }
    }

    private void ShowNewCanvas()
    {
        canvasManager.ShowNewCanvas();
    }
}
