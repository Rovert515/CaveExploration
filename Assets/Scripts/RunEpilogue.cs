using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pretty straightforward little script for running through the scripted (heh heh) epilogue. Pauses for initialDelay
// seconds, sets the dialogue state, waits till the dialogue is done, pauses for initialDelay seconds, reveals the
// sky and plays birdsong, waits for finalDelay seconds and then cuts to credits
public class RunEpilogue : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image blackScreen; // a black screen that hides the sky

    [SerializeField] private float initialDelay = 2f; // how long it sits on a black screen at the start
                                                      // before dialogue starts
    [SerializeField] private float finalDelay = 2f; // how long it sits looking at the skybox at the end
                                                    // before the epilogue ends

    [SerializeField] private AudioClip finalAmbiance;
    private AudioSource audioSource; // audio source to play ambiance at the end

    private bool initialDelayOver = false; // makes it so that Update doesn't assume the dialogue is done before
        // it even begins

    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
        StartCoroutine(EpilogueBegin());
    }

    // Update is called once per frame
    void Update()
    {
        // checking for this every frame isn't necessarily the best way to do this, but nothing is being
        // rendered in this scene anyway so it's not like we need to worry about performance

        // if the dialogue has ended
        if (initialDelayOver & DialogueManager.currentDialogueManager.currentDialogueState == null)
        {
            StartCoroutine(EpilogueEnd());
        }
    }

    private IEnumerator EpilogueBegin()
    {
        yield return new WaitForSeconds(initialDelay);
        Dialogue_Repository.AfterExplosionDialogueTrigger();
        initialDelayOver = true;
    }

    private IEnumerator EpilogueEnd()
    {
        yield return new WaitForSeconds(initialDelay);
        audioSource.volume = 0.01f; // set to correct volume for the finalAmbiance (that file is really damn loud)
        audioSource.PlayOneShot(finalAmbiance); // plays the ambient noise
        blackScreen.gameObject.SetActive(false); // turn off the black screen so they can see the sky
        yield return new WaitForSeconds(finalDelay);
        UnityEngine.SceneManagement.SceneManager.LoadScene("5Credits");
    }
}
