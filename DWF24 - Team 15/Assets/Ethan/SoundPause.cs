using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPause : MonoBehaviour
{
    public AudioSource gameAudio;  // Reference to your AudioSource

    void Start()
    {
        if (gameAudio != null)
        {
            gameAudio.loop = true;
            gameAudio.Play();  // Start playing the audio
        }
    }

    public void PauseAudio()
    {
        gameAudio?.Pause();  // Pause the audio
    }

    public void ResumeAudio()
    {
        gameAudio?.UnPause();  // Resume the audio
    }

    public void StopAudio()
    {
        gameAudio?.Stop();  // Stop the audio
    }
}
