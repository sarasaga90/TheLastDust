using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si es el jugador
        if (other.CompareTag("Enemy"))
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();

            if (player != null)
            {
                // Si el jugador NO está cayendo encima del enemigo
                if (player.VerticalVelocity > 0)
                {
                    // Daño
                    HealthManager.instance.Hurt();

                    // Knockback en dirección contraria al enemigo
                    player.Knockback(transform.position);
                }
            }
        }
    }
}
