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

   // [SerializeField]
    //private Button[] ingredientButtons = new Button[5];
    private List<string> currentIngredients = new List<string>();

    private List<string> requiredIngredients = new List<string>();

     void Start()
    {
        requiredIngredients.Add("Rum");
                requiredIngredients.Add("Vodka");

        requiredIngredients.Add("Brandy");


        // foreach (Button button in ingredientButtons)
        // {
        //     if (button != null)
        //     {
        //         string ingredientTag = button.tag;
        //         button.onClick.AddListener(() => OnButtonClick(ingredientTag));
        //         Debug.Log("Setting up button: " + button.name + " with tag: " + button.tag);
        //     }
        //     else
        //     {   
        //         Debug.LogWarning("Button is null in ingredientButtons array");
        //     }
        //     if (button.interactable)
        //         {
        //             Debug.Log("Button " + button.name + " is interactable.");
        //         }
        //         else
        //         {
        //             Debug.LogWarning("Button " + button.name + " is not interactable.");
        //         }
        // }
        // ingredientButtons = newCanvas.GetComponentsInChildren<Button>();

        // foreach (Button button in ingredientButtons)
        // {
        //     button.onClick.AddListener(() => OnButtonClick(button.tag));
        // }
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
            Debug.Log("Setting up button: " + button.name + " with tag: " + button.tag);
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

            Debug.Log("mainCanvas enabled: " + mainCanvas.enabled);
        Debug.Log("mainCanvas GraphicRaycaster enabled: " + mainCanvas.GetComponent<GraphicRaycaster>().enabled);
        }

        mainCanvas.enabled = true;
        mainCanvas.GetComponent<GraphicRaycaster>().enabled = true;
    }

    public void OnButtonClick(string ingredient){
                Debug.Log("Button clicked: " + ingredient);
        
         AddIngredient(ingredient);
         if(currentIngredients.Count == 3){
            CheckDrink();
        }
    }

    public void AddIngredient(string ingredient){
        if (currentIngredients.Count < 3)
        {
            currentIngredients.Add(ingredient);
            Debug.Log("Added ingredient: " + ingredient);
        }
        else
        {
            messageText.text = "The drink is already full.";
            Debug.Log("The drink is already full.");
        }
    }

    public bool CheckDrink(){
        for(int i = 0; i <requiredIngredients.Count - 1; i++){
            if(currentIngredients[i] != requiredIngredients[i]){
                messageText.text = "The drink is incorrect";
                Debug.Log("The drink is incorrect");
                return false;
            }
        }

        messageText.text = "correct!";
        Debug.Log("The drink is correct!");
        ShowMainCanvas();
        return true;
    }

    public void ResetDrink()
    {
        currentIngredients.Clear();
        messageText.text = "";
        Debug.Log("Drink reset.");
    }
}
