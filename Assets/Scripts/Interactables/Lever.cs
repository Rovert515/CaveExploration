using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    [SerializeField] private Door door; // the door that this lever opens
    [SerializeField] private GameObject placedRock; // the rock that will "appear" on top of the lever when it's "placed" there
    [SerializeField] private GameObject leverPart; // the child object that is the actual cyllinder for the lever
    private static bool playerHasRock = false; // just a little thing for if the player has a rock they can use to push the lever

    //Solving the first puzzle room dialogue
    static DialogueManager.DialogueState solvedPuzzle1Dialogue =
        new DialogueManager.DialogueState("N/A", "",
            new DialogueManager.DialogueState("I did it!", "Great! Into the unknown!")
        );

    private void Awake()
    {
        promptText = "This lever is stuck.";
        if (door != null) // if it's connected to a door, make sure that door locks
        {
            Debug.Log("123");
            door.Lock();
        }
        if (placedRock != null)
        {
            placedRock.SetActive(false);
        }
    }

    public void PlayerGainRock() // run by a Liftable Rock when the player picks it up
    {
        playerHasRock = true;
        promptText = "Click to wedge rock into lever";
    }

    override public void Interact(CharacterMotor charMotor)
    {
        if (playerHasRock)
        {
            // when the player puts the rock on it (e.g. clicks the lever after interacting with the rock earlier

            door.Unlock(); // unlock attached door

            leverPart.transform.rotation = new Quaternion(30f, 0f, 0f, 0f); // have the rock "appear" and lever move
            placedRock.SetActive(true);
            playerHasRock = false;
            PlayerCursor.DeselectObj(); // makes the player cursor deselect this object
            promptText = "The lever has been flipped now";

            DialogueManager.currentDialogueManager.SetDialogueState(solvedPuzzle1Dialogue); //plays dialogue for solving puzzle
        }
    }
}
