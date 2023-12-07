using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCursor : MonoBehaviour
{
    private static PlayerCursor instance; // active player curssor at the moment

    [SerializeField] private Image cursorIcon; // the cursor icon on the player canvas
    private Color defaultCursorColor; // default color of the cursor, will change to white when there is an object selected
    [SerializeField] private TMPro.TextMeshProUGUI promptTextBox; // a text box for prompts when you select an interactable object

    CharacterMotor charMotor; // CharacterMotor script of the player the cursor is attached to, to pass to Interactables so they
                              // have a reference to the player

    Interactable selectedObject = null;

    void Start()
    {
        instance = this; // set this to the active player cursor
        if (cursorIcon != null)
        {
            defaultCursorColor = cursorIcon.color; // save the default color of the cursorIcon so we can change it around later
        }
        charMotor = GetComponentInParent<CharacterMotor>(true); // this will be attached somewhere inside the mess that is the player
            // hierarchy, so this will go grab the proper Player object through it's CharacterMotor script
    }

    private void OnTriggerEnter(Collider other)
    {
        Interactable selected = other.GetComponent<Interactable>();
        if (selected != null) // if something with the Interactable script has entered range. Or, to be more precise, some child of the
            // Interactable script, because Interactable itself is abstract
        {
            selectedObject = selected; // make it the selected object
            cursorIcon.color = Color.white; // change the cursor color
            promptTextBox.text = selectedObject.GetPromptText(); // set the prompt text to that of the interactable
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // if it has something currently selected, and the thing that's leaving its area is the thing it has selected,
        // then make it no longer be selecting anything
        if (selectedObject != null)
        {
            if (other.gameObject == selectedObject.gameObject) // I know this should be part of an & with the above, but unity was trying
                // to check the second side of the & even when the first failed and I was getting null reference errors, so they're
                // separate statements now
            {
                selectedObject = null;
                cursorIcon.color = defaultCursorColor;
                promptTextBox.text = "";
            }
        }
    }

    public static void DeselectObj() // called by an Interactable if it disables itself to make the cursor stop detecting it, 
        // because presumably any interactable disabling itself is currently being interacted with
    {
        instance.selectedObject = null;
        instance.cursorIcon.color = instance.defaultCursorColor;
        instance.promptTextBox.text = "";
    }

    private void Update()
    {
        if (selectedObject != null & Input.GetMouseButtonDown(0)) // if there is an object selected and the player clicks the left mouse button
        {
            selectedObject.Interact(charMotor);
        }
    }
}
