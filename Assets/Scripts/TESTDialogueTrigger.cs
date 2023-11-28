using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTDialogueTrigger : MonoBehaviour
{
    DialogueManager.DialogueState tree =
        new DialogueManager.DialogueState("N/A", "Hello, hello, testing testing. Do you read me?",
            new DialogueManager.DialogueState("Oooh, a button", "Congratulations, you clicked a button!"),
            new DialogueManager.DialogueState("I'm in a test aren't I", "Yes you are and there's no escape",
                new DialogueManager.DialogueState("NOOOOOOOOO", "Suffer and perish"),
                new DialogueManager.DialogueState("Does that mean god is real", "Sure, little .txt, sure")
            ),
            new DialogueManager.DialogueState("So, come here often?", "Yes, you wouldn't believe how long this code took to write")
        );

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // if the object that has triggered it is the player
        {
            DialogueManager.currentDialogueManager.SetDialogueState(tree);
        }
    }
}
