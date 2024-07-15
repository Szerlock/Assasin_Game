using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartDay1 : MonoBehaviour
{
    [SerializeField]
    private DialogeManager dialogeManager;
    [SerializeField]
    private ScriptLuna luna;

    //private GameObject drinkMakingCanvas;
    private List<CharacterBase> characters = new List<CharacterBase>();

    [SerializeField] 
    private int targetDialogueIndex = 1; 
    [SerializeField]
    private CanvasManager canvasManager;

    private int currentCharacterIndex = 0;

    private int currentDay = 1;

    void Start()
    {
        characters.Add(luna);
        luna.showLuna();

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
            if(canvasManager.CheckDrink() == true){
                canvasManager.ShowMainCanvas();
            }
        }
    }

    private void ShowNewCanvas()
    {
        canvasManager.ShowNewCanvas();
    }

    public void nextChar(){
        if(dialogeManager.getDialogueIndex() == dialogeManager.size() - 1){
            characters[currentCharacterIndex].HideCharacter();
            currentCharacterIndex++;

            //More characters to show
            if (currentCharacterIndex < characters.Count)
        {
            // Show the next character
            characters[currentCharacterIndex].ShowCharacter();

            // Set the new character for the dialogue manager
            dialogeManager.SetCharacter(characters[currentCharacterIndex]);

            // Update the required ingredients for the new character
            List<string> characterIngredients = characters[currentCharacterIndex].GetRequiredIngredients(currentDay);
            canvasManager.SetRequiredIngredients(characterIngredients);

            // Restart the dialogue for the new character
            dialogeManager.ResetDialogue();
        }

        }
        else{
            Debug.Log("Not yet");
        }
    }
}
