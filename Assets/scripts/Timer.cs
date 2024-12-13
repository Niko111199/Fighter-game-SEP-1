using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text timer;
    [SerializeField] private int startime;

    private float remainingTime;
    private bool isRunning = true;

    [SerializeField] private Health Player1;
    [SerializeField] private Health player2;


    private void Start()
    {
        remainingTime = startime;

        StartCoroutine(CountDownTimer());
    }

    private void Update()
    {
        StopTimeOnDeath();
    }

    private IEnumerator CountDownTimer()
    {
        while (remainingTime > 0 && isRunning)
        {
            UpdateTimerDisplay();

            yield return new WaitForSeconds(1f);

            remainingTime--;
        }

        if (remainingTime <= 0)
        {
            remainingTime = 0;
            UpdateTimerDisplay();

            if (Player1.GetHealth() < player2.GetHealth())
            {
                Player1.PlayDeath();
                Player1.HealthOnUI(0);
            }
            else if (Player1.GetHealth() > player2.GetHealth())
            {
                player2.PlayDeath();
                player2.HealthOnUI(0);
            }
            else if (Player1.GetHealth() == player2.GetHealth())
            {
                Player1.PlayDeath();
                Player1.HealthOnUI(0);
                player2.PlayDeath();
                player2.HealthOnUI(0);
            }
        }
    }

    private void StopTimeOnDeath()
    {
        if (Player1.GetHealth() <= 0 || player2.GetHealth() <= 0)
        {
            StopTimer();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timer.text = $"{minutes:00}:{seconds:00}";
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void startTimer()
    {
        if (remainingTime > 0)
        {
            isRunning = true;
            StartCoroutine (CountDownTimer());
        }
    }
}
