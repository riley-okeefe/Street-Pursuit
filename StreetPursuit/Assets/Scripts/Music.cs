using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private static Music instance;
    private AudioSource audioSource;
    private bool menuMusicPlaying = true; // Flag to track if menu music is playing

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Method to stop the menu music
    public void StopMenuMusic()
    {
        audioSource.Stop();
        menuMusicPlaying = false;
    }

    // Method to start the menu music
    public void StartMenuMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            menuMusicPlaying = true;
        }
    }

    // Event handler for sceneLoaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the main menu scene is loaded
        if (scene.name == "StartScene")
        {
            // Start menu music if it's not already playing
            if (!menuMusicPlaying)
            {
                StartMenuMusic();
            }
        }
    }
}
