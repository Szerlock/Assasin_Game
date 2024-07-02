using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCharacterClass
{
    private string[] dialoges;

    public AbstractCharacterClass(string[] dialoges){
        this.dialoges = dialoges;
    }
}
