using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuHoverSound : MonoBehaviour, IPointerEnterHandler
{
    private SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = SoundManager.instance;

        if (soundManager == null)
        {
            Console.WriteLine("Something went wrong, MenuHoverSound");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        soundManager.PlayAudio(AudioType.SFX_02);
    }

    
}
