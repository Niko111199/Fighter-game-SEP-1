using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InitVolumeParam : MonoBehaviour
{
    public string volumeParameter;
    public float multiplier = 20f;

    public AudioMixer mixer;
    private void Start()
    {
        if(PlayerPrefs.HasKey(volumeParameter))
            mixer.SetFloat(volumeParameter, Mathf.Log10(PlayerPrefs.GetFloat(volumeParameter)) * multiplier);
    }
}
