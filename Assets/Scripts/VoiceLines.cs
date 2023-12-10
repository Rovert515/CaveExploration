using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Just a container for all of the voice lines. Voice lines are connected to Dialogue States in other scripts,
// mainly Dialogue_Repository
public class VoiceLines : MonoBehaviour
{
    public AudioClip[] voiceLines = new AudioClip[55];

    public static AudioClip[] globVoiceLines; // global version of the attached voicelines, singleton

    private void Start()
    {
        globVoiceLines = voiceLines;
    }
}
