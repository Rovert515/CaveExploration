using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stores the dialogue that plays when the player interacts with any of the area based dialogue triggers in the levels
public class Dialogue_Repository : MonoBehaviour
{

    //First Hallway Dialogue (Part 1)
    static DialogueManager.DialogueState hallway1Dialogue =
        new DialogueManager.DialogueState("N/A", "",
            new DialogueManager.DialogueState("It's so dark in here. Even with the flashlight.", 
                "Yeah well, caves at night are like that.", 
                new DialogueManager.DialogueState("What time is it out there?", "A little past midnight.",
                    new DialogueManager.DialogueState ("Oh, sorry to keep you up so late.", 
                        "Hey don't worry, I'm just gonna get one hell of an overtime check.", 
                        new DialogueManager.DialogueState("Don't you have to get home?",
                            "Nah, got a bed here and everything.",
                            new DialogueManager.DialogueState("Sounds lonely.", "It's not so bad. I like the quiet.",
                                new DialogueManager.DialogueState("Hm.", 
                                    "And I get strangers like you keeping me up at all odds hours. " + 
                                    "Dumbass hikers who don't understand what a return time is.",
                                    new DialogueManager.DialogueState("And here I thought I was special.", 
                                        "Nah you're a dime a dozen.",
                                        new DialogueManager.DialogueState("[sarcastic] I'm hurt."),
                                        VoiceLines.globVoiceLines[13] // corresponding voice line
                                    ),
                                    VoiceLines.globVoiceLines[12] // corresponding voice line
                                ),
                                VoiceLines.globVoiceLines[11] // corresponding voice line
                            ),
                            VoiceLines.globVoiceLines[10] // corresponding voice line
                        ),
                        new DialogueManager.DialogueState("Well, hopefully I'll get out soon.", 
                            "The caves around here usually aren't that complicated, " + 
                            "most of them are just a bunch of straight lines.",
                            new DialogueManager.DialogueState("I don't know a lot about caves, but that sounds strange.", 
                                "Not really, these caves were formed thousands of years ago by lava flow.", 
                                new DialogueManager.DialogueState("I'm not at risk of death by fire right? " + 
                                    "Cause that sounds like a horrible way to go.", 
                                    "Nah, the mountain is a looooong dormant volcano - completely dead.",
                                    new DialogueManager.DialogueState("Unlike me, I hope."),
                                    VoiceLines.globVoiceLines[16] // corresponding voice line
                                ),
                                VoiceLines.globVoiceLines[15] // corresponding voice line
                            ),
                            VoiceLines.globVoiceLines[14] // corresponding voice line
                        ),
                        VoiceLines.globVoiceLines[9] // corresponding voice line
                    ),
                    VoiceLines.globVoiceLines[8] // corresponding voice line
                ),
                VoiceLines.globVoiceLines[7] // corresponding voice line
            )
        );

    //Arriving at the first puzzle room dialogue
    static DialogueManager.DialogueState puzzleRoom1Dialogue =
        new DialogueManager.DialogueState("N/A", "Okay, there should be a door to the rest of the cave system around here.",
            new DialogueManager.DialogueState("Alright yeah, I see the door- shit.", "What?",
                new DialogueManager.DialogueState("The lever-pulley-thing is broken.", 
                    "Damn, well see if you can fix it. It's your only way out of here.",
                    new DialogueManager.DialogueState("Maybe I can weigh it down with something..."),
                    VoiceLines.globVoiceLines[30] // corresponding voice line
                ),
                VoiceLines.globVoiceLines[29] // corresponding voice line
            ),
            VoiceLines.globVoiceLines[28] // corresponding voice line
        );

    //Walking down second tunnel hallway (Part 2)
    static DialogueManager.DialogueState hallway2DialoguePart2 =
        new DialogueManager.DialogueState("Yeah?", "Yeah. Like a forest that's been devastated by fire and is regrowing.", 
            new DialogueManager.DialogueState("...", "All the old trees are gone and new trees have begun to grow, " + 
                "but the charred and burned stumps remain.", 
                new DialogueManager.DialogueState("...", "There's new life growing, but the scars are still visible. You know?",
                    new DialogueManager.DialogueState("...yeah."),
                    VoiceLines.globVoiceLines[38] // corresponding voice line
                ),
                VoiceLines.globVoiceLines[37] // corresponding voice line
            ),
            VoiceLines.globVoiceLines[36] // corresponding voice line
        );

