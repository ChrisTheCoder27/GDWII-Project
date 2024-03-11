using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab; 
    
    GameObject player;

    private EnemyPatrol enemyPatrol;
    public bool isRange;
    float lastAttack;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (isRange)
        {
            if (lastAttack <= Time.time - 1)
            {
                if (player.transform.position.x <= transform.position.x + 10 && player.transform.position.x >= transform.position.x - 10 && player.transform.position.y <= transform.position.y + 2 && player.transform.position.y >= transform.position.y - 2)
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    if (transform.rotation == Quaternion.Euler(0, 0, 0))
                    {
                        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(28, 0.0f);
                    }
                    else
                    {
                        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-28, 0.0f);
                    }
                    Destroy(bullet, 15);
                }
                lastAttack = Time.time;
            }

        }
    }
}
