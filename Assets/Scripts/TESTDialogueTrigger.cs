using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTDialogueTrigger : MonoBehaviour
{

    static DialogueManager.DialogueState begin2 =
        new DialogueManager.DialogueState("Distress signal?", "All our equipment is outfitted with one if it experiences enough damage. " +
            "Are you one of the hikers that left earlier? You missed your return time! Where are you?");

    static DialogueManager.DialogueState begin =
        new DialogueManager.DialogueState("N/A", "Hello? Hello? Is anyone there? If you can hear me, please respond!",
            new DialogueManager.DialogueState("Hello?", "Oh thank god, I saw the distress single and " +
                "I thought someone DIED!",
                begin2),
            new DialogueManager.DialogueState("I'm here.", "Oh thank god, I saw the distress single and " +
                "I thought someone DIED!",
                begin2),
            new DialogueManager.DialogueState("Who is this?", "Oh thank god, I saw the distress single and " +
                "I thought someone DIED!",
                begin2)
        );

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // if the object that has triggered it is the player
        {
            DialogueManager.currentDialogueManager.SetDialogueState(begin);
        }
    }
}
