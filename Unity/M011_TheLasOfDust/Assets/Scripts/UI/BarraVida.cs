using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Slider sliderVida;

    void Start()
    {
        sliderVida.maxValue = HealthManager.instance.maxHealth;
        sliderVida.value = HealthManager.instance.currentHealth;
    }

    void Update()
    {
        sliderVida.value = HealthManager.instance.currentHealth;
    }
}