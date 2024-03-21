using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static int moneyTotal = 0;

    [SerializeField] TMP_Text currentMoneyText;

    void Start()
    {
        currentMoneyText.text = $"Money: {moneyTotal}";
    }
}
