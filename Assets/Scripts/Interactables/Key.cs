using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A Key that locks a connected door until the player "Picks it up" by clicking on it
public class Key : Interactable
{
    [SerializeField] private Door door; // the door that the key unlocks

    public bool pickedUp = false; // determines whether or not it has been picked up (so that illuminating glowy rocks, which would normally
                                  // enable it, cannot enable it if it's been picked up)

    //After solving the second puzzle
    static DialogueManager.DialogueState solvedPuzzle2Dialogue =
        new DialogueManager.DialogueState("N/A", "",
            new DialogueManager.DialogueState("Got it!", "Awesome, you're almost out of there!"),
            VoiceLines.globVoiceLines[40] // corresponding voice line
        );

    void Awake()
    {
        promptText = "Click to pick up key";

        door.Lock();
    }

    public override void Interact(CharacterMotor charMotor)
    {
        door.Unlock();
        pickedUp = true;
        PlayerCursor.DeselectObj(); // makes the player cursor deselect this object
        gameObject.SetActive(false);
        DialogueManager.currentDialogueManager.SetDialogueState(solvedPuzzle2Dialogue);
    }
}
