using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class DialogeManager : MonoBehaviour
{
    [SerializeField]
     private TMPro.TMP_Text dialogueText; 
    [SerializeField] 
    private Button dialogueButton;

    private int currentDialogeIndex = 0;
    private string[] currentDialoges;

    private CharacterBase currentCharacter;

    private bool isDialogeActive = true;

    void Start()
    {
        StartCoroutine(InitializeDialogueManager()); 
    }

    private IEnumerator  InitializeDialogueManager()
    {
        while (currentCharacter == null)
        {
            GameObject character = GameObject.FindGameObjectWithTag("Character");
            if (character != null)
            {
                currentCharacter = character.GetComponent<CharacterBase>();
            }
            yield return null;
        }
        currentDialoges = currentCharacter.GetDialogues();
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

    public void SetCharacter(CharacterBase character)
    {
        currentCharacter = character;
        currentDialoges = currentCharacter.GetDialogues();
        currentDialogeIndex = 0;
        ShowDialogue();
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
        if (currentDialogeIndex < currentDialoges.Length)
        {
            ShowDialogue();
        }
        else
        {
            isDialogeActive = false;
            currentCharacter.HideCharacter();
        }
    }

    public int getDialogueIndex(){
        return currentDialogeIndex;
    }
 
}
