using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
   public int healthAmount = 1;
   
   private void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("Player"))
       {
           HealthManager.instance.AddHealth(healthAmount);
           Destroy(gameObject);
       }
   }
}