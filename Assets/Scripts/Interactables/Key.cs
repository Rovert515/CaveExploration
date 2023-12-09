using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    [SerializeField] private Door door; // the door that the key unlocks

    public bool pickedUp = false; // determines whether or not it has been picked up (so that illuminating glowy rocks, which would normally
        // enable it, cannot enable it if it's been picked up)

    void Start()
    {
        promptText = "Click to pick up key";

        door.Lock();
    }

    public override void Interact(CharacterMotor charMotor)
    {
        door.Unlock();
        pickedUp = true;
        PlayerCursor.DeselectObj(); // makes the player cursor deselect this object
        gameObject.SetActive(false);
    }
}
