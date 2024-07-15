using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLuna : CharacterBase
{
    [SerializeField]
    private GameObject lunaSprite;
    private string[] dialogesDay1 = {
        "Hi how is your day",
        "Yes you i'm talking to you ...",
        "Wow you don't know me?"
    };

    private string[] drinkList ={
        "Rum",
        "Vodka",
        "Brandy"
    };
    
    private bool choice1;

    public void showLuna(){
        Instantiate(lunaSprite);
    }

    public void DestroyLuna()
    {
        Destroy(gameObject);
    }

    public override string[] GetDialogues()
    {
        return this.dialogesDay1;
    }
}
