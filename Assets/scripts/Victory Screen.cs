using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  
public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private Health player1Health;
    [SerializeField] private Health player2Health;
    [SerializeField] private GameObject UI;
    [SerializeField] private float delayTime = 3f;
    [SerializeField] private TMPro.TMP_Text winnerText;  

    private void Start()
    {
        if (UI != null)
        {
            UI.SetActive(false);  
        }
    }

    private void Update()
    {
        if (player1Health.GetHasDied() || player2Health.GetHasDied())
        {
            if (!IsInvoking(nameof(ShowVictoryUI)))
            {
                Invoke(nameof(ShowVictoryUI), delayTime); 
                DisablePlayers(); 
            }
        }
    }

    private void ShowVictoryUI()
    {
        UI.SetActive(true);

        if (player1Health.GetHasDied())
        {
            winnerText.text = $"{CustomeNameScript.Player2} Wins!";
        }
        else if (player2Health.GetHasDied())
        {
            winnerText.text = $"{CustomeNameScript.Player1} Wins!";
        }
        else if (player1Health.GetHasDied() && player2Health.GetHasDied())
        {
            winnerText.text = "Draw!";
        }
    }

    private void DisablePlayers()
    {
        player1Health.GetComponent<Player1>().enabled = false;
        player2Health.GetComponent<Player1>().enabled = false;
    }
}
