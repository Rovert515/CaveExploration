using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTDialogueTrigger : MonoBehaviour
{

    //Introduction Dialogue (Part 2)
    static DialogueManager.DialogueState begin2 =
        new DialogueManager.DialogueState("Distress signal?", "All our equipment is outfitted with one if it experiences enough damage. " +
            "Are you one of the hikers that left earlier? You missed your return time! Where are you?",
            new DialogueManager.DialogueState("I… don't know. I rented some equipment to go on a hike. " + 
                "I think I fell in a cave.", "Oh dear. Okay. Well, can you take stock for me?",
                new DialogueManager.DialogueState("I'm fine, just a little banged up. What is this place?",
                    "You’ve probably fallen into one of the natural caves here. I'll help you look for a way out.",
                    new DialogueManager.DialogueState("It's so dark....", 
                        "You should have a flashlight in that pack of yours.",
                        new DialogueManager.DialogueState("I think I lost it when I fell. Hold on.")
                    )
                )
            )
        );

    //Introduction Dialogue (Part 1)
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

    //Flashlight Gotten Dialogue (Part 1)
    static DialogueManager.DialogueState flashlightDialogue =
        new DialogueManager.DialogueState("N/A", "", 
            new DialogueManager.DialogueState("Found it.", "Great, let's get out of here.")
        );

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

    //After first shadow monster dialogue
    static DialogueManager.DialogueState hallwayShadowDialogue =
        new DialogueManager.DialogueState("N/A", "",
            new DialogueManager.DialogueState("What the hell was that?!", "What? Is something wrong?",
                new DialogueManager.DialogueState("I swear I just one of the shadows move.", 
                    "It's probabably just your mind playing tricks on you.",
                    new DialogueManager.DialogueState("I... okay.", "Shine your flashlight at it, maybe?")
                )
            )
        );

    //After scaring away shadow dialogue
    static DialogueManager.DialogueState scaredShadow1Dialogue =
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

    //Solving the first puzzle room dialogue
    static DialogueManager.DialogueState solvedPuzzle1Dialogue =
        new DialogueManager.DialogueState("N/A", "",
            new DialogueManager.DialogueState("I did it!", "Great! Into the unknown!")
        );

    //Walking down second tunnel


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // if the object that has triggered it is the player
        {

            if (gameObject.tag == "BeginningDialogue") //if the object is the trigger for the first dialogue
            {
                DialogueManager.currentDialogueManager.SetDialogueState(begin);
            }
            else if (gameObject.tag == "Hallway1Dialogue") //if the object is the trigger for the hallway dialogue
            {
                DialogueManager.currentDialogueManager.SetDialogueState(hallway1Dialogue);
            }
            else if (gameObject.tag == "PuzzleRoom1Dialogue") //if the object is the trigger for the 1st puzzle room dialogue
            {
                DialogueManager.currentDialogueManager.SetDialogueState(puzzleRoom1Dialogue);
            }
        }
    }

    //Trigger for Flashlight Dialogue
    public static void FlashlightDialogueTrigger()
    {
        DialogueManager.currentDialogueManager.SetDialogueState(flashlightDialogue);
    }
    
    //Trigger for 1st Hallway Shadow Dialogue
    public static void HallwayShadowDialogueTrigger()
    {
        DialogueManager.currentDialogueManager.SetDialogueState(hallwayShadowDialogue);
    }
    
    //Trigger for 1st Scaring Away Shadow Dialogue
    public static void ScareShadowDialogue1Trigger()
    {
        DialogueManager.currentDialogueManager.SetDialogueState(scaredShadow1Dialogue);
    }

    
    //Trigger for Solving 1st Puzzle Dialogue
    public static void SolvePuzzle1DialogueTrigger()
    {
        DialogueManager.currentDialogueManager.SetDialogueState(solvedPuzzle1Dialogue);
    }
    /*
    //Trigger for 2nd Scaring Away Shadow Dialogue
    public static void ScareShadowDialogue2Trigger()
    {
        DialogueManager.currentDialogueManager.SetDialogueState(scaredShadow2Dialogue);
    }

    //Trigger for Solving 2nd Puzzle Dialogue
    public static void SolvePuzzle2DialogueTrigger()
    {
        DialogueManager.currentDialogueManager.SetDialogueState(solvedPuzzle2Dialogue);
    }

    //Trigger for After Explosion Dialogue
    public static void AfterExplosionDialogueTrigger()
    {
        DialogueManager.currentDialogueManager.SetDialogueState(finalDialogue);
    }
    */
}
