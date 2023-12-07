using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftableRock : Interactable
{
    [SerializeField] private Lever lever; // the Lever script on the gameobject that this rock allows the player to interact with

    private void Start()
    {
        promptText = "Click to pick up rock";
    }

    override public void Interact(CharacterMotor charMotor)
    {
        lever.PlayerGainRock(); // tells the lever script that the player has the rock now
        PlayerCursor.DeselectObj(); // makes the player cursor deselect this object
        gameObject.SetActive(false); // sets this game object to inactive because the player has "picked it up"
    }
}
