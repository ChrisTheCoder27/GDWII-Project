using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float bulletSpeed;
    public Rigidbody2D rb;

    public GameObject moneyPrefab;

    bool moneyDropped;

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
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

        if (other.gameObject.tag == "Boss")
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
