using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected string promptText; // when the cursor hovers over this object, the player will see "Click to " followed by this text

    public string GetPromptText() // returns the prompt text, presumably to the prompt text box when the cursor hovers over this item
    {
        return promptText;
    }

    abstract public void Interact(CharacterMotor charMotor); // this will be run when the player clicks on the object while hovering over
        // it with the cursor, defines the function of the Interactable
}
