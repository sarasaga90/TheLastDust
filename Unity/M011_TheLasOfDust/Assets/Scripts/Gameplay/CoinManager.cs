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


    // Start is called before the first frame update
    void Start()
    {
        coinText.text = " " + coinCount;
    }
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
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
