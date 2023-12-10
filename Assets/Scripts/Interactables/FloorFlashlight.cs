using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A flashlight on the floor at the start of the game. Disables the player's flashlight until they pick it up by
// clicking on it
public class FloorFlashlight : Interactable
{
    [SerializeField] private GameObject playerFlashLight; // the player's flashlight, hidden until they "pick up" this one

    //Flashlight Gotten Dialogue (Part 1)
    static DialogueManager.DialogueState flashlightDialogue =
        new DialogueManager.DialogueState("N/A", "",
            new DialogueManager.DialogueState("Found it.", "Great, let's get out of here.",
                VoiceLines.globVoiceLines[6]
                )
        );

    private void Start()
    {
        promptText = "Click to pick up flashlight";
        playerFlashLight.SetActive(false);
    }

    override public void Interact(CharacterMotor charMotor)
    {
        playerFlashLight.SetActive(true); // activates the player flashlight because they've "picked it up"
        DialogueManager.currentDialogueManager.SetDialogueState(flashlightDialogue); // starts the dialogue for picking up the flashlight
        PlayerCursor.DeselectObj(); // makes the player cursor deselect this object
        gameObject.SetActive(false); // sets this game object to inactive because the player has "picked it up"
    }
}
