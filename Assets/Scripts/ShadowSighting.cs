using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSighting : MonoBehaviour
{
    [SerializeField] private GameObject destination; // the point this moves towards
    private UnityEngine.AI.NavMeshAgent agent;

    //After first shadow monster dialogue
    static DialogueManager.DialogueState shadowSightingDialogue =
        new DialogueManager.DialogueState("N/A", "",
            new DialogueManager.DialogueState("What the hell was that?!", "What? Is something wrong?",
                new DialogueManager.DialogueState("I swear I just one of the shadows move.",
                    "It's probabably just your mind playing tricks on you.",
                    new DialogueManager.DialogueState("I... okay.", "Shine your flashlight at it, maybe?")
                )
            )
        );

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = destination.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        DialogueManager.currentDialogueManager.SetDialogueState(shadowSightingDialogue);
        Destroy(gameObject);
    }
}
