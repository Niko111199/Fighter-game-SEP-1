using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Top10 : MonoBehaviour
{
    private const int MaxHighScores = 10;
    private List<PlayerScore> highScores = new List<PlayerScore>();

    public ScrollRect scrollRect; 
    public GameObject scoreItemPrefab; 
    public Transform scoreListParent; 

    void Start()
    {

        LoadHighScores();
        DisplayHighScores();
    }

    public void UpdateHighScores(string player1Name, int player1Score, string player2Name, int player2Score)
    {
        PlayerScore player1 = new PlayerScore(player1Name, player1Score);
        PlayerScore player2 = new PlayerScore(player2Name, player2Score);

        highScores.Add(player1);
        highScores.Add(player2);

        highScores.Sort((x, y) => y.score.CompareTo(x.score));

        if (highScores.Count > MaxHighScores)
        {
            highScores.RemoveAt(highScores.Count - 1);
        }

        SaveHighScores();

        DisplayHighScores();
    }

    void SaveHighScores()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetString("HighScoreName" + i, highScores[i].name);
            PlayerPrefs.SetInt("HighScore" + i, highScores[i].score);
        }
        PlayerPrefs.Save();
    }

    void LoadHighScores()
    {
        highScores.Clear();
        for (int i = 0; i < MaxHighScores; i++)
        {
            if (PlayerPrefs.HasKey("HighScoreName" + i))
            {
                string name = PlayerPrefs.GetString("HighScoreName" + i);
                int score = PlayerPrefs.GetInt("HighScore" + i);
                highScores.Add(new PlayerScore(name, score));
            }
        }
    }

    void DisplayHighScores()
    {
        foreach (Transform child in scoreListParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var score in highScores)
        {
            GameObject newItem = Instantiate(scoreItemPrefab, scoreListParent);
            TextMeshProUGUI[] texts = newItem.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = score.name;
            texts[1].text = score.score.ToString();
        }

        LogHighScoresToConsole();
    }

    void LogHighScoresToConsole()
    {
        Debug.Log("High Scores List:");
        foreach (var score in highScores)
        {
            Debug.Log("Name: " + score.name + " | Score: " + score.score);
        }
    }
}

[System.Serializable]
public class PlayerScore
{
    public string name;
    public int score;

    public PlayerScore(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
