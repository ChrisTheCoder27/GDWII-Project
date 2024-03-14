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
    // Ammo would be determined by the weapon the player is using
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
        moneyText.text = $"Money: ${money}";

        // Checks if the player has a gun equipped - if false, no image is displayed, if true, the equipped gun's image is displayed
        if (!hasGun)
        {
            gunImage.SetActive(false);
        }
        else if (hasGun)
        {
            gunImage.SetActive(true);
        }

        if (Input.GetButtonDown("Fire1") && PauseMenu.gameIsPaused == false)
        {
            if (currentAmmo > 0)
            {
                currentAmmo--;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && PauseMenu.gameIsPaused == false)
        {
            currentAmmo = maxAmmo;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {        
        // Checks if the player collides with an object with the "Money" tag
        if (collision.gameObject.CompareTag("Money"))
        {
            // Increases money variable by a random value
            money += Random.Range(5, 11);
            Destroy(collision.gameObject);
            Money.moneyTotal = money;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if the player collided with an enemy or was hit by a bullet
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (health > 0)
            {
                health -= maxHealth / 5;
            }
        }
    }
}
