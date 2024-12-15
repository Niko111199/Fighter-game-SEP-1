using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Konamicode : MonoBehaviour
{
    private KeyCode[] KonamiCode =
    {
        KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.B, KeyCode.A
    };
    private int Administratior = 0;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KonamiCode[Administratior]))
            {
                Administratior++;

                if (Administratior >= KonamiCode.Length)
                {
                    PlayerisAdministrator();
                    Administratior = 0;
                }
            }
            else
            {
                Administratior = 0;
            }

            print(Administratior);
        }
    }

    public void PlayerisAdministrator()
    {
        print("spiller  er adminstrator");

        PlayerPrefs.SetInt("PlayerisAdministrator", 1);
        PlayerPrefs.Save();
    }

    public void AdmistratorisPlayer()
    {
        print("spiller ikke er adminstrator");

        PlayerPrefs.SetInt("PlayerisAdministrator", 0);
        PlayerPrefs.Save();
    }
}
