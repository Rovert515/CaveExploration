using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                                        new DialogueManager.DialogueState("[sarcastic] I'm hurt.")
                                    )
                                )
                            )
                        ),
                        new DialogueManager.DialogueState("Well, hopefully I'll get out soon.", 
                            "The caves around here usually aren't that complicated, " + 
                            "most of them are just a bunch of straight lines.",
                            new DialogueManager.DialogueState("I don't know a lot about caves, but that sounds strange.", 
                                "Not really, these caves were formed thousands of years ago by lava flow.", 
                                new DialogueManager.DialogueState("I'm not at risk of death by fire right? " + 
                                    "Cause that sounds like a horrible way to go.", 
                                    "Nah, the mountain is a looooong dormant volcano - completely dead.",
                                    new DialogueManager.DialogueState("Unlike me, I hope.")
                                )
                            )
                        )
                    )
                )
            )
        );

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
                                        new DialogueManager.DialogueState("[sarcastic] My hero.")
                                    )
                                )
                            ),
                            new DialogueManager.DialogueState("Maybe I did hit my head...", 
                                "There should be a first aid kit somewhere in that bag.",
                                new DialogueManager.DialogueState("None that I can see.", "Maybe you also lost it in the fall.",
                                    new DialogueManager.DialogueState("[quietly] Or maybe those shadows took it.", 
                                        "I didn't quite catch that.",
                                        new DialogueManager.DialogueState("Nothing nothing, I'll keep an eye out for it.")
                                    )
                                )
                            ),
                            new DialogueManager.DialogueState("[say nothing]")
                        )
                    )
                )
            )
        );

    //Arriving at the first puzzle room dialogue
    static DialogueManager.DialogueState puzzleRoom1Dialogue =
        new DialogueManager.DialogueState("N/A", "Okay, there should be a door to the rest of the cave system around here.",
            new DialogueManager.DialogueState("Alright yeah, I see the door- shit.", "What?",
                new DialogueManager.DialogueState("The lever-pulley-thing is broken.", 
                    "Damn, well see if you can fix it. It's your only way out of here.",
                    new DialogueManager.DialogueState("Maybe I can weigh it down with something...")
                )
            )
        );

    //Walking down second tunnel hallway (Part 2)
    static DialogueManager.DialogueState hallway2DialoguePart2 =
        new DialogueManager.DialogueState("Yeah?", "Yeah. Like a forest that's been devastated by fire and is regrowing.", 
            new DialogueManager.DialogueState("...", "All the old trees are gone and new trees have begun to grow, " + 
                "but the charred and burned stumps remain.", 
                new DialogueManager.DialogueState("...", "There's new life growing, but the scars are still visible. You know?",
                    new DialogueManager.DialogueState("...yeah.")
                )
            )
        );

    //Walking down second tunnel hallway (Part 1)
    static DialogueManager.DialogueState hallway2Dialogue =
        new DialogueManager.DialogueState("N/A", "",
            new DialogueManager.DialogueState("I’m seeing a lot of support beams and stuff, what's that about?",
                "Oh um, I think there used to be some mining operations here? Back when that was a thing people did. " +
                "It's abandoned now, obviously, but the mining tunnels remain.",
                new DialogueManager.DialogueState("It’s spooky.", "Remanant of another time, I guess.",
                    new DialogueManager.DialogueState("Feels haunted but like, in a mundane way, not a ghost way.", 
                        "In what way?",
                        new DialogueManager.DialogueState("Like your childhood home after someone else has moved in.", "",
                            new DialogueManager.DialogueState("Your old bedroom is an office, the dining room is seated for " +
                                "4 instead of 5, the cabinets are all organized differently.", "",
                                new DialogueManager.DialogueState("The insides are different, but the bones are the same.",
                                    "I think I know what you mean.",
                                    hallway2DialoguePart2
                                )
                            )
                        ),
                        new DialogueManager.DialogueState("Like a convenience store that’s gone out of business.", "", 
                            new DialogueManager.DialogueState("The shelves are all unstocked and it's overrun with " + 
                                "cobwebs and rats.", "", 
                                new DialogueManager.DialogueState("But the fluorescent lights still hum and bathe the " + "" +
                                    "tiled floor with sickly yellow light.", "", 
                                    new DialogueManager.DialogueState("The food and drinks are gone, but the artificial " + 
                                        "remains.", "I think I know what you mean.", 
                                        hallway2DialoguePart2
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
                                        hallway2DialoguePart2
                                    )
                                )
                            )
                        )
                    )
                )
            )
        );

    //After scaring away multiple shadows in the second hallway
    static DialogueManager.DialogueState scaredShadowDialogue2 =
        new DialogueManager.DialogueState("N/A", "", 
            new DialogueManager.DialogueState("Believe me or don't, but there are definitely shadow monsters down here.", 
                "...", 
                new DialogueManager.DialogueState("...?", "...okay.", 
                    new DialogueManager.DialogueState("Okay?", "Okay. Either you're crazy and I lose nothing from believing you.", 
                        new DialogueManager.DialogueState("...", "OR you're telling the truth. And I'm not about to be the " + 
                            "idiot in a horror movie who doesn't believe the victim.", 
                            new DialogueManager.DialogueState("I'm not a victim.", "Not yet!", 
                                new DialogueManager.DialogueState("...", "Too soon?", 
                                    new DialogueManager.DialogueState ("Yeah, just a little.", "Sorry.", 
                                        new DialogueManager.DialogueState ("...", "", 
                                            new DialogueManager.DialogueState("Thanks for believing me, though.")
                                        )
                                    )
                                )
                            )
                        )
                    )
                )
            )
        );

    //Arrival at the second puzzle
    static DialogueManager.DialogueState puzzleRoom2Dialogue =
        new DialogueManager.DialogueState("N/A", "", 
            new DialogueManager.DialogueState("Alright, I'm at another small chamber, there's a lot of old mining gear " + 
                "and another door.", "It's locked I presume?", 
                new DialogueManager.DialogueState("Probably, I'll see if I can find some way to open it.")
            )
        );

    //After solving the second puzzle
    static DialogueManager.DialogueState solvedPuzzle2Dialogue =
        new DialogueManager.DialogueState("N/A", "", 
            new DialogueManager.DialogueState("Got it!", "Awesome, you're almost out of there!")
        );

    //Walking down third tunnel hallway
    static DialogueManager.DialogueState hallway3Dialogue =
        new DialogueManager.DialogueState("N/A", "", 
            new DialogueManager.DialogueState("So, I should be near the end here?", "Yeah. Hopefully.", 
                new DialogueManager.DialogueState("Hopefully?", "Yeah.", 
                    new DialogueManager.DialogueState("...what do you mean by-")
                )
            )
        );

    //Shadows then begin to spawn in a large number, cutting off the previous dialogue
    static DialogueManager.DialogueState shadowHordeDialogue =
        new DialogueManager.DialogueState("N/A", "What's wrong?", 
            new DialogueManager.DialogueState("T-there's some shadow monsters.", "Well, scare them away!", 
                new DialogueManager.DialogueState("There's a lot!!", "Then run!!!")
            )
        );

    //Arrival in the third puzzle room
    static DialogueManager.DialogueState puzzleRoom3Dialogue =
        new DialogueManager.DialogueState("N/A", "", 
            new DialogueManager.DialogueState("There's no exit tunnel!! What do I do??", "Okay okay okay, call me crazy-", 
                new DialogueManager.DialogueState("Shadow monsters are breathing down my neck, I can handle crazy.", 
                    "You need to cause an explosion.", 
                    new DialogueManager.DialogueState("...I stand corrected.", "I'm serious! It might be your only chance.", 
                        new DialogueManager.DialogueState("...", "", 
                            new DialogueManager.DialogueState("Okay.", "",
                                new DialogueManager.DialogueState("Let's do this.")
                            )
                        )
                    )
                )
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
                    )
                )
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
                gameObject.SetActive(false); ;
            }
            else if (gameObject.tag == "Hallway2Dialogue") //if the object is the trigger for the hallway dialogue
            {
                DialogueManager.currentDialogueManager.SetDialogueState(hallway2Dialogue);
            }
            else if (gameObject.tag == "PuzzleRoom2Dialogue") //if the object is the trigger for the 2nd puzzle room dialogue
            {
                DialogueManager.currentDialogueManager.SetDialogueState(puzzleRoom2Dialogue);
            }
            else if (gameObject.tag == "Hallway3Dialogue") //if the object is the trigger for the hallway dialogue
            {
                DialogueManager.currentDialogueManager.SetDialogueState(hallway3Dialogue);
            }
            else if (gameObject.tag == "PuzzleRoom3Dialogue") //if the object is the trigger for the 3rd puzzle room dialogue
            {
                DialogueManager.currentDialogueManager.SetDialogueState(puzzleRoom3Dialogue);
            }
        }
    }
    
    
    //Trigger for 1st Scaring Away Shadow Dialogue
    public static void ScareShadowDialogueTrigger1()
    {
        DialogueManager.currentDialogueManager.SetDialogueState(scaredShadowDialogue1);
    }
    
    //Trigger for 2nd Scaring Away Shadow Dialogue
    public static void ScareShadowDialogueTrigger2()
    {
        DialogueManager.currentDialogueManager.SetDialogueState(scaredShadowDialogue2);
    }
    
    //Trigger for Solving 2nd Puzzle Dialogue
    public static void SolvePuzzle2DialogueTrigger()
    {
        DialogueManager.currentDialogueManager.SetDialogueState(solvedPuzzle2Dialogue);
    }

    //Trigger for Large Amount of Shadow Spawn Dialogue
    public static void ShadowHordeDialogue()
    {
        DialogueManager.currentDialogueManager.SetDialogueState(shadowHordeDialogue);
    }

    //Trigger for After Explosion Dialogue
    public static void AfterExplosionDialogueTrigger()
    {
        DialogueManager.currentDialogueManager.SetDialogueState(finalDialogue);
    }
    
}
