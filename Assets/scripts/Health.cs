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

    private bool hasDied;
    
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
        Player.SetTrigger("Knock out");
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
