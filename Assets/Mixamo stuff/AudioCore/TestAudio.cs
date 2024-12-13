using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudio : MonoBehaviour
{
    public SoundManager soundManager;

    #region Unity Functions
#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            soundManager.PlayAudio(AudioType.ST_01, true, 1.0f);
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            soundManager.StopAudio(AudioType.ST_01, true);
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            soundManager.RestartAudio(AudioType.ST_01, true);
        }



        if (Input.GetKeyUp(KeyCode.Y))
        {
            soundManager.PlayAudio(AudioType.SFX_01, true);
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            soundManager.StopAudio(AudioType.SFX_01, true);
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            soundManager.RestartAudio(AudioType.SFX_01, true);
        }
    }
#endif
    #endregion
}
