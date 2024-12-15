using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private Animator Player;
    [SerializeField] private Player1 movement;

    [SerializeField] private Image Healthbar;

    [SerializeField] private Top10 Highscore;
    [SerializeField] private Pointscript Player1;
    [SerializeField] private Pointscript Player2;

    private bool hasDied;

    public bool GetHasDied()
    {
        return hasDied;
    }

    public void DealDamage(float damage)
    {
        if (hasDied)
        {
            return;
        }

        health -= damage;
        HealthOnUI(health);

        if (health <= 0f)
        {
            PlayDeath();
        }
    }

    public void PlayDeath()
    {
        hasDied = true;
        Player.SetTrigger("Knock out");

        string player1Name = CustomeNameScript.Player1;
        string player2Name = CustomeNameScript.Player2;

        int player1Score = Player1.score;
        int player2Score = Player2.score;

        Highscore.UpdateHighScores(player1Name, player1Score, player2Name, player2Score);
        
    }

    void KnockoutPayer()
    {
       
        Player.enabled = false;
        movement.enabled = false;
    }

    public void HealthOnUI(float AmountOfHealth)
    {
        AmountOfHealth /= 100f;

        if (AmountOfHealth < 0f)
        {
            AmountOfHealth = 0f;
        }

        Healthbar.fillAmount = AmountOfHealth;
    }

    public float GetHealth()
    {
        return health;
    }
}
