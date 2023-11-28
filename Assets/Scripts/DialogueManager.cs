using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // enum for sending followup choices to DialogueState.GetFollowup
    public enum OptionChoice
    {
        Select0,
        Select1,
        Select2
    }

    // a class that DialogueManager uses to hold data about the current position of the dialogue, including a linked tree design leading to followup
    // DialogueStates
    public class DialogueState
    {
        private string optionTxt; // the text displayed when this is an option as a dialogue continuation (not used if this is a line triggered by other factors)
        private string messageTxt; // the text the walkietalkie displays when this option is active
        private AudioClip messageAud; // the voice line the walkietalkie plays when this option is active
        private DialogueState option0; // the followup displayed as option 1. If null, option 2 will simply be "Continue" (which ends the dialogue tree)
        private DialogueState option1; // the followup displayed as option 2. If null, option 2 will not be displayed
        private DialogueState option2; // the followup displayed as option 3. If null, option 3 will not be displayed


        public string GetOptionTxt() {  return optionTxt; } // read only accessor for optionTxt
        public string GetMessageTxt() { return messageTxt; } // read only accessor for messageTxt
        public AudioClip GetMessageAud() { return messageAud; } // read only accessor for messageAud

        public DialogueState GetFollowup(OptionChoice optID) // takes an OptionChoice and returns the appropriate option from the followups
        {
            switch (optID)
            {
                case OptionChoice.Select0:
                    return option0;
                case OptionChoice.Select1:
                    return option1;
                case OptionChoice.Select2:
                    return option2;
            }
            return null;
        }

        public DialogueState(string optionT, string messageT) // a constructor for a DialogueState with no options (will default to Continue)
        {
            optionTxt = optionT;
            messageTxt = messageT;
        }
        public DialogueState(string optionT, string messageT, DialogueState opt0) // a constructor for a DialogueState with one option
        {
            optionTxt = optionT;
            messageTxt = messageT;
            option0 = opt0;
        }
        public DialogueState(string optionT, string messageT, DialogueState opt0, DialogueState opt1) // a constructor for a DialogueState with two options
        {
            optionTxt = optionT;
            messageTxt = messageT;
            option0 = opt0;
            option1 = opt1;
        }
        public DialogueState(string optionT, string messageT, DialogueState opt0, DialogueState opt1, DialogueState opt2) // a constructor for a DialogueState with three options
        {
            optionTxt = optionT;
            messageTxt = messageT;
            option0 = opt0;
            option1 = opt1;
            option2 = opt2;
        }
    }

    public static DialogueManager currentDialogueManager; // singleton to hold the active Dialoguemanager
    public DialogueState currentDialogueState; // the currently selected dialogue for this DialogueManager

    private AudioSource currentAudioSource; // the current audiosource, that voice lines will be played to,
                                            // set in awake to be the one attached to the active camera

    // the local UI elements for the walkie talkie and text options
    [SerializeField] private GameObject walkieTalkie;
    private UnityEngine.UI.Image walkieImageOn; // image component of the walkie talkie when it is on (primary object)
    private UnityEngine.UI.Image walkieImageOff; // image component of the walkie talkie when it is on (child object)
    [SerializeField] private TextMeshProUGUI messageTxtDisplay;
    [SerializeField] private TextMeshProUGUI option0Display;
    [SerializeField] private TextMeshProUGUI option1Display;
    [SerializeField] private TextMeshProUGUI option2Display;

    private void Awake()
    {
        currentDialogueManager = this; // sets the currently active DialogueManager to be this instance

        currentAudioSource = Camera.main.GetComponent<AudioSource>(); // sets the currentAudioSource to the one attached to the current camera
        currentAudioSource.loop = false; // make sure the current audio source doesn't loop

        UnityEngine.UI.Image[] walkieImages = walkieTalkie.GetComponentsInChildren<UnityEngine.UI.Image>(true);
        if (walkieImages.Length < 2 ) // just a little thing to send an error message to the console if our canvas is set up incorrectly
                                      // with insufficient walkie talkie images
        {
            Debug.LogError("Insufficient walkie talkie images attached to walkie talkie");
        }
        walkieImageOff = walkieImages[0]; // walkieImages should find the one attached the walkie talkie child object first,
                                          // which is the OffImage
        walkieImageOn = walkieImages[1]; // walkieImages should find the one attached the walkie talkie parent object second,
                                         // which is the OnImage

        // start the canvas with all of the text disabled and the walkie image set to off
        walkieImageOn.enabled = false;
        walkieImageOff.enabled = true;
        messageTxtDisplay.enabled = false;
        option0Display.enabled = false;
        option1Display.enabled = false;
        option2Display.enabled = false;
    }

    public void SetDialogueState(DialogueState state) // set the current Dialogue State to the one inputted and update relevant UI elements
    {
        if (currentDialogueState == null) // if the current DialogueState is null, we need to reactivate walkietalkie and enable the messagetxt
        {
            walkieImageOn.enabled = true;
            walkieImageOff.enabled = false;
            messageTxtDisplay.enabled = true;
            option0Display.enabled = true;
            option1Display.enabled = true;
            option2Display.enabled = true;
        }

        currentDialogueState = state;

        messageTxtDisplay.text = currentDialogueState.GetMessageTxt();
        currentAudioSource.clip = currentDialogueState.GetMessageAud(); // set the current voice line to the current audio source's clip
        currentAudioSource.Play(); // play the current voice line

        if (currentDialogueState.GetFollowup(OptionChoice.Select0) != null) // if there's a followup, set it up
        {
            option0Display.enabled = true;
            option0Display.text = "1. " + currentDialogueState.GetFollowup(OptionChoice.Select0).GetOptionTxt();
            if (currentDialogueState.GetFollowup(OptionChoice.Select1) != null) // if there's a followup, set it up
            {
                option1Display.enabled = true;
                option1Display.text = "2. " + currentDialogueState.GetFollowup(OptionChoice.Select1).GetOptionTxt();
                if (currentDialogueState.GetFollowup(OptionChoice.Select2) != null) // if there's a followup, set it up
                {
                    option2Display.enabled = true;
                    option2Display.text = "3. " + currentDialogueState.GetFollowup(OptionChoice.Select2).GetOptionTxt();
                } else { option2Display.enabled = false; option2Display.text = null; }
            } else { option1Display.enabled = false; option1Display.text = null; }
        }
        else  // if there are no followups (because of the constructor, if there's none in the first spot there aren't any at all)
        {
            // send continue text to the first text box, the function that runs when continue is selected will handle the actual closing of the text box
            option0Display.enabled = true;
            option0Display.text = "1. Continue";

            option1Display.enabled = false;
            option1Display.text = null;
            option2Display.enabled = false;
            option2Display.text = null;
        }
    }

    public void WipeDialogueState() // set the current dialogue state to null and deactivate relevant UI elements
    {
        currentDialogueState = null;
        // hide option text, hide message text, end the audio if it's playing
        messageTxtDisplay.enabled = false;

        option0Display.enabled = false;
        option0Display.text = null;
        option1Display.enabled = false;
        option1Display.text = null;
        option2Display.enabled = false;
        option2Display.text = null;

        currentAudioSource.Stop();
    }
}
