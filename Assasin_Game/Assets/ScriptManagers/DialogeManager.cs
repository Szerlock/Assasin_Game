using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogeManager : MonoBehaviour
{
    [SerializeField]
     private TMPro.TMP_Text dialogueText; 
    [SerializeField] 
    private Button dialogueButton;

    private int currentDialogeIndex = 0;
    private string[] currentDialoges;

    private bool isDialogeActive = true;

    void Start()
    {
        StartCoroutine(InitializeDialogueManager()); 
    }

    private IEnumerator  InitializeDialogueManager()
    {
        GameObject character = null;
        while (character == null)
        {
            character = GameObject.FindGameObjectWithTag("Character");
            yield return null;
        }
        var characterScript = character.GetComponent<CharacterBase>();
        currentDialoges = characterScript.GetDialogues();
        ShowDialogue();
        dialogueButton.onClick.AddListener(OnDialogueButtonClicked);
    }

    private void ShowDialogue()
    {
        if(dialogueText != null && isDialogeActive){
            if(currentDialogeIndex < currentDialoges.Length){
                dialogueText.text = currentDialoges[currentDialogeIndex];
            }
        }
    }

    public void PauseDialogue(){
        isDialogeActive = false;

    }

    public void ResumeDialogue(){
        isDialogeActive = true;
        ShowDialogue();
    }

    private void OnDialogueButtonClicked()
    {
        currentDialogeIndex++;
        ShowDialogue();
    }

    public int getDialogueIndex(){
        return currentDialogeIndex;
    }

    

    
}
