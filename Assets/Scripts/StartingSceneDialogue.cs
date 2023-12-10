using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains and runs the dialogue that plays at the beginning of the first level
public class StartingSceneDialogue : MonoBehaviour
{

    //Introduction Dialogue (Part 2)
    static DialogueManager.DialogueState begin2 =
        new DialogueManager.DialogueState("Distress signal?", "All our equipment is outfitted with one that triggers if it experiences enough damage. " +
            "Are you one of the hikers that left earlier? You missed your return time! Where are you?",
            new DialogueManager.DialogueState("I… don't know. I rented some equipment to go on a hike. " +
                "I think I fell in a cave.", "Oh dear. Okay. Well, can you take stock for me?",
                new DialogueManager.DialogueState("I'm fine, just a little banged up. What is this place?",
                    "You’ve probably fallen into one of the natural caves here. I'll help you look for a way out.",
                    new DialogueManager.DialogueState("It's so dark....",
                        "You should have a flashlight in that pack of yours.",
                        new DialogueManager.DialogueState("I think I lost it when I fell. Hold on."),
                        VoiceLines.globVoiceLines[5] // corresponding voice line
                    ),
                    VoiceLines.globVoiceLines[4] // corresponding voice line
                ),
                VoiceLines.globVoiceLines[3] // corresponding voice line
            ),
            VoiceLines.globVoiceLines[2] // corresponding voice line
        );

    //Introduction Dialogue (Part 1)
    static DialogueManager.DialogueState begin =
        new DialogueManager.DialogueState("N/A", "Hello? Hello? Is anyone there? If you can hear me, please respond!",
            new DialogueManager.DialogueState("Hello?", "Oh thank god, I saw the distress single and " +
                "I thought someone DIED!",
                begin2,
                VoiceLines.globVoiceLines[1] // corresponding voice line
            ),
            new DialogueManager.DialogueState("I'm here.", "Oh thank god, I saw the distress single and " +
                "I thought someone DIED!",
                begin2,
                VoiceLines.globVoiceLines[1] // corresponding voice line
            ),
            new DialogueManager.DialogueState("Who is this?", "Oh thank god, I saw the distress single and " +
                "I thought someone DIED!",
                begin2,
                VoiceLines.globVoiceLines[1] // corresponding voice line
            ),
            VoiceLines.globVoiceLines[0] // corresponding voice line
        );

    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.currentDialogueManager.SetDialogueState(begin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
