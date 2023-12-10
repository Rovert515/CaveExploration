using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMonDialogue : ShadowMonMove
{
    //After scaring away shadow dialogue
    static DialogueManager.DialogueState scaredShadowDialogue1 =
        new DialogueManager.DialogueState("N/A", "",
            new DialogueManager.DialogueState("That... worked...", "",
                new DialogueManager.DialogueState("What *was* that?!", "What was what?",
                    new DialogueManager.DialogueState("The shadow monster!", "...",
                        new DialogueManager.DialogueState("I'm not crazy.", "I didn't say anything.",
                            new DialogueManager.DialogueState("Seriously, there was a shadow creature or monster or something!", 
                                "Okay okay. I mean, look I don't... not believe you?",
                                new DialogueManager.DialogueState("Really sounds like you do... uh don't.", 
                                    "I believe you saw something that was scared away by the flashlight. " + 
                                    "But it probably wasn't a shadow monster.",
                                    new DialogueManager.DialogueState("Still not sure how I feel about there being something down here with me.", 
                                        "Can't help you there. Just keep scaring whatever it is away.",
                                        new DialogueManager.DialogueState("[sarcastic] My hero."),
                                        VoiceLines.globVoiceLines[24] // corresponding voice line
                                    ),
                                    VoiceLines.globVoiceLines[23] // corresponding voice line
                                ),
                                VoiceLines.globVoiceLines[22] // corresponding voice line
                            ),
                            new DialogueManager.DialogueState("Maybe I did hit my head...", 
                                "There should be a first aid kit somewhere in that bag.",
                                new DialogueManager.DialogueState("None that I can see.", "Maybe you also lost it in the fall.",
                                    new DialogueManager.DialogueState("[quietly] Or maybe those shadows took it.", 
                                        "I didn't quite catch that.",
                                        new DialogueManager.DialogueState("Nothing nothing, I'll keep an eye out for it."),
                                        VoiceLines.globVoiceLines[27] // corresponding voice line
                                    ),
                                    VoiceLines.globVoiceLines[26] // corresponding voice line
                                ),
                                VoiceLines.globVoiceLines[25] // corresponding voice line
                            ),
                            new DialogueManager.DialogueState("[say nothing]"),
                            VoiceLines.globVoiceLines[21] // corresponding voice line
                        )
                    ),
                    VoiceLines.globVoiceLines[20] // corresponding voice line
                )
            )
        );

    public override void Illuminated()
    {
        base.Illuminated();
        StartCoroutine(DialogueDelay());
    }

    IEnumerator DialogueDelay()
    {
        yield return new WaitForSeconds(delay * 0.9f);
        DialogueManager.currentDialogueManager.SetDialogueState(scaredShadowDialogue1);
    }

}
