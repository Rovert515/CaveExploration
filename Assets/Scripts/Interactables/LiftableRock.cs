using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftableRock : Interactable
{
    [SerializeField] private Lever lever; // the Lever script on the gameobject that this rock allows the player to interact with

    private void Start()
    {
        promptText = "pick up rock";
        if (lever != null)
        {
            lever.enabled = false; // disables the lever script on the lever, so that it doesn't read an interactable
        }
    }

    override public void Interact(CharacterMotor charMotor)
    {
        lever.enabled = true; // enables the lever script on the lever because the player has the rock now
        gameObject.SetActive(false); // sets this game object to inactive because the player has "picked it up"
    }
}
