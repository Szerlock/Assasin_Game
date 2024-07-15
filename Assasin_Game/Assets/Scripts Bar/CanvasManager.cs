using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Canvas mainCanvas;
    public GameObject newCanvas;

    private GameObject newCanvasInstance;
    private Canvas newCanvasComponent;
    
    private TMP_Text messageText;


    private List<string> currentIngredients = new List<string>();
    private List<string> requiredIngredients = new List<string>();

    public void SetRequiredIngredients(List<string> ingredients)
    {
        requiredIngredients = ingredients;
        ResetDrink();
    }

    void SetupIngredientButtons()
    {
        Button[] buttons = newCanvasInstance.GetComponentsInChildren<Button>();
        TMP_Text[] tmpTexts = newCanvasInstance.GetComponentsInChildren<TMP_Text>();
        foreach (TMP_Text tmpText in tmpTexts)
        {
        if (tmpText.gameObject.CompareTag("Drink")) 
        {
            messageText = tmpText;
            break; 
        }
        }
        foreach (Button button in buttons)
        {
            string ingredientTag = button.tag;
            button.onClick.AddListener(() => OnButtonClick(ingredientTag));
        }

        
    }

    public void ShowNewCanvas()
    {
        mainCanvas.enabled = false;
        mainCanvas.GetComponent<GraphicRaycaster>().enabled = false;


        if (newCanvasInstance == null)
        {
            newCanvasInstance = Instantiate(newCanvas);
            newCanvasComponent = newCanvasInstance.GetComponent<Canvas>();
            SetupIngredientButtons();

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

    public void OnButtonClick(string ingredient){
        
         AddIngredient(ingredient);
         if(currentIngredients.Count == 3){
            CheckDrink();
        }
    }

    public void AddIngredient(string ingredient){
        if (currentIngredients.Count < 3)
        {
            currentIngredients.Add(ingredient);
        }
        else
        {
            messageText.text = "The drink is already full.";
        }
    }

    public bool CheckDrink(){
        for(int i = 0; i <requiredIngredients.Count; i++){
            if(currentIngredients[i] != requiredIngredients[i]){
                messageText.text = "The drink is incorrect";
                return false;
            }
        }

        messageText.text = "correct!";
        return true;
    }

    public void ResetDrink()
    {
        currentIngredients.Clear();
        messageText.text = "";
    }

    public int GetCurrentIngredientsCount()
    {
        return currentIngredients.Count;
    }
}
