using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; 
    private int coinCount;
    private int dustCount;
    public TMP_Text coinText;
    public TMP_Text dustText;


    void Start()
    {
        coinText.text = " " + coinCount;
        dustText.text = " " + dustCount;
    }
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        coinText.text = " " + coinCount;
    }

    public void AddDust(int amount)
    {
        dustCount += amount;
        dustText.text = " " + dustCount;
    }

    public int GetCoinCount()
    {
        return coinCount;
    }   
}
