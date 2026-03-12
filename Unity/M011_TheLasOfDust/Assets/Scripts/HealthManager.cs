using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth, maxHealth;

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
        
    }

    public void Hurt()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            EndGame();
        }
        
        
    }

    void EndGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
