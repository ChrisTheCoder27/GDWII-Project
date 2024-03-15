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

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().health -= damage;
            Destroy(gameObject);
            if (other.gameObject.GetComponent<EnemyController>().health <= 0)
            {
                Instantiate(moneyPrefab, other.transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject, 5);
    }
}
