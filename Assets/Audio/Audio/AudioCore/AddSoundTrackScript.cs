using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSoundTrackScript : MonoBehaviour
{
    public SoundManager SoundManager;
    public AudioType Type = AudioType.None;
    public bool fadeIn = false;
    public float delay = 0.0f;
    // Start is called before the first frame update
    
    void Start()
    {
        SoundManager = SoundManager.instance;

        if (SoundManager.instance == null)
        {
            Debug.LogWarning("Instance is null for AudioManager");
            return;
        }

        SoundManager.PlayAudio(Type, fadeIn, delay);
    }
}
