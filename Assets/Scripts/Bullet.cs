using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float bulletSpeed;
    public Rigidbody2D rb;
    GameObject player;

    public GameObject moneyPrefab;

    bool moneyDropped;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().health -= damage;
            Destroy(gameObject);
            if (other.gameObject.GetComponent<EnemyController>().health <= 0)
            {
                // Ensures that only 1 money drops, even if multiple bullets hit the enemy
                if (!moneyDropped)
                {
                    Instantiate(moneyPrefab, other.transform.position, Quaternion.identity);
                    moneyDropped = true;
                }
            }
        }
        Destroy(gameObject, 4);
    }
}
