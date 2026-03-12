using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;

    }

    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}