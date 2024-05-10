using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioSources; // Array of all audio sources
    public Button[] audioButtons;      // Array of all corresponding buttons
    private int currentIndex = 0;      // Current index of the displayed audio button
    public Text currentAudioText;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Ensure AudioManager does not get destroyed on loading a new scene
    }

    void Start()
    {
        if (audioButtons.Length != audioSources.Length)
        {
            Debug.LogError("Mismatch between audio buttons and sources count.");
            return; // Check to prevent index out of bounds if arrays are not set up correctly.
        }

        UpdateButtonVisibility();  // Initialize buttons visibility and start audio on load
    }

    public void NextAudio()
    {
        if (currentIndex < audioSources.Length - 1)
        {
            StopCurrentAudio();  // Stop the current audio before switching
            currentIndex++;
            UpdateButtonVisibility();  // Update buttons and play audio of the visible one
        }
    }

    public void PreviousAudio()
    {
        if (currentIndex > 0)
        {
            StopCurrentAudio();  // Stop the current audio before switching
            currentIndex--;
            UpdateButtonVisibility();  // Update buttons and play audio of the visible one
        }
    }

    private void UpdateButtonVisibility()
    {
        // Hide all buttons and stop all audios as a precaution
        foreach (Button btn in audioButtons)
        {
            btn.gameObject.SetActive(false);
        }
        foreach (AudioSource audio in audioSources)
        {
            audio.Stop();
        }

        // Show current button and play its associated audio
        audioButtons[currentIndex].gameObject.SetActive(true);
        PlayAudioSource(currentIndex);
    }

    private void PlayAudioSource(int index)
    {
        AudioSource audio = audioSources[index];
        if (audio != null)
        {
            audio.Play();  // Play the audio associated with the current index
            
        }
    }

    private void StopCurrentAudio()
    {
        AudioSource audio = audioSources[currentIndex];
        if (audio != null)
        {
            audio.Stop();  // Stop the current audio
        }
    }

    public void PlayCurrentAudio()
    {
        AudioSource audio = audioSources[currentIndex];
        if (audio != null)
        {
            DontDestroyOnLoad(audio.gameObject);  // Ensure the AudioSource GameObject is not destroyed
            audio.Play();
            SceneManager.LoadScene("Dialouge");  // Load the new scene
        }
    }
}

