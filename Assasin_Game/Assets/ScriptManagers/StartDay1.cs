using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartDay1 : MonoBehaviour
{
    [SerializeField]
    private DialogeManager dialogeManager;
    //public ScriptLuna luna;
    //private GameObject drinkMakingCanvas;
    private List<CharacterBase> characters = new List<CharacterBase>();

    [SerializeField] 
    private int targetDialogueIndex = 1; 
    [SerializeField]
    private CanvasManager canvasManager;

    private int currentCharacterIndex = 0;


    void Start()
    {
        characters.Add(new ScriptLuna());

        if (characters.Count > 0)
        {
            characters[currentCharacterIndex].ShowCharacter();
            dialogeManager.SetCharacter(characters[currentCharacterIndex]);
        }

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
        if(canvasManager.GetCurrentIngredientsCount() == 3){
            if(canvasManager.CheckDrink()){
                canvasManager.ShowMainCanvas();
            }
        }
    }

    private void ShowNewCanvas()
    {
        canvasManager.ShowNewCanvas();
    }
}
