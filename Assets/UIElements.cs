using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIElements : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI moneyText;

    [SerializeField] GameObject gunImage;
    public bool hasGun;

    private int maxHealth = 100;
    private int health;
    private int maxAmmo = 10;
    private int currentAmmo;
    private int money = 0;

    void Start()
    {
        // Assigning health and ammo variables at start
        health = maxHealth;
        currentAmmo = maxAmmo;

        healthText.text = $"Health: {health}%";
        ammoText.text = $"Ammo: {currentAmmo}";
        moneyText.text = "Money: 0";
    }

    void Update()
    {
        healthText.text = $"Health: {health}%";
        ammoText.text = $"Ammo: {currentAmmo}";
        moneyText.text = $"Money: {money}";

        if (!hasGun)
        {
            gunImage.SetActive(false);
        }
        else if (hasGun)
        {
            gunImage.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {        
        // Checks if the player collides with an object with the "Money" tag
        if (collision.gameObject.CompareTag("Money"))
        {
            // Increases money variable by a random value
            money += Random.Range(5, 9);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if the player collided with an enemy or was hit by a bullet
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            health -= maxHealth / 5;
        }
    }
}
