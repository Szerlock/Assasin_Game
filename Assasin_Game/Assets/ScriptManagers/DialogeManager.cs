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
        if(currentDialogeIndex < currentDialoges.Length){
            dialogueText.text = currentDialoges[currentDialogeIndex];
        }
    }

    private void OnDialogueButtonClicked()
    {
        currentDialogeIndex++;
        ShowDialogue();
    }

    

    
}
