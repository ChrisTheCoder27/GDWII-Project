using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreMenu : MonoBehaviour
{
    public static bool rifleOwned;
    public static bool shotgunOwned;
    public static bool sniperOwned;

    [SerializeField] Button rifleButton;
    [SerializeField] Button shotgunButton;
    [SerializeField] Button sniperButton;

    [SerializeField] int riflePrice;
    [SerializeField] int shotgunPrice;
    [SerializeField] int sniperPrice;

    void Start()
    {
        rifleButton.onClick.AddListener(ClickRifleButton);
        shotgunButton.onClick.AddListener(ClickShotgunButton);
        sniperButton.onClick.AddListener(ClickSniperButton);

        // Checks if the player has already purchased any of the weapons available
        if (rifleOwned)
        {
            rifleButton.interactable = false;
            rifleButton.GetComponentInChildren<TMP_Text>().text = "Purchased!";
        }

        if (shotgunOwned)
        {
            shotgunButton.interactable = false;
            shotgunButton.GetComponentInChildren<TMP_Text>().text = "Purchased!";
        }

        if (sniperOwned)
        {
            sniperButton.interactable = false;
            sniperButton.GetComponentInChildren<TMP_Text>().text = "Purchased!";
        }
    }

    // Method when the player tries buying the assault rifle
    void ClickRifleButton()
    {
        if (Money.moneyTotal < riflePrice)
        {
            Debug.Log("Purchase failed. Not enough money.");
        }
        else
        {
            Money.moneyTotal -= riflePrice;
            rifleOwned = true;
            rifleButton.interactable = false;
            rifleButton.GetComponentInChildren<TMP_Text>().text = "Purchased!";
        }
    }

    // Method when the player tries buying the shotgun
    void ClickShotgunButton()
    {
        if (Money.moneyTotal < shotgunPrice)
        {
            Debug.Log("Purchase failed. Not enough money.");
        }
        else
        {
            Money.moneyTotal -= shotgunPrice;
            shotgunOwned = true;
            shotgunButton.interactable = false;
            shotgunButton.GetComponentInChildren<TMP_Text>().text = "Purchased!";
        }
    }

    // Method when the player tries buying the sniper
    void ClickSniperButton()
    {
        if (Money.moneyTotal < sniperPrice)
        {
            Debug.Log("Purchase failed. Not enough money.");
        }
        else
        {
            Money.moneyTotal -= sniperPrice;
            sniperOwned = true;
            sniperButton.interactable = false;
            sniperButton.GetComponentInChildren<TMP_Text>().text = "Purchased!";
        }
    }

}
