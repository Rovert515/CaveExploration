using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A Door that allows the player to move to another room when clicked on. Can be locked and unlocked by other objects.
// Does not transport the player if clicked on when locked
public class Door : Interactable
{
    [SerializeField] private string destinationID; // scene ID for the scene that this door leads to

    private bool locked = false; //whether or not the door is locked

    private void Start()
    {
        if (promptText == null) // if this is connected to something that locks it, the prompt text
                                // will already have been changed by Lock() in the other object's Awake(),
                                //  so we only set it to the default if it's null
        {
            promptText = "Click to open door";
        }
    }

    public void Lock()
    {
        locked = true;
        promptText = "This door is locked";
    }

    public void Unlock()
    {
        locked = false;
        promptText = "Click to open door";
    }

    override public void Interact(CharacterMotor charMotor)
    {
        // if the door is unlocked and the player clicks on it, load the scene in destinationID
        if (!locked)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(destinationID);
        }
    }
}
