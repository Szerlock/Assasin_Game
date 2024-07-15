using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public abstract string[] GetDialogues();
    public virtual void ShowCharacter() { gameObject.SetActive(true); }
    public virtual void HideCharacter() { gameObject.SetActive(false); }
    public virtual void DestroyCharacter() { Destroy(gameObject); }

    public abstract List<string> GetRequiredIngredients(int day);
}
