using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletSniperPrefab;
    public GameObject rifleRoundsPrefab;
    public GameObject shotgunRoundPrefab;

    [SerializeField] GameObject pistol;
    [SerializeField] GameObject assaultRifle;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject sniper;

    bool pistolMode;
    bool pistolModeEnabled;
    bool sniperMode;
    bool sniperModeEnabled;
    bool rifleMode;
    bool rifleModeEnabled;
    bool shotgunMode;
    bool shotgunModeEnabled;

    public bool PistolMode
    {
        get
        {
            return pistolMode;
        }
    }

    public bool SniperMode
    {
        get
        {
            return sniperMode;
        }
    }

    public bool RifleMode
    {
        get
        {
            return rifleMode;
        }
    }

    public bool ShotgunMode
    {
        get
        {
            return shotgunMode;
        }
    }

    void Start()
    {
        SwitchToPistol();
    }

    void Update()
    {
        if (!PauseMenu.gameIsPaused)
        {
            // The number keys at the top of the keyboard switch between the weapons
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SwitchToSniper();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SwitchToRifle();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwitchToShotgun();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwitchToPistol();
            }

            if (Input.GetButtonDown("Fire1") && pistolMode && pistolModeEnabled)
            {
                ShootPistol();
            }

            if (Input.GetButtonDown("Fire1") && sniperMode && sniperModeEnabled)
            {
                ShootSniper();
            }

            if (Input.GetButtonDown("Fire1") && rifleMode && rifleModeEnabled)
            {
                ShootRifle();
            }

            if (Input.GetButtonDown("Fire1") && shotgunMode && shotgunModeEnabled)
            {
                ShotgunBlast();
            }
        }
    }

    void ShootPistol()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootSniper()
    {
        Instantiate(bulletSniperPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootRifle()
    {
        Instantiate(rifleRoundsPrefab, firePoint.position, firePoint.rotation);
    }

    void ShotgunBlast()
    {
        Instantiate(shotgunRoundPrefab, firePoint.position, firePoint.rotation);
    }

    void SwitchToSniper()
    {
        pistolMode = false;
        pistolModeEnabled = false;
        sniperMode = false;
        rifleMode = false;
        rifleModeEnabled = false;
        sniperModeEnabled = false;
        sniperMode = true;
        sniperModeEnabled = true;
        Debug.Log("Switching to Sniper!");

        pistol.gameObject.SetActive(false);
        assaultRifle.gameObject.SetActive(false);
        shotgun.gameObject.SetActive(false);
        sniper.gameObject.SetActive(true);
    }

    void SwitchToRifle()
    {
        sniperMode = false;
        sniperModeEnabled = false;
        shotgunMode = false;
        shotgunModeEnabled = false;
        pistolMode = false;
        pistolModeEnabled = false;
        rifleMode = true;
        rifleModeEnabled = true;
        Debug.Log("Switching to Rifle!");

        pistol.gameObject.SetActive(false);
        assaultRifle.gameObject.SetActive(true);
        shotgun.gameObject.SetActive(false);
        sniper.gameObject.SetActive(false);
    }

    void SwitchToShotgun()
    {
        rifleMode = false;
        rifleModeEnabled = false;
        sniperMode = false;
        sniperModeEnabled = false;
        pistolMode = false;
        pistolModeEnabled = false;
        shotgunMode = true;
        shotgunModeEnabled = true;
        Debug.Log("Switching to Shotgun!");

        pistol.gameObject.SetActive(false);
        assaultRifle.gameObject.SetActive(false);
        shotgun.gameObject.SetActive(true);
        sniper.gameObject.SetActive(false);
    }

    void SwitchToPistol()
    {
        shotgunMode = false;
        shotgunModeEnabled = false;
        rifleMode = false;
        rifleModeEnabled = false;
        sniperMode = false;
        sniperModeEnabled = false;
        pistolMode = true;
        pistolModeEnabled = true;
        Debug.Log("Switching to Pistol!");

        pistol.gameObject.SetActive(true);
        assaultRifle.gameObject.SetActive(false);
        shotgun.gameObject.SetActive(false);
        sniper.gameObject.SetActive(false);
    }
}
