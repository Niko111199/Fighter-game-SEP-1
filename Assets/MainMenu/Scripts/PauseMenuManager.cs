using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject menuUI;

    // Ensures time scale and audio states are reset when entering the scene
    private void Start()
    {
        Time.timeScale = 1f; // Reset time scale to normal
        isPaused = false;    // Reset pause state
        AudioListener.pause = false; // Ensure audio is not paused
    }

    // Load a new scene
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f; // Reset time scale before leaving
        AudioListener.pause = false; // Ensure audio is not paused
        SceneManager.LoadScene(sceneName);
    }

    // Pause the game
    public void PauseGame()
    {
        Time.timeScale = 0f; // Stop game time
        isPaused = true;     // Mark as paused
        menuUI.SetActive(true); // Show pause menu UI

        AudioListener.pause = true; // Pause audio
    }

    // Resume the game
    public void ContinueGame()
    {
        Time.timeScale = 1f; // Resume game time
        isPaused = false;    // Mark as unpaused
        menuUI.SetActive(false); // Hide pause menu UI

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
