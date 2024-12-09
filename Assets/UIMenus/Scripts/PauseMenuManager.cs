using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    private bool isPaused = false;
    public string pauseSceneName = "PauseScene"; // Name of the pause scene

    // Ensures time scale and audio states are reset when entering the scene
    private void Start()
    {
        Time.timeScale = 1f; // Reset time scale to normal
        isPaused = false;    // Reset pause state
        AudioListener.pause = false; // Ensure audio is not paused
    }

    private void Update()
    {
        // Check for "ESC" key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseContinue();
        }
    }

    // Pause the game and open the pause scene
    public void PauseGame()
    {
        if (isPaused) return; // Prevent multiple pauses
        Time.timeScale = 0f; // Stop game time (pauses everything using time)
        isPaused = true;     // Mark as paused
        AudioListener.pause = true; // Pause audio

        // Load the pause scene additively
        SceneManager.LoadScene(pauseSceneName, LoadSceneMode.Additive);
    }

    // Resume the game and close the pause scene
    public void ContinueGame()
    {
        if (!isPaused) return; // Prevent unnecessary resumes

        // Unload the pause scene if it's currently loaded
        if (SceneManager.GetSceneByName(pauseSceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(pauseSceneName);
        }

        // Resume the game state
        Time.timeScale = 1f; // Resume game time
        isPaused = false;    // Mark as unpaused
        AudioListener.pause = false; // Resume audio
    }

    // Toggle pause and continue
    public void TogglePauseContinue()
    {
        if (isPaused)
        {
            ContinueGame(); // Resume if paused
        }
        else
        {
            PauseGame(); // Pause if not paused
        }
    }
}
