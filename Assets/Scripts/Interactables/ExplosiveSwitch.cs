using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A switch that, when clicked on by the player cursor, freezes the player, shakes the camera, causes a rumbling sound
// effect, and then transports the player to the epilogue
public class ExplosiveSwitch : Interactable
{
    [SerializeField] AudioClip explosion;

    void Start()
    {
        promptText = "Click to press the plunger";
    }

    public override void Interact(CharacterMotor charMotor)
    {
        PlayerCursor.DeselectObj(); // makes the player cursor deselect this object
        charMotor.gameObject.GetComponentInChildren<PlayerCursor>().gameObject.SetActive(false); // disable
            // the player cursor so they can't click anything else right now
        charMotor.enabled = false; // disable the motor so the player can't move during this
        Camera.main.transform.parent.GetComponent<MouseLook>().enabled = false;
        Camera.main.GetComponent<CameraShakeScript>().CameraShake();
        AudioSource audioOutput = Camera.main.GetComponent<AudioSource>();
        audioOutput.volume = audioOutput.volume / 2; // cut the volume in half because this is going to be loud
        audioOutput.PlayOneShot(explosion);
        StartCoroutine(CutToEpilogue());
    }

    private IEnumerator CutToEpilogue()
    {
        yield return new WaitForSeconds(3f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("4Epilogue");
    }
}