    //Walking down second tunnel hallway (Part 1)
    static DialogueManager.DialogueState hallway2Dialogue =
        new DialogueManager.DialogueState("N/A", "",
            new DialogueManager.DialogueState("I�m seeing a lot of support beams and stuff, what's that about?",
                "Oh um, I think there used to be some kind of mining operation here? Back when that was a thing people did. " +
                "It's abandoned now, obviously, but the mining tunnels remain.",
                new DialogueManager.DialogueState("It�s spooky.", "Remnant of another time, I guess.",
                    new DialogueManager.DialogueState("Feels haunted but like, in a mundane way, not a ghost way.", 
                        "Yeah, in what way?",
                        new DialogueManager.DialogueState("Like your childhood home after someone else has moved in.", "",
                            new DialogueManager.DialogueState("Your old bedroom is an office, the dining room is seated for " +
                                "4 instead of 5, the cabinets are all organized differently.", "",
                                new DialogueManager.DialogueState("The insides are different, but the bones are the same.",
                                    "I think I know what you mean.",
                                    hallway2DialoguePart2,
                                    VoiceLines.globVoiceLines[35] // corresponding voice line
                                )
                            )
                        ),
                        new DialogueManager.DialogueState("Like a convenience store that�s gone out of business.", "", 
                            new DialogueManager.DialogueState("The shelves are all unstocked and it's overrun with " + 
                                "cobwebs and rats.", "", 
                                new DialogueManager.DialogueState("But the fluorescent lights still hum and bathe the " + "" +
                                    "tiled floor with sickly yellow light.", "", 
                                    new DialogueManager.DialogueState("The food and drinks are gone, but the artificial " + 
                                        "remains.", "I think I know what you mean.", 
                                        hallway2DialoguePart2,
                                        VoiceLines.globVoiceLines[35] // corresponding voice line
                                    )
                                )
                            )
                        ),
                        new DialogueManager.DialogueState("Like an abandoned parking lot overgrown by plants.", "", 
                            new DialogueManager.DialogueState("The strict white lines of parking spaces are faded, " + 
                                "but still visible.", "", 
                                new DialogueManager.DialogueState("Pitch black asphalt is cracked with weeds, " + 
                                    "but it burns hot in the summer.", "", 
                                    new DialogueManager.DialogueState("The natural has reclaimed it, but only on the surface.", 
                                        "I think I know what you mean.", 
                                        hallway2DialoguePart2,
                                        VoiceLines.globVoiceLines[35] // corresponding voice line
                                    )
                                )
                            )
                        ),
                        VoiceLines.globVoiceLines[34] // corresponding voice line
                    ),
                    VoiceLines.globVoiceLines[33] // corresponding voice line
                ),
                VoiceLines.globVoiceLines[32] // corresponding voice line
            )
        );

    //Arrival at the second puzzle
    static DialogueManager.DialogueState puzzleRoom2Dialogue =
        new DialogueManager.DialogueState("N/A", "", 
            new DialogueManager.DialogueState("Alright, I'm at another small chamber, there's a lot of old mining gear " + 
                "and another door.", "It's locked I presume?", 
                new DialogueManager.DialogueState("Probably, I'll see if I can find some way to open it."),
                VoiceLines.globVoiceLines[39] // corresponding voice line
            )
        );

    //After scaring away multiple shadows in the third hallway
    static DialogueManager.DialogueState shadowDialogue =
        new DialogueManager.DialogueState("N/A", "",
            new DialogueManager.DialogueState("Believe me or don't, but there are definitely shadow monsters down here.",
                "...",
                new DialogueManager.DialogueState("...?", "...okay.",
                    new DialogueManager.DialogueState("Okay?", "Okay. Either you're crazy and I lose nothing from believing you.",
                        new DialogueManager.DialogueState("...", "OR you're telling the truth. And I'm not about to be the " +
                            "idiot in a horror movie who doesn't believe the victim.",
                            new DialogueManager.DialogueState("I'm not a victim.", "Not yet!",
                                new DialogueManager.DialogueState("...", "Too soon?",
                                    new DialogueManager.DialogueState("Yeah, just a little.", "Sorry.",
                                        new DialogueManager.DialogueState("...", "",
                                            new DialogueManager.DialogueState("Thanks for believing me, though.")
                                        ),
                                        VoiceLines.globVoiceLines[47] // corresponding voice line
                                    ),
                                    VoiceLines.globVoiceLines[46] // corresponding voice line
                                ),
                                VoiceLines.globVoiceLines[45] // corresponding voice line
                            ),
                            VoiceLines.globVoiceLines[44] // corresponding voice line
                        ),
                        VoiceLines.globVoiceLines[43] // corresponding voice line
                    ),
                    VoiceLines.globVoiceLines[42] // corresponding voice line
                ),
                VoiceLines.globVoiceLines[41] // corresponding voice line
            )
        );

