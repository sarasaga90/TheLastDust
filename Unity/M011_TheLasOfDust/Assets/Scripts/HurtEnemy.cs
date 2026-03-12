using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();

                if (player != null && player.VerticalVelocity < 0)
                 {
                EnemyHealthManager enemy = GetComponentInParent<EnemyHealthManager>();
                if (enemy != null)
                {
                    enemy.TakeDamage();

                    player.Bounce();
                }
            }
        }
    }
}
