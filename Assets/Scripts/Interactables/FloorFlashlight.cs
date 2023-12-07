using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFlashlight : Interactable
{
    [SerializeField] private GameObject playerFlashLight; // the player's flashlight, hidden until they "pick up" this one

    private void Start()
    {
        promptText = "Click to pick up flashlight";
        playerFlashLight.SetActive(false);
    }

    override public void Interact(CharacterMotor charMotor)
    {
        playerFlashLight.SetActive(true); // activates the player flashlight because they've "picked it up"
        //DialogueManager.currentDialogueManager.SetDialogueState(SOMETHING); // starts the dialogue for picking up the flashlight
        PlayerCursor.DeselectObj(); // makes the player cursor deselect this object
        gameObject.SetActive(false); // sets this game object to inactive because the player has "picked it up"
    }
}
