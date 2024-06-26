using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunFire : MonoBehaviour
{
    public Transform pistolFirePoint;
    public Transform shotgunFirePoint;
    public Transform rifleFirePoint;
    public Transform sniperFirePoint;
    public GameObject bulletPrefab;
    public GameObject bulletSniperPrefab;
    public GameObject rifleRoundsPrefab;
    public GameObject shotgunRoundPrefab;

    [SerializeField] UIElements uiElements;

    [SerializeField] GameObject player;
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject assaultRifle;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject sniper;

    [SerializeField] float bulletSpeed;

    [SerializeField] AudioClip emptyGun;

    bool pistolMode;
    bool pistolModeEnabled;
    bool sniperMode;
    bool sniperModeEnabled;
    bool rifleMode;
    bool rifleModeEnabled;
    bool shotgunMode;
    bool shotgunModeEnabled;
    private float lastAttack;
    private Vector2 worldPosition;
    private Vector2 direction;

    void PistolRotate()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)pistolFirePoint.transform.position).normalized;
        pistolFirePoint.transform.right = direction;
    }
    void RifleRotate()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)rifleFirePoint.transform.position).normalized;
        rifleFirePoint.transform.right = direction;
    }
    void ShotgunRotate()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)shotgunFirePoint.transform.position).normalized;
        shotgunFirePoint.transform.right = direction;
    }
    void SniperRotate()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)sniperFirePoint.transform.position).normalized;
        sniperFirePoint.transform.right = direction;
    }
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
        PistolRotate();
        RifleRotate();
        ShotgunRotate();
        SniperRotate();

        if (!PauseMenu.gameIsPaused)
        {
            if (uiElements.isReloading)
            {
                return;
            }
            // The number keys at the top of the keyboard switch between the weapons
            if (Input.GetKeyDown(KeyCode.Alpha4) && StoreMenu.sniperOwned)
            {
                SwitchToSniper();
                lastAttack = Time.time - 1.5f;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && StoreMenu.rifleOwned)
            {
                SwitchToRifle();
                lastAttack = Time.time;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && StoreMenu.shotgunOwned)
            {
                SwitchToShotgun();
                lastAttack = Time.time - 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwitchToPistol();
                lastAttack = Time.time;
            }

            if (Input.GetButtonDown("Fire1") && pistolMode && pistolModeEnabled && lastAttack <= Time.time - 0.2) 
            {
                if (uiElements.PistolAmmo > 0)
                {
                    ShootPistol();
                    lastAttack = Time.time;
                    uiElements.PistolAmmo--;
                }
                else
                {
                    AudioSource.PlayClipAtPoint(emptyGun, transform.position);
                }
            }

            if (Input.GetButtonDown("Fire1") && sniperMode && sniperModeEnabled && lastAttack <= Time.time - 1.5)
            {
                if (uiElements.SniperAmmo > 0)
                {
                    ShootSniper();
                    lastAttack = Time.time;
                    uiElements.SniperAmmo--;
                }
                else
                {
                    AudioSource.PlayClipAtPoint(emptyGun, transform.position);
                }
            }

            if (Input.GetButtonDown("Fire1") && rifleMode && rifleModeEnabled)
            {
                if (uiElements.RifleAmmo > 0)
                {
                    ShootRifle();
                    lastAttack = Time.time;
                    uiElements.RifleAmmo--;
                }
                else
                {
                    AudioSource.PlayClipAtPoint(emptyGun, transform.position);
                }
            }

            if (Input.GetButtonDown("Fire1") && shotgunMode && shotgunModeEnabled && lastAttack <= Time.time - 1)
            {
                if (uiElements.ShotgunAmmo > 0)
                {
                    ShotgunBlast();
                    lastAttack = Time.time;
                    uiElements.ShotgunAmmo--;
                }
                else
                {
                    AudioSource.PlayClipAtPoint(emptyGun, transform.position);
                }
            }
        }
    }


    void ShootPistol()
    {
        GameObject bullet = Instantiate(bulletPrefab, pistolFirePoint.position, pistolFirePoint.rotation);
        
        pistol.GetComponent<AudioSource>().Play();
    }

    void ShootSniper()
    {
        GameObject bullet = Instantiate(bulletSniperPrefab, sniperFirePoint.position, sniperFirePoint.rotation);
        
        sniper.GetComponent<AudioSource>().Play();
    }

    void ShootRifle()
    {
        GameObject bullet = Instantiate(rifleRoundsPrefab, rifleFirePoint.position, rifleFirePoint.rotation);
        
        assaultRifle.GetComponent<AudioSource>().Play();
    }

    void ShotgunBlast()
    {
        GameObject bullet = Instantiate(shotgunRoundPrefab, shotgunFirePoint.position, shotgunFirePoint.rotation);
        
        shotgun.GetComponent<AudioSource>().Play();
    }

    void SwitchToSniper()
    {
        pistolMode = false;
        pistolModeEnabled = false;
        shotgunMode = false;
        rifleMode = false;
        rifleModeEnabled = false;
        shotgunModeEnabled = false;
        sniperMode = true;
        sniperModeEnabled = true;

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

        pistol.gameObject.SetActive(true);
        assaultRifle.gameObject.SetActive(false);
        shotgun.gameObject.SetActive(false);
        sniper.gameObject.SetActive(false);
    }
}
