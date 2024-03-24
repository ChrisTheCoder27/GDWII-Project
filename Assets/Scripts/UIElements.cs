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
    private int maxAmmo = 16;
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
    }

    public int RifleAmmo
    {
        get
        {
            return currentRifleAmmo;
        }
    }

    public int ShotgunAmmo
    {
        get
        {
            return currentShotgunAmmo;
        }
    }

    public int SniperAmmo
    {
        get
        {
            return currentSniperAmmo;
        }
    }

    void Start()
    {
        // Assigning health, ammo, and money variables at start
        health = maxHealth;
        healthBar.SetHealth(maxHealth);
        currentPistolAmmo = maxAmmo;
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
                maxAmmo = 16;
                ammoText.text = $"Ammo: {currentPistolAmmo}";

                if (Input.GetButtonDown("Fire1"))
                {
                    if (currentPistolAmmo > 0)
                    {
                        currentPistolAmmo--;
                    }
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    currentPistolAmmo = maxAmmo;
                }
            }
            else if (gunFire.RifleMode)
            {
                maxAmmo = 30;
                ammoText.text = $"Ammo: {currentRifleAmmo}";

                if (Input.GetButtonDown("Fire1"))
                {
                    if (currentRifleAmmo > 0)
                    {
                        currentRifleAmmo--;
                    }
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    currentRifleAmmo = maxAmmo;
                }
            }
            else if (gunFire.ShotgunMode)
            {
                maxAmmo = 12;
                ammoText.text = $"Ammo: {currentShotgunAmmo}";

                if (Input.GetButtonDown("Fire1"))
                {
                    if (currentShotgunAmmo > 0)
                    {
                        currentShotgunAmmo--;
                    }
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    currentShotgunAmmo = maxAmmo;
                }
            }
            else if (gunFire.SniperMode)
            {
                maxAmmo = 8;
                ammoText.text = $"Ammo: {currentSniperAmmo}";

                if (Input.GetButtonDown("Fire1"))
                {
                    if (currentSniperAmmo > 0)
                    {
                        currentSniperAmmo--;
                    }
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    currentSniperAmmo = maxAmmo;
                }
            }

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
                health -= maxHealth / 10;
                healthBar.SetHealth(health);
            }
        }
    }

}
