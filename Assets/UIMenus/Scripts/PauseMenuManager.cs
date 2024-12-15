using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private Timer time;
    [SerializeField] private GameObject pauseUi;
    [SerializeField] private Player1 player1;
    [SerializeField] private Player1 player2;


    // Ensures time scale and audio states are reset when entering the scene
    private void Start()
    {
        isPaused = false;    // Reset pause state
        AudioListener.pause = false; // Ensure audio is not paused
    }

    public void ChangetoScene(int changeToScene)
    {
        SceneManager.LoadScene(changeToScene);
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
        time.StopTimer(); // stops time
        isPaused = true;     // Mark as paused
        AudioListener.pause = true; // Pause audio

        // Open pause Menu
        pauseUi.SetActive(true);

        // pause player movenment
        player1.enabled = false;
        player2.enabled = false;
    }

    // Resume the game and close the pause scene
    public void ContinueGame()
    {
        if (!isPaused) return; // Prevent unnecessary resumes



        // Resume the game state
        time.startTimer();
        isPaused = false;    // Mark as unpaused
        AudioListener.pause = false; // Resume audio

        //closes pause menu
        pauseUi.SetActive(false);

        //reenable movement
        player1.enabled = true;
        player2.enabled = true;
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
