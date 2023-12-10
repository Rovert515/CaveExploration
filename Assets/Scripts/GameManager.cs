using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameManager, monitors the player's dialogue key inputs
public class GameManager : MonoBehaviour
{
    void Update()
    {
        CheckForDialogueKeys();
    }

    private static void CheckForDialogueKeys() // Check for key presses that choose next dialogue option
    {
        if (DialogueManager.currentDialogueManager.currentDialogueState != null) // only does it if there's an active convo
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) // 
            {
                if (DialogueManager.currentDialogueManager.currentDialogueState.GetFollowup(DialogueManager.OptionChoice.Select0) != null)
                // if the current dialogue state has an option in the first option slot
                {
                    DialogueManager.currentDialogueManager.SetDialogueState( // move the dialogue state to the one in the first option slot
                        DialogueManager.currentDialogueManager.currentDialogueState.GetFollowup(DialogueManager.OptionChoice.Select0));
                }
                else // if there's nothing in the first slot, that means there are no follow ups whatsoever, so this should be just the
                     // "Continue" that ends trees. Thus, end the convo by wiping the dialogue state
                {
                    DialogueManager.currentDialogueManager.WipeDialogueState();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) // 
            {
                if (DialogueManager.currentDialogueManager.currentDialogueState.GetFollowup(DialogueManager.OptionChoice.Select1) != null)
                // if the current dialogue state has an option in the second option slot
                {
                    DialogueManager.currentDialogueManager.SetDialogueState( // move the dialogue state to the one in the second option slot
                        DialogueManager.currentDialogueManager.currentDialogueState.GetFollowup(DialogueManager.OptionChoice.Select1));
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) // 
            {
                if (DialogueManager.currentDialogueManager.currentDialogueState.GetFollowup(DialogueManager.OptionChoice.Select2) != null)
                // if the current dialogue state has an option in the third dialogue slot
                {
                    DialogueManager.currentDialogueManager.SetDialogueState( // move the dialogue state to the one in the third option slot
                        DialogueManager.currentDialogueManager.currentDialogueState.GetFollowup(DialogueManager.OptionChoice.Select2));
                }
            }
        }
    }
}
