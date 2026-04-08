using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth, maxHealth;

    public float invincibilityLength = 2f;
    private float invincCounter;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
        }
    }

    public void Hurt()
    {
        if(invincCounter <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                Die();
                
                
            }
            else
            {
                invincCounter = invincibilityLength;
            }
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    void Die()
    {
        currentHealth = 0;
        GameManager.instance.Respawn();
    }

    void EndGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
