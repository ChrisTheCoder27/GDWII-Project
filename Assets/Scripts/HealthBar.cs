using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Sets the slider for the health bar
    [SerializeField] Slider slider;

    // Changes the health bar to reflect the player's health
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
