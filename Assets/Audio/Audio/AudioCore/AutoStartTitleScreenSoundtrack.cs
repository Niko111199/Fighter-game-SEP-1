using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoStartTitleScreenSoundtrack : MonoBehaviour
{
    public SoundManager SoundManager;
    // Start is called before the first frame update

    void Start()
    {
        SoundManager = SoundManager.instance;

        if (SoundManager.instance == null)
        {
            Debug.LogWarning("Instance is null for AudioManager");
            return;
        }

        SoundManager.PlayAudio(AudioType.ST_01, true, 0.2f);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SoundManager.StopAudio(AudioType.ST_01);
        }
        else if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
        {
            SoundManager.StopAudio(AudioType.ST_01);
        }
    }

    //private void OnDisable()
    //{
    //    SoundManager.StopAudio(AudioType.ST_01);
    //}


}
