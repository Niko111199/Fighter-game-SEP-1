using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CustomeNameScript : MonoBehaviour
{
    public static string Player1 = "";
    public static string Player2 = "";

    public InputField Player1Name;
    public InputField Player2Name;
    public TMPro.TMP_Text player1UI;
    public TMPro.TMP_Text player2UI;

    public string getName1()
    {
        return Player1;
    }

    public string getName2()
    {
        return Player2;
    }

    private void Awake()
    {

        if (PlayerPrefs.HasKey("Player1Name"))
        {
            Player1 = PlayerPrefs.GetString("Player1Name");
        }

        if (PlayerPrefs.HasKey("Player2Name"))
        {
            Player2 = PlayerPrefs.GetString("Player2Name");
        }
    }

    public void SetPlayerName()
    {
        if (!string.IsNullOrEmpty(Player1Name.text))
        {
            Player1 = Player1Name.text;
            PlayerPrefs.SetString("Player1Name", Player1);
        }
        else
        {
            Player1 = "Player 1";
        }

        if (!string.IsNullOrEmpty(Player2Name.text))
        {
            Player2 = Player2Name.text;
            PlayerPrefs.SetString("Player2Name", Player2);
        }
        else
        {
            Player2 = "Player 2";
        }

        PlayerPrefs.Save();
    }
    void Start()
    {
        if (player1UI != null)
        {
            player1UI.text = Player1;
        }

        if (player2UI != null)
        {
            player2UI.text = Player2;
        }
    }

    public void SetStandardNames()
    {
        Player1 = "Player 1";
        Player2 = "Player 2";
        PlayerPrefs.SetString("Player1Name", Player1);
        PlayerPrefs.SetString("Player2Name", Player2);
        PlayerPrefs.Save();
    }
}
