using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.instance;
        if (soundManager == null)
        {
            Console.WriteLine("Not good. Main Menu");
        }
    }
    public void Play(int gamescene)
    {
        soundManager.PlayAudio(AudioType.ST_03);
        SceneManager.LoadScene(gamescene);
    }


    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
