using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySound : MonoBehaviour
{
    [SerializeField] AudioClip pickupSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
    }
}
