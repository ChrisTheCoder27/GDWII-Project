using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    private StoreMenu StoreMenu;

    [SerializeField] UIElements uiElements;

    [SerializeField] GameObject player;
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
            if (Input.GetKeyDown(KeyCode.Alpha4) && StoreMenu.sniperOwned)
            {
                SwitchToSniper();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && StoreMenu.rifleOwned)
            {
                SwitchToRifle();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && StoreMenu.shotgunOwned)
            {
                SwitchToShotgun();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwitchToPistol();
            }

            if (Input.GetButtonDown("Fire1") && pistolMode && pistolModeEnabled)
            {
                if (uiElements.PistolAmmo > 0)
                {
                    ShootPistol();
                }
            }

            if (Input.GetButtonDown("Fire1") && sniperMode && sniperModeEnabled)
            {
                if (uiElements.SniperAmmo > 0)
                {
                    ShootSniper();
                }
            }

            if (Input.GetButtonDown("Fire1") && rifleMode && rifleModeEnabled)
            {
                if (uiElements.RifleAmmo > 0)
                {
                    ShootRifle();
                }
            }

            if (Input.GetButtonDown("Fire1") && shotgunMode && shotgunModeEnabled)
            {
                if (uiElements.ShotgunAmmo > 0)
                {
                    ShotgunBlast();
                }
            }
        }
    }

    void ShootPistol()
    {
        GameObject bullet = Instantiate(bulletPrefab, pistolFirePoint.position, pistolFirePoint.rotation);
        if (player.transform.localScale.x > 0)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(28, 0.0f);
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-28, 0.0f);
        }
    }

    void ShootSniper()
    {
        GameObject bullet = Instantiate(bulletSniperPrefab, sniperFirePoint.position, sniperFirePoint.rotation);
        if (player.transform.localScale.x > 0)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(28, 0.0f);
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-28, 0.0f);
        }
    }

    void ShootRifle()
    {
        GameObject bullet = Instantiate(rifleRoundsPrefab, rifleFirePoint.position, rifleFirePoint.rotation);
        if (player.transform.localScale.x > 0)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(28, 0.0f);
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-28, 0.0f);
        }
    }

    void ShotgunBlast()
    {
        GameObject bullet = Instantiate(shotgunRoundPrefab, shotgunFirePoint.position, shotgunFirePoint.rotation);
        if (player.transform.localScale.x > 0)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(28, 0.0f);
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-28, 0.0f);
        }
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
