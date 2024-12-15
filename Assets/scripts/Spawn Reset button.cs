using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResetbutton : MonoBehaviour
{
    [SerializeField] private GameObject ResetButton;
    [SerializeField] private Transform Parant;
    [SerializeField] private Vector3 SpawnPosition;

    private bool ButtonIsSpawned;

    void Update()
    {
        if (!ButtonIsSpawned && PlayerPrefs.GetInt("PlayerisAdministrator", 0) == 1)
        {
            GameObject button = Instantiate(ResetButton, Parant);
            ButtonIsSpawned = true;
        }
    }
}