    //Walking down third tunnel hallway
    static DialogueManager.DialogueState hallway3Dialogue =
        new DialogueManager.DialogueState("N/A", "", 
            new DialogueManager.DialogueState("So, I should be near the end here?", "Yeah. Hopefully.", 
                new DialogueManager.DialogueState("Hopefully? What do you mean by- shit.", "What's wrong?", 
                    new DialogueManager.DialogueState("There's no exit tunnel!! What do I do??", "Okay okay okay, call me crazy-", 
                        new DialogueManager.DialogueState("Shadow monsters are breathing down my neck, I can handle crazy.", 
                            "You need to cause an explosion.", 
                            new DialogueManager.DialogueState("...I stand corrected.", "I'm serious! It might be your only chance.", 
                                new DialogueManager.DialogueState("...", "", 
                                    new DialogueManager.DialogueState("Okay.", "",
                                        new DialogueManager.DialogueState("Let's do this.")
                                    )
                                ),
                                VoiceLines.globVoiceLines[52] // corresponding voice line
                            ),
                            VoiceLines.globVoiceLines[51] // corresponding voice line
                        ),
                        VoiceLines.globVoiceLines[50] // corresponding voice line
                    ),
                    VoiceLines.globVoiceLines[49] // corresponding voice line
                ),
                VoiceLines.globVoiceLines[48] // corresponding voice line
            )
        );

    //After the explosion and solving the third puzzle
    static DialogueManager.DialogueState finalDialogue =
        new DialogueManager.DialogueState("N/A", "", 
            new DialogueManager.DialogueState("...I did... it...", "[garbled]", 
                new DialogueManager.DialogueState("Hello...?", "[garbled]", 
                    new DialogueManager.DialogueState("I can't... understand you...", "", 
                        new DialogueManager.DialogueState("If you can... hear me...", "", 
                            new DialogueManager.DialogueState("Thank you..."), 
                            new DialogueManager.DialogueState("I'm sorry..."), 
                            new DialogueManager.DialogueState("Goodbye...")
                        )
                    ),
                    VoiceLines.globVoiceLines[54] // corresponding voice line
                ),
                VoiceLines.globVoiceLines[53] // corresponding voice line
            )
        );

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // if the object that has triggered it is the player
        {

            if (gameObject.tag == "Hallway1Dialogue") //if the object is the trigger for the hallway dialogue
            {
                DialogueManager.currentDialogueManager.SetDialogueState(hallway1Dialogue);
                gameObject.SetActive(false);
            }
            else if (gameObject.tag == "PuzzleRoom1Dialogue") //if the object is the trigger for the 1st puzzle room dialogue
            {
                DialogueManager.currentDialogueManager.SetDialogueState(puzzleRoom1Dialogue);
                gameObject.SetActive(false);
            }
            else if (gameObject.tag == "Hallway2Dialogue") //if the object is the trigger for the hallway dialogue
            {
                DialogueManager.currentDialogueManager.SetDialogueState(hallway2Dialogue);
                gameObject.SetActive(false);
            }
            else if (gameObject.tag == "PuzzleRoom2Dialogue") //if the object is the trigger for the 2nd puzzle room dialogue
            {
                DialogueManager.currentDialogueManager.SetDialogueState(puzzleRoom2Dialogue);
                gameObject.SetActive(false);
            }
            else if (gameObject.tag == "ShadowDialogue") //if the object is the trigger for the 2nd puzzle room dialogue
            {
                DialogueManager.currentDialogueManager.SetDialogueState(shadowDialogue);
                gameObject.SetActive(false);
            }
            else if (gameObject.tag == "Hallway3Dialogue") //if the object is the trigger for the hallway dialogue
            {
                DialogueManager.currentDialogueManager.SetDialogueState(hallway3Dialogue);
                gameObject.SetActive(false);
            }
        }
    }

    //Trigger for After Explosion Dialogue
    public static void AfterExplosionDialogueTrigger()
    {
        DialogueManager.currentDialogueManager.SetDialogueState(finalDialogue);
    }
    
}
