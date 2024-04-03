using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIElements : MonoBehaviour
{
    // Variables set in the inspector
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] HealthBar healthBar;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] GunFire gunFire;
    [SerializeField] TextMeshProUGUI moneyText;

    [SerializeField] GameObject canvasUI;
    [SerializeField] GameObject storeMenu;

    // Health variables
    private int maxHealth = 100;
    private int health;

    // Ammo variables
    private int maxPistolAmmo = 16;
    private int maxRifleAmmo = 30;
    private int maxShotgunAmmo = 12;
    private int maxSniperAmmo = 8;
    private int currentPistolAmmo;
    private int currentRifleAmmo;
    private int currentShotgunAmmo;
    private int currentSniperAmmo;

    private int money = 0;

    public int Health
    {
        get 
        {
            return health; 
        }
    }

    public int PistolAmmo
    {
        get
        {
            return currentPistolAmmo;
        }
        set
        {
            currentPistolAmmo = value;
        }
    }

    public int RifleAmmo
    {
        get
        {
            return currentRifleAmmo;
        }
        set
        {
            currentRifleAmmo = value;
        }
    }

    public int ShotgunAmmo
    {
        get
        {
            return currentShotgunAmmo;
        }
        set
        {
            currentShotgunAmmo = value;
        }
    }

    public int SniperAmmo
    {
        get
        {
            return currentSniperAmmo;
        }
        set
        {
            currentSniperAmmo = value;
        }
    }

    void Start()
    {
        // Assigning health, ammo, and money variables at start
        health = maxHealth;
        healthBar.SetHealth(maxHealth);
        currentPistolAmmo = 16;
        currentRifleAmmo = 30;
        currentShotgunAmmo = 12;
        currentSniperAmmo = 8;
        money = Money.moneyTotal;

        healthText.text = $"Health: {health}%";
        ammoText.text = $"Ammo: {currentPistolAmmo}";
        moneyText.text = $"Money: {money}";
    }

    void Update()
    {
        if (PauseMenu.gameIsPaused == false)
        {
            healthText.text = $"Health: {health}%";
            moneyText.text = $"Money: ${money}";

            if (gunFire.PistolMode)
            {
                ammoText.text = $"Ammo: {currentPistolAmmo}";
            }
            else if (gunFire.RifleMode)
            {
                ammoText.text = $"Ammo: {currentRifleAmmo}";
            }
            else if (gunFire.ShotgunMode)
            {
                ammoText.text = $"Ammo: {currentShotgunAmmo}";
            }
            else if (gunFire.SniperMode)
            {
                ammoText.text = $"Ammo: {currentSniperAmmo}";
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }
    }

    void Reload()
    {
        if(gunFire.PistolMode)
        {
            currentPistolAmmo = maxPistolAmmo;
        }
        else if (gunFire.RifleMode)
        {
            currentRifleAmmo = maxRifleAmmo;
        }
        else if (gunFire.ShotgunMode)
        {
            currentShotgunAmmo = maxShotgunAmmo;
        }
        else if (gunFire.SniperMode)
        {
            currentSniperAmmo = maxSniperAmmo;
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
        }

        // Checks if the player collides with a medkit
        if (collision.gameObject.CompareTag("Medkit"))
        {
            if (health != maxHealth)
            {
                health += 50;
                if (health > maxHealth)
                {
                    health = maxHealth;
                }
                healthBar.SetHealth(health);
                Destroy(collision.gameObject);
            }
        }

        // Checks if the player got hit by a bullet
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            if (health > 0)
            {
                health -= maxHealth / 10;
                healthBar.SetHealth(health);
            }
        }
        if (collision.gameObject.CompareTag("BossBullet"))
        {
            if (health > 0)
            {
                health -= maxHealth / 20;
                healthBar.SetHealth(health);
            }
        }

        // Checks if the player reaches the end of a level
        if (collision.gameObject.CompareTag("Finish"))
        {
            PauseMenu.gameIsPaused = true;
            Time.timeScale = 0f;
            Money.moneyTotal = money;
            canvasUI.SetActive(false);
            storeMenu.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if the player collided with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (health > 0)
            {
                health -= maxHealth / 5;
                healthBar.SetHealth(health);
            }
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            if (health > 0)
            {
                health -= maxHealth / 5;
                healthBar.SetHealth(health);
            }
        }
    }

}
