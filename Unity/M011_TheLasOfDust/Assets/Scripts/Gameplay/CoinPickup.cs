using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
   public int coinAmount = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.instance.AddCoins(coinAmount);
            Destroy(gameObject);
        }
    }
}
